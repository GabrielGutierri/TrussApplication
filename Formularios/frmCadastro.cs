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


namespace Software_Trelisa
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
        }
        private bool VerificaDados(string nome, string email, string senha, string repetirSenha, SqlConnection connectionString)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(repetirSenha))
                throw new Exception("Todos os campos são obrigatórios!");

            if(Verificacoes.VerificaEmail(email) && Verificacoes.VerificaSenha(senha, repetirSenha) && Verificacoes.VerificaUser(email, connectionString))
                return true;          
            else return false;
        }


        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                string email = txtEmail.Text;
                string senha = txtPassword.Text;
                string repetirSenha = txtRepeatPassword.Text;
                string connectionString = "Data Source=truss-server.database.windows.net;Initial Catalog=TrussDatabase;User ID=TrussAdmin;Password=TrussGVMJF0422";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter();
                connection.Open();
                if (VerificaDados(nome, email, senha, repetirSenha, connection))
                {
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO USUARIO (userName, email, userPassword) VALUES (@nome, @email, CONVERT(VARBINARY(256),pwdencrypt(@senha)))", connection);

                    cmd.Parameters.Add("@nome", SqlDbType.VarChar, 70).Value = txtNome.Text;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = txtEmail.Text;

                    cmd.Parameters.Add("@senha", SqlDbType.VarChar, 100).Value = txtPassword.Text;
                    adapter.InsertCommand = cmd;
                    adapter.InsertCommand.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
