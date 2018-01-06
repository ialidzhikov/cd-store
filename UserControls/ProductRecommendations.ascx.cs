using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ProductRecommendations : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void LoadProductRecommendations(string productId)
    {
        // display product recommendations
        DataTable table = CatalogAccess.GetRecommendations(productId);
        if (table.Rows.Count > 0)
        {
            list.ShowHeader = true;
            list.DataSource = table;
            list.DataBind();
        }
    }
    public void LoadCartRecommendations()
    {
        // display product recommendations
        DataTable table = ShoppingCartDao.GetRecommendations();
        if (table.Rows.Count > 0)
        {
            list.ShowHeader = true;
            list.DataSource = table;
            list.DataBind();
        }
    }
}