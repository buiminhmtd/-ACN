using System;
using System.Web.Mail;
using System.Text;

namespace MyWeb.Common
{
    public class MailSender
    {
        #region[Declare variables]
        private static string _Mail_Smtp;
        private static string _Mail_Port;
        private static string _Mail_From;
        private static string _Mail_Name;
        private static string _Mail_Password;
        #endregion
        #region[Public Properties]
        public static string Mail_Smtp { get { if (_Mail_Smtp != null && _Mail_Smtp != "") { return _Mail_Smtp; } else { return GlobalClass.Mail_Smtp; } } set { _Mail_Smtp = value; } }
        public static string Mail_Port { get { if (_Mail_Port != null && _Mail_Port != "") { return _Mail_Port; } else { return GlobalClass.Mail_Port; } } set { _Mail_Port = value; } }
        public static string Mail_From { get { if (_Mail_From != null && _Mail_From != "") { return _Mail_From; } else { return GlobalClass.Mail_Noreply; } } set { _Mail_From = value; } }
        public static string Mail_Name { get { if (_Mail_Name != null && _Mail_Name != "") { return _Mail_Name; } else { return GlobalClass.Mail_Noreply; } } set { _Mail_Name = value; } }
        public static string Mail_Password { get { if (_Mail_Password != null && _Mail_Password != "") { return _Mail_Password; } else { return GlobalClass.Mail_Password; } } set { _Mail_Password = value; } }
        #endregion
        #region[Public Properties]
        public static void SendMail(string to, string bbc, string subject, string messages)
        {
            SendMail(to, bbc, subject, messages, Mail_Smtp, Mail_Port, Mail_From, Mail_Name, Mail_Password);
        }
        public static void SendMail(string to, string bbc, string subject, string messages, string smtp, string port, string from, string user, string password)
        {
            try
            {
                System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
                mail.To = to;
                mail.Bcc = bbc;
                mail.From = from;
                mail.Subject = subject;
                mail.BodyEncoding = Encoding.GetEncoding("utf-8");
                mail.BodyFormat = MailFormat.Html;
                mail.Body = messages;
                mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendusing"] = 2;
                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = smtp;
                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"] = port;
                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpusessl"] = 1; // "true";
                //mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout"] = 60;
                mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1;
                mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = user;
                mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = password;
                //SmtpMail.SmtpServer = smtp;
                SmtpMail.Send(mail);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
