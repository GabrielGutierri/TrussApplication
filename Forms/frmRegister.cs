using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace TrussApplication
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private bool ValidateData(string name, string email, string password, string repeatPassword, SqlConnection connectionString)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(repeatPassword))
                throw new Exception("All fields are required!");

            if (Validations.ValidateEmail(email) && Validations.ValidatePassword(password, repeatPassword) && Validations.ValidateUser(email, connectionString))
                return true;
            else return false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                string repeatPassword = txtRepeatPassword.Text;
                string connectionString = $"Data Source=truss-server.database.windows.net;Initial Catalog=TrussDatabase;User ID=TrussAdmin;Password=TrussGVMJF0422";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter();
                connection.Open();
                if (ValidateData(name, email, password, repeatPassword, connection))
                {
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO USUARIO (userName, email, userPassword) VALUES (@name, @email, CONVERT(VARBINARY(256),pwdencrypt(@password)))", connection);

                    cmd.Parameters.Add("@name", SqlDbType.VarChar, 70).Value = txtName.Text;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = txtEmail.Text;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = txtPassword.Text;
                    adapter.InsertCommand = cmd;
                    adapter.InsertCommand.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}