﻿using System;
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
        /// <param name="caracter">Caracter con el que se va a rellenar</param>
        /// <returns>Cadena con misma longitud y caracteres reptidos</returns>
        public static string ToEqualize(this string shortCad, string text, char caracter)
        {
            if (shortCad.Length < text.Length) shortCad = shortCad.PadRight(text.Length, caracter);

            return shortCad;
        }
    }
}