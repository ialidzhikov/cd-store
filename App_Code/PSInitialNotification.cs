namespace CommerceLib
{
    /// <summary>
    /// 1st pipeline stage - used to send a notification email to
    /// the customer, confirming that the order has been received
    /// </summary>
    public class PSInitialNotification : IPipelineSection
    {
        private OrderProcessor orderProcessor;

        public void Process(OrderProcessor processor)
        {
            // set processor reference
            orderProcessor = processor;
            // audit
            orderProcessor.CreateAudit("PSInitialNotification started.", 20000);
            try
            {
                // send mail to customer
                orderProcessor.MailCustomer("CdShop order received.", GetMailBody());
                // audit
                orderProcessor.CreateAudit(
                "Notification e-mail sent to customer.", 20002);
                // update order status
                orderProcessor.Order.UpdateStatus(1);
                // continue processing
                orderProcessor.ContinueNow = true;
            }
            catch
            {
                // mail sending failure
                throw new OrderProcessorException("Unable to send e-mail to customer.", 0);
            }
            // audit
            processor.CreateAudit("PSInitialNotification finished.", 20001);
        }

        private string GetMailBody()
        {
            string mail;
            mail = "Благодарим ви за поръчката! Продуктите, които поръчахте са следните:\n\n"
            + orderProcessor.Order.OrderAsString
            + "\n\nПоръчката ви ще бъде доставена до:\n\n"
            + orderProcessor.Order.CustomerAddressAsString
            + "\n\nНомер за справка на поръчката:\n\n"
            + orderProcessor.Order.OrderId.ToString()
            + "\n\nЩе получите мейл с потвърждение, когато поръчката ви е изпратена. "
            + "Благодарим, че пазарувахте в CdShop!";

            return mail;
        }
    }
}