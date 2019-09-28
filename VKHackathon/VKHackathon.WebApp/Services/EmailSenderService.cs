﻿using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using VKHackathon.WebApp.Services.Interfaces;

namespace VKHackathon.WebApp.Services
{
    public class EmailSenderService : IEmailSender
    {
        //TODO: Заменить данные
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "olympiad-it@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;

            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var admin = new SmtpClient())
            {
                await admin.ConnectAsync("smtp.yandex.ru", 465, true);
                await admin.AuthenticateAsync("olympiad-it@yandex.ru", "AwesomePassword432");
                await admin.SendAsync(emailMessage);
                await admin.DisconnectAsync(true);
            }
        }

        public async Task SendEmailConfirm(string email, string url)
        {
            await SendEmailAsync(email, "Подтверждение регистрации", $"<a href=\"{url}\">Подтверждение почты</a>");
        }
    }
}
