﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderPlaced : Page
{
    protected override void OnInit(EventArgs e)
    {
        // Uncomment to enforce SSL (as explained in Chapter 16)
        // (Master as CdShop).EnforceSSL = true;
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set the title of the page
        this.Title = CdShopConfiguration.SiteName + " : Order Placed";
    }
}