namespace ECommerce.CdShop.Entity
{
    using System;
    using System.Data;

    /// <summary>
    /// Audit entity
    /// </summary>
    public class Audit
    {
        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public DateTime DateStamp { get; private set; }
        public string Message { get; private set; }
        public int MessageNumber { get; private set; }

        public Audit(DataRow row)
        {
            Id = (int) row["Id"];
            OrderId = (int)row["OrderId"];
            DateStamp = (DateTime)row["DateStamp"];
            Message = row["Message"] as string;
            MessageNumber = (int) row["messageNumber"];
        }
    }
}