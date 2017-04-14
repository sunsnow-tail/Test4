using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EmailSettings {

        public string MailToAddress = "orders@example.com";

        public string MailFromAddress = "sportsstore@example.com";

        public bool UseSsl = true;

        public string Username = "MySmtpUsername";

        public string Password = "MySmtpPassword";

        public string ServerName = "smtp.example.com";

        public int ServerPort = 587;

        public bool WriteAsFile = false;

        public string FileLocation = @"c:\sports_store_emails";
    }

}
