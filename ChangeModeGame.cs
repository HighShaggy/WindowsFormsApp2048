using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2048
{
    public partial class ChangeModeGame : Form
    {
        public List<RadioButton> radioButtons; 
        public ChangeModeGame()
        {
            InitializeComponent();
            radioButtons = new List<RadioButton>
            {
                radioButton1, radioButton2, radioButton3
            };
        }

        private void ChangeModeGame_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
