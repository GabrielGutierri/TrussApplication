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

namespace TrussApplication
{
    public partial class frmLogin : Form
    {
        bool buttonClicked;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frmRegister f = new frmRegister();
            f.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = $"Data Source=truss-server.database.windows.net;Initial Catalog=TrussDatabase;User ID=TrussAdmin;Password=TrussGVMJF0422";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter();
                connection.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT email, userPassword FROM USUARIO where email = @email AND pwdcompare(@password, userPassword) = 1", connection);

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 70).Value = txtUser.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = txtPassword.Text;
                adapter.InsertCommand = cmd;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        buttonClicked = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (buttonClicked != true)
            {
                Application.Exit();
            }
        }
    }
}