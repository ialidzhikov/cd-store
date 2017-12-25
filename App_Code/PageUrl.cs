using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PageUrl
/// </summary>
public class PageUrl
{
    private readonly string page;
    private readonly string url;

    public PageUrl(string page, string url)
    {
        this.page = page;
        this.url = url;
    }

    public string Page
    {
        get
        {
            return page;
        }
    }

    public string Url
    {
        get
        {
            return url;
        }
    }
}
