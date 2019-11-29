using System.Security.Cryptography;
using System.Text;
using Analisis_Hash.Extensions;

namespace Analisis_Hash.Functions
{
    internal class Authentication
    {
        /// <summary>
        /// Funcion SHA256 en Hexadecimal
        /// </summary>
        /// <param name="text">Texto para calcular el resumen con SHA256</param>
        /// <returns>Resumen en Hexadecimal</returns>
        public string Sha256Hex(string text)
        {
            string hashString;

            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.Default.GetBytes(text));
                hashString = hash.ToHex(true);
            }

            return hashString;
        }
    }
}