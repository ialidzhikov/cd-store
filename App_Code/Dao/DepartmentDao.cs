namespace ECommerce.CdShop.Dao
{
    using System.Data;
    using ECommerce.CdShop.Entity;

    /// <summary>
    /// Database access object for Department
    /// </summary>
    public class DepartmentDao : AbstractDao<Department>
    {
        protected override Department FromDataRow(DataRow row)
        {
            return new Department
            {
                Id = int.Parse(row["Id"].ToString()),
                Name = row["Name"].ToString(),
                Description = row["Description"].ToString(),
            };
        }
    }
}
