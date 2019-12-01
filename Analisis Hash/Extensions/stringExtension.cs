using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analisis_Hash.Extensions
{
    internal static class stringExtension
    {
        /// <summary>
        ///     Funcion para pasar de texto a bits
        /// </summary>
        /// <param name="text">Texto a convertir</param>
        /// <param name="encoding">Tipo de codificacion</param>
        /// <returns>Cadena binaria del texto</returns>
        public static string TextToBin(this string text, Encoding encoding)
        {
            return string.Join("", encoding.GetBytes(text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
        }

        /// <summary>
        ///     Funcion para pasar los bits a texto
        /// </summary>
        /// <param name="data">Cadena binaria a transformar</param>
        /// <param name="encoding">Tipo de codificacion</param>
        /// <returns>Cadena de texto</returns>
        public static string BinToText(this string data, Encoding encoding)
        {
            var byteList = new List<byte>();

            for (var i = 0; i < data.Length; i += 8) byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));

            return encoding.GetString(byteList.ToArray());
        }

        /// <summary>
        ///     Funcion para pasar de texto a bits
        /// </summary>
        /// <param name="text">Texto a convertir en Hexadecimal</param>
        /// <returns>Cadena binaria del Hexadecimal</returns>
        public static string HexToBin(this string text)
        {
            return string.Join("",
                text.Select(n => Convert.ToString(Convert.ToInt32(n.ToString(), 16), 2).PadLeft(4, '0')));
        }

        /// <summary>
        ///     Funcion para pasar de bits a Hexadecimal
        /// </summary>
        /// <param name="data">Texto a convertir en Hexadecimal</param>
        /// <returns>Cadena Hexadecimal del data</returns>
        public static string BinToHex(this string data)
        {
            var byteList = new List<byte>();
            for (var i = 0; i < data.Length; i += 4) byteList.Add(Convert.ToByte(data.Substring(i, 4), 2));

            return string.Join("", byteList.ToArray().Select(x => Convert.ToString(x, 16)));
        }

        /// <summary>
        ///     Funcion para igualar una cadena con otra en longitud, manteniendo sus caracteres
        /// </summary>
        /// <param name="shortCad">Cadena que se quiere emparejar</param>
        /// <param name="text">Cadena principal con la que se va a emparejar</param>
        /// <returns>Cadena con misma longitud y caracteres reptidos</returns>
        public static string ToEqualize(this string shortCad, string text)
        {
            while (shortCad.Length < text.Length) shortCad += shortCad;

            shortCad = shortCad.Substring(0, text.Length);

            return shortCad;
        }

        /// <summary>
        ///     Funcion para igualar una cadena con otra en longitud, manteniendo sus caracteres
        /// </summary>
        /// <param name="shortCad">Cadena que se quiere emparejar</param>
        /// <param name="text">Cadena principal con la que se va a emparejar</param>
        /// <param name="caracter">Caracter con el que se va a rellenar</param>
        /// <returns>Cadena con misma longitud y caracteres reptidos</returns>
        public static string ToEqualize(this string shortCad, string text, char caracter)
        {
            if (shortCad.Length < text.Length) shortCad = shortCad.PadRight(text.Length, caracter);

            return shortCad;
        }

        /// <summary>
        ///     Funcion para igualar una cadena con otra en longitud, manteniendo sus caracteres
        /// </summary>
        /// <param name="bytes">Arreglo de bytes que se convertira a Hexadecimal</param>
        /// <param name="upper">Booleana para saber si las letras seran mayusculas o no</param>
        /// <returns>Cadena en Hexadecimal</returns>
        public static string ToHex(this byte[] bytes, bool upper)
        {
            var builder = new StringBuilder(bytes.Length * 2);
            for (var i = 0; i < bytes.Length; i++) builder.Append(bytes[i].ToString(upper ? "X2" : "x2"));

            return builder.ToString();
        }
    }
}