using CommerceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void goButton_Click(object sender, EventArgs e)
    {
        try
        {
            OrderInfo orderInfo = CommerceLibAccess.GetOrder(orderIDBox.Text);
            resultLabel.Text = "Order found.";
            addressLabel.Text =
            orderInfo.CustomerAddressAsString.Replace("\n", "<br />");
            creditCardLabel.Text = orderInfo.CreditCard.CardNumberX;
            orderLabel.Text = orderInfo.OrderAsString.Replace("\n", "<br />");
            processButton.Enabled = true;
            processResultLabel.Text = "";
        }
        catch
        {
            resultLabel.Text = "No order found, or order is in old format.";
            addressLabel.Text = "";
            creditCardLabel.Text = "";
            orderLabel.Text = "";
            processButton.Enabled = false;
        }
    }

    protected void processButton_Click(object sender, EventArgs e)
    {
        try
        {
            OrderProcessor processor = new OrderProcessor(orderIDBox.Text);
            processor.Process();
            OrderInfo orderInfo = CommerceLibAccess.GetOrder(orderIDBox.Text);
            processResultLabel.Text = "Order processed, status now: "
            + orderInfo.Status.ToString();
        }
        catch
        {
            OrderInfo orderInfo = CommerceLibAccess.GetOrder(orderIDBox.Text);
            processResultLabel.Text = "Order processing error, status now: " + orderInfo.Status.ToString();
        }
    }
}