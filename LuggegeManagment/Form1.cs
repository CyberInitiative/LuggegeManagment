using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LuggegeManagment
{
    public partial class Form1 : Form
    {
        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable();
        BindingSource bs = new BindingSource();
        public static List<Passenger> passengers = new List<Passenger>();   
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        
            radioButton5.Checked = true;

            dataTable.Columns.Add("surname", typeof(string));
            dataTable.Columns.Add("name", typeof(string));
            dataTable.Columns.Add("patronymic", typeof(string));
            dataTable.Columns.Add("flightnumber", typeof(string));
            dataTable.Columns.Add("laggagenumber", typeof(string));
            dataTable.Columns.Add("amountofplaces", typeof(int));
            dataTable.Columns.Add("sumweight", typeof(double));
            dataTable.Rows.Add("Ivanko", "Petr", "Petrovich", "CK101", "CH100433", 2, 20);
            dataTable.Rows.Add("Petrenko", "Oleg", "Ivanovich", "SK1212", "CK122412", 3, 30);
            dataTable.Rows.Add("Sidorov", "Ivan", "Ivanovich", "JK302", "SL100100", 1, 5);
            dataTable.Rows.Add("Medvedev", "Ivan", "Yurevich", "HK372", "SL123909", 2, 21);
            dataTable.Rows.Add("Sidorov", "Nikolay", "Nikolaevich", "KK001", "OL12121", 1, 8);
            dataTable.Rows.Add("Careva", "Maria", "Olegovna", "NK154", "BN666321", 1, 8);

            ConvertToListMethod();

            BsPassenger();
                 
            dataGridView1.DataSource = bs;

            /*
            if (dataGridView1.DataSource == dataTable)
            {
                button7.Enabled = false;
            }
            */
        }
        #region Buttuns
        private void addButton_Click(object sender, EventArgs e)
        { 
            dataGridView1.DataSource = dataTable;
            try
            {
                dataTable.Rows.Add(textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Введенные вами данные некорректны");
            }

            passengers.Clear();
            bs.Clear();

            ConvertToListMethod();

            foreach (Passenger passenger in passengers)
            {
                bs.Add(passenger);
            }

        }
        private void editButton_Click(object sender, EventArgs e)
        {          
            dataGridView1.DataSource = dataTable;
            foreach (DataRow row in dataTable.Rows)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                if (row["surname"].ToString() == textBox3.Text)
                    row.SetField("surname", textBox10.Text);
                if (row["name"].ToString() == textBox4.Text)
                    row.SetField("name", textBox11.Text);
                if (row["patronymic"].ToString() == textBox5.Text)
                    row.SetField("patronymic", textBox12.Text);
                if (row["flightnumber"].ToString() == textBox6.Text)
                    row.SetField("flightnumber", textBox13.Text);
                if (row["laggagenumber"].ToString() == textBox7.Text)
                    row.SetField("laggagenumber", textBox14.Text);
                if (row["amountofplaces"].ToString() == textBox8.Text)
                    row.SetField("amountofplaces", textBox15.Text);
                if (row["sumweight"].ToString() == textBox9.Text)
                    row.SetField("sumweight", textBox16.Text);
            }
        }    
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = dataTable;
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);
            }
            catch (Exception)
            {
                MessageBox.Show("Удалять нечего!");
            }

            passengers.Clear();
            bs.Clear();

            ConvertToListMethod();

            foreach (Passenger passenger in passengers)
            {
                bs.Add(passenger);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            double midWeight = GetMidWeightOfLuggage(passengers);
            MessageBox.Show("Суммарный вес багажа всех пассажиров: " + Convert.ToString(midWeight));
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                dataGridView1.DataSource = dataTable;
                if (radioButton5.Checked == true)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Фамилия LIKE '{0}%'", textBox1.Text);
                }
                if (radioButton3.Checked == true)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Имя LIKE '{0}%'", textBox1.Text);
                }
                if (radioButton4.Checked == true)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Отчество LIKE '{0}%'", textBox1.Text);
                }
                if (radioButton6.Checked == true)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Номер_рейса LIKE '{0}%'", textBox1.Text);
                }
                if (radioButton7.Checked == true)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Номер_багажной_квитанции LIKE '{0}%'", textBox1.Text);
                }
                if (radioButton8.Checked == true)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert([Количество_мест_багажа], System.String) LIKE '%{0}%'", textBox1.Text);
                }
                if (radioButton9.Checked == true)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert([Суммарный_вес_багажа_пассажира], System.String) LIKE '%{0}%'", textBox1.Text);
                }
            }
            else if (radioButton10.Checked == true)
            {
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = "Суммарный_вес_багажа_пассажира >= 30";
                dataGridView1.DataSource = dataView;
            }
            else
            {
                dataGridView1.DataSource = passengers;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataTable;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dataSet.Tables[0].WriteXml(sfd.FileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            passengers.Clear();
            dataTable.Clear();
            bs.Clear();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlReader xmlFile = XmlReader.Create(ofd.FileName, new XmlReaderSettings());
                    dataSet.ReadXml(xmlFile);
                    dataGridView1.DataSource = dataSet.Tables[0].DefaultView;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            UpdateMethod();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataTable;
            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                if (item.Cells["Фамилия"].Value.ToString() == textBox17.Text)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
            }

            passengers.Clear();

            ConvertToListMethod();
            bs.Clear();

            BsPassenger();

        }
        #endregion
        #region TextBoxRegion
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || (radioButton10.Checked == false))
            {
                dataGridView1.DataSource = passengers;
            }
        }     
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char character = e.KeyChar;
            if (!Char.IsLetter(character) && character != 8)
            {
                e.Handled = true;
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char character = e.KeyChar;
            if (!Char.IsLetter(character) && character != 8)
            {
                e.Handled = true;
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char character = e.KeyChar;
            if (!Char.IsLetter(character) && character != 8)
            {
                e.Handled = true;
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char character = e.KeyChar;
            if (!Char.IsDigit(character) && character != 8)
            {
                e.Handled = true;
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char character = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && character != 8 && character != 44)
            {
                e.Handled = true;
            }
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region Methods
        private double GetMidWeightOfLuggage(List<Passenger> passengersList)
        {
            double summarweight = 0.0;
            foreach (var passenger in passengersList)
            {
                summarweight += passenger.sumweight;
            }
            return Math.Round(summarweight, 3);
        }

        public void ConvertToListMethod()
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Passenger passenger = new Passenger();
                passenger.surname = Convert.ToString(dataTable.Rows[i]["surname"]);
                passenger.name = Convert.ToString(dataTable.Rows[i]["name"]);
                passenger.patronymic = Convert.ToString(dataTable.Rows[i]["patronymic"]);
                passenger.flightnumber = Convert.ToString(dataTable.Rows[i]["flightnumber"]);
                passenger.laggagenumber = Convert.ToString(dataTable.Rows[i]["laggagenumber"]);
                passenger.amountofplaces = Convert.ToInt16(dataTable.Rows[i]["amountofplaces"]);
                passenger.sumweight = Convert.ToDouble(dataTable.Rows[i]["sumweight"]);
                passengers.Add(passenger);
            }
        }
        private void ClearTable(DataTable dataTable)
        {
            dataTable.Clear();
        }
        public void UpdateMethod()
        {
            passengers.Clear();

            ConvertToListMethod();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bs;
        }
        public void BsPassenger()
        {
            foreach (Passenger passenger in passengers)
            {
                bs.Add(passenger);
            }
        }
        #endregion
        #region ElseElements
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void radioButton10_CheckedChanged_1(object sender, EventArgs e)
        {

        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox3.Text = selectedRow.Cells[0].Value.ToString();
            textBox4.Text = selectedRow.Cells[1].Value.ToString();
            textBox5.Text = selectedRow.Cells[2].Value.ToString();
            textBox6.Text = selectedRow.Cells[3].Value.ToString();
            textBox7.Text = selectedRow.Cells[4].Value.ToString();
            textBox8.Text = selectedRow.Cells[5].Value.ToString();
            textBox9.Text = selectedRow.Cells[6].Value.ToString();
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Фамилия"].ToString() == "Ivanko" && row["Имя"].ToString() == "Petr") // getting the row to edit , change it as you need

                {
                    row["Отчество"] = textBox4.Text;
                }


            }
            */
           
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}