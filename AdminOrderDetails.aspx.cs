﻿using CommerceLib;
using ECommerce.CdShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminOrderDetails : Page
{
    // set up the form
    protected void Page_Load(object sender, EventArgs e)
    {
        // check if we must display order details
        if (!Page.IsPostBack && Request.QueryString["OrderID"] != null)
        {
            string orderId = Request.QueryString["OrderID"];
            // fill constituent controls with data
            PopulateControls(orderId);
            // set edit mode
            SetEditMode(false);
        }
    }

    // populate the form with data
    private void PopulateControls(string orderId)
    {
        // obtain order info
        OrderInfo orderInfo = CommerceLibAccess.GetOrder(orderId);
        // populate labels and text boxes with order info
        orderIdLabel.Text = "Поръчка #" + orderId;
        totalAmountLabel.Text = String.Format("{0:c} ", orderInfo.TotalCost);
        dateCreatedTextBox.Text = orderInfo.DateCreated.ToString();
        dateShippedTextBox.Text = orderInfo.DateShipped.ToString();
        statusDropDown.SelectedIndex = orderInfo.Status;
        authCodeTextBox.Text = orderInfo.AuthCode;
        referenceTextBox.Text = orderInfo.Reference;
        commentsTextBox.Text = orderInfo.Comments;
        customerNameTextBox.Text = orderInfo.CustomerName;
        shippingAddressTextBox.Text = orderInfo.CustomerAddressAsString;
        shippingTypeTextBox.Text = orderInfo.Shipping.ShippingType;
        customerEmailTextBox.Text = orderInfo.Customer.Email;
        // Decide which one of the buttons should
        // be enabled and which should be disabled
        switch (orderInfo.Status)
        {
            case 8:
            case 9:
                // if the order was canceled or completed...
                processOrderButton.Text = "Обработи поръчката";
                processOrderButton.Enabled = false;
                cancelOrderButton.Enabled = false;
                break;
            case 3:
                // if the order is awaiting a stock check...
                processOrderButton.Text = "Потвърди наличност за поръчката";
                processOrderButton.Enabled = true;
                cancelOrderButton.Enabled = true;
                break;
            case 6:
                // if the order is awaiting shipment...
                processOrderButton.Text = "Потвърди доставката на поръчката";
                processOrderButton.Enabled = true;
                cancelOrderButton.Enabled = true;
                break;
            default:
                // otherwise...
                processOrderButton.Text = "Обработи поръчката";
                processOrderButton.Enabled = true;
                cancelOrderButton.Enabled = true;
                break;
        }
        // fill the data grid with order details
        grid.DataSource = orderInfo.OrderDetails;
        grid.DataBind();
        // fill the audit data grid with audit trail
        auditGrid.DataSource = orderInfo.AuditTrail;
        auditGrid.DataBind();

        // show status items
        statusDropDown.Items.Clear();
        for (int i = 0; i < CommerceLibAccess.OrderStatuses.Length; i++)
        {
            statusDropDown.Items.Add(
            new ListItem(CommerceLibAccess.OrderStatuses[i], i.ToString()));
        }
        statusDropDown.SelectedIndex = orderInfo.Status;
    }

    // enable or disable edit mode
    private void SetEditMode(bool enable)
    {
        dateShippedTextBox.Enabled = enable;
        statusDropDown.Enabled = enable;
        authCodeTextBox.Enabled = enable;
        referenceTextBox.Enabled = enable;
        commentsTextBox.Enabled = enable;
        editButton.Enabled = !enable;
        updateButton.Enabled = enable;
        cancelButton.Enabled = enable;
    }

    // enter edit mode
    protected void editButton_Click(object sender, EventArgs e)
    {
        string orderId = Request.QueryString["OrderID"];
        PopulateControls(orderId);
        SetEditMode(true);
    }

    // cancel edit mode
    protected void cancelButton_Click(object sender, EventArgs e)
    {
        string orderId = Request.QueryString["OrderID"];
        PopulateControls(orderId);
        SetEditMode(false);
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        int orderId = int.Parse(Request.QueryString["OrderID"]);
        try
        {
            // Get new order data
            string dateCreated = dateCreatedTextBox.Text;
            string dateShipped = dateShippedTextBox.Text;
            int status = int.Parse(statusDropDown.SelectedValue);
            string authCode = authCodeTextBox.Text;
            string reference = referenceTextBox.Text;
            string comments = commentsTextBox.Text;
            // Update the order
            CommerceLibAccess.UpdateOrder(orderId, dateCreated,
            dateShipped, status, authCode, reference, comments);
        }
        catch
        {
            // In case of an error, we simply ignore it
        }
        // Exit edit mode and populate the form again
        SetEditMode(false);
        PopulateControls(orderId.ToString());
    }

    // mark order as verified
    protected void markVerifiedButton_Click(object sender, EventArgs e)
    {
        // obtain the order ID from the query string
        string orderId = Request.QueryString["OrderID"];
        // mark order as verified
        OrderDao.MarkVerified(orderId);
        // update the form
        PopulateControls(orderId);
    }

    // mark order as completed
    protected void markCompletedButton_Click(object sender, EventArgs e)
    {
        // obtain the order ID from the query string
        string orderId = Request.QueryString["OrderID"];
        // mark the order as completed
        OrderDao.MarkCompleted(orderId);
        // update the form
        PopulateControls(orderId);
    }

    // mark order as canceled
    protected void markCanceledButton_Click(object sender, EventArgs e)
    {
        // obtain the order ID from the query string
        string orderId = Request.QueryString["OrderID"];
        // mark the order as canceled
        OrderDao.MarkCanceled(orderId);
        // update the form
        PopulateControls(orderId);
    }

    protected void processOrderButton_Click(object sender, EventArgs e)
    {
        string orderId = Request.QueryString["OrderID"];
        OrderProcessor processor = new OrderProcessor(orderId);
        processor.Process();
        PopulateControls(orderId);
    }

    // cancel order
    protected void cancelOrderButton_Click(object sender, EventArgs e)
    {
        string orderId = Request.QueryString["OrderID"];
        CommerceLibAccess.UpdateOrderStatus(int.Parse(orderId), 9);
        PopulateControls(orderId);
    }
    
}