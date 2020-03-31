using System;
using System.IO;
using System.Windows;

namespace ServiceApplicationBuyGrandAdmin
{
    public class Logging
    {
        public void logging(Exception e, string type, string message)
        {
            string file = "Logging_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            string source = AppDomain.CurrentDomain.BaseDirectory + "\\Logging\\";
            string filepath = source + file;
            DateTime now = DateTime.Now;

            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    if(e != null)
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