using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spinda
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private string zfill(string pid)
        {
            if (pid.Length < 8)
            {
                do
                {
                    pid = "0" + pid;
                }
                while (pid.Length < 8);
            }
            return pid;
        }

        private List<uint> Recover(uint pid)
        {
            uint add;
            uint k;
            uint mult;
            byte[] low = new byte[0x10000];
            bool[] flags = new bool[0x10000];

            
            k = 0xC64E6D00; // Mult << 8
            mult = 0x41c64e6d; // pokerng constant
            add = 0x6073; // pokerng constant
            uint count = 0;
            foreach (byte element in low)
            {
                low[count] = 0;
                count++;
            }
            count = 0;
            foreach (bool element in flags)
            {
                flags[count] = true;
                count++;
            }
            for (short i = 0; i < 256; i++)
            {
                uint right = (uint)(mult * i + add);
                ushort val = (ushort)(right >> 16);
                flags[val] = true;
                low[val--] = (byte)(i);
                flags[val] = true;
                low[val] = (byte)(i);
            }
            List<uint> origin = new List<uint>();

            uint first = pid << 16;
            uint second = pid & 0xFFFF0000;
            uint search = second - first * mult;

            for (uint i = 0; i < 256; i++, search -= k)
            {
                if (flags[search >> 16])
                {
                    uint test = first | (i << 8) | low[search >> 16];
                    if (((test * mult + add) & 0xffff0000) == second)
                    {
                        origin.Add(test);
                    }
                }
            }
            return origin;
        }

        private uint comparetoslot (uint compare)
        {
            List<uint> limits = new List<uint> { 20, 40, 50, 60, 70, 80, 85, 90, 94, 98, 99, 100 };
            uint i = 0;
            foreach(uint limit in limits)
            {
                if (compare < limit)
                {
                    return i;
                }
                i += 1;
            }
            return 255;
        }

        private uint slottolevel (uint slot)
        {
            List<uint> levels = new List<uint> { 15, 15, 15, 14, 14, 14, 16, 16, 16, 16, 16, 16 };
            return levels[(int)slot];
        }

        private Bitmap pidtospinda(uint piduint, string shiny)
        {
            int spot1x, spot1y, spot2x, spot2y, spot3x, spot3y, spot4x, spot4y;
            string pid, pid1, pid2, pid3, pid4, pid5, pid6, pid7, pid8;


            pid = zfill(piduint.ToString("X"));
            pid1 = pid.Substring(0, 1);
            pid2 = pid.Substring(1, 1);
            pid3 = pid.Substring(2, 1);
            pid4 = pid.Substring(3, 1);
            pid5 = pid.Substring(4, 1);
            pid6 = pid.Substring(5, 1);
            pid7 = pid.Substring(6, 1);
            pid8 = pid.Substring(7, 1);

            spot1x = int.Parse(pid8, System.Globalization.NumberStyles.HexNumber);
            spot1y = int.Parse(pid7, System.Globalization.NumberStyles.HexNumber);
            spot2x = int.Parse(pid6, System.Globalization.NumberStyles.HexNumber);
            spot2y = int.Parse(pid5, System.Globalization.NumberStyles.HexNumber);
            spot3x = int.Parse(pid4, System.Globalization.NumberStyles.HexNumber);
            spot3y = int.Parse(pid3, System.Globalization.NumberStyles.HexNumber);
            spot4x = int.Parse(pid2, System.Globalization.NumberStyles.HexNumber);
            spot4y = int.Parse(pid1, System.Globalization.NumberStyles.HexNumber);

            string shinyval;
            if (shiny == "Yes")
            {
                shinyval = "shiny";
            }
            else
            {
                shinyval = "";
            }
            var bitmap = new Bitmap(260, 295);
            using (var g = Graphics.FromImage(bitmap))
            {
                var bmp1 = (Bitmap)Image.FromFile("spindapog" + shinyval + ".png");
                var bmp2 = (Bitmap)Image.FromFile("spot1" + shinyval + ".png");
                var bmp3 = (Bitmap)Image.FromFile("spot2" + shinyval + ".png");
                var bmp4 = (Bitmap)Image.FromFile("spot3" + shinyval + ".png");
                var bmp5 = (Bitmap)Image.FromFile("spot4" + shinyval + ".png");
                g.DrawImage(bmp1, 0, 0);
                g.DrawImage(bmp2, spot1x * 5, spot1y * 5);
                g.DrawImage(bmp3, spot2x * 5, spot2y * 5);
                g.DrawImage(bmp4, spot3x * 5, spot3y * 5);
                g.DrawImage(bmp5, spot4x * 5, spot4y * 5);
                if (OverlayCheck.Checked)
                {
                    var bmp6 = (Bitmap)Image.FromFile("spindaoverlay" + shinyval + ".png");
                    g.DrawImage(bmp6, 0, 0);
                }

                return bitmap;
            }

        }
        private void GenerateFrames(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<uint> correctslots = new List<uint> { 0,1,3,4,6,8,10 };

            uint seed;
            try
            {
                seed = uint.Parse(SeedTextBox.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                MessageBox.Show("Error: Seed has not been entered properly, please fix this if you want results.");
                return;
            }
            PokeRNG rng = new PokeRNG(seed);
            uint startingFrame, maxFrames;
            try
            {
                startingFrame = uint.Parse(StartingFrameTextBox.Text);
                maxFrames = uint.Parse(FrameAmountTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Error: Starting Frame and/or Frame Amount have not been entered properly, please fix this if you want results.");
                return;
            }
            List<decimal> minIVs = new List<decimal> { MinHPUD.Value, MinATKUD.Value, MinDEFUD.Value, MinSPAUD.Value, MinSPDUD.Value, MinSPEUD.Value };
            List<decimal> maxIVs = new List<decimal> { MaxHPUD.Value, MaxATKUD.Value, MaxDEFUD.Value, MaxSPAUD.Value, MaxSPDUD.Value, MaxSPEUD.Value };

            int delay = 0;

            if (DelayCheckBox.Checked)
            {
                try
                {
                    delay = int.Parse(DelayTextBox.Text);
                }
                catch
                {
                    MessageBox.Show("Error: Delay has not been entered properly, please fix this if you want it to impact the frames or uncheck the Delay box.");
                }
            }

            uint f = 1;

            while (f < startingFrame + delay)
            {
                rng.nextUInt();
                f += 1;
            }
            uint tid, sid, tsv;
            try
            {
                tid = uint.Parse(TIDTextBox.Text);
                sid = uint.Parse(SIDTextBox.Text);
                tsv = (tid ^ sid) / 8;
            }
            catch
            {
                tsv = 8193;
                MessageBox.Show("Error: TID/SID have not been entered properly, please fix this if you want shinies to be marked correctly.");
            }

            string selectedNature = "None";

            if (NatureCheckBox.Checked)
            {
                try
                {
                    selectedNature = NatureComboBox.Text;
                }
                catch
                {
                    MessageBox.Show("Error: Chosen Nature has not been entered properly, please fix this or uncheck the Nature box if you want results.");
                    return;
                }
            }

            uint selectedPID = 0;

            if (PIDCheck.Checked)
            {
                try
                {
                    selectedPID = uint.Parse(PIDTextBox.Text, System.Globalization.NumberStyles.HexNumber);
                    if (Recover(selectedPID).Count == 0)
                    {
                        MessageBox.Show("Selected PID is not possible");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Error: Chosen PID has not been entered properly, please fix this or uncheck the PID box if you want results");
                    return;
                }
            }

            int j = 0;

            while (j < 6)
            {
                if (maxIVs[j] < minIVs[j] | minIVs[j] > maxIVs[j])
                {
                    MessageBox.Show("Error: IV Range has not been entered properly.");
                    break;
                }
                j += 1;
            }

            uint cnt = 0;

            while (cnt < maxFrames + delay)
            {
                bool flag = true;
                PokeRNG go = new PokeRNG(rng.seed);
                go.nextUInt();

                uint slot = comparetoslot(go.nextUShort() % 100);

                go.nextUInt();

                uint nature = go.nextUShort() % 25;

                uint pid;

                do
                {
                    uint low = go.nextUShort();
                    uint high = go.nextUShort();
                    pid = (high << 16) | low;
                } while (pid % 25 != nature);

                if (MethodComboBox.Text == "H2")
                {
                    go.nextUInt();
                }
                uint iv1 = go.nextUShort();
                if (MethodComboBox.Text == "H4")
                {
                    go.nextUInt();
                }
                uint iv2 = go.nextUShort();
                List<uint> ivs = GetIVs(iv1, iv2);
                string shiny = "No";
                
                
                uint psv = (uint)(((pid & 0xFFFF) ^ (pid >> 16)) / 8);
                string naturestr = natures[(int)nature];


                if (tsv == psv)
                {
                    shiny = "Yes";
                }
                if (ShinyCheckBox.Checked)
                {
                    if (!(tsv == psv))
                    {
                        flag = false;
                    }
                    
                }

                
            

                if (NatureCheckBox.Checked & !(selectedNature == naturestr))
                {
                    flag = false;
                }

                if (SpindaCheck.Checked & !(correctslots.Contains(slot)))
                {
                    flag = false;
                }

                if (PIDCheck.Checked & !(selectedPID == pid))
                {
                    flag = false;
                }

                int i = 0;

                while (i<6)
                {
                    if (ivs[i] < minIVs[i] | ivs[i] > maxIVs[i])
                    {
                        flag = false;
                        break;
                    }
                    i += 1;
                }

                if (flag)
                {
                    dataGridView1.Rows.Add(cnt + startingFrame, slot.ToString(), slottolevel(slot).ToString(), pid.ToString("X"), shiny, pidtospinda(pid,shiny), naturestr, ivs[0], ivs[1], ivs[2], ivs[3], ivs[4], ivs[5]);
                }
                cnt += 1;
                rng.nextUInt();
            }



        }

        public bool GetShiny(int tsv, int pid)
        {
            return (((uint)pid & 0xffff) ^ ((uint)pid >> 16) ^ tsv ) < 8;
        }

        List<string> natures = new List<string> {
                "Hardy","Lonely","Brave","Adamant","Naughty",
                "Bold","Docile","Relaxed","Impish","Lax",
                "Timid","Hasty","Serious","Jolly","Naive",
                "Modest","Mild","Quiet","Bashful","Rash",
                "Calm","Gentle","Sassy","Careful","Quirky"};

        private List<uint> GetIVs(uint iv1, uint iv2)
        {
            uint hp = iv1 & 0x1f;
            uint atk = (iv1 >> 5) & 0x1f;
            uint defense = (iv1 >> 10) & 0x1f;
            uint spa = (iv2 >> 5) & 0x1f;
            uint spd = (iv2 >> 10) & 0x1f;
            uint spe = iv2 & 0x1f;
            return new List<uint> { hp, atk, defense, spa, spd, spe };
        }

        public static TextBox tb = new TextBox();

        private void PainterButton_Click(object sender, EventArgs e)
        {
            using (Painter form2 = new Painter())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    PIDTextBox.Text = form2.TheValue;
                }
            }
        }

        private void SearcherButton_Click(object sender, EventArgs e)
        {
            Searcher s = new Searcher();
            s.Show();
        }
    }
}
