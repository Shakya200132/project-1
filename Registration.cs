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
    public partial class Registration : Form
    {
        private string connectionString;
        private int existingPasswordCount;

        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\User\Documents\Doctor Appointment Booking System 2\Doctor Appointment Booking System 2\Login.mdf"";Integrated Security=True");
            conn.Open();
        }

        private void button_Register_Click(object sender, EventArgs e)
        {
            if (ValidateRegistration())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO LoginTable (username, password) VALUES (@username, @password)";

                    using (SqlCommand sqlCommand = new SqlCommand(insertQuery, connection))
                    {
                        sqlCommand.Parameters.AddWithValue("@username", textBox1.Text);
                        sqlCommand.Parameters.AddWithValue("@password", HashFunction(textBox2.Text));

                        int rowsAffected = sqlCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User successfully registered!");
                            this.Hide();

                            // Open the Home form as a modal dialog
                            Home home = new Home();
                            home.ShowDialog();
                        }

                        else
                        {
                            MessageBox.Show("Registration failed. Please try again.");
                        }
                    }
                }
            }
        }

        private bool ValidateRegistration()
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }

            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("New Password and Confirm Password do not match. Please try again.");
                return false;
            }
            if (existingPasswordCount > 0)
            {
                MessageBox.Show("Password already exists. Please choose a different password.");
                // Exit the method if the password already exists
            }

            // Additional validation can be added as needed

            return true;
        }


        private object HashFunction(string text)
        {
            throw new NotImplementedException();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';  
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }
    }
}
