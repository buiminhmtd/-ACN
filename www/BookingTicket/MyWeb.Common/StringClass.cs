using System;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Common 
{
    public class StringClass : System.Web.UI.Page
    {
        /// <summary>
        /// Create attribute and funtion for textbox
        /// </summary>
        /// <param name="textBox">Textbox to set client attribute</param>
        /// <param name="Event">Event set for textbox</param>
        /// <param name="Funtion">Value of event - funtion javascript</param>
        /// <param name="ScriptFuntion">String funtion script return</param>
        public static void CreateClientScriptAttributes(TextBox textBox, string Event, string Funtion, string ScriptFuntion)
        {
            textBox.Page.ClientScript.RegisterClientScriptBlock(textBox.GetType(), textBox.ID.ToString() + "_" + Event, ScriptFuntion);
            textBox.Attributes.Add(Event, Funtion);
        }

        /// <summary>
        /// Create attribute and funtion for textbox
        /// </summary>
        /// <param name="checkBox">CheckBox to set client attribute</param>
        /// <param name="Event">Event set for checkbox</param>
        /// <param name="Funtion">Value of event - funtion javascript</param>
        /// <param name="ScriptFuntion">String funtion script return</param>
        public static void CreateClientScriptAttributes(CheckBox checkBox, string Event, string Funtion, string ScriptFuntion)
        {
            checkBox.Page.ClientScript.RegisterClientScriptBlock(checkBox.GetType(), checkBox.ID.ToString() + "_" + Event, ScriptFuntion);
            checkBox.Attributes.Add(Event, Funtion);
        }

        /// <summary>
        /// Ma hoa chuoi ky tu (MD5)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Encrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            var md5 = new MD5CryptoServiceProvider();
            byte[] valueArray = Encoding.ASCII.GetBytes(value);
            valueArray = md5.ComputeHash(valueArray);
            var sb = new StringBuilder();
            for (int i = 0; i < valueArray.Length; i++)
                sb.Append(valueArray[i].ToString("x2").ToLower());
            return sb.ToString();
        }
        /// <summary>
        /// Tao mot chuoi ngau nghien
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        #region Random String
        public static string RandomString(int size)
        {
            Random rnd = new Random();
            string srds = "";
            string[] str = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            for (int i = 0; i < size; i++)
            {
                srds = srds + str[rnd.Next(0, 61)];
            }
            return srds;
        }
        #endregion
        /// <summary>
        /// Tao chuoi dung cho rewrite url
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        #region Name To Tag
        public static string NameToTag(string strName)
        {
            string strReturn = "";
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            strReturn = Regex.Replace(strName, "[^\\w\\s]", string.Empty).Replace(" ", "-").ToLower();
            string strFormD = strReturn.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, string.Empty).Replace("đ", "d");
        }
        #endregion

        public static string ShowNameLevel(string Name, string Level)
        {
            int strLevel = (Level.Length / 5);
            string strReturn = "";
            for (int i = 1; i < strLevel; i++)
            {
                strReturn = strReturn + ".....";
            }
            strReturn += Name;
            return strReturn;
        }
        /// <summary>
        /// Kiem tra chuoi. Tra ve true neu do dai chuoi > 1
        /// </summary>
        /// <param name="String">Chuoi kiem tra</param>
        /// <returns>true or false</returns>
        #region Check String
        public static bool Check(object String)
        {
            return String != null && String.ToString().Length > 0 ? true : false;
        }
        #endregion
        /// <summary>
        /// Xoa ky tu unicode tu chuoi
        /// </summary>
        /// <param name="strString"></param>
        /// <returns></returns>
        #region Remove Unicode
        public static string RemoveUnicode(string strString)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string strFormD = strString.Normalize(NormalizationForm.FormD);
            return regex.Replace(strFormD, string.Empty).Replace("đ", "d");
        }
        #endregion
        /// <summary>
        /// Ma hoa mot chuoi
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        #region Encode
        public static string Encode(string str)
        {
            byte[] encbuff = Encoding.UTF8.GetBytes(str);
            string strtemp = Convert.ToBase64String(encbuff);
            string strtam = "";
            Int32 i = 0, len = strtemp.Length;
            for (i = 3; i <= len; i += 3)
            {
                strtam = strtam + strtemp.Substring(i - 3, 3) + RandomString(1);
            }
            strtam = strtam + strtemp.Substring(i - 3, len - (i - 3));
            return strtam;
        }
        #endregion
        /// <summary>
        /// Giai ma mot chuoi
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        #region Decode
        public static string Decode(string str)
        {
            string strtam = "";
            Int32 i = 0, len = str.Length;
            for (i = 4; i <= len; i += 4)
            {
                strtam = strtam + str.Substring(i - 4, 3);
            }
            strtam = strtam + str.Substring(i - 4, len - (i - 4));
            byte[] decbuff = Convert.FromBase64String(strtam);
            return System.Text.Encoding.UTF8.GetString(decbuff);
        }
        #endregion
        /// <summary>
        /// Lay ten file tu chuoi
        /// </summary>
        /// <param name="String">Chuoi can lay</param>
        /// <returns>Ten file bo qua phan mo rong</returns>
        #region GetFileName
        public static string GetFileName(string String)
        {
            return String.Substring(0, String.LastIndexOf("."));
        }
        #endregion
        /// <summary>
        /// Lay phan mo rong cua file tu chuoi
        /// </summary>
        /// <param name="String">Chuoi can lay</param>
        /// <returns>Phan mo rong cua file</returns>
        #region GetFileExtension
        public static string GetFileExtension(string String)
        {
            return String.Substring(String.LastIndexOf(".") + 1);
        }
        #endregion

        #region ThumbImage
        public static string ThumbImage(string ImagePath) 
        {
            return ImagePath.ToLower().Replace("uploads/", "uploads/_thumbs/");
        }
        #endregion

        #region GetContent
        public static string GetContent(object String)
        {
            return String != null && String.ToString().Length > 0 ? String.ToString() : "";
        }
        public static string GetContent(string String, int Length)
        {
            return String.Length > Length && String.Length - Length > 5 ? String.Substring(0, String.IndexOf(" ", Length)) + "..." : String;
        }
        #endregion

        public static string FormatNumber(string _strInput)
        {
            string strInput = _strInput;
            int Length = 0;
            if (strInput.IndexOf('.') > 0)
                Length = strInput.Length - (strInput.Length - strInput.IndexOf('.'));
            else
                Length = strInput.Length;
            string afterFormat = "";
            if (Length <= 3)
                afterFormat = strInput;
            else if (Length > 3)
            {
                afterFormat = strInput.Insert(Length - 3, ",");
                Length = afterFormat.IndexOf(",");
                while (Length > 3)
                {
                    afterFormat = afterFormat.Insert(Length - 3, ",");
                    Length = Length - 3;
                }
            }
            return afterFormat;
        }
    }
}
