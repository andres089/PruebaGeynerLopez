using System;
using System.IO;
using System.Configuration;

namespace Prueba.Transversal
{
    public class Utilidades
    {
        /// <summary>
        /// Registra un error en un archivo de texto.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="claseMetodo"></param>
        public static void RegistrarError(Exception ex, string claseMetodo)
        {
            try
            {
                if (ex.StackTrace.ToString().IndexOf("System.Web.HttpResponseWrapper.set_StatusCode(Int32 value)") < 0)
                {
                    string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["LogError"].ToString());
                    string nombre = DateTime.Now.ToString("dd_MM_yyyy") + ".txt";

                    if (!Directory.Exists(ruta))
                    {
                        Directory.CreateDirectory(ruta);
                    }
                    using (var sw = new StreamWriter(Path.Combine(ruta, nombre), true))
                    {
                        sw.WriteLine("*********************************************************");
                        sw.WriteLine("Error :" + ex.Message);
                        sw.WriteLine("Hora :" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                        sw.WriteLine("Traza: " + ex.StackTrace);
                        sw.WriteLine("Clase_Metodo: " + claseMetodo);
                        sw.Close();
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Concatena el texto de un mensaje con separador.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="texto"></param>
        /// <param name="separador"></param>
        /// <returns></returns>
        public static string ConcatenarMensaje(string mensaje, string texto, string separador)
        {
            string resultado = string.Empty;

            if (mensaje.Trim().Length > 0)
            {
                resultado = string.Concat(mensaje, separador, texto);
            }
            else
            {
                resultado = texto;
            }
            return resultado;
        }
    }
}
