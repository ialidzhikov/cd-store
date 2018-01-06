namespace ECommerce.CdShop.Entity
{
    /// <summary>
    /// Category entity
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
