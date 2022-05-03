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
                string connectionString = $"Data Source=truss-server.database.windows.net;Initial Catalog=TrussDatabase;User ID=;Password=";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter();
                connection.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT nome, senha FROM USUARIO where nome = @email AND senha = @senha", connection);

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 70).Value = txtUser.Text;
                Password password = new Password(txtPassword.Text);
                cmd.Parameters.Add("@senha", SqlDbType.VarChar, 100).Value = password.Encrypt();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.ExecuteNonQuery();
                var dr = cmd.ExecuteReader();
                dr.Read();
                MessageBox.Show(dr["nome"].ToString());
                cmd.Dispose();
                connection.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
