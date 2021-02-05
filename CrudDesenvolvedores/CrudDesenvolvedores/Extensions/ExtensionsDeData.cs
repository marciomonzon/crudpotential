using System;

namespace CrudDesenvolvedores.Extensions
{
    public static class ExtensionsDeData
    {
        public static DateTime StringToDate(this string dateString)
        {
            if (string.IsNullOrEmpty((dateString ?? "").Trim()))
                throw new Exception("Data Inválida!");

            DateTime resultDate;
            if (DateTime.TryParse(dateString, out resultDate))
                return resultDate;

            throw new Exception("Data Inválida!");
        }
    }
}
