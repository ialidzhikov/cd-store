using System;
using System.Data;

namespace ECommerce.CdShop.Entity
{
    /// <summary>
    /// OrderDetail entity
    /// </summary>
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitCost { get; set; }
        public string ItemAsString { get; set; }

        public double Subtotal
        {
            get
            {
                return Quantity * UnitCost;
            }
        }

        public OrderDetail(DataRow orderDetailRow)
        {
            OrderId = Int32.Parse(orderDetailRow["OrderId"].ToString());
            ProductId = Int32.Parse(orderDetailRow["ProductId"].ToString());
            ProductName = orderDetailRow["ProductName"].ToString();
            Quantity = Int32.Parse(orderDetailRow["Quantity"].ToString());
            UnitCost = Double.Parse(orderDetailRow["UnitCost"].ToString());
            // set info property
            Refresh();
        }

        public void Refresh()
        {
            ItemAsString = Quantity.ToString() + " " + ProductName + ", $" +
           UnitCost.ToString() + " each, total cost $" + Subtotal.ToString();
        }
    }
}