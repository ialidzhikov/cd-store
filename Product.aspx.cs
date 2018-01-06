using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Retrieve ProductID from the query string
        string productId = Request.QueryString["ProductID"];
        // Retrieves product details
        ECommerce.CdShop.Entity.Product pd = CatalogAccess.GetProductDetails(productId);
        // Does the product exist?
        if (pd.Name != null)
        {
            PopulateControls(pd);
        }
        else
        {
            Server.Transfer("~/NotFound.aspx");
        }
        // 301 redirect to the proper URL if necessary
        //Link.CheckProductUrl(Request.QueryString["ProductID"]);
    }
    // Fill the control with data
    private void PopulateControls(ECommerce.CdShop.Entity.Product pd)
    {
        // Display product recommendations
        string productId = pd.Id.ToString();
        recommendations.LoadProductRecommendations(productId);

        // Display product details
        titleLabel.Text = pd.Name;
        descriptionLabel.Text = pd.Description;
        priceLabel.Text = String.Format("{0:c}", pd.Price);
        productImage.ImageUrl = "ProductImages/" + pd.Image;
        // Set the title of the page
        this.Title = CdShopConfiguration.SiteName + pd.Name;

        // obtain the attributes of the product
        DataTable attrTable = CatalogAccess.GetProductAttributes(pd.Id.ToString());
        // temp variables
        string prevAttributeName = "";
        string attributeName, attributeValue, attributeValueId;
        // current DropDown for attribute values
        Label attributeNameLabel;
        DropDownList attributeValuesDropDown = new DropDownList();
        // read the list of attributes
        foreach (DataRow r in attrTable.Rows)
        {
            // get attribute data
            attributeName = r["AttributeName"].ToString();
            attributeValue = r["AttributeValue"].ToString();
            attributeValueId = r["AttributeValueID"].ToString();
            // if starting a new attribute (e.g. Color, Size)
            if (attributeName != prevAttributeName)
            {
                prevAttributeName = attributeName;
                attributeNameLabel = new Label();
                attributeNameLabel.Text = attributeName + ": ";
                attributeValuesDropDown = new DropDownList();
                attrPlaceHolder.Controls.Add(attributeNameLabel);
                attrPlaceHolder.Controls.Add(attributeValuesDropDown);
            }
            // add a new attribute value to the DropDownList
            attributeValuesDropDown.Items.Add(new ListItem(attributeValue, attributeValueId));
        }
    }

    protected void AddToCartButton_Click(object sender, EventArgs e)
    {
        // Retrieve ProductID from the query string
        string productId = Request.QueryString["ProductID"];
        // Retrieve the selected product options
        string options = "";
        foreach (Control cnt in attrPlaceHolder.Controls)
        {
            if (cnt is Label)
            {
                Label attrLabel = (Label)cnt;
                options += attrLabel.Text;
            }
            if (cnt is DropDownList)
            {
                DropDownList attrDropDown = (DropDownList)cnt;
                options += attrDropDown.Items[attrDropDown.SelectedIndex] + "; ";
            }
        }
        // Add the product to the shopping cart
        ShoppingCartDao.AddItem(productId, options);
    }
}
