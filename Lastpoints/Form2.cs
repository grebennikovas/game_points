using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lastpoints
{
    public partial class Form2 : Form
    {
        int Size = 28;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1.settingsOpen = true;
            this.Width = 220;
            this.Height = 200;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            Sizers.SelectedItem = Sizers.Items[2];

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.settingsOpen = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int sizeX = Convert.ToInt32(SizeX.Text);
            int sizeY = Convert.ToInt32(SizeY.Text);
            Form1.LoadField(sizeX, sizeY, Size);
            Form1.GameBox.Refresh();
            this.Close();
        }

        private void SizeX_TextChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void SizeY_TextChanged(object sender, EventArgs e)
        {
            Check();
        }


        private void Check()
        {
            if (SizeX.Text == "" || Convert.ToInt32(SizeX.Text) < 15 || Convert.ToInt32(SizeX.Text) > 60 || SizeY.Text == "" || Convert.ToInt32(SizeY.Text) < 15 ||Convert.ToInt32(SizeY.Text) > 38)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void Sizers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Sizers.SelectedIndex == 0)
            {
                Size = 15;
            }
            if (Sizers.SelectedIndex == 1)
            {
                Size = 20;
            }
            if (Sizers.SelectedIndex == 2)
            {
                Size = 25;
            }
        }
    }
}
