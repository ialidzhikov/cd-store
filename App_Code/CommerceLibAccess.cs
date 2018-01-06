using ECommerce.CdShop.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommerceLibAccess
/// </summary>
public class CommerceLibAccess
{
    public static readonly string[] OrderStatuses =
    {
        "Order placed, notifying customer", // 0
        "Awaiting confirmation of funds", // 1
        "Notifying supplier—stock check", // 2
        "Awaiting stock confirmation", // 3
        "Awaiting credit card payment", // 4
        "Notifying supplier—shipping", // 5
        "Awaiting shipment confirmation", // 6
        "Sending final notification", // 7
        "Order completed", // 8
        "Order canceled" // 9
    };

    public static List<OrderDetail> GetOrderDetails(string orderId)
    {
        // use existing method for DataTable
        DataTable orderDetailsData = OrderDao.GetDetails(orderId);
        // create List<>
        List<OrderDetail> orderDetails = new List<OrderDetail>(orderDetailsData.Rows.Count);
        foreach (DataRow orderDetail in orderDetailsData.Rows)
        {
            orderDetails.Add(
            new OrderDetail(orderDetail));
        }

        return orderDetails;
    }

    public static OrderInfo GetOrder(string orderId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CommerceLibOrderGetInfo";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderId";
        param.Value = orderId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // obtain the results
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        DataRow orderRow = table.Rows[0];
        // save the results into an CommerceLibOrderInfo object
        OrderInfo orderInfo = new OrderInfo(orderRow);
        return orderInfo;
    }

    public static List<Shipping> GetShippingInfo(int shippingRegionId)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CommerceLibShippingGetInfo";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Id";
        param.Value = shippingRegionId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // obtain the results
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        List<Shipping> result = new List<Shipping>();
        foreach (DataRow row in table.Rows)
        {
            Shipping rowData = new Shipping();
            rowData.Id = int.Parse(row["Id"].ToString());
            rowData.ShippingType = row["ShippingType"].ToString();
            rowData.ShippingCost =
            double.Parse(row["ShippingCost"].ToString());
            rowData.ShippingRegionId = shippingRegionId;
            result.Add(rowData);
        }
        return result;
    }

    public static void CreateAudit(int orderID, string message, int messageNumber)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CreateAudit";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderId";
        param.Value = orderID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Message";
        param.Value = message;
        param.DbType = DbType.String;
        param.Size = 512;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@MessageNumber";
        param.Value = messageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        GenericDataAccess.ExecuteNonQuery(comm);
    }

    public static void UpdateOrderStatus(int orderID, int status)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CommerceLibOrderUpdateStatus";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderId";
        param.Value = orderID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Status";
        param.Value = status;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        GenericDataAccess.ExecuteNonQuery(comm);
    }

    public static void SetOrderAuthCodeAndReference(int orderID, string authCode, string reference)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CommerceLibOrderSetAuthCode";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderId";
        param.Value = orderID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@AuthCode";
        param.Value = authCode;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Reference";
        param.Value = reference;
        param.DbType = DbType.String;
        param.Size = 50;
        comm.Parameters.Add(param);
        // execute the stored procedure
        GenericDataAccess.ExecuteNonQuery(comm);
    }

    public static void SetOrderDateShipped(int orderID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CommerceLibOrderSetDateShipped";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderId";
        param.Value = orderID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // execute the stored procedure
        GenericDataAccess.ExecuteNonQuery(comm);
    }

    public static List<Audit> GetOrderAuditTrail(string orderID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CommerceLibOrderGetAuditTrail";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderId";
        param.Value = orderID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // obtain the results
        DataTable orderAuditTrailData =
        GenericDataAccess.ExecuteSelectCommand(comm);
        // create List<>
        List<Audit> orderAuditTrail = new List<Audit>(orderAuditTrailData.Rows.Count);
        foreach (DataRow orderAudit in orderAuditTrailData.Rows)
        {
            orderAuditTrail.Add(new Audit(orderAudit));
        }

        return orderAuditTrail;
    }

    public static List<OrderInfo> ConvertDataTableToOrders(DataTable table)
    {
        List<OrderInfo> orders = new List<OrderInfo>(table.Rows.Count);
        foreach (DataRow orderRow in table.Rows)
        {
            try
            {
                // try to add order
                orders.Add(new OrderInfo(orderRow));
            }
            catch
            {
                // can't add this order
            }
        }
        return orders;
    }

    public static List<OrderInfo> GetOrdersByCustomer(string customerID)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CommerceLibOrdersGetByCustomer";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CustomerId";
        param.Value = new Guid(customerID);
        param.DbType = DbType.Guid;
        comm.Parameters.Add(param);
        // obtain the results
        return ConvertDataTableToOrders(GenericDataAccess.ExecuteSelectCommand(comm));
    }

    public static List<OrderInfo> GetOrdersByDate(string startDate, string endDate)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CommerceLibOrdersGetByDate";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@StartDate";
        param.Value = startDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@EndDate";
        param.Value = endDate;
        param.DbType = DbType.Date;
        comm.Parameters.Add(param);
        // obtain the results
        return ConvertDataTableToOrders(GenericDataAccess.ExecuteSelectCommand(comm));
    }

    public static List<OrderInfo> GetOrdersByRecent(int count)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CommerceLibOrdersGetByRecent";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Count";
        param.Value = count;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // obtain the results
        return ConvertDataTableToOrders(GenericDataAccess.ExecuteSelectCommand(comm));
    }

    public static List<OrderInfo> GetOrdersByStatus(int status)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CommerceLibOrdersGetByStatus";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@Status";
        param.Value = status;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // obtain the results
        return ConvertDataTableToOrders(GenericDataAccess.ExecuteSelectCommand(comm));
    }

    public static void UpdateOrder(int orderID,
                                   string newDateCreated, string newDateShipped,
                                   int newStatus, string newAuthCode, string newReference,
                                   string newComments)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CommerceLibOrderUpdate";
        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@OrderId";
        param.Value = orderID;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DateCreated";
        param.Value = DateTime.Parse(newDateCreated);
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
        // The DateShipped parameter is sent only if data is available
        if (newDateShipped != null && newDateShipped != "")
        {
            param = comm.CreateParameter();
            param.ParameterName = "@DateShipped";
            param.Value = DateTime.Parse(newDateShipped);
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);
        }
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Status";
        param.Value = newStatus;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@AuthCode";
        param.Value = newAuthCode;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Reference";
        param.Value = newReference;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@Comments";
        param.Value = newComments;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);
        // update the order
        GenericDataAccess.ExecuteNonQuery(comm);
    }
}
