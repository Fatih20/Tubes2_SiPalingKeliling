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

        private void Form1_Resize(object sender, EventArgs e)
        {
            route.Location = new Point((int)((this.Width - route.Width) / 2), label7.Location.Y + 25);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.graph = new Graph(textBox1.Text);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File tidak ditemukan!");
            }
            catch (Exception err)
            {
                if (err.GetType() == typeof(DirectoryNotFoundException))
                {
                    MessageBox.Show("Directory file tidak ditemukan!");
                }
                else
                {
                    MessageBox.Show(err.Message);
                }
            }
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
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

            dataGridView1.ScrollBars = ScrollBars.None;
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

            Graph problem = new Graph(this.graph);
            Solution solution = problem.Solve(radioButton2.Checked, checkBox1.Checked);

            // Route
            route.Text = solution.getRoute();
            route.Location = new Point((int)((this.Width - route.Width) / 2), label7.Location.Y + 25);

            // Nodes
            nodes.Text = solution.getNodes().ToString();

            // Steps
            steps.Text = solution.getSteps().ToString();

            // Execution Time
            executionTime.Text = solution.getExecutionTime().ElapsedMilliseconds.ToString() + " ms";

            int[,] countVisit = new int[dataGridView1.ColumnCount, dataGridView1.RowCount];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
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
                    dataGridView1[y, x].Style.BackColor = Color.FromArgb(99, 230, 226);
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

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void nodes_Click(object sender, EventArgs e)
        {

        }

        private void steps_Click(object sender, EventArgs e)
        {

        }

        private void executionTime_Click(object sender, EventArgs e)
        {

        }

        private void route_Click(object sender, EventArgs e)
        {

        }
    }
}