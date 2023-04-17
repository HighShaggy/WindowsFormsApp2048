using System;

using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace WindowsFormsApp2048
{
    public partial class PlayGame : Form
    {
        private const int mapSize = 4;

        private Label[,] labelMap;

        private static Random random = new Random();

        private static int score = 0;

        public PlayGame()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = score.ToString();
            LoadMap();
            
            GenerateNumber();
            

        }
        private bool EndGame()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (labelMap[i, j].Text == "")
                    {
                        return false;
                    }
                }
            }

            
            for (int i = 0; i < mapSize - 1; i++)
            {
                for (int j = 0; j < mapSize - 1; j++)
                {
                    if (labelMap[i, j].Text == labelMap[i, j + 1].Text || labelMap[i, j].Text == labelMap[i+1,j].Text)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void GenerateNumber()
        {
            while (true)
            {
                string number;
                int chance = random.Next(1, 11);
                if (chance <= 2)
                {
                    number = "4";
                }
                else
                {
                    number = "2";
                }
                var randomNumberLabel = random.Next(mapSize * mapSize);
                var indexRow = randomNumberLabel / mapSize;
                var indexColumn = randomNumberLabel % mapSize;
                if (labelMap[indexRow, indexColumn].Text == string.Empty)
                {
                    labelMap[indexRow, indexColumn].Text = number;
                    break;
                }
            }
        }

        private void LoadMap()
        {
            labelMap = new Label[mapSize, mapSize];
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLable = CreateLabel(i, j);
                    Controls.Add(newLable);
                    labelMap[i, j] = newLable;
                }
            }
        }

        private Label CreateLabel(int indexRow, int indexColumn)
        {
            var label = new Label();

            label.BackColor = SystemColors.ControlDark;
            label.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label.Size = new Size(70, 70);
            label.TabIndex = 0;
            int x = 10 + indexColumn * 76;
            int y = 70 + indexRow * 76;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Location = new Point(x, y);
            return label;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = mapSize - 1; j >= 0; j--)
                    {
                        if (labelMap[i, j].Text != string.Empty)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (labelMap[i, k].Text != string.Empty)
                                {
                                    if (labelMap[i, j].Text == labelMap[i, k].Text)
                                    {
                                        var number = int.Parse(labelMap[i, j].Text);
                                        labelMap[i, j].Text = (number * 2).ToString();
                                        score += int.Parse(labelMap[i, j].Text);
                                        labelMap[i, k].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }



                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = mapSize - 1; j >= 0; j--)
                    {
                        if (labelMap[i, j].Text == string.Empty)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (labelMap[i, k].Text != string.Empty)
                                {

                                    labelMap[i, j].Text = labelMap[i, k].Text;

                                    labelMap[i, k].Text = string.Empty;

                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (labelMap[i, j].Text != string.Empty)
                        {
                            for (int k = j + 1; k < mapSize; k++)
                            {
                                if (labelMap[i, k].Text != string.Empty)
                                {
                                    if (labelMap[i, j].Text == labelMap[i, k].Text)
                                    {
                                        var number = int.Parse(labelMap[i, j].Text);
                                        labelMap[i, j].Text = (number * 2).ToString();
                                        score += int.Parse(labelMap[i, j].Text);
                                        labelMap[i, k].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }



                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (labelMap[i, j].Text == string.Empty)
                        {
                            for (int k = j + 1; k < mapSize; k++)
                            {
                                if (labelMap[i, k].Text != string.Empty)
                                {

                                    labelMap[i, j].Text = labelMap[i, k].Text;

                                    labelMap[i, k].Text = string.Empty;

                                    break;
                                }
                            }
                        }
                    }
                }

            }
            if (e.KeyCode == Keys.Up)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = 0; i < mapSize; i++)
                    {
                        if (labelMap[i, j].Text != string.Empty)
                        {
                            for (int k = i + 1; k < mapSize; k++)
                            {
                                if (labelMap[k, j].Text != string.Empty)
                                {
                                    if (labelMap[i, j].Text == labelMap[k, j].Text)
                                    {
                                        var number = int.Parse(labelMap[i, j].Text);
                                        labelMap[i, j].Text = (number * 2).ToString();
                                        score += int.Parse(labelMap[i, j].Text);
                                        labelMap[k, j].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }



                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = 0; i < mapSize; i++)
                    {
                        if (labelMap[i, j].Text == string.Empty)
                        {
                            for (int k = i + 1; k < mapSize; k++)
                            {
                                if (labelMap[k, j].Text != string.Empty)
                                {

                                    labelMap[i, j].Text = labelMap[k, j].Text;

                                    labelMap[k, j].Text = string.Empty;

                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = mapSize - 1; i >= 0; i--)
                    {
                        if (labelMap[i, j].Text != string.Empty)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (labelMap[k, j].Text != string.Empty)
                                {
                                    if (labelMap[i, j].Text == labelMap[k, j].Text)
                                    {
                                        var number = int.Parse(labelMap[i, j].Text);
                                        labelMap[i, j].Text = (number * 2).ToString();
                                        score += int.Parse(labelMap[i, j].Text);
                                        labelMap[k, j].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }



                for (int j = 0; j < mapSize; j++)
                {
                    for (int i = mapSize - 1; i >= 0; i--)
                    {
                        if (labelMap[i, j].Text == string.Empty)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (labelMap[k, j].Text != string.Empty)
                                {

                                    labelMap[i, j].Text = labelMap[k, j].Text;

                                    labelMap[k, j].Text = string.Empty;

                                    break;
                                }
                            }
                        }
                    }
                }
            }
            label2.Text = score.ToString();
            if (EndGame())
            {
                UserManager.Add(new User() { Name = "фывф" + score, Score = score });
                MessageBox.Show("Игра окончена!");
                return;
            }
            GenerateNumber();
            
        }

        private void рестартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }



        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" КАК ИГРАТЬ: Используйте клавиши ваши стрелками, чтобы переместить плитки. Когда два плитки с тем же номером ощупь, они слияния в один!");
        }

        private void таблицаЛидеровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultsForm newForm = new ResultsForm();
            newForm.Show();

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

