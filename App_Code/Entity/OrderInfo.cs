using ECommerce.CdShop.Entity;
using ECommerce.CdShop.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for OrderInfo
/// </summary>
public class OrderInfo
{
    public int OrderId { get; set; }
    public string DateCreated { get; set; }
    public string DateShipped { get; set; }
    public string Comments { get; set; }
    public int Status { get; set; }
    public string AuthCode { get; set; }
    public string Reference { get; set; }
    public MembershipUser Customer { get; set; }
    public ProfileCommon CustomerProfile { get; set; }
    public SecureCard CreditCard { get; set; }
    public double TotalCost { get; set; }
    public string OrderAsString { get; set; }
    public string CustomerAddressAsString { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
    public Shipping Shipping { get; set; }
    public Tax Tax { get; set; }
    private List<Audit> auditTrail;

    public OrderInfo(DataRow row)
    {
        OrderId = Int32.Parse(row["Id"].ToString());
        DateCreated = row["DateCreated"].ToString();
        DateShipped = row["DateShipped"].ToString();
        Comments = row["Comments"].ToString();
        Status = Int32.Parse(row["Status"].ToString());
        AuthCode = row["AuthCode"].ToString();
        Reference = row["Reference"].ToString();
        Customer = Membership.GetUser(
        new Guid(row["CustomerId"].ToString()));
        CustomerProfile = (HttpContext.Current.Profile as ProfileCommon).GetProfile(Customer.UserName);
        CreditCard = new SecureCard(CustomerProfile.CreditCard);
        OrderDetails = CommerceLibAccess.GetOrderDetails(row["Id"].ToString());

        // Get Shipping Data
        Shipping = new Shipping();
        if (row["ShippingId"] != DBNull.Value
            && row["ShippingType"] != DBNull.Value
            && row["ShippingCost"] != DBNull.Value)
        {
            Shipping.Id = Int32.Parse(row["ShippingId"].ToString());
            Shipping.ShippingType = row["ShippingType"].ToString();
            Shipping.ShippingCost = double.Parse(row["ShippingCost"].ToString());
        }
        else
        {
            Shipping.Id = -1;
        }


        // Get Tax Data
        Tax = new Tax();
        if (row["TaxId"] != DBNull.Value
        && row["TaxType"] != DBNull.Value
        && row["TaxPercentage"] != DBNull.Value)
        {
            Tax.Id = Int32.Parse(row["TaxId"].ToString());
            Tax.TaxType = row["TaxType"].ToString();
            Tax.TaxPercentage =
            double.Parse(row["TaxPercentage"].ToString());
        }
        else
        {
            Tax.Id = -1;
        }
        // set info properties
        Refresh();
    }

    public void Refresh()
    {
        // calculate total cost and set data
        StringBuilder sb = new StringBuilder();
        TotalCost = 0.0;
        foreach (OrderDetail item in OrderDetails)
        {
            sb.AppendLine(item.ItemAsString);
            TotalCost += item.Subtotal;
        }
        sb.AppendLine();
        // Add shipping cost
        if (Shipping.Id != -1)
        {
            sb.AppendLine("Shipping: " + Shipping.ShippingType);
            TotalCost += Shipping.ShippingCost;
        }
        // Add tax
        if (Tax.Id != -1 && Tax.TaxPercentage != 0.0)
        {
            double taxAmount = Math.Round(TotalCost * Tax.TaxPercentage,
            MidpointRounding.AwayFromZero) / 100.0;
            sb.AppendLine("Tax: " + Tax.TaxType + ", $"
            + taxAmount.ToString());
            TotalCost += taxAmount;
        }
        sb.AppendLine();
        sb.Append("Total order cost: $");
        sb.Append(TotalCost.ToString());
        OrderAsString = sb.ToString();
        // get customer address string
        sb = new StringBuilder();
        sb.AppendLine(Customer.UserName);
        sb.AppendLine(CustomerProfile.Address1);
        if (CustomerProfile.Address2 != "")
        {
            sb.AppendLine(CustomerProfile.Address2);
        }
        sb.AppendLine(CustomerProfile.City);
        sb.AppendLine(CustomerProfile.Region);
        sb.AppendLine(CustomerProfile.PostalCode);
        sb.AppendLine(CustomerProfile.Country);
        CustomerAddressAsString = sb.ToString();
    }

    public string StatusAsString
    {
        get
        {
            try
            {
                return CommerceLibAccess.OrderStatuses[Status];
            }
            catch
            {
                return "Status unknown";
            }
        }
    }
    public string CustomerName
    {
        get
        {
            return Customer.UserName;
        }
    }

    public List<Audit> AuditTrail
    {
        get
        {
            if (auditTrail == null)
            {
                auditTrail = CommerceLibAccess.GetOrderAuditTrail(OrderId.ToString());
            }

            return auditTrail;
        }
    }

    public void UpdateStatus(int status)
    {
        // call static method
        CommerceLibAccess.UpdateOrderStatus(OrderId, status);
        // update field
        Status = status;
    }

    public void SetAuthCodeAndReference(string authCode, string reference)
    {
        // call static method
        CommerceLibAccess.SetOrderAuthCodeAndReference(OrderId,
        authCode, reference);
        // update fields
        AuthCode = authCode;
        Reference = reference;
    }

    public void SetDateShipped()
    {
        // call static method
        CommerceLibAccess.SetOrderDateShipped(OrderId);
        // update field
        DateShipped = DateTime.Now.ToString();
    }
}