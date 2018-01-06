using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerDetails : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set the title of the page
        this.Title = CdShopConfiguration.SiteName + " : Customer Details";
    }
}