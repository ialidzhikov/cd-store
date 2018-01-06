namespace ECommerce.CdShop.Entity
{
    /// <summary>
    /// Order entity
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string DateCreated { get; set; }
        public string DateShipped { get; set; }
        public bool Verified { get; set; }
        public bool Completed { get; set; }
        public bool Canceled { get; set; }
        public string Comments { get; set; }
        public string CustomerName { get; set; }
        public string ShippingAddress { get; set; }
        public string CustomerEmail { get; set; }
    }
}
