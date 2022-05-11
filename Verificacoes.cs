using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Software_Trelisa
{
    public static class Verificacoes
    {
        public static bool VerificaEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success) return true;
            else throw new Exception("email não está no formato correto!");
        }

        public static bool VerificaSenha(string senha, string senhaRepetida)
        {
            if (senha != senhaRepetida)
                throw new Exception("As senhas não batem!");
            else return true;
        }

        public static bool VerificaUser(string email, SqlConnection connectionString)
        {
            
            SqlCommand cmd = new SqlCommand("SELECT COUNT(email) from USUARIO where email = @email", connectionString);
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 70).Value = email;

            int contador = (int)cmd.ExecuteScalar();
            MessageBox.Show($"{contador}");
            return true;
        }
    }
}
