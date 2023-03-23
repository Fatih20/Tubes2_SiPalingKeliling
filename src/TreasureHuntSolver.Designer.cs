namespace Tubes2Stima
{
    partial class TreasureHuntSolver
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            label7 = new Label();
            label10 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            trackBar1 = new TrackBar();
            label11 = new Label();
            label8 = new Label();
            label9 = new Label();
            label6 = new Label();
            nodes = new Label();
            steps = new Label();
            route = new Label();
            executionTime = new Label();
            panel3 = new Panel();
            label3 = new Label();
            label2 = new Label();
            panel4 = new Panel();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(489, 17);
            label1.Name = "label1";
            label1.Size = new Size(462, 60);
            label1.TabIndex = 0;
            label1.Text = "Treasure Hunt Solver";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.FromArgb(44, 44, 46);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(260, 17);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Load";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.FromArgb(44, 44, 46);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(47, 58);
            button2.Name = "button2";
            button2.Size = new Size(103, 29);
            button2.TabIndex = 3;
            button2.Text = "Solve";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // radioButton1
            // 
            radioButton1.Anchor = AnchorStyles.None;
            radioButton1.AutoSize = true;
            radioButton1.ForeColor = SystemColors.ButtonHighlight;
            radioButton1.Location = new Point(23, 18);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(54, 24);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "BFS";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.Anchor = AnchorStyles.None;
            radioButton2.AutoSize = true;
            radioButton2.ForeColor = SystemColors.ButtonHighlight;
            radioButton2.Location = new Point(161, 17);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(56, 24);
            radioButton2.TabIndex = 6;
            radioButton2.TabStop = true;
            radioButton2.Text = "DFS";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.None;
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = SystemColors.ButtonHighlight;
            checkBox1.Location = new Point(298, 17);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(55, 24);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "TSP";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.BackColor = Color.FromArgb(28, 28, 30);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.ForeColor = SystemColors.ButtonHighlight;
            textBox1.Location = new Point(15, 17);
            textBox1.Margin = new Padding(0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(220, 27);
            textBox1.TabIndex = 9;
            textBox1.Text = "Source File";
            textBox1.Click += textBox1_Click;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.None;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.FromArgb(58, 58, 60);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Enabled = false;
            dataGridView1.GridColor = SystemColors.ActiveCaptionText;
            dataGridView1.ImeMode = ImeMode.Off;
            dataGridView1.Location = new Point(35, 259);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView1.Size = new Size(1279, 514);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(58, 58, 60);
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(650, 798);
            label7.Name = "label7";
            label7.Size = new Size(68, 28);
            label7.TabIndex = 13;
            label7.Text = "Route";
            label7.Click += label7_Click;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(503, 644);
            label10.Name = "label10";
            label10.Size = new Size(0, 20);
            label10.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(58, 58, 60);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(35, 99);
            panel1.Name = "panel1";
            panel1.Size = new Size(373, 64);
            panel1.TabIndex = 19;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.FromArgb(58, 58, 60);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(radioButton1);
            panel2.Controls.Add(radioButton2);
            panel2.Controls.Add(checkBox1);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(522, 99);
            panel2.Name = "panel2";
            panel2.Size = new Size(381, 100);
            panel2.TabIndex = 20;
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.None;
            trackBar1.BackColor = Color.FromArgb(58, 58, 60);
            trackBar1.Location = new Point(105, 87);
            trackBar1.Maximum = 2000;
            trackBar1.Minimum = 250;
            trackBar1.Name = "trackBar1";
            trackBar1.RightToLeft = RightToLeft.No;
            trackBar1.Size = new Size(130, 56);
            trackBar1.TabIndex = 17;
            trackBar1.TickFrequency = 250;
            trackBar1.Value = 250;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(58, 58, 60);
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.ButtonHighlight;
            label11.Location = new Point(131, 62);
            label11.Name = "label11";
            label11.Size = new Size(83, 20);
            label11.TabIndex = 18;
            label11.Text = "Delay Step";
            label11.Click += label11_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(58, 58, 60);
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(1243, 118);
            label8.Name = "label8";
            label8.Size = new Size(47, 20);
            label8.TabIndex = 14;
            label8.Text = "Steps";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(58, 58, 60);
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(1121, 118);
            label9.Name = "label9";
            label9.Size = new Size(44, 20);
            label9.TabIndex = 15;
            label9.Text = "Time";
            label9.Click += label9_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(58, 58, 60);
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(992, 116);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 12;
            label6.Text = "Nodes";
            label6.Click += label6_Click;
            // 
            // nodes
            // 
            nodes.Anchor = AnchorStyles.None;
            nodes.AutoSize = false;
            nodes.BackColor = Color.FromArgb(58, 58, 60);
            nodes.ForeColor = Color.White;
            nodes.Location = new Point(label6.Location.X, label6.Location.Y + 20);
            nodes.TextAlign = ContentAlignment.MiddleCenter;
            nodes.Name = "nodes";
            nodes.Size = new Size(label6.Width, label6.Height);
            // 
            // steps
            // 
            steps.Anchor = AnchorStyles.None;
            steps.AutoSize = false;
            steps.BackColor = Color.FromArgb(58, 58, 60);
            steps.ForeColor = Color.White;
            steps.Location = new Point(label8.Location.X, label8.Location.Y + 20);
            steps.TextAlign = ContentAlignment.MiddleCenter;
            steps.Name = "steps";
            steps.Size = new Size(label8.Width, label8.Height);
            // 
            // route
            // 
            route.Anchor = AnchorStyles.None;
            route.AutoSize = true;
            route.BackColor = Color.FromArgb(58, 58, 60);
            route.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            route.ForeColor = Color.White;
            route.Location = new Point(label7.Location.X + 55, label7.Location.Y);
            route.TextAlign = ContentAlignment.MiddleCenter;
            route.MaximumSize = new Size(1200, 0);
            route.Name = "route";
            // 
            // executionTime
            // 
            executionTime.Anchor = AnchorStyles.None;
            executionTime.AutoSize = false;
            executionTime.BackColor = Color.FromArgb(58, 58, 60);
            executionTime.ForeColor = Color.White;
            executionTime.Location = new Point(label9.Location.X, label9.Location.Y + 20);
            executionTime.Name = "executionTime";
            executionTime.TextAlign = ContentAlignment.MiddleCenter;
            executionTime.Size = new Size(label9.Width, label9.Height);
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.None;
            panel3.BackColor = Color.FromArgb(58, 58, 60);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(trackBar1);
            panel3.Location = new Point(972, 99);
            panel3.Name = "panel3";
            panel3.Size = new Size(339, 146);
            panel3.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(231, 89);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 20;
            label3.Text = "2000 ms";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(45, 89);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 19;
            label2.Text = "250 ms";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.None;
            panel4.BackColor = Color.FromArgb(58, 58, 60);
            panel4.Location = new Point(35, 789);
            panel4.Name = "panel4";
            panel4.Size = new Size(1276, 115);
            panel4.TabIndex = 26;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.None;
            button4.BackColor = Color.FromArgb(44, 44, 46);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Location = new Point(193, 58);
            button4.Name = "button4";
            button4.Size = new Size(142, 29);
            button4.TabIndex = 9;
            button4.Text = "Show Progress";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // TreasureHuntSolver
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 30);
            ClientSize = new Size(1348, 930);
            Controls.Add(label7);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label10);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(nodes);
            Controls.Add(route);
            Controls.Add(steps);
            Controls.Add(executionTime);
            Controls.Add(label6);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Name = "TreasureHuntSolver";
            Text = "Treasure Hunt Solver";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private CheckBox checkBox1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Label label7;
        private Label label10;
        private Panel panel1;
        private Panel panel2;
        private TrackBar trackBar1;
        private Label label11;
        private Label label8;
        private Label label9;
        private Label label6;
        private Label route;
        private Label nodes;
        private Label steps;
        private Label executionTime;
        private Panel panel3;
        private Panel panel4;
        private Label label3;
        private Label label2;
        private Button button4;
    }
}