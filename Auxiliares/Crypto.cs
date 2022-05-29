using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Software_Trelisa.Auxiliares
{
    public static class Crypto
    {
        public static string Encrypt(string text)
        {
            var hashmd5 = MD5.Create();
            byte[] bytes = Encoding.Default.GetBytes(text);
            byte[] encoded = hashmd5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encoded.Length; i++)
                sb.Append(encoded[i].ToString("x2"));

            return sb.ToString();
        }
    }
}
