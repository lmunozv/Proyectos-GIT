using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Collections;

namespace Bizagi.Test.Util
{
    public class CommonMethods
    {
        public string ConvertNumbersToLetters(string num, bool minuscula)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }
            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                string punto = " PUNTO ";
                string coma = " COMA ";
                if (num.Contains("."))
                {
                    dec = punto + ToText(Convert.ToDouble(decimales));
                }
                else if (num.Contains(","))
                {
                    dec = coma + ToText(Convert.ToDouble(decimales));
                }
            }


            res = ToText(Convert.ToDouble(entero)) + dec;
            if (minuscula)
            {
                res = res.ToLower();
            }
            return res;
        }

        public string GetMonthInLetters(DateTime fecha, string cultura)
        {
            return fecha.ToString("MMMM", CultureInfo.CreateSpecificCulture(cultura));
        }



        public string SetString(ArrayList listaValores)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (var obj in listaValores)
                {
                    AjusteAlfanumericoBO item = (AjusteAlfanumericoBO)obj;
                    if (item.Negrita)
                    {

                       item.Informacion=  item.Informacion.Negrita();
                    }
                    switch ((EnumOrientacion)item.Orientacion)
                    {
                        case EnumOrientacion.Izquierda:
                            if (item.CantidadElemento > 0)
                            {
                                sb.Append(item.Informacion.PadLeft(item.CantidadElemento, Convert.ToChar(item.Elemento)));
                            }
                            else
                            {
                                sb.Append(item.Informacion);
                            }

                            break;
                        case EnumOrientacion.Derecha:
                            if (item.CantidadElemento > 0)
                            {
                                sb.Append(item.Informacion.PadRight(item.CantidadElemento, Convert.ToChar(item.Elemento)));
                            }
                            else
                            {
                                sb.Append(item.Informacion);
                            }
                            break;
                        case EnumOrientacion.Justificado:
                            sb.Append(item.Informacion);
                            break;
                        case EnumOrientacion.Cetrado:
                            var centeredString = item.Informacion.PadLeft(((item.CantidadElemento - item.Informacion.Length) / 2)
                                + item.Informacion.Length)
                                   .PadRight(item.CantidadElemento);
                            sb.Append(centeredString);
                            break;
                    }

                    for (int i = 0; i < item.CantidadSaltoLinea; i++)
                    {
                        sb.Append("\n");
                    }
                }
                return sb.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetDayInLetters(DateTime fecha, string cultura)
        {
            return fecha.ToString("dddd", CultureInfo.CreateSpecificCulture(cultura));
        }

        /// <summary>
        /// Luis Fernando Muñoz Vega.
        /// Metodo que se encaga de escribir el archivo en la ruta.
        /// </summary>
        /// <param name="pathFile"></param>
        /// <param name="stringReport"></param>
        public void WriteFile(string path, string nameFile, string information)
        {
            string directory = path + Convert.ToString(@"\");
            string pathFile = directory + nameFile;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            StreamWriter writer = File.AppendText(pathFile);
            writer.WriteLine(information);
            writer.Close();
        }

        private static string ToText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UN";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + ToText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + ToText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = ToText(Math.Truncate(value / 10) * 10) + " Y " + ToText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + ToText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = ToText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = ToText(Math.Truncate(value / 100) * 100) + " " + ToText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + ToText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = ToText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + ToText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + ToText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = ToText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + ToText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + ToText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = ToText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + ToText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

        }
    }

    public class AjusteAlfanumericoBO
    {
        public string Informacion { get; set; }
        public int Orientacion { get; set; }
        public string Elemento { get; set; }
        public int CantidadElemento { get; set; }
        public int CantidadSaltoLinea { get; set; }
        public bool Negrita { get; set; }
    }


    public enum EnumOrientacion
    {
        Izquierda = 1,
        Derecha = 2,
        Justificado = 3,
        Cetrado = 4
    }

    public static class HtmlStringUtils
    {
        public static string Negrita(this string s)
        {
            return "<strong>" + s + "</strong>";
        }
    }
}
