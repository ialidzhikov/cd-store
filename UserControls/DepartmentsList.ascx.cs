using ECommerce.CdShop.Dao;
using System;
using System.Web.UI;

public partial class UserControls_DepartmentsList : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DepartmentDao dao = new DepartmentDao();
            list.DataSource = dao.GetAll();
            list.DataBind();
        }
    }
}
