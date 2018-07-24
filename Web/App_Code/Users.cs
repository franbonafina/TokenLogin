using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for Users
/// </summary>
public class Users
{
    public List<User> lstUsers = new List<User>();

    public void InitFromXml(string strPath)
    {
        try
        {
            XDocument xDoc = XDocument.Load(strPath);
            lstUsers = (from xUser in xDoc.Descendants("User")
                        select new User
                        {
                            Name = xUser.Attribute("Name").Value,
                            Password = xUser.Attribute("Password").Value,
                            CountryIds = (from xCountry in xUser.Descendants("Country") select Int32.Parse(xCountry.Attribute("id").Value)).ToList(),
                            BgSetIds = (from xBgSet in xUser.Descendants("BgSet") select Int32.Parse(xBgSet.Attribute("id").Value)).ToList()
                        }).ToList();
        }
        catch (Exception ex)
        {
            ;
        }
    }

    public bool Authorize(string strUser, string strPwd, out User user)
    {
        bool bResult = false;        
        user = (from u in lstUsers where u.Name == strUser && u.Password == strPwd select u).FirstOrDefault();
        bResult = (user != null);
        return bResult;
    }
}


public class User
{
    public string Name = "";
    public string Password = "";
    public List<int> CountryIds = new List<int>();
    public List<int> BgSetIds = new List<int>();
}

