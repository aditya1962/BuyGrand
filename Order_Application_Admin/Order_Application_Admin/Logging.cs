using System;
using System.Configuration;
using System.IO;
using System.Windows;

namespace Order_Application_Admin
{
    public class Logging
    {
        public void logging(Exception e, string type, string message)
        {
            try
            {
                string file = "Logging_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                string source = AppDomain.CurrentDomain.BaseDirectory + "\\Logging\\";
                string filepath = source + file;
                DateTime now = DateTime.Now;
                using(StreamWriter writer = new StreamWriter(filepath,true))
                {
                    if (e != null)
                    {
                        writer.WriteLine(now + "||" + type + "||" + e);
                    }
                    else
                    {
                        writer.WriteLine(now + "||" + type + "||" + message);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}