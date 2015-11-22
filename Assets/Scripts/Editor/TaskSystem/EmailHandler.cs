using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class EmailHandler
{
    public void SendEmail(string emailTo, string subject, string bodyText)
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("duifkoe@hotmail.com");
        mail.To.Add(emailTo);
        mail.Subject = subject;
        mail.Body = bodyText;

        SmtpClient smtpServer = new SmtpClient("smtp.live.com");    // should fit the sender
        smtpServer.EnableSsl = true;
        smtpServer.Port = 587;
        smtpServer.UseDefaultCredentials = false;
        smtpServer.Credentials = new System.Net.NetworkCredential("duifkoe@hotmail.com", "Vlucht714") as ICredentialsByHost;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
        Debug.Log("successfully sent an email to " + emailTo);
    }
}