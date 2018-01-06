using System;
using System.Web;

/// <summary>
/// Link factory class
/// </summary>
public class Link
{
    // Builds an absolute URL
    private static string BuildAbsolute(string relativeUri)
    {
        Uri uri = HttpContext.Current.Request.Url;
        string app = HttpContext.Current.Request.ApplicationPath;
        if (!app.EndsWith("/"))
        {
            app += "/";
        }

        relativeUri = relativeUri.TrimStart('/');
        string path = String.Format("http://{0}:{1}{2}{3}", uri.Host, uri.Port, app, relativeUri);
        return HttpUtility.UrlPathEncode(path);
    }

    // Generate a department URL
    public static string ToDepartment(string departmentId, string page)
    {
        if (page == "1")
        {
            return BuildAbsolute(String.Format("Catalog.aspx?DepartmentID={0}", departmentId));
        }
        else
        {
            return BuildAbsolute(String.Format("Catalog.aspx?DepartmentID={0}&Page ={1}", departmentId, page));
        }
    }

    public static string ToDepartment(string departmentId)
    {
        return ToDepartment(departmentId, "1");
    }

    public static string ToCategory(string departmentId, string categoryId, string page)
    {
        if (page == "1")
        {
            string relative = String.Format("Catalog.aspx?DepartmentID={0}&CategoryID={1}", departmentId, categoryId);
            return BuildAbsolute(relative);
        }
        else
        {
            string relative = String.Format("Catalog.aspx?DepartmentID={0}&CategoryID={1}&Page={2}", departmentId, categoryId, page);
            return BuildAbsolute(relative);
        }
    }

    public static string ToCategory(string departmentId, string categoryId)
    {
        return ToCategory(departmentId, categoryId, "1");
    }

    public static string ToProduct(string productId)
    {
        return BuildAbsolute(String.Format("Product.aspx?ProductID={0}", productId));
    }

    public static string ToProductImage(string fileName)
    {
        return BuildAbsolute("/ProductImages/" + fileName);
    }

    public static string ToSearch(string searchString, bool allWords, string page)
    {
        if (page == "1")
        {
            return BuildAbsolute(
            String.Format("/Search.aspx?Search={0}&AllWords={1}", searchString, allWords.ToString()));

        }
        else
        {
            return BuildAbsolute(String.Format("/Search.aspx?Search={0}&AllWords={1}&Page={2}", searchString, allWords.ToString(), page));
        }
    }

    public static string ToPayPalViewCart()
    {
        string path = String.Format("{0}&business={1}&return={2}&cancel_return={3}&display=1",
                                    CdShopConfiguration.PaypalUrl, CdShopConfiguration.PaypalEmail,
                                    CdShopConfiguration.PaypalReturnUrl, CdShopConfiguration.PaypalCancelUrl);
        return HttpUtility.UrlPathEncode(path);
    }

    public static string ToPayPalAddItem(string productUrl, string productName, decimal productPrice, string productOptions)
    {
        string path = String.Format("{0}&business={1}&return={2}&cancel_return={3}&shopping_url={4}&item_name={5}&amount={6:0.00}&currency={7}&on0=Options&os0={8}&add=1",
                                    CdShopConfiguration.PaypalUrl, CdShopConfiguration.PaypalEmail, CdShopConfiguration.PaypalReturnUrl, CdShopConfiguration.PaypalCancelUrl,
                                    productUrl, productName, productPrice, CdShopConfiguration.PaypalCurrency, productOptions);
        return HttpUtility.UrlPathEncode(path);
    }

    public static string ToPayPalCheckout(string orderName, decimal orderAmount)
    {
        return HttpUtility.UrlPathEncode(String.Format("{0}/business={1}&item_name={2}&amount={3:0.00}&currency={4}&return={5}&cancel_return={6}",
            CdShopConfiguration.PaypalUrl, CdShopConfiguration.PaypalEmail, orderName, orderAmount,
            CdShopConfiguration.PaypalCurrency, CdShopConfiguration.PaypalReturnUrl, CdShopConfiguration.PaypalCancelUrl));
    }
}
