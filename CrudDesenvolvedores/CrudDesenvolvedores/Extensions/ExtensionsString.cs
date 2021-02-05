using System;

namespace CrudDesenvolvedores.Extensions
{
    public static class ExtensionsString
    {
        public static int ConverterParaInteiro(this string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new Exception("Valor de conversão inválido!");

            int valorConvertido = 0;

            int.TryParse(number, out valorConvertido);

            return valorConvertido;
        }
    }
}
