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
    public partial class Form1 : Form
    {
        List<Passenger> passengers = new List<Passenger>();

        public Form1()
        {
            InitializeComponent();

            Passenger p1 = new Passenger("Ivanko", "Petr", "Petrovich", "CK101", "CH100433", 1, 11.2);
            Passenger p2 = new Passenger("Petrenko", "Oleg", "Ivanovich", "SK1212", "CK123412", 1, 12.5);
            Passenger p3 = new Passenger("Sidorov", "Ivan", "Ivanovich", "JK302", "SL12121", 2, 5);
            passengers.Add(p1);
            passengers.Add(p2);
            passengers.Add(p3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
