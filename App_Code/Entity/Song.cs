namespace ECommerce.CdShop.Entity
{
    /// <summary>
    /// Song entity
    /// </summary>
    public class Song
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public string Duration { get; set; }
    }
}
