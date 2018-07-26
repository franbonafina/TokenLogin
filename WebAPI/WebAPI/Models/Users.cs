using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebAPI.Models
{
    public class Users
    {
        public List<User> lstUsers = new List<User>();

        public void InitFromDataBase(){
            /*{
               try
               {
                  lstUsers = (from User in
                               select new User
                               {
                                   Name =
                                   email =
                                   firstName =
                                  lastName =
                               }).ToList();
               }
               catch (Exception ex)
               {
                   ;
               }
           }*/
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
}

