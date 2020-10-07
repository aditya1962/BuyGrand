using System;
using System.IO;
using System.Windows;
using System.Web;

namespace ServiceApplicationBuyGrandSeller
{
    public class Logging
    {
        public static void WriteLog(Exception ex, string type, string message)
        {
            string file = "Logging-" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            string destination = HttpContext.Current.Server.MapPath("~") ;
            string path = destination + file;
            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    string logMessage = "";
                    if (ex==null)
                    {
                        logMessage = DateTime.Now.ToString("HH:MM:ss") + "| " + type + " | " + message;
                    }
                    else
                    {
                        logMessage = DateTime.Now.ToString("HH:MM:ss") + "| " + 
                             type + " | " + ex + " | " + message;
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