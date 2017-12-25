using System;
using System.Web.UI;

public partial class UserControls_CategoriesList : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string departmentId = Request.QueryString["DepartmentID"];
            if (departmentId != null)
            {
                list.DataSource = CatalogAccess.GetCategoriesInDepartment(departmentId);
                list.DataBind();
            }
        }
    }
}