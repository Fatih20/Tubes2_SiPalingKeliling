using System.Drawing;
using System.Windows.Forms;

namespace Tubes2Stima
{
    public partial class TreasureHuntSolver : Form
    {
        private Graph graph;
        public TreasureHuntSolver()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            this.graph = new Graph(textBox1.Text);
            dataGridView1.DataSource = Helper.DataTableFromTextFile(textBox1.Text);
            dataGridView1.CurrentCell = dataGridView1[0, 0];
            dataGridView1.CurrentCell.Selected = false;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1[i, j].Value.ToString() == "X")
                    {
                        dataGridView1[i, j].Value = "";
                        dataGridView1[i, j].Style.BackColor = Color.Black;
                    }
                    else if (dataGridView1[i, j].Value.ToString() == "R")
                    {
                        dataGridView1[i, j].Value = "";
                    }
                    else if (dataGridView1[i, j].Value.ToString() == "K")
                    {
                        dataGridView1[i, j].Value = "Start";
                    }
                    else
                    {
                        dataGridView1[i, j].Value = "Treasure";
                    }
                }
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            int tinggi = dataGridView1.Height / dataGridView1.Rows.Count;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = tinggi;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Solution solution = this.graph.Solve(radioButton2.Checked, checkBox1.Checked);

            // Route
            Label route = new Label();
            route.Text = solution.getRoute();
            route.AutoSize = true;
            route.Location = new Point(label7.Location.X + 55, label7.Location.Y);
            this.Controls.Add(route);

            // Nodes
            Label nodes = new Label();
            nodes.Text = solution.getNodes().ToString();
            nodes.AutoSize = true;
            nodes.Location = new Point(label6.Location.X, label6.Location.Y + 20);
            this.Controls.Add(nodes);

            // Steps
            Label steps = new Label();
            steps.Text = solution.getSteps().ToString();
            steps.AutoSize = true;
            steps.Location = new Point(label8.Location.X, label8.Location.Y + 20);
            this.Controls.Add(steps);

            // Execution Time
            Label executionTime = new Label();
            executionTime.Text = solution.getExecutionTime().ElapsedMilliseconds.ToString() + " ms";
            executionTime.AutoSize = true;
            executionTime.Location = new Point(label9.Location.X, label9.Location.Y + 20);
            this.Controls.Add(executionTime);

            int[,] countVisit = new int[dataGridView1.ColumnCount, dataGridView1.RowCount];
            for(int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for(int j = 0; j < dataGridView1.RowCount; j++)
                {
                    countVisit[i, j] = 0;
                }
            }

            // Visualize Progress
            List<Tuple<int, int, string>> progress = solution.getProgress();
            for (int i = 0; i < progress.Count; i++)
            {
                int x = progress.ElementAt(i).Item1;
                int y = progress.ElementAt(i).Item2;
                if (progress.ElementAt(i).Item3 == "RED")
                {
                    dataGridView1[y, x].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1[y, x].Style.BackColor = Color.Blue;
                }
                Thread.Sleep(trackBar1.Value);
                Application.DoEvents();
                if (i == progress.Count - 1)
                {
                    Thread.Sleep(trackBar1.Value);
                }
                Application.DoEvents();

                dataGridView1[y, x].Style.BackColor = Color.FromArgb(255 - (30 * countVisit[y, x]), 214 - (30 * countVisit[y, x]), 10);

                countVisit[y, x]++;
            }

            // Reset Color
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1[i, j].Style.BackColor != Color.Black)
                    {
                        dataGridView1[i, j].Style.BackColor = Color.White;
                    }
                }
            }

            // Change Color
            char[,] solutionPath = solution.getSolutionMap();

            for (int i = 0; i < solutionPath.GetLength(0); i++)
            {
                for (int j = 0; j < solutionPath.GetLength(1); j++)
                {
                    if (solutionPath[i, j] != 'X')
                    {
                        dataGridView1[j, i].Style.BackColor = Color.GreenYellow;
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}