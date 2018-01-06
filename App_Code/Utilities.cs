using System;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Class contains miscellaneous functionality
/// </summary>
public static class Utilities
{
    static Utilities()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void SendMail(string from, string to, string subject, string body)
    {
        SmtpClient smtpClient = new SmtpClient(CdShopConfiguration.MailServer, 587);
        using (smtpClient)
        {
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(CdShopConfiguration.MailUsername, CdShopConfiguration.MailPassword);

            MailMessage mailMessage = new MailMessage(from, to, subject, body);

            smtpClient.Send(mailMessage);
        }
    }

    // Send error log mail
    public static void LogError(Exception ex)
    {
        // get the current date and time
        string dateTime = DateTime.Now.ToLongDateString() + ", at " + DateTime.Now.ToShortTimeString();
        // stores the error message
        string errorMessage = "Exception generated on " + dateTime;
        // obtain the page that generated the error
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        errorMessage += "\n\n Page location: " + context.Request.RawUrl;
        // build the error message
        errorMessage += "\n\n Message: " + ex.Message;
        errorMessage += "\n\n Source: " + ex.Source;
        errorMessage += "\n\n Method: " + ex.TargetSite;
        errorMessage += "\n\n Stack Trace: \n\n" + ex.StackTrace;
        // send error email in case the option is activated in web.config
        if (CdShopConfiguration.EnableErrorLogEmail)
        {
            string from = CdShopConfiguration.MailFrom;
            string to = CdShopConfiguration.ErrorLogEmail;
            string subject = "BalloonShop Error Report";
            string body = errorMessage;
            SendMail(from, to, subject, body);
        }
    }
}