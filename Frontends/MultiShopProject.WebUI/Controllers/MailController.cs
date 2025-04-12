﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MultiShopProject.WebUI.Models;

namespace MultiShopProject.WebUI.Controllers;

public class MailController : Controller
{
    [HttpGet]
    public IActionResult SendMail()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SendMail(MailRequest mailRequest)
    {
        MimeMessage mimeMessage = new MimeMessage();

        MailboxAddress mailboxAddressFrom = new MailboxAddress("MultiShopProject Katalog", "abc@gmail.com");
        mimeMessage.From.Add(mailboxAddressFrom);

        MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
        mimeMessage.To.Add(mailboxAddressTo);

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = mailRequest.MessageContent;
        mimeMessage.Body = bodyBuilder.ToMessageBody();

        mimeMessage.Subject = mailRequest.Subject;

        SmtpClient client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate("abc@gmail.com", "google ikili doğrulama şifresi");
        client.Send(mimeMessage);
        client.Disconnect(true);

        return View();
    }
}
