using ECommerce.CdShop.Dao;
using ECommerce.CdShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminProducts : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Load the grid only the first time the page is loaded
        if (!Page.IsPostBack)
        {
            // Get CategoryID and DepartmentID from the query string
            string categoryId = Request.QueryString["CategoryID"];
            string departmentId = Request.QueryString["DepartmentID"];
            // Obtain the category name
            CategoryDao dao = new CategoryDao();
            ECommerce.CdShop.Entity.Category cd = dao.Find(categoryId);
            string categoryName = cd.Name;
            // Link to department
            catLink.Text = categoryName;
            catLink.NavigateUrl = "AdminCategories.aspx?DepartmentID=" + departmentId;
            // Load the products grid
            BindGrid();
        }
    }

    // Populate the GridView with data
    private void BindGrid()
    {
        // Get CategoryID from the query string
        string categoryId = Request.QueryString["CategoryID"];
        // Get a DataTable object containing the products
        grid.DataSource = CatalogAccess.GetAllProductsInCategory(categoryId);
        // Needed to bind the data bound controls to the data source
        grid.DataBind();
    }

    // Enter row into edit mode
    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set the row for which to enable edit mode
        grid.EditIndex = e.NewEditIndex;
        // Set status message
        statusLabel.Text = "Редактиране на ред # " + e.NewEditIndex.ToString();
        // Reload the grid
        BindGrid();
    }

    protected void grid_RowCancelingEdit(object sender,
    GridViewCancelEditEventArgs e)
    {
        // Cancel edit mode
        grid.EditIndex = -1;
        // Set status message
        statusLabel.Text = "Отказано редактиране";
        // Reload the grid
        BindGrid();
    }

    // Update a product
    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string id = grid.DataKeys[e.RowIndex].Value.ToString();
            string name = ((TextBox)grid.Rows[e.RowIndex].FindControl("nameTextBox")).Text;
            string description = ((TextBox)grid.Rows[e.RowIndex].FindControl("descriptionTextBox")).Text;
            string price = ((TextBox)grid.Rows[e.RowIndex].FindControl("priceTextBox")).Text;
            string thumbnail = ((TextBox)grid.Rows[e.RowIndex].FindControl("thumbTextBox")).Text;
            string image = ((TextBox)grid.Rows[e.RowIndex].FindControl("imageTextBox")).Text;
            string promoDept = ((CheckBox)grid.Rows[e.RowIndex].Cells[6].Controls[0]).Checked.ToString();
            string promoFront = ((CheckBox)grid.Rows[e.RowIndex].Cells[7].Controls[0]).Checked.ToString();

            bool success = CatalogAccess.UpdateProduct(id, name, description, price, thumbnail, image, promoDept, promoFront);
            // Cancel edit mode
            grid.EditIndex = -1;
            
            statusLabel.Text = success ? "Успешно обновяване на продукт" : "Неуспешно обновяване на продукт";
        }
        catch
        {
            // Display error
            statusLabel.Text = "Неуспешно обновяване на продукт";
        }
        // Reload grid
        BindGrid();
    }
    // Create a new product
    protected void createProduct_Click(object sender, EventArgs e)
    {
        // Get CategoryID from the query string
        string categoryId = Request.QueryString["CategoryID"];
        // Execute the insert command
        bool success = CatalogAccess.CreateProduct(categoryId, newName.Text, newDescription.Text, newPrice.Text, newThumbnail.Text, newImage.Text,
newPromoDept.Checked.ToString(), newPromoFront.Checked.ToString());
        // Display status message
        statusLabel.Text = success ? "Успешно създаване" : "Неуспешно създаване";
        // Reload the grid
        BindGrid();
    }
}
