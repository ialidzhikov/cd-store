namespace ECommerce.CdShop.Dao
{
    using ECommerce.CdShop.Entity;
    using System.Data;

    /// <summary>
    /// Summary description for CategoryDao
    /// </summary>
    public class CategoryDao : AbstractDao<Category>
    {
        protected override Category FromDataRow(DataRow row)
        {
            return new Category
            {
                Id = int.Parse(row["Id"].ToString()),
                DepartmentId = int.Parse(row["DepartmentId"].ToString()),
                Name = row["Name"].ToString(),
                Description = row["Description"].ToString(),
            };
        }
    }
}
