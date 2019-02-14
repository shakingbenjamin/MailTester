using System;
using System.Net;
using System.Net.Mail;

namespace MailTestApplication
{
    public class MailTester
    {
        public static string BodyBuilder(string server, int port, string to, string from)
        {
            var result = "";
            try
            {
                var enl = "</br>";

                var s = new MailStatus
                {
                    IPAddress = Dns.GetHostName(),
                    MailServer = server,
                    PortNumber = port,
                    ToAddress = to,
                    FromAddress = from,
                    TimeSent = DateTime.Now.ToString()
                };

                result += $"<strong>Test Information</strong>{enl}{enl} Host/IP Address: {s.IPAddress}{enl} Mail Server: {s.MailServer}{enl}" +
                    $"Port: {s.PortNumber}{enl}To: {s.ToAddress}{enl} From: {s.FromAddress}{enl} Sent At: {s.TimeSent}";
            }
            catch(Exception ex)
            {
                
            }
                
            return result;
        }

        public static void SendEmail(string server,string port, string to, string from)
        {
            try
            {
                var _port = Convert.ToInt32(port);
                string _body = BodyBuilder(server, _port, to, from);
                string _subject = "Mail Services Test";

                using (SmtpClient msgClient = new SmtpClient())
                {
                    msgClient.EnableSsl = false;
                    msgClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    msgClient.UseDefaultCredentials = false;
                    msgClient.Credentials = new NetworkCredential
                    {
                        // add necessary credentials
                    };
                    msgClient.Host = server; //"webmail.domain.com";
                    msgClient.Port = _port; //25 by default;

                    using (MailMessage msg = new MailMessage())
                    {
                        msg.IsBodyHtml = true;
                        msg.To.Add(to);
                        msg.From = new MailAddress(from);
                        msg.Subject = _subject;
                        msg.Body = _body;
                        msgClient.Send(msg);
                    }
                }
            }
            catch(Exception ex)
            {
                // error logging
            }
        }
    }
}
