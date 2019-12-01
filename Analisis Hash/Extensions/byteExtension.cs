using System.Text;

namespace Analisis_Hash.Extensions
{
    internal static class byteExtension
    {
        /// <summary>
        ///     Funcion para igualar una cadena con otra en longitud, manteniendo sus caracteres
        /// </summary>
        /// <param name="bytes">Arreglo de bytes que se convertira a Hexadecimal</param>
        /// <param name="upper">Booleana para saber si las letras seran mayusculas o no</param>
        /// <returns>Cadena en Hexadecimal</returns>
        public static string ToHex(this byte[] bytes, bool upper = false)
        {
            var builder = new StringBuilder(bytes.Length * 2);
            for (var i = 0; i < bytes.Length; i++) builder.Append(bytes[i].ToString(upper ? "X2" : "x2"));

            return builder.ToString();
        }
    }
}