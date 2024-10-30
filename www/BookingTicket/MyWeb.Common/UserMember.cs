using System;
using System.Linq;
using System.Text;
using System.Web;

namespace MyWeb.Common
{
    public class UserMember : System.Web.UI.Page
    {
        static CookieClass cookie = new CookieClass();
        /// <summary>
        /// Luu thong tin cua user dang nhap vao cookie tu bien
        /// </summary>
        public static void SaveUserToCookie(string strFullName, string strUserName)
        {
            cookie.SetCookie("FullName", strFullName);
            cookie.SetCookie("UserName", strUserName);
            cookie.SetCookie("IsAdmin", "0");
        }
        /// <summary>
        /// Luu thong tin cua user dang nhap vao cookie
        /// </summary>
        /// <param name="FullName of user"></param>
        /// <param name="UserName of user"></param>
        /// <param name="Is admin of website"></param>
        public static void SaveUserToCookie(string strFullName, string strUserName, string strIsAdmin)
        {
            cookie.SetCookie("FullName", strFullName);
            cookie.SetCookie("UserName", strUserName);
            cookie.SetCookie("IsAdmin", strIsAdmin);
        }
        /// <summary>
        /// Luu thong tin cua user dang nhap vao bien
        /// </summary>
        /// <param name="FullName of user"></param>
        /// <param name="UserName of user"></param>
        public void SaveUserToVariable(string strFullName, string strUserName)
        {
            Session["FullName"] = strFullName;
            Session["UserName"] = strUserName;
        }
        /// <summary>
        /// Luu thong tin cua user dang nhap vao bien
        /// </summary>
        /// <param name="FullName of user"></param>
        /// <param name="UserName of user"></param>
        /// <param name="Is admin of website"></param>
        public static void SaveUserToVariable(string strFullName, string strUserName, string strIsAdmin)
        {
            //GlobalClass.FullName = strFullName;
            //GlobalClass.UserName = strUserName;
            //GlobalClass.IsAdmin = strIsAdmin;
        }
        /// <summary>
        /// Luu thong tin cua user tu cookie
        /// </summary>
        public static void GetUserVariableFromCookie()  
        {
            //GlobalClass.FullName = cookie.GetCookie("FullName").ToString();
            //GlobalClass.UserName = cookie.GetCookie("UserName").ToString();
            //GlobalClass.IsAdmin = cookie.GetCookie("IsAdmin").ToString();
        }
    }
}
