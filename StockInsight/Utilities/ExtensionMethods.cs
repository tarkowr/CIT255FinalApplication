﻿using System;
using System.Globalization;

namespace StockInsight.Utilities
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Extension to convert a string to double and round it to 2 decimal places
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double ConvertStringToDouble(this String str)
        {
            str = str ?? "0.01";
            return Math.Round(double.Parse(str),2);
        }

        /// <summary>
        /// Formats the stock price as a currency
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string FormatStockPrice(this Double val)
        {
            return $"${val.ToString("F")}";
        }

        /// <summary>
        /// Extension to convert a string to title case
        /// Credit to: https://stackoverflow.com/questions/1206019/converting-string-to-title-case
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToTitleCase(this String text)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            
            return textInfo.ToTitleCase(text);
        }
    }
}
