using SpindaFinder.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spinda
{
    public partial class Searcher : Form
    {
        public Searcher()
        {
            InitializeComponent();
        }

        List<uint> correctslots = new List<uint> { 0, 1, 3, 4, 6, 8, 10 };

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            uint pidi = uint.Parse(PIDTextBox.Text, System.Globalization.NumberStyles.HexNumber);
            List<uint> origin = recoverLower16BitsPID(pidi);
            List<uint> origin2 = new List<uint>() { };
            foreach(uint seed in origin)
            {
                PokeRNGR rng = new PokeRNGR(seed);

                uint seed1 = rng.nextUInt();

                PokeRNGR testRNG = new PokeRNGR(seed1);
                uint testPID;
                uint slot;
                uint nextRNG = seed >> 16;
                uint nextRNG2 = testRNG.nextUShort();

                do
                {
                    if ((nextRNG % 25) == (pidi % 25))
                    {
                        slot = testRNG.seed * 0xeeb9eb65 + 0xa3561a1;
                        seed1 = slot * 0xdc6c95d9 + 0x4d3cb126;
                        origin2.Add(seed1);
                    }
                    testPID = (nextRNG << 16) | nextRNG2;
                    nextRNG = testRNG.nextUShort();
                    nextRNG2 = testRNG.nextUShort();
                } while ((testPID % 25) != (pidi % 25));

            }

            foreach(uint seed in origin2)
            {
                PokeRNG go = new PokeRNG(seed);
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

                string naturestr = natures[(int)nature];

                dataGridView1.Rows.Add(seed.ToString("X8"), slot.ToString(), slottolevel(slot).ToString(), pid.ToString("X"), correctslots.Contains(slot), pidtospinda(pid, ShinyCheck.Checked ? "Yes" : "No"), naturestr, ivs[0], ivs[1], ivs[2], ivs[3], ivs[4], ivs[5]);
            }
        }

        List<string> natures = new List<string> {
                "Hardy","Lonely","Brave","Adamant","Naughty",
                "Bold","Docile","Relaxed","Impish","Lax",
                "Timid","Hasty","Serious","Jolly","Naive",
                "Modest","Mild","Quiet","Bashful","Rash",
                "Calm","Gentle","Sassy","Careful","Quirky"};

        private uint comparetoslot(uint compare)
        {
            List<uint> limits = new List<uint> { 20, 40, 50, 60, 70, 80, 85, 90, 94, 98, 99, 100 };
            uint i = 0;
            foreach (uint limit in limits)
            {
                if (compare < limit)
                {
                    return i;
                }
                i += 1;
            }
            return 255;
        }

        private uint slottolevel(uint slot)
        {
            List<uint> levels = new List<uint> { 15, 15, 15, 14, 14, 14, 16, 16, 16, 16, 16, 16 };
            return levels[(int)slot];
        }

        private Bitmap pidtospinda(uint piduint, string shiny)
        {
            int spot1x, spot1y, spot2x, spot2y, spot3x, spot3y, spot4x, spot4y;
            string pid, pid1, pid2, pid3, pid4, pid5, pid6, pid7, pid8;


            pid = piduint.ToString("X8");
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
                ResourceManager rm = Resources.ResourceManager;

                var bmp1 = (Bitmap)rm.GetObject("spindapog" + shinyval);
                var bmp2 = (Bitmap)rm.GetObject("spot1" + shinyval);
                var bmp3 = (Bitmap)rm.GetObject("spot2" + shinyval);
                var bmp4 = (Bitmap)rm.GetObject("spot3" + shinyval);
                var bmp5 = (Bitmap)rm.GetObject("spot4" + shinyval);
                g.DrawImage(bmp1, 0, 0);
                g.DrawImage(bmp2, spot1x * 5, spot1y * 5);
                g.DrawImage(bmp3, spot2x * 5, spot2y * 5);
                g.DrawImage(bmp4, spot3x * 5, spot3y * 5);
                g.DrawImage(bmp5, spot4x * 5, spot4y * 5);
                if (OverlayCheck.Checked)
                {
                    var bmp6 = (Bitmap)rm.GetObject("spindaoverlay" + shinyval);
                    g.DrawImage(bmp6, 0, 0);
                }

                return bitmap;
            }

        }

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

        private List<uint> recoverLower16BitsPID(uint pid)
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
                flags[count] = false;
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

        private void PainterButton_Click(object sender, EventArgs e)
        {
            using (var form2 = new Painter())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    PIDTextBox.Text = form2.TheValue;
                }
            }
        }
    }
}
