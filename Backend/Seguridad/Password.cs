using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Seguridad
{
    public class Password
    {
        public static string ObtenerHash(string password)
        {
            var sha = new SHA1CryptoServiceProvider();
            var byteArray = Encoding.ASCII.GetBytes(password);
            var hashed = sha.ComputeHash(byteArray);
            return BitConverter.ToString(hashed).Replace("-", "").ToLower();
        }
    }
}
