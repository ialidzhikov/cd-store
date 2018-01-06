using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_CartSummary : UserControl
{
    // we don't want to display the cart summary in the shopping cart page
    protected void Page_Init(object sender, EventArgs e)
    {
        // get the current page
        string page = Request.AppRelativeCurrentExecutionFilePath;
        // if we're in the shopping cart, don't display the cart summary
        if (String.Compare(page, "~/ShoppingCart.aspx", true) == 0)
            this.Visible = false;
        else
            this.Visible = true;
    }

    // fill cart summary contents in the PreRender stage
    protected void Page_PreRender(object sender, EventArgs e)
    {
        PopulateControls();
    }

    // fill the controls with data
    private void PopulateControls()
    {
        // get the items in the shopping cart
        System.Data.DataTable dt = ShoppingCartDao.GetItems();
        // if the shopping cart is empty...
        if (dt.Rows.Count == 0)
        {
            cartSummaryLabel.Text = "Вашата количка е празна.";
            totalAmountLabel.Text = String.Format("{0:c}", 0);
            viewCartLink.Visible = false;
            list.Visible = false;
        }
        else
        // if the shopping cart is not empty...
        {
            // populate the list with the shopping cart contents
            list.Visible = true;
            list.DataSource = dt;
            list.DataBind();
            // set up controls
            cartSummaryLabel.Text = "Вашата количка ";
            viewCartLink.Visible = true;
            // display the total amount
            decimal amount = ShoppingCartDao.GetTotalAmount();
            totalAmountLabel.Text = String.Format("{0:c}", amount);
        }
    }
}