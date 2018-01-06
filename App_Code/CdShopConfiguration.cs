using System;
using System.Configuration;

/// <summary>
/// Repository for CdShop configuration settings
/// </summary>
public static class CdShopConfiguration
{
    private static string dbConnectionString;
    private static string dbProviderName;
    private readonly static int productsPerPage;
    private readonly static int productDescriptionLength;
    private readonly static string siteName;

    static CdShopConfiguration()
    {
        dbConnectionString = ConfigurationManager.ConnectionStrings["CdShopConnection"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["CdShopConnection"].ProviderName;
        productsPerPage = Int32.Parse(ConfigurationManager.AppSettings["ProductsPerPage"]);
        productDescriptionLength = Int32.Parse(ConfigurationManager.AppSettings["ProductDescriptionLength"]);
        siteName = ConfigurationManager.AppSettings["SiteName"];
    }

    // Returns the connection string for the BalloonShop database
    public static string DbConnectionString
    {
        get
        {
            return dbConnectionString;
        }
    }

    // Returns the data provider name
    public static string DbProviderName
    {
        get
        {
            return dbProviderName;
        }
    }
    // Returns the address of the mail server

    public static string MailServer
    {
        get
        {
            return ConfigurationManager.AppSettings["MailServer"];
        }
    }

    // Returns the email username
    public static string MailUsername
    {
        get
        {
            return ConfigurationManager.AppSettings["MailUsername"];
        }
    }
    
    // Returns the email password
    public static string MailPassword
    {
        get
        {
            return ConfigurationManager.AppSettings["MailPassword"];
        }
    }

    // Returns the email password
    public static string MailFrom
    {
        get
        {
            return ConfigurationManager.AppSettings["MailFrom"];
        }
    }

    // Send error log emails?
    public static bool EnableErrorLogEmail
    {
     get
        {
            return bool.Parse(ConfigurationManager.AppSettings["EnableErrorLogEmail"]);
        }
    }
    
    public static string ErrorLogEmail
    {
        get
        {
            return ConfigurationManager.AppSettings["ErrorLogEmail"];
        }
    }

    public static int ProductsPerPage
    {
        get
        {
            return productsPerPage;
        }
    }

    public static int ProductDescriptionLength
    {
        get
        {
            return productDescriptionLength;
        }
    }

    public static string SiteName
    {
        get
        {
            return siteName;
        }
    }

    public static string PaypalUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["PaypalUrl"];
        }
    }

    public static string PaypalEmail
    {
        get
        {
            return ConfigurationManager.AppSettings["PaypalEmail"];
        }
    }

    public static string PaypalCurrency
    {
        get
        {
            return ConfigurationManager.AppSettings["PaypalCurrency"];
        }
    }

    public static string PaypalReturnUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["PaypalReturnUrl"];
        }
    }

    public static string PaypalCancelUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["PaypalCancelUrl"];
        }
    }
   
    public static int CartPersistDays
    {
        get
        {
            return int.Parse(ConfigurationManager.AppSettings["CartPersistDays"]);
        }
    }

    // Returns the email address for customers to contact the site
    public static string CustomerServiceEmail
    {
        get
        {
            return
            ConfigurationManager.AppSettings["CustomerServiceEmail"];
        }
    }

    // The "from" address for auto-generated order processor emails
    public static string OrderProcessorEmail
    {
        get
        {
            return
            ConfigurationManager.AppSettings["OrderProcessorEmail"];
        }
    }

    // The email address to use to contact the supplier
    public static string SupplierEmail
    {
        get
        {
            return ConfigurationManager.AppSettings["SupplierEmail"];
        }
    }
}
