﻿using KidAccidentPrecaution.Models.Entities.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace KidAccidentPrecaution.Models.Email_Notifier
{
    public class EmailOrganizer
    {
        public void Mailer(Band  ObjBand)
        {
            //MailMessage message = new MailMessage();
            //message.From = new MailAddress("hr@inzenjer.in");

            //message.To.Add(new MailAddress("ramjinrajin@gmail.com"));

            //message.Subject = ObjBand.Email.SubjectLine;
            //message.Body = ObjBand.Email.Body;
            //message.IsBodyHtml = true;

            //SmtpClient client = new SmtpClient();
            //client.Host = "mail.colorsfx.com";
            //client.Port = 25;
            //client.UseDefaultCredentials = false;
            //client.EnableSsl = false;
            //client.Credentials = new NetworkCredential("heera@inzenjer.in", "heera@inzenjer");
            //client.Send(message);
             
        }

        public static class SMTPProtocol
        {
            public static void NotifyPartners(string subject, string body, string emailTo)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("info@inzenjer.in");

                message.To.Add(new MailAddress(emailTo));

                message.Subject = subject;
                message.Body = body;

                SmtpClient client = new SmtpClient();
                client.Host = "relay-hosting.secureserver.net";
                client.Port = 25;
                client.UseDefaultCredentials = false;
                client.EnableSsl = false;
                client.Credentials = new NetworkCredential("info@inzenjer.in", "InZenjer@2017");
                client.Send(message);
            }
        }
    }
}