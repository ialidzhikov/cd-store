namespace ECommerce.CdShop.Entity
{
    /// <summary>
    /// Tax entity
    /// </summary>
    public class Tax
    {
        public int Id { get; set; }
        public string TaxType { get; set; }
        public double TaxPercentage { get; set; }
    }
}