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


        private void Form1_Load(object sender, EventArgs e)
        {
            // Set BFS as default algorithm
            radioButton1.Checked = true;
            nodes.Text = "";
            executionTime.Text = "";
            steps.Text = "";
            route.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Validate and read .txt file to graph and datagrid
            try
            {
                // Disable all inputs and clickable controls
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                checkBox1.Enabled = false;
                trackBar1.Enabled = false;
                textBox1.Enabled = false;

                // Read .txt file and create Graph
                this.graph = new Graph(textBox1.Text);

                // Styling DataGridView
                dataGridView1.DataSource = Helper.DataTableFromTextFile(textBox1.Text);
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.CurrentCell = dataGridView1[0, 0];
                dataGridView1.CurrentCell.Selected = false;

                // Set DataGridView values
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        if (this.graph.getMap()[j,i] == 'X')
                        {
                            dataGridView1[i, j].Style.BackColor = Color.Black;
                        }
                    }
                }

                // Continue Styling DataGridView
                dataGridView1.ScrollBars = ScrollBars.None;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                int tinggi = dataGridView1.Height / dataGridView1.Rows.Count;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Height = tinggi;
                }

                // Enable all inputs and clickable controls
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                checkBox1.Enabled = true;
                trackBar1.Enabled = true;
                textBox1.Enabled = true;

                // Clear last solution
                nodes.Text = "";
                executionTime.Text = "";
                steps.Text = "";
                route.Text = "";
            }
            catch (FileNotFoundException)
            {
                // Show error
                MessageBox.Show("File tidak ditemukan!", "Error");

                // Enable all inputs and clickable controls
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                checkBox1.Enabled = true;
                trackBar1.Enabled = true;
                textBox1.Enabled = true;
            }
            catch (Exception err)
            {
                if (err.GetType() == typeof(DirectoryNotFoundException))
                {
                    // Show error
                    MessageBox.Show("Directory file tidak ditemukan!", "Error");

                    // Enable all inputs and clickable controls
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button4.Enabled = true;
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    checkBox1.Enabled = true;
                    trackBar1.Enabled = true;
                    textBox1.Enabled = true;
                }
                else
                {
                    // Show error
                    MessageBox.Show(err.Message, "Error");

                    // Enable all inputs and clickable controls
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button4.Enabled = true;
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    checkBox1.Enabled = true;
                    trackBar1.Enabled = true;
                    textBox1.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Main program to solve maze
            try
            {
                // Disable all inputs and clickable controls
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                checkBox1.Enabled = false;
                trackBar1.Enabled = false;
                textBox1.Enabled = false;

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

                // Create temporary graph
                Graph problem = new Graph(this.graph);

                // Solve maze
                Solution solution = problem.Solve(radioButton2.Checked, checkBox1.Checked);

                // Route
                route.Text = solution.getRoute();
                route.Location = new Point((int)((this.Width - route.Width) / 2), label7.Location.Y + 30);
                if (route.Text.Length > this.Width)
                {
                    route.Font = new Font("Segoe UI", 5F, FontStyle.Bold);
                }
                else if (route.Text.Length > this.Width / 2)
                {
                    route.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
                }
                else if (route.Text.Length > this.Width / 4)
                {
                    route.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                }
                else if (route.Text.Length > this.Width / 8)
                {
                    route.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
                else
                {
                    route.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                }

                // Nodes
                nodes.Text = solution.getNodes().ToString();

                // Steps
                steps.Text = solution.getSteps().ToString();

                // Execution Time
                executionTime.Text = solution.getExecutionTime().ElapsedMilliseconds.ToString() + " ms";

                // Change Color for Solution Path
                char[,] solutionPath = solution.getSolutionMap();

                for (int i = 0; i < solutionPath.GetLength(0); i++)
                {
                    for (int j = 0; j < solutionPath.GetLength(1); j++)
                    {
                        if (solutionPath[i, j] != 'X')
                        {
                            dataGridView1[j, i].Style.BackColor = Color.FromArgb(48, 209, 88);
                        }
                    }
                }

                // Enable all inputs and clickable controls
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                checkBox1.Enabled = true;
                trackBar1.Enabled = true;
                textBox1.Enabled = true;
            }
            catch (NullReferenceException)
            {
                // Show error
                MessageBox.Show("Silahkan isi file peta terlebih dahulu!", "Error");

                // Enable all inputs and clickable controls
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                checkBox1.Enabled = true;
                trackBar1.Enabled = true;
                textBox1.Enabled = true;
            }
            catch (Exception err)
            {
                // Show error
                MessageBox.Show(err.Message, "Error");

                // Enable all inputs and clickable controls
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                checkBox1.Enabled = true;
                trackBar1.Enabled = true;
                textBox1.Enabled = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Main program to solve maze
            try
            {
                // Disable all inputs and clickable controls
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                checkBox1.Enabled = false;
                trackBar1.Enabled = false;
                textBox1.Enabled = false;

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

                // Create temporary graph
                Graph problem = new Graph(this.graph);

                // Solve maze
                Solution solution = problem.Solve(radioButton2.Checked, checkBox1.Checked);

                // Route
                route.Text = solution.getRoute();
                route.Location = new Point((int)((this.Width - route.Width) / 2), label7.Location.Y + 30);
                if (route.Text.Length > this.Width)
                {
                    route.Font = new Font("Segoe UI", 5F, FontStyle.Bold);
                }
                else if (route.Text.Length > this.Width / 2)
                {
                    route.Font = new Font("Segoe UI", 6F, FontStyle.Bold);
                }
                else if (route.Text.Length > this.Width / 4)
                {
                    route.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                }
                else if (route.Text.Length > this.Width / 8)
                {
                    route.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
                else
                {
                    route.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                }

                // Nodes
                nodes.Text = solution.getNodes().ToString();

                // Steps
                steps.Text = solution.getSteps().ToString();

                // Execution Time
                executionTime.Text = solution.getExecutionTime().ElapsedMilliseconds.ToString() + " ms";

                // Initialize countVisit for darken background color
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
                    if(i > 0)
                    {
                        int xBefore = progress.ElementAt(i-1).Item1;
                        int yBefore = progress.ElementAt(i-1).Item2;
                        dataGridView1[y, x].Value = Image.FromFile("../../../src/images/buaya.png");
                        dataGridView1[yBefore, xBefore].Value = Image.FromFile("../../../src/images/empty.png");
                    }
                    if (progress.ElementAt(i).Item3 == "RED")
                    {
                        // Backtrack
                        dataGridView1[y, x].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        // Progress
                        dataGridView1[y, x].Style.BackColor = Color.FromArgb(99, 230, 226);
                    }
                    // Delay
                    Thread.Sleep(trackBar1.Value);
                    Application.DoEvents();
                    if (i == progress.Count - 1)
                    {
                        Thread.Sleep(trackBar1.Value);
                    }
                    Application.DoEvents();

                    // Darken background color
                    dataGridView1[y, x].Style.BackColor = Color.FromArgb(255 - (30 * countVisit[y, x]), 214 - (30 * countVisit[y, x]), 10);

                    // Increment countVisit
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

                // Change Color for Solution Path
                char[,] solutionPath = solution.getSolutionMap();

                for (int i = 0; i < solutionPath.GetLength(0); i++)
                {
                    for (int j = 0; j < solutionPath.GetLength(1); j++)
                    {
                        if (solutionPath[i, j] != 'X')
                        {
                            dataGridView1[j, i].Style.BackColor = Color.FromArgb(48, 209, 88);
                        }
                    }
                }

                // Reset Treasures
                foreach(Tuple<int,int> T in solution.getTreasures())
                {
                    dataGridView1[T.Item2, T.Item1].Value = Image.FromFile("../../../src/images/wibu.jpg");
                }

                // Reset Starting Point
                dataGridView1[solution.getProgress()[0].Item2, solution.getProgress()[0].Item1].Value = Image.FromFile("../../../src/images/fatih.png");
                
                // Enable all inputs and clickable controls
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                checkBox1.Enabled = true;
                trackBar1.Enabled = true;
                textBox1.Enabled = true;
            }
            catch (NullReferenceException)
            {
                // Show error
                MessageBox.Show("Silahkan isi file peta terlebih dahulu!", "Error");

                // Enable all inputs and clickable controls
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                checkBox1.Enabled = true;
                trackBar1.Enabled = true;
                textBox1.Enabled = true;
            }
            catch (Exception err)
            {
                // Show error
                MessageBox.Show(err.Message, "Error");

                // Enable all inputs and clickable controls
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                checkBox1.Enabled = true;
                trackBar1.Enabled = true;
                textBox1.Enabled = true;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            // Erase input when textbox clicked
            textBox1.Text = "";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}