using ECommerce.CdShop.Dao;
using ECommerce.CdShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminCategories : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Load the grid only the first time the page is loaded
        if (!Page.IsPostBack)
        {
            // Load the categories grid
            BindGrid();
            // Get DepartmentID from the query string
            string departmentId = Request.QueryString["DepartmentID"];
            // Obtain the department's name
            DepartmentDao dao = new DepartmentDao();
            Department department = dao.Find(departmentId);
            string departmentName = department.Name + "</b>";
            // Link to department
            deptLink.Text = departmentName;
            deptLink.NavigateUrl = "AdminDepartments.aspx";
        }
    }

    // Populate the GridView with data
    private void BindGrid()
    {
        // Get DepartmentID from the query string
        string departmentId = Request.QueryString["DepartmentID"];
        // Get a DataTable object containing the categories
        grid.DataSource = CatalogAccess.GetCategoriesInDepartment(departmentId);
        // Bind the data grid to the data source
        grid.DataBind();
    }

    // Enter row into edit mode
    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set the row for which to enable edit mode
        grid.EditIndex = e.NewEditIndex;
        // Set status message
        statusLabel.Text = "Editing row # " + e.NewEditIndex.ToString();
        // Reload the grid
        BindGrid();
    }

    // Cancel edit mode
    protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        // Cancel edit mode
        grid.EditIndex = -1;
        // Set status message
        statusLabel.Text = "Отказано редактиране";
        // Reload the grid
        BindGrid();
    }

    // Update row
    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Retrieve updated data
        string id = grid.DataKeys[e.RowIndex].Value.ToString();
        string name = ((TextBox)grid.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
        string description = ((TextBox)grid.Rows[e.RowIndex].FindControl("descriptionTextBox")).Text;
        // Execute the update command
        bool success = CatalogAccess.UpdateCategory(id, name, description);
        // Cancel edit mode
        grid.EditIndex = -1;
        // Display status message
        statusLabel.Text = success ? "Успешно обновяване" : "Неуспешно обновяване";
        // Reload the grid
        BindGrid();
    }

    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = grid.DataKeys[e.RowIndex].Value.ToString();
        bool success = CatalogAccess.DeleteCategory(id);
        
        grid.EditIndex = -1;
        statusLabel.Text = success ? "Успешно изтриване" : "Неуспешно изтриване";
        
        BindGrid();
    }

    // Create a new category
    protected void createCategory_Click(object sender, EventArgs e)
    {
        string departmentId = Request.QueryString["DepartmentID"];
        bool success = CatalogAccess.CreateCategory(departmentId, newName.Text, newDescription.Text);
        statusLabel.Text = success ? "Успешно създаване" : "Неуспешно създаване";

        BindGrid();
    }
}
