using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strCmd = Request["cmd"] == null? "" : Request["cmd"].ToString();
        if (strCmd.ToLower() == "clearsession")
        {
            Utilities.SetAuthorizedUser(null);
        }
        else if (Utilities.GetAuthorizedUser() != null)
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string strPath = Request.PhysicalApplicationPath;
        strPath += "App_Data\\Users.xml";

        Users users = new Users();
        users.InitFromXml(strPath);

        User authUser = null;

        if (users.Authorize(txtUser.Text, txtPwd.Text, out authUser))
        {
            Utilities.SetAuthorizedUser(authUser);
            Session["authorized"] = null;
            Session["countryid"] = null;

            Response.Redirect("Default.aspx");
        }
        else{
            Utilities.SetAuthorizedUser(null);
            lblErrText.Text = "Invalid credentials! Logon failed.";
        }
    }
}