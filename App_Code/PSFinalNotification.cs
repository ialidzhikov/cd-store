namespace CommerceLib
{
    /// <summary>
    /// 8th pipeline stage - used to send a notification email to
    /// the customer, confirming that the order has been shipped
    /// </summary>
    public class PSFinalNotification : IPipelineSection
    {
        private OrderProcessor orderProcessor;
        public void Process(OrderProcessor processor)
        {
            // set processor reference
            orderProcessor = processor;
            // audit
            orderProcessor.CreateAudit("PSFinalNotification started.",
            20700);
            try
            {
                // send mail to customer
                orderProcessor.MailCustomer("CdShop order dispatched.",
                GetMailBody());
                // audit
                orderProcessor.CreateAudit(
                "Dispatch e-mail sent to customer.", 20702);
                // update order status
                orderProcessor.Order.UpdateStatus(8);
            }
            catch
            {
                // mail sending failure
                throw new OrderProcessorException(
                "Unable to send e-mail to customer.", 7);
            }
            // audit
            processor.CreateAudit("PSFinalNotification finished.", 20701);
        }

        private string GetMailBody()
        {
            // construct message body
            string mail =
            "Поръчката ви е изпратена! Следните "
            + "продукти бяха доставени:\n\n"
            + orderProcessor.Order.OrderAsString
            + "\n\nПоръчката ви бе доставена до:\n\n"
            + orderProcessor.Order.CustomerAddressAsString
            + "\n\nНомер за справка на поръчката:\n\n"
            + orderProcessor.Order.OrderId.ToString()
            + "\n\nБлагодарим, че пазарувахте в CdShop!";

            return mail;
        }
    }
}