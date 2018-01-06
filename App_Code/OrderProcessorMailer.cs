using System.Web.Security;

namespace CommerceLib
{
    /// <summary>
    /// Mailing utilities for OrderProcessor
    /// </summary>
    public static class OrderProcessorMailer
    {
        public static void MailAdmin(int orderID, string subject, string message, int sourceStage)
        {
            // Send mail to administrator
            string to = CdShopConfiguration.ErrorLogEmail;
            string from = CdShopConfiguration.OrderProcessorEmail;
            string body = "Message: " + message
            + "\nSource: " + sourceStage.ToString()
            + "\nOrder ID: " + orderID.ToString();
            Utilities.SendMail(from, to, subject, body);
        }

        public static void MailCustomer(MembershipUser customer, string subject, string body)
        {
            // Send mail to customer
            string to = customer.Email;
            string from = CdShopConfiguration.CustomerServiceEmail;
            Utilities.SendMail(from, to, subject, body);
        }

        public static void MailSupplier(string subject, string body)
        {
            // Send mail to supplier
            string to = CdShopConfiguration.SupplierEmail;
            string from = CdShopConfiguration.OrderProcessorEmail;
            Utilities.SendMail(from, to, subject, body);
        }
    }
}