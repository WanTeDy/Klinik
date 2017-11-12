using System;
using System.Collections.Generic;
using System.Linq;
using Klinik.Utils.BusinessOperations.Cart;
using Klinik.Utils.DataBase.Emails;
using Klinik.Utils.Helpers;
using Klinik.Utils.Models;

namespace Klinik.Utils.BusinessOperations.Orders
{
    public class SendMailOperation : BaseOperation
    {
        private string _name { get; set; }
        private string _phone { get; set; }
        private string _email { get; set; }

        public SendMailOperation(string name, string phone, string email)
        {
            _name = name;
            _phone = phone;
            _email = email;
            RussianName = "Отправка почты";
        }

        protected override void InTransaction()
        {
            UserEmailMessage mail = new UserEmailMessage
            {
                Date = DateTime.Now,
                Phone = _phone,
                Message = _email,
                Username = _name,
                Email = _email,
            };
            Context.Emails.Add(mail);
            Context.SaveChanges();

            Send(mail);
        }

        private void Send(UserEmailMessage mail)
        {
            SmtpEmailSender mailSender = new SmtpEmailSender("mail.klinikimzentrum.od.ua", "info@klinikimzentrum.od.ua", "klinikimzentrum!");//Properties.Settings.Default.SmtpServer, Properties.Settings.Default.EmailFrom, Properties.Settings.Default.EmailPassword);
            var body = SmtpEmailSender.GetHtmlRazor(mail, SmtpEmailSender.FormatUrl("SupportMailView"));
            mailSender.Send("klinikimzentrum.od.ua@gmail.com", "Новый запрос", body);
        }
    }
}