using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminShoppingCart : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        byte days = byte.Parse(daysList.SelectedItem.Value);
        ShoppingCartDao.DeleteOldCarts(days);
        countLabel.Text = "Старите колички са успешно прамахнати от базата данни.";
    }

    protected void countButton_Click(object sender, EventArgs e)
    {
        byte days = byte.Parse(daysList.SelectedItem.Value);
        int oldItems = ShoppingCartDao.CountOldCarts(days);
        if (oldItems == -1)
        {
            countLabel.Text = "Неуспешно преброяване на старите колички!";
        }
        else if (oldItems == 0)
        {
            countLabel.Text = "Няма намерени стари колички.";
        }
        else
        {
            countLabel.Text = "Намерени са " + oldItems.ToString() + " стари колички.";
        }
    }
}