using System;
using System.Web;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace MyWeb.Common
{
    public class PageHelper : System.Web.UI.UserControl
    {
        private string[] Separator = new string[] { ","};
        public static Control FindControl(Control Root, string Id) 
        {
            if (Root.ID == Id)
                return Root;
            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControl(Ctl, Id);
                if (FoundCtl != null)
                    return FoundCtl;
            }
            return null;
        }

        public static void AppendParameterUrl(string parameterName, string parameterValue)
        {
            System.Reflection.PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            // make collection editable
            isreadonly.SetValue(HttpContext.Current.Request.QueryString, false, null);
            // remove
            HttpContext.Current.Request.QueryString.Remove(parameterName);
            // modify
            HttpContext.Current.Request.QueryString.Set(parameterName, parameterValue);
            // make collection readonly again
            isreadonly.SetValue(HttpContext.Current.Request.QueryString, true, null);
        }
        public static String AppendUrlParameter(string URL, string parameterName, string parameterValue) 
        {
            if ((URL == null) || (URL.Length == 0)) URL = HttpContext.Current.Request.Url.PathAndQuery.ToString();
            string[] urlParts = URL.Split(Convert.ToChar("?"));
            string newQueryString = "";
            if(urlParts.Length >1){
                var parameters = urlParts[1].Split(Convert.ToChar("&"));
                for (var i = 0; (i < parameters.Length); i++)
                {
                    var parameterParts = parameters[i].Split(Convert.ToChar("="));
                    if (parameterParts[0] != parameterName)
                    {
                        if (newQueryString == "")
                            newQueryString = "?";
                        else
                            newQueryString += "&";
                        newQueryString += parameterParts[0] + "=" + parameterParts[1];
                    }
                }
            }
            if (newQueryString == "")
                newQueryString = "?";
            else
                newQueryString += "&";
            newQueryString += parameterName + "=" + parameterValue;
            return urlParts[0] + newQueryString;
        }

        public static string PopulatePager(int recordCount, int currentPage)
        {
            return PopulatePager(recordCount, currentPage, 10);
        }
        public static string PopulatePager(int recordCount, int currentPage, int pageSize)
        {
            return PopulatePager(recordCount, currentPage, pageSize, "First:Last");
        }
        public static string PopulatePager(int recordCount, int currentPage, int pageSize, string Navigation)
        {
            string[] strNati = Navigation.Split(Convert.ToChar(":"));
            double dblPageCount = (double)((decimal)recordCount / (decimal)pageSize);
            int pageCount = (int)Math.Ceiling(dblPageCount);
            string strReturn = string.Empty;
            if (pageCount > 0)
            {
                strReturn += currentPage > 1 ? string.Format("<a href=\"{0}\" rel=\"nofollow\">{1}</a>", AppendUrlParameter("", "page", "1"), strNati[0]) : strNati[0];
                for (int i = 1; i <= pageCount; i++)
                {
                    strReturn += i == currentPage ? string.Format(" <span>{0}</span> ", i.ToString()) : string.Format(" <a href=\"{0}\" rel=\"nofollow\">{1}</a> ", AppendUrlParameter("", "page", i.ToString()), i.ToString());
                }
                strReturn += currentPage < pageCount ? string.Format(" <a href=\"{0}\" rel=\"nofollow\">{1}</a> ", AppendUrlParameter("", "page", pageCount.ToString()), strNati[1]) : strNati[1];
            }
            return strReturn;
        }

        public static string ShowActiveImage(string ActiveCode)
        {
            string strReturn = ActiveCode == "1" || ActiveCode == "True" ? "stop.png" : "start.png";
            return GlobalClass.GetUrlAdminImage() + strReturn;
        }

        public static string ShowCheckImage(string ActiveCode)
        {
            string strReturn = ActiveCode == "1" || ActiveCode == "True" ? "check.gif" : "uncheck.gif";
            return GlobalClass.GetUrlAdminImage() + strReturn;
        }

        public static string ShowActiveToolTip(string ActiveCode)
        {
            return ActiveCode == "1" || ActiveCode == "True" ? "Hide" : "Show";
        }

        public static string ShowActiveStatus(string ActiveCode)
        {
            return ActiveCode == "1" || ActiveCode == "True" ? "Show" : "Hide";
        }

        public static void LoadDropDownList(DropDownList ddl, ArrayList array) 
        {
            ddl.DataSource = array;
            ddl.DataBind();
        }

        public static void LoadDropDownList(DropDownList ddl, string[] StringArray) 
        {
            LoadDropDownList(ddl, StringArray, false);
        }

        public static void LoadDropDownList(DropDownList ddl, string[] StringArray, bool ListItem)
        {
            if (ListItem){
                ddl.DataSource = StringArray2ListItem(StringArray);
                ddl.DataTextField = "Text";
                ddl.DataValueField = "Value";
                
            }else{
                ddl.DataSource = StringArray2ArrayList(StringArray);
            }
            ddl.DataBind();
        }

        public static List<ListItem> StringArray2ListItem(string[] StringArray) 
        {
            char[] splitter = { ',',';' };
            List<ListItem> list = new List<ListItem>();
            for (int i = 0; i < StringArray.Length; i++)
            {
                string[] arr = StringArray[i].Split(splitter);
                if (arr.Length > 1){
                    list.Add(new ListItem(arr[1], arr[0]));
                }
                else{
                    list.Add(new ListItem(arr[0], arr[0]));
                }
            }
            return list;
        }

        public static ArrayList StringArray2ArrayList(string[] StringArray)
        {
            ArrayList arrlist = new ArrayList();
            for (int i = 0; i < StringArray.Length; i++)
            {
                arrlist.Add(StringArray[i]);
            }
            return arrlist;
        }

        public static void LoadDropDownListTarget(DropDownList ddl) 
        {
            string[] myArr = new string[] { "_self", "_blank" };
            ddl.DataSource = StringArray2ArrayList(myArr);
            ddl.DataBind();
        }

        public static void LoadDropDownListNumber(DropDownList ddl, int BeginNumber, int EndNumber)
        {
            for (int i = BeginNumber; i <= EndNumber; i++)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        public static void LoadDropDownListPosition(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Top banner", "2,Hình ảnh nổi bật", "3,Đối tác", "4,Flash Trang chủ", "5,Banner giữa", "8,Cạnh trái", "9,Cạnh phải" };
            //string[] myArr = new string[] { "1,Top banner", "2,Hình ảnh nổi bật", "3,Đối tác", "4,Gian hàng điện tử", "5,Quảng cáo", "6,Bên trái", "7,Bên phải", "8,Cạnh trái", "9,Cạnh phải" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static string ShowAdvertisePosition(string Position)
        {
            string strString = "";
            string[] myArr = new string[] { "1,Top banner", "2,Hình ảnh nổi bật", "3,Đối tác", "4,Flash Trang chủ", "5,Banner giữa", "8,Cạnh trái", "9,Cạnh phải" };
            char[] splitter = { ',', ';' };
            for (int i = 0; i < myArr.Length; i++)
            {
                string[] arr = myArr[i].Split(splitter);
                if (arr[0].Equals(Position))
                {
                    strString = arr[1];
                    break;
                }
            }
            return strString;
        }
        public static void LoadDropDownListYesNo(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Yes", "0,No" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static void LoadDropDownListCoKhong(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Có", "0,Không" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static void LoadDropDownListFilterActive(DropDownList ddl)
        {
            string[] myArr = new string[] { ", -- All -- ", "1,Show", "0,Hide" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static void LoadDropDownListActive(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Có", "0,Không" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static void LoadDropDownListPagePosition(DropDownList ddl) 
        {
            string[] myArr = new string[] { "2,Menu chính","1,Menu dưới" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static void LoadDropDownListPageType(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Trang liên kết", "2,Trang nội dung"};
            LoadDropDownList(ddl, myArr, true);
        }

        public static void LoadDropDownListAdvertiseType(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Hình ảnh", "2,Nội dung" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static string ShowPageType(string ActiveCode)
        {
            return ActiveCode == "1" ? "Trang liên kết" : "Trang nội dung";
        }

        public static void LoadDropDownListAreaType(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Khu vực đất liền", "2,Khu vực biển", "3,Khu vực thủy văn" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static string ShowAreaType(string Type)
        {
            return Type == "1" ? "Khu vực đất liền" : Type == "2" ? "Khu vực biển" : "Khu vực thủy văn";
        }

        public static void LoadDropDownListSupportType(DropDownList ddl)
        {
            string[] myArr = new string[] { "1,Yahoo messenger", "2,Skype" };
            LoadDropDownList(ddl, myArr, true);
        }

        public static string ShowSupportType(string Type) 
        {
            return Type == "1" ? "Yahoo messenger" : Type == "2" ? "Skype" : "Google talk";
        }

        public static string GetContent(string URL)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            return sr.ReadToEnd();
            sr.Close();
            myResponse.Close();
        }

        public static string GetContent(string URL, string strStart, string strEnd)
        {
            string Content = GetContent(URL);
            int pStart = Content.IndexOf(strStart);
            int pEnd = Content.IndexOf(strEnd);
            string strReturn = Content.Substring(pStart, pEnd - pStart);
            return StripATag(strReturn);
        }
        public static string StripATag(string text)
        {
            return Regex.Replace(text, @"<a[^>]*?href\s*=\s*[""']?([^'"" >]+?)[ '""]?/?>|<.a*?>", string.Empty);
        }
    }
}
