using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Configuration;


/// <summary>
/// Summary description for Utilities
/// </summary>
public class Utilities
{
    public static string strPhysicalPath = "";
    public static string strVirtualPath = "";
     

    public Utilities()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GetConfigValue(string strKey)
    {
        string strValue = "";

        Configuration rootWebConfig =
                WebConfigurationManager.OpenWebConfiguration(strVirtualPath);

        KeyValueConfigurationElement customSetting =
            rootWebConfig.AppSettings.Settings[strKey];

        if (customSetting != null)
        {
            strValue = customSetting.Value;
        }

        return strValue;
    }

    public static bool IsTextValid(string strText, out char invalidChar)
    {
        bool bResult = true;
        invalidChar = ' ';

        foreach (char c in strText)
        {            
            if (c > 255 || c == '|' || c == '\v' || c == '\t' || c == '\b' || c == '\f' || c == '\a')
            {
                bResult = false;
                invalidChar = c;
                break;
            }
        }

        return bResult;
    }

    public static User GetAuthorizedUser()
    {
        return HttpContext.Current.Session["AuthorizedUser"] as User;
    }

    public static void SetAuthorizedUser(User user)
    {
        HttpContext.Current.Session["AuthorizedUser"] = user;
    }

}
