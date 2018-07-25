using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
/// <summary>
/// Summary description for Extentions
/// </summary>
public static class HelperExtenstions
{
	
    /// <summary>
    /// Grid Default Sort Experssion
    /// </summary>
    /// <param name="_gridview">Current Gridview</param>
    /// <param name="DefaultExperssion">Default Sort Expression</param>
    /// <returns>Gives an expression that contins sort expression and sort direction</returns>
    public static string GetSortOrder(this System.Web.UI.WebControls.GridView _gridview, string DefaultExperssion)
    {
        if (_gridview.Attributes["SortExpression"] == null) _gridview.Attributes["SortExpression"] = DefaultExperssion;
        if (_gridview.Attributes["SortDirection"] == null) _gridview.Attributes["SortDirection"] = "DESC";
        return string.Format("{0} {1}", _gridview.Attributes["SortExpression"], _gridview.Attributes["SortDirection"]);
    }

    /// <summary>
    /// Cusotme Defined GridView Sort
    /// </summary>
    /// <param name="_gridview">Current GrieView</param>
    /// <param name="Experssion">An Sortexpression to sort</param>
    public static void Sort(this System.Web.UI.WebControls.GridView _gridview, string Experssion)
    {
        String sortExpression = Experssion;
        String sortDirection = string.Empty;
        //======================checking the sort order==============================
        if (sortExpression.Equals(_gridview.Attributes["SortExpression"].ToString()))
            sortDirection = (_gridview.Attributes["SortDirection"].ToString().StartsWith("ASC")) ? "DESC" : "ASC";
        if (sortDirection == string.Empty) sortDirection = "ASC";
        //======================end of checking sort order===========================
        _gridview.Attributes["SortExpression"] = sortExpression;
        _gridview.Attributes["SortDirection"] = sortDirection;

        //return string.Format(BPGConstants.FormatSortExpression, _gridview.Attributes[BPGConstants.SortExpression], _gridview.Attributes[BPGConstants.SortDirection]);
        _gridview.DataBind();
    }

    /// <summary>
    /// GrieView SortExpression and SortDirection
    /// </summary>
    /// <param name="_gridview">Current Gridview</param>
    /// <param name="Experssion">An expression to set the SortExpression</param>
    /// <returns></returns>
    public static string SetSortOrder(this System.Web.UI.WebControls.GridView _gridview, string Experssion)
    {
        String sortExpression = Experssion;
        String sortDirection = string.Empty;
        //======================checking the sort order==============================
        if (sortExpression.Equals(_gridview.Attributes["SortExpression"].ToString()))
            sortDirection = (_gridview.Attributes["SortDirection"].ToString().StartsWith("ASC")) ? "DESC" : "ASC";
        if (sortDirection == string.Empty) sortDirection = "ASC";
        //======================end of checking sort order===========================
        _gridview.Attributes["SortExpression"] = sortExpression;
        _gridview.Attributes["SortDirection"] = sortDirection;

        return string.Format("{0} {1}", _gridview.Attributes["SortExpression"], _gridview.Attributes["SortDirection"]);
    }
}
