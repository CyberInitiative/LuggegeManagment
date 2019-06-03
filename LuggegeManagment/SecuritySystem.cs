using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuggegeManagment
{
    public partial class SecuritySystem : Form
    {
        public SecuritySystem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin")
            {
                if (textBox2.Text == "admin")
                {
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                    Application.Exit();
                }
            }
            else
                MessageBox.Show("Не правильный логин или пароль");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SecuritySystem_Load(object sender, EventArgs e)
        {

        }
    }
}
