using System;
using System.Web;

namespace MyWeb.Common
{
    public class CookieClass
    {

        /// <summary>
        /// Get cookie name from cookie
        /// </summary>
        /// <param name="CookieName"></param>
        /// <returns></returns>
        public string GetCookie(string CookieName)
        {
            return StringClass.Check(HttpContext.Current.Request.Cookies[CookieName]) ? HttpContext.Current.Request.Cookies[CookieName].Value : "";
        }
        /// <summary>
        /// Set string to cookie
        /// </summary>
        /// <param name="CookieName"></param>
        /// <param name="CookieValue"></param>
        public void SetCookie(string CookieName, string CookieValue)
        {
            HttpCookie cookie = new HttpCookie(CookieName);
            cookie.Value = CookieValue;
            cookie.Expires = DateTime.Now.AddDays(30);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
