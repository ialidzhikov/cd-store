using ECommerce.CdShop.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SecurityLibTester : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void processButton_Click(object sender, EventArgs e)
    {
        string hash1 = PasswordHasher.Hash(pwdBox1.Text);
        string hash2 = PasswordHasher.Hash(pwdBox2.Text);
        StringBuilder sb = new StringBuilder();
        sb.Append("The hash of the first password is: ");
        sb.Append(hash1);
        sb.Append("<br />The hash of the second password is: ");
        sb.Append(hash2);
        if (hash1 == hash2)
        {
            sb.Append("<br />The passwords match! Welcome!");
        }
        else
        {
            sb.Append("<br />Password invalid. "
            + "Armed guards are on their way.");
        }
        result.Text = sb.ToString();
    }
}