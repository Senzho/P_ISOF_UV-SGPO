using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OrozGP.Util
{
    /// <summary>
    /// Clase con métodos para la encriptación / codificación de cadenas de texto.
    /// </summary>
    class Encriptacion
    {
        /// <summary>
        /// Codifica una cadena de texto en SHA256.
        /// </summary>
        /// <param name="cadena">Cadena de texto a codificar.</param>
        /// <returns>
        /// Una cadena de texto con el valor SHA256 de una cadena de texto dada.
        /// </returns>
        public static string Sha256(string cadena)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();
            byte[] inputBytes = Encoding.UTF8.GetBytes(cadena);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);
            StringBuilder hash = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                hash.Append(hashedBytes[i].ToString("x2").ToLower());
            }
            return hash.ToString();
        }
    }
}
