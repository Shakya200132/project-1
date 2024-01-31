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
    public partial class Form1 : Form
    {
        private string connectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\User\Documents\Doctor Appointment Booking System 2\Doctor Appointment Booking System 2\Login.mdf"";Integrated Security=True");
            conn.Open();
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.Show();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox1.Text))
            {
                string query = "SELECT * FROM LoginTable WHERE username = @username AND password = @password";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = textBox1.Text;
                        sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = HashFunction(textBox2.Text);

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                // User with the provided username and password found
                                MessageBox.Show("User successfully logged in!");

                                // Hide the current form
                                this.Hide();

                                // Open the Home form as a modal dialog
                                Home home = new Home();
                                home.ShowDialog();
                            }
                            else
                            {
                                // No matching user found
                                MessageBox.Show("Invalid username or password.");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter both username and password.");
            }
        }

        private object HashFunction(string text)
        {
            throw new NotImplementedException();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
