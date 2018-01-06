using CommerceLib;
using ECommerce.CdShop.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Checkout : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    // fill controls with data
    private void PopulateControls()
    {
        // get the items in the shopping cart
        DataTable dt = ShoppingCartDao.GetItems();
        // populate the list with the shopping cart contents
        grid.DataSource = dt;
        grid.DataBind();
        grid.Visible = true;
        // display the total amount
        decimal amount = ShoppingCartDao.GetTotalAmount();
        totalAmountLabel.Text = String.Format("{0:c}", amount);
        // check customer details
        bool addressOK = true;
        bool cardOK = true;
        if (Profile.Address1 + Profile.Address2 == ""
        || Profile.ShippingRegion == ""
        || Profile.ShippingRegion == "Please Select"
        || Profile.Country == "")
        {
            addressOK = false;
        }
        if (Profile.CreditCard == "")
        {
            cardOK = false;
        }
        // report/hide place order button
        if (!addressOK)
        {
            if (!cardOK)
            {
                InfoLabel.Text =
                "You must provide a valid address and credit card "
                + "before placing your order.";
            }
            else
            {
                InfoLabel.Text =
                "You must provide a valid address before placing your "
                + "order.";
            }
        }
        else if (!cardOK)
        {
            InfoLabel.Text = "You must provide a credit card before "
            + "placing your order.";
        }
        else
        {
            InfoLabel.Text =
            "Please confirm that the above details are "
            + "correct before proceeding.";
        }
        placeOrderButton.Visible = addressOK && cardOK;
        shippingSelection.Visible = addressOK && cardOK;
        // Populate shipping selection
        if (addressOK && cardOK)
        {
            int shippingRegionId = int.Parse(Profile.ShippingRegion);
            List<Shipping> shippingInfoData = CommerceLibAccess.GetShippingInfo(shippingRegionId);
            foreach (Shipping shipping in shippingInfoData)
            {
                ListItem item = new ListItem(shipping.ShippingType, shipping.Id.ToString());
                shippingSelection.Items.Add(item);
            }
            shippingSelection.SelectedIndex = 0;
        }
    }

    protected void placeOrderButton_Click(object sender, EventArgs e)
    {
        // Store the total amount
        decimal amount = ShoppingCartDao.GetTotalAmount();
        // Get shipping ID or default to 0
        int shippingId = 0;
        int.TryParse(shippingSelection.SelectedValue, out shippingId);
        // Get tax ID or default to "No tax"
        string shippingRegion =
        (HttpContext.Current.Profile as ProfileCommon).ShippingRegion;
        int taxId;
        switch (shippingRegion)
        {
            case "2":
                taxId = 1;
                break;
            default:
                taxId = 2;
                break;
        }
        // Create the order and store the order ID
        string orderId = ShoppingCartDao.CreateCommerceLibOrder(shippingId, taxId);
        // Process order
        OrderProcessor processor = new OrderProcessor(orderId);
        processor.Process();
        // Redirect to the conformation page
        Response.Redirect("OrderPlaced.aspx");
    }

}