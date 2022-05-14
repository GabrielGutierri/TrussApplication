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

namespace Software_Trelisa
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frmCadastro f = new frmCadastro();
            f.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = $"";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter();
                connection.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT email, userPassword FROM USUARIO where email = @email AND pwdcompare(@senha, userPassword) = 1", connection);

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 70).Value = txtUser.Text;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar, 100).Value = txtPassword.Text;
                adapter.InsertCommand = cmd;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MessageBox.Show("?????????????????????????????????");
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
