using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;

namespace Order_Application_Admin
{
    public class Email
    {
        private string host = "smtp.gmail.com";
        private int port = 587;

        public void sendEmail(string [] values)
        {
            try
            {
                NetworkCredential credential = new NetworkCredential(values[2], values[3]); //email username and password
                SmtpClient client = new SmtpClient(host);
                client.Port = port;
                client.EnableSsl = true;
                client.Credentials = credential;

                MailMessage message = new MailMessage { From = new MailAddress(values[2]) };

                ManageSellerReference.ManageSellerSoapClient seller = new ManageSellerReference.ManageSellerSoapClient();
                string toEmail = seller.getEmail(values[0]);
                message.To.Add(new MailAddress(toEmail));

                message.Subject = values[1];
                message.Body = values[4];
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;

                message.Priority = MailPriority.Normal;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.SendCompleted += new SendCompletedEventHandler(sendCompleteHandler);
                client.SendMailAsync(message);
            }
            catch(Exception ex)
            {
                Logging logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
            }
        }

        private static void sendCompleteHandler(object sender,AsyncCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                MessageBox.Show("Email sending cancelled");
            }
            if(e.Error!=null)
            {
                MessageBox.Show("Error occured: " + e.Error.ToString());
            }                       
            else
            {
                MessageBox.Show("Email sent successfully");
            }
 
        }                           
    }
}