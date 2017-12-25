using System;
using System.Web.UI;

public partial class UserControls_SearchBox : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // don't repopulate control on postbacks
        if (!IsPostBack)
        {
            // load search box controls' values
            string allWords = Request.QueryString["AllWords"];
            string searchString = Request.QueryString["Search"];
            if (allWords != null)
                allWordsCheckBox.Checked = (allWords.ToUpper() == "TRUE");
            if (searchString != null)
                searchTextBox.Text = searchString;
        }
    }

    // Perform the product search
    protected void goButton_Click(object sender, EventArgs e)
    {
        ExecuteSearch();
    }
    // Redirect to the search results page
    private void ExecuteSearch()
    {
        string searchText = searchTextBox.Text;
        bool allWords = allWordsCheckBox.Checked;
        if (searchTextBox.Text.Trim() != "")
            Response.Redirect(Link.ToSearch(searchText, allWords, "1"));
    }
}