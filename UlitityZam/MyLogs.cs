using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlitityZam
{
    public class MyLogs
    {
        private readonly string _directoryPath;

        public MyLogs()
        {
            _directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyLogs");

            // Crear la carpeta si no existe
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }
        }

        private string GetFilePath()
        {
            string fileName = $"{DateTime.Now:yyyy-MM-dd}.txt";
            return Path.Combine(_directoryPath, fileName);
        }
        /// <summary>
        /// Escrivbe los logs 
        /// </summary>
        /// <param name="message">mensaje a escribir</param>
        /// <param name="clase">nombre de la clase a la que pertencen</param>
        public void WriteLog(string message, string clase)
        {
            string filePath = GetFilePath();
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {clase} - {message}\n";

            // Verificar si el archivo existe y crearlo si no existe
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, logMessage);
            }
            else
            {
                File.AppendAllText(filePath, logMessage);
            }
        }


    }
}
