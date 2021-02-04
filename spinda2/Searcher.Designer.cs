namespace Spinda
{
    partial class Searcher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Searcher));
            this.label12 = new System.Windows.Forms.Label();
            this.MethodComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.PIDTextBox = new System.Windows.Forms.TextBox();
            this.PainterButton = new System.Windows.Forms.Button();
            this.OverlayCheck = new System.Windows.Forms.CheckBox();
            this.Frame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shiny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Form = new System.Windows.Forms.DataGridViewImageColumn();
            this.Nature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShinyCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Method:";
            // 
            // MethodComboBox
            // 
            this.MethodComboBox.BackColor = System.Drawing.Color.White;
            this.MethodComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MethodComboBox.ForeColor = System.Drawing.Color.Black;
            this.MethodComboBox.FormattingEnabled = true;
            this.MethodComboBox.Items.AddRange(new object[] {
            "H1",
            "H2",
            "H4"});
            this.MethodComboBox.Location = new System.Drawing.Point(64, 7);
            this.MethodComboBox.Name = "MethodComboBox";
            this.MethodComboBox.Size = new System.Drawing.Size(50, 20);
            this.MethodComboBox.TabIndex = 45;
            this.MethodComboBox.Text = "H1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Frame,
            this.Slot,
            this.Level,
            this.PID,
            this.Shiny,
            this.Form,
            this.Nature,
            this.HP,
            this.ATK,
            this.DEF,
            this.SPA,
            this.SPD,
            this.SPE});
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.dataGridView1.Location = new System.Drawing.Point(15, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 91;
            this.dataGridView1.Size = new System.Drawing.Size(820, 319);
            this.dataGridView1.TabIndex = 47;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(12, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 23);
            this.button1.TabIndex = 48;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(14, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Custom PID";
            // 
            // PIDTextBox
            // 
            this.PIDTextBox.BackColor = System.Drawing.Color.White;
            this.PIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PIDTextBox.ForeColor = System.Drawing.Color.Black;
            this.PIDTextBox.Location = new System.Drawing.Point(83, 39);
            this.PIDTextBox.Name = "PIDTextBox";
            this.PIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.PIDTextBox.TabIndex = 36;
            // 
            // PainterButton
            // 
            this.PainterButton.Location = new System.Drawing.Point(189, 38);
            this.PainterButton.Name = "PainterButton";
            this.PainterButton.Size = new System.Drawing.Size(75, 23);
            this.PainterButton.TabIndex = 38;
            this.PainterButton.Text = "Paint!";
            this.PainterButton.UseVisualStyleBackColor = true;
            this.PainterButton.Click += new System.EventHandler(this.PainterButton_Click);
            // 
            // OverlayCheck
            // 
            this.OverlayCheck.AutoSize = true;
            this.OverlayCheck.Location = new System.Drawing.Point(270, 83);
            this.OverlayCheck.Name = "OverlayCheck";
            this.OverlayCheck.Size = new System.Drawing.Size(104, 17);
            this.OverlayCheck.TabIndex = 49;
            this.OverlayCheck.Text = "Spinda Overlay?";
            this.OverlayCheck.UseVisualStyleBackColor = true;
            // 
            // Frame
            // 
            this.Frame.HeaderText = "Seed";
            this.Frame.Name = "Frame";
            // 
            // Slot
            // 
            this.Slot.HeaderText = "Slot";
            this.Slot.Name = "Slot";
            this.Slot.Width = 50;
            // 
            // Level
            // 
            this.Level.HeaderText = "Level";
            this.Level.Name = "Level";
            this.Level.Width = 50;
            // 
            // PID
            // 
            this.PID.HeaderText = "PID";
            this.PID.Name = "PID";
            // 
            // Shiny
            // 
            this.Shiny.HeaderText = "Spinda?";
            this.Shiny.Name = "Shiny";
            this.Shiny.Width = 70;
            // 
            // Form
            // 
            this.Form.HeaderText = "Form";
            this.Form.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Form.Name = "Form";
            this.Form.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Form.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Form.Width = 80;
            // 
            // Nature
            // 
            this.Nature.HeaderText = "Nature";
            this.Nature.Name = "Nature";
            this.Nature.Width = 70;
            // 
            // HP
            // 
            this.HP.HeaderText = "HP";
            this.HP.Name = "HP";
            this.HP.Width = 40;
            // 
            // ATK
            // 
            this.ATK.HeaderText = "ATK";
            this.ATK.Name = "ATK";
            this.ATK.Width = 40;
            // 
            // DEF
            // 
            this.DEF.HeaderText = "DEF";
            this.DEF.Name = "DEF";
            this.DEF.Width = 40;
            // 
            // SPA
            // 
            this.SPA.HeaderText = "SPA";
            this.SPA.Name = "SPA";
            this.SPA.Width = 40;
            // 
            // SPD
            // 
            this.SPD.HeaderText = "SPD";
            this.SPD.Name = "SPD";
            this.SPD.Width = 40;
            // 
            // SPE
            // 
            this.SPE.HeaderText = "SPE";
            this.SPE.Name = "SPE";
            this.SPE.Width = 40;
            // 
            // ShinyCheck
            // 
            this.ShinyCheck.AutoSize = true;
            this.ShinyCheck.Location = new System.Drawing.Point(380, 83);
            this.ShinyCheck.Name = "ShinyCheck";
            this.ShinyCheck.Size = new System.Drawing.Size(58, 17);
            this.ShinyCheck.TabIndex = 50;
            this.ShinyCheck.Text = "Shiny?";
            this.ShinyCheck.UseVisualStyleBackColor = true;
            // 
            // Searcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 439);
            this.Controls.Add(this.ShinyCheck);
            this.Controls.Add(this.OverlayCheck);
            this.Controls.Add(this.PainterButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.PIDTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.MethodComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Searcher";
            this.Text = "Searcher";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox MethodComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox PIDTextBox;
        private System.Windows.Forms.Button PainterButton;
        private System.Windows.Forms.CheckBox OverlayCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frame;
        private System.Windows.Forms.DataGridViewTextBoxColumn Slot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shiny;
        private System.Windows.Forms.DataGridViewImageColumn Form;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nature;
        private System.Windows.Forms.DataGridViewTextBoxColumn HP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ATK;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEF;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPE;
        private System.Windows.Forms.CheckBox ShinyCheck;
    }
}