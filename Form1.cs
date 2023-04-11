using System;

using System.Drawing;

using System.Windows.Forms;

namespace WindowsFormsApp2048
{
    public partial class Form1 : Form
    {
        private const int mapSize = 4;
        private Label[,] labelMap;
        private static Random random=new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMap();
            GenerateNumber();
        }

        private void GenerateNumber()
        {
            var randomNumberLabel = random.Next(mapSize * mapSize);
            var indexRow = randomNumberLabel / mapSize;
            var indexColumn=randomNumberLabel % mapSize;
            if (labelMap[indexRow, indexColumn].Text==string.Empty)
            {
                labelMap[indexRow, indexColumn].Text = "2";
            }
            else
            {
                GenerateNumber();
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

            }
        }
    }
}
