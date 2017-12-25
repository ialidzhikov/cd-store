using ECommerce.CdShop.Dao;
using ECommerce.CdShop.Entity;
using System;
using System.Web;
using System.Web.UI;

public partial class UserControls_Catalog : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateControls();
        }
    }

    private void PopulateControls()
    {
        string departmentId = Request.QueryString["DepartmentID"];
        string categoryId = Request.QueryString["CategoryID"];
        if (categoryId != null)
        {
            // Retrieve category and department details and display them
            Category cd = CatalogAccess.GetCategoryDetails(categoryId);
            catalogTitleLabel.Text = HttpUtility.HtmlEncode(cd.Name);
            DepartmentDao dao = new DepartmentDao();
            Department department = dao.Find(departmentId);
            catalogDescriptionLabel.Text = HttpUtility.HtmlEncode(cd.Description);
            
            this.Title = HttpUtility.HtmlEncode(CdShopConfiguration.SiteName + ": " + department.Name + ": " + cd.Name);
        }
        else if (departmentId != null)
        {
            DepartmentDao dao = new DepartmentDao();
            Department department = dao.Find(departmentId);
            catalogTitleLabel.Text = HttpUtility.HtmlEncode(department.Name);
            catalogDescriptionLabel.Text = HttpUtility.HtmlEncode(department.Description);
            // Set the title of the page
            this.Title = HttpUtility.HtmlEncode(CdShopConfiguration.SiteName + ": " + department.Name);
        }
    }
}
