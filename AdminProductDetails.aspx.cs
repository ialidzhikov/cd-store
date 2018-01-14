using ECommerce.CdShop.Dao;
using ECommerce.CdShop.Entity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminProductDetails : Page
{
    private string currentProductId;
    private string currentCategoryId;
    private string currentDepartmentId;

    private CategoryDao categoryDao;

    public AdminProductDetails()
    {
        categoryDao = new CategoryDao();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Get DepartmentID, CategoryID, and ProductID from the query string
        // and save their values
        currentDepartmentId = Request.QueryString["DepartmentID"];
        currentCategoryId = Request.QueryString["CategoryID"];
        currentProductId = Request.QueryString["ProductID"];
        // Fill the controls with data only on the initial page load
        if (!IsPostBack)
        {
            // Fill controls with data
            PopulateControls();
        }
    }

    // Populate the controls
    private void PopulateControls()
    {
        // Retrieve product details and category details from database
        ECommerce.CdShop.Entity.Product productDetails = CatalogAccess.GetProductDetails(currentProductId);
        Category categoryDetails = categoryDao.Find(currentCategoryId);
        // Set up labels and images
        productNameLabel.Text = productDetails.Name;
        image1.ImageUrl = Link.ToProductImage(productDetails.Thumbnail);
        image2.ImageUrl = Link.ToProductImage(productDetails.Image);
        // Link to department
        catLink.Text = categoryDetails.Name;
        catLink.NavigateUrl = "AdminCategories.aspx?DepartmentID=" + currentDepartmentId;
        // Clear form
        categoriesLabel.Text = "";
        categoriesListAssign.Items.Clear();
        categoriesListMove.Items.Clear();
        categoriesListRemove.Items.Clear();
        // Fill categoriesLabel and categoriesListRemove with data
        string categoryId, categoryName;
        DataTable productCategories = CatalogAccess.GetCategoriesWithProduct(currentProductId);
        for (int i = 0; i < productCategories.Rows.Count; i++)
        {
            // obtain category id and name
            categoryId = productCategories.Rows[i]["Id"].ToString();
            categoryName = productCategories.Rows[i]["Name"].ToString();
            // add a link to the category admin page
            categoriesLabel.Text +=
            (categoriesLabel.Text == "" ? "" : ", ") +
            "<a href='AdminProducts.aspx?DepartmentID=" +
            CatalogAccess.GetCategoryDetails(currentCategoryId).DepartmentId +
            "&CategoryID=" + categoryId + "'>" +
            categoryName + "</a>";
            // populate the categoriesListRemove combo box
            categoriesListRemove.Items.Add(new ListItem(categoryName, categoryId));
        }
        // Delete from catalog or remove from category?
        if (productCategories.Rows.Count > 1)
        {
            deleteButton.Visible = false;
            removeButton.Enabled = true;
        }
        else
        {
            deleteButton.Visible = true;
            removeButton.Enabled = false;
        }
        // Fill categoriesListMove and categoriesListAssign with data
        productCategories = CatalogAccess.GetCategoriesWithoutProduct(currentProductId);
        for (int i = 0; i < productCategories.Rows.Count; i++)
        {
            // obtain category id and name
            categoryId = productCategories.Rows[i]["Id"].ToString();
            categoryName = productCategories.Rows[i]["Name"].ToString();
            // populate the list boxes
            categoriesListAssign.Items.Add(new ListItem(categoryName, categoryId));
            categoriesListMove.Items.Add(new ListItem(categoryName, categoryId));
        }
    }

    protected void removeButton_Click(object sender, EventArgs e)
    {
        // Check if a category was selected
        if (categoriesListRemove.SelectedIndex != -1)
        {
            // Get the category ID that was selected in the DropDownList
            string categoryId = categoriesListRemove.SelectedItem.Value;
            // Remove the product from the category
            bool success = CatalogAccess.RemoveProductFromCategory(currentProductId, categoryId);
            // Display status message
            statusLabel.Text = success ? "Успешно премахване" : "Неуспешно премахване";
            // Refresh the page
            PopulateControls();
        }
        else
        {
            statusLabel.Text = "Трябва да изберете категория";
        }
    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        // Delete the product from the catalog
        CatalogAccess.DeleteProduct(currentProductId);
        // Need to go back to the categories page now
        Response.Redirect("AdminDepartments.aspx");
    }

    protected void assignButton_Click(object sender, EventArgs e)
    {
        // Check if a category was selected
        if (categoriesListAssign.SelectedIndex != -1)
        {
            // Get the category ID that was selected in the DropDownList
            string categoryId = categoriesListAssign.SelectedItem.Value;
            // Assign the product to the category
            bool success = CatalogAccess.AssignProductToCategory(currentProductId, categoryId);
            // Display status message
            statusLabel.Text = success ? "Успешно добавяне" : "Неуспешно добавяне";
            // Refresh the page
            PopulateControls();
        }
        else
        {
            statusLabel.Text = "Трябва да изберете категория";
        }
    }

    protected void moveButton_Click(object sender, EventArgs e)
    {
        // Check if a category was selected
        if (categoriesListMove.SelectedIndex != -1)
        {
            // Get the category ID that was selected in the DropDownList
            string newCategoryId = categoriesListMove.SelectedItem.Value;
            // Move the product to the category
            bool success = CatalogAccess.MoveProductToCategory(currentProductId, currentCategoryId, newCategoryId);
            // If the operation was successful, reload the page,
            // so the new category will reflect in the query string
            if (!success)
            {
                statusLabel.Text = "Неуспешно преместване на продукт към дадената категория";

            }
            else
            {
                Response.Redirect("AdminProductDetails.aspx" +
                "?DepartmentID=" + currentDepartmentId +
                "&CategoryID=" + newCategoryId +
                "&ProductID=" + currentProductId);
            }
        }
        else
        {
            statusLabel.Text = "Трябва да изберете категория";
        }

    }

    protected void upload1Button_Click(object sender, EventArgs e)
    {
        // proceed with uploading only if the user selected a file
        if (image1FileUpload.HasFile)
        {
            try
            {
                string fileName = image1FileUpload.FileName;
                string location = Server.MapPath("./ProductImages/") + fileName;
                // save image to server
                image1FileUpload.SaveAs(location);
                // update database with new product details
                ECommerce.CdShop.Entity.Product pd = CatalogAccess.GetProductDetails(currentProductId);
                CatalogAccess.UpdateProduct(currentProductId, pd.Name,
               pd.Description, pd.Price.ToString(), fileName, pd.Image, pd.PromoDept.ToString(), pd.PromoFront.ToString());
                // reload the page
                String url = "AdminProductDetails.aspx?DepartmentID=" + currentDepartmentId +
                "&CategoryID=" + currentCategoryId +
                "&ProductID=" + currentProductId;
                Response.Redirect(url);
            }
            catch
            {
                statusLabel.Text = "Неуспешно качване на изображение 1";
            }
        }
    }

    protected void upload2Button_Click(object sender, EventArgs e)
    {
        // proceed with uploading only if the user selected a file
        if (image2FileUpload.HasFile)
        {
            try
            {
                string fileName = image2FileUpload.FileName;
                string location = Server.MapPath("./ProductImages/") + fileName;
                // save image to server
                image2FileUpload.SaveAs(location);
                // update database with new product details
                ECommerce.CdShop.Entity.Product pd = CatalogAccess.GetProductDetails(currentProductId);
                CatalogAccess.UpdateProduct(currentProductId, pd.Name,
pd.Description, pd.Price.ToString(), pd.Thumbnail, fileName,
pd.PromoDept.ToString(), pd.PromoFront.ToString());
                // reload the page
                Response.Redirect("AdminProductDetails.aspx" +
                "?DepartmentID=" + currentDepartmentId +
                "&CategoryID=" + currentCategoryId +
                "&ProductID=" + currentProductId);
            }
            catch
            {
                statusLabel.Text = "Неуспешно качване на изображение 2";
            }
        }
    }
}
