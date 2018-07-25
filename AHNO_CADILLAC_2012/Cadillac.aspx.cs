using System;

public partial class Cadillac : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["cid"] != null && Request["cid"].ToString() != "")
            {
                ltrlFlash.Text = "<script type=\"text/JavaScript\">" +
                                 "var so = new SWFObject(\"cadillacContainer.swf\", \"Cadillac\", \"816\", \"510\", \"8\", \"black\");" +
                                 "so.addParam(\"wmode\", \"transparent\");" +
                                 "so.addVariable(\"couponId\", \"" + Request["cid"].ToString() + "\");" +
                                 "so.write(\"flashDiv\");" +
                                 "</script>";
            }
            else
            {
                ltrlFlash.Text = "<script type=\"text/JavaScript\">" +
                                "var so = new SWFObject(\"cadillacContainer.swf\", \"Cadillac\", \"816\", \"510\", \"8\", \"black\");" +
                                "so.addParam(\"wmode\", \"transparent\");" +
                                "so.write(\"flashDiv\");" +
                                "</script>";
            }
        }
    }
}