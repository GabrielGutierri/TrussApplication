using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrussApplication
{
    public static class Validations
    {
        public static bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success) return true;
            else throw new Exception("Email is not in the correct format!");
        }

        public static bool ValidatePassword(string password, string repeatedPassword)
        {
            if (password != repeatedPassword)
                throw new Exception("Passwords do not match!");
            else return true;
        }

        public static bool ValidateUser(string email, SqlConnection connectionString)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(email) from USUARIO where email = @email", connectionString);
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 70).Value = email;
            int count = (int)cmd.ExecuteScalar();
            if (count != 0)
                throw new Exception("Email is already registered!");
            else return true;
        }

        public static bool ValidateAngle(string angle)
        {
            if (Convert.ToInt32(angle) > 90 || Convert.ToInt32(angle) < 0)
            {
                throw new Exception("The angle must be between 0° and 90°");
            }
            else return true;
        }
    }
}