using System;
using System.IO;
using System.Windows;

namespace ServiceApplicationBuyGrandSeller
{
    public class Logging
    {
        public static void WriteLog(Exception ex, string type, string message)
        {
            string file = "Logging-" + DateTime.Now.ToString("YYYY-MM-DD") + ".txt";
            string destination = AppDomain.CurrentDomain.BaseDirectory + "\\Logging\\";
            string path = destination + file;
            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    string logMessage = "";
                    if (ex==null)
                    {
                        logMessage = DateTime.Now.ToString("HH:MM:SS") + "| " + type + " | " + message;
                    }
                    else
                    {
                        logMessage = DateTime.Now.ToString("HH:MM:SS") + "| " + 
                            ex + " | " + type + " | " + message;
                    }
                    writer.WriteLine(logMessage);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}