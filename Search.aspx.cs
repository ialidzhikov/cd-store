using System;
using System.Web.UI;

public partial class Search : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // fill the table contents
            string searchString = Request.QueryString["Search"];
            titleLabel.Text = "Product Search";
            descriptionLabel.Text = "You searched for \"" + searchString + "\"";
            // set the title of the page
            this.Title = CdShopConfiguration.SiteName + " : Product Search : " + searchString;
        }
    }
}
