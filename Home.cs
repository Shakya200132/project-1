using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctor_Appointment_Booking_System_2
{
    public partial class Home : Form
    {

        public Home()
        {
            InitializeComponent();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\User\source\repos\Doctor Appointment Booking System 1\Logging.mdf"";Integrated Security=True");
            conn.Open();
            string[] specialties = { "specialist1", "specialist2" , "specialist3" , "specialist4" , "specialist5" };

            comboBox1.Items.AddRange(specialties);
            comboBox2.Items.AddRange(specialties);
            comboBox3.Items.AddRange(specialties);
            comboBox4.Items.AddRange(specialties);
            comboBox5.Items.AddRange(specialties);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dateTimePicker1.MinDate = DateTime.Now;

            DateTime selectedDateTime = dateTimePicker1.Value;

            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now.AddDays(30);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string selectedSpecialty1 = comboBox1.Text;
            string selectedSpecialty2 = comboBox2.Text;
            string selectedSpecialty3 = comboBox3.Text;
            string selectedSpecialty4 = comboBox4.Text;
            string selectedSpecialty5 = comboBox5.Text;
            DateTime selectedDateTime = dateTimePicker1.Value;


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;


        }
        private bool CheckAvailability(string specialty, DateTime dateTime)
        {
            
            return true;
        }
    }

}



