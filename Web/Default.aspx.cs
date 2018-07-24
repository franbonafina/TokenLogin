using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using Vc100PluginLib;
using System.IO;
using Microsoft.Win32;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;





public partial class _Default : System.Web.UI.Page
{
    public DataStorage ds = null;
    protected int nMenuItemCounter = 0;
    public enCustomerType type = enCustomerType.enPrepaid;



    protected string GetIPAddress()
    {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }

        return context.Request.ServerVariables["REMOTE_ADDR"];
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        Utilities.strVirtualPath = Request.ApplicationPath;
        Utilities.strPhysicalPath = Request.PhysicalApplicationPath;
       
        string strIpAddress = GetIPAddress();        


        ds = new DataStorage(Utilities.strPhysicalPath, type, 3);
      
        nMenuItemCounter = 0;

        odsCountries.Selecting += new ObjectDataSourceSelectingEventHandler();

        lstCountries.DataBound += new EventHandler(lstCountries_DataBound);        
        trMenus.SelectedNodeChanged += new EventHandler();
    }

    void lstCountries_DataBound(object sender, EventArgs e)
    {
        ScriptManager sm = ScriptManager.GetCurrent(this);
        if (!sm.IsInAsyncPostBack)
        {
            int nCurrentCountry = Session["countryid"] == null ? -1 : (int)Session["countryid"];
            bool bAuthorized = Session["authorized"] == null ? true : (bool)Session["authorized"];

            if (Session["countryid"] != null)
            {
                lstCountries.SelectedValue = ((int)Session["countryid"]).ToString();
            }

            if (Session["authorized"] != null)
            {
                lstAuthorized.SelectedValue = ((bool)Session["authorized"]) ? "true" : "false";
            }
        }

        PopulateMenuCtrl();

        UpdateCountryAttributes();
    }


    protected void lstTags_SelectedIndexChanged(object sender, EventArgs e)
    {
        Text tx = null;

        if (lstTags.SelectedIndex >= 0)
        {
            tx = (from t in ds.TextList where t.ID == Int32.Parse(lstTags.SelectedValue) select t).FirstOrDefault();
        }

        if (tx != null)
        {
            txtTextHeader.Text = tx.Headline;
            txtTextBody.Text = tx.TextBody;
        }
        else
        {
            txtTextHeader.Text = "";
            txtTextBody.Text = "";
        }

        btnDeleteTag.Enabled = (lstTags.SelectedIndex >= 0);
        btnMoveTagDown.Enabled = (lstTags.SelectedIndex >= 0);
        btnMoveTagUp.Enabled = (lstTags.SelectedIndex >= 0);
    }

    Country GetSelectedCountry()
    {
        if (string.IsNullOrEmpty(lstCountries.SelectedValue))
        {
            return null;
        }
        else
        {
            Country selectedCountry = (from c in ds.Countries where c.ID == Int32.Parse(lstCountries.SelectedValue) select c).FirstOrDefault();
            return selectedCountry;
        }
    }

    void PopulateMenuCtrl()
    {
        trMenus.Nodes.Clear();

        PopulateMenuNode(GetTopLevelMenu(), trMenus.Nodes);
    }

    void PopulateMenuNode(List<MenuItem> menus, TreeNodeCollection nodes)
    {
        foreach (MenuItem mi in menus)
        {
            TreeNode tn = new TreeNode(mi.MenuText, mi.ID.ToString());

            PopulateMenuNode(mi.SubMenus, tn.ChildNodes);

            nodes.Add(tn);
        }
    }

    TreeNode FindTreeViewNode(TreeNodeCollection nodes, string val)
    {
        TreeNode objTreeNodeMatch = null;
        foreach (TreeNode tn in nodes)
        {
            if (tn.Value == val)
            {
                objTreeNodeMatch = tn;
                break;
            }
            else
            {
                objTreeNodeMatch = FindTreeViewNode(tn.ChildNodes, val);
                if (objTreeNodeMatch != null) break;
            }
        }

        return objTreeNodeMatch;
    }

    ListItem FindListViewItem(string val)
    {
        ListItem objListItemMatch = null;
        foreach (ListItem li in lstTags.Items)
        {
            if (li.Value == val)
            {
                objListItemMatch = li;
                break;
            }
        }

        return objListItemMatch;
    }

    void UpdateCountryAttributes()
    {
        Country c = GetSelectedCountry();
        if (c != null)
        {
            chHasPortal.Checked = c.HasPortal;
            chBlockKeysNotAuth.Checked = c.BlockKeysIfNotAuth;
        }
    }

    bool GetAuthorized()
    {
        bool bAuthorized = Boolean.Parse(lstAuthorized.SelectedValue);
        return bAuthorized;
    }

    List<MenuItem> GetTopLevelMenu()
    {
        bool bAuthorized = GetAuthorized();
        Country country = GetSelectedCountry();
        List<MenuItem> lstMenus = (bAuthorized ? country.Menu : country.MenuNotAuth);
        return lstMenus;
    }


    protected void btnAddSubmenu_Click(object sender, EventArgs e)
    {
        Country country = GetSelectedCountry();
        bool bAuthorized = GetAuthorized();

        if (trMenus.SelectedValue != "")
        {
            //Get menu by ID
            MenuItem mi = country.FindMenuById(Int32.Parse(trMenus.SelectedValue), bAuthorized);
            if (mi != null)
            {
                MenuItem miNewItem = new MenuItem();
                miNewItem.MenuText = "New Menu Item";
                miNewItem.ID = country.GetMaxMenuId() + 1;

                if (miNewItem.ID == 0)
                {
                    miNewItem.ID = 1;
                }
            }
        }
    }
}
        

    
