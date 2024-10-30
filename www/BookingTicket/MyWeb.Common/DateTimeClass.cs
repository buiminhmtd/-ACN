using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Text;

namespace MyWeb.Common
{
    public class DateTimeClass
    {
        public static string DatePicker(TextBox htmlHelper, string name, string value)
        {
            return "<script type=\"text/javascript\">" +
                     "$(function() {" +
                     "$(\"#" + name + "\").datepicker();" +
                     "});" +
                     "</script>" +
                     "<input type=\"text\" size=\"10\" value=\"" + value + "\" id=\"" + name + "\" name=\"" + name + "\"/>";
        }

        /// <summary>
        /// Convert string Date
        /// </summary>
        /// <param name="Date">string Date to convert</param>
        /// <returns>Default datetime format dd/MM/yyyy</returns>
        public static string ConvertDate(string Date)
        {
            return ConvertDate(Date, "dd/MM/yyyy");
        }
        /// <summary>
        /// Convert string Date
        /// </summary>
        /// <param name="Date">string Date to convert</param>
        /// <param name="DateFormat">string format date</param>
        /// <returns>string Date format as DateFormat</returns>
        public static string ConvertDate(string Date, string DateFormat)
        {
            if (Date.Length >0 ){
                DateTime dt = Convert.ToDateTime(Date);
                return dt.ToString(DateFormat);
            }
            else{
                return "";
            }
        }

        /// <summary>
        /// Convert Date
        /// </summary>
        /// <param name="Date">Date to convert</param>
        /// <returns>Default datetime format dd/MM/yyyy</returns>
        public static string ConvertDate(DateTime Date)
        {
            return ConvertDate(Date, "dd/MM/yyyy");
        }
        /// <summary>
        /// Convert Date
        /// </summary>
        /// <param name="Date">Date</param>
        /// <param name="DateFormat">string format date</param>
        /// <returns>string Date format as DateFormat</returns>
        public static string ConvertDate(DateTime Date, string DateFormat)
        {
            if (Date != null)
            {
                return Date.ToString(DateFormat);
            }
            else
            {
                return "";
            }
        }

        public static DateTime Convert2Date(string Date)
        {
            DateTime dt = Convert.ToDateTime(Date);
            return dt;
        }

        /// <summary>
        /// Convert string Datetime
        /// </summary>
        /// <param name="DateTime">string Datetime to convert</param>
        /// <returns>Default dd/MM/yyyy HH:mm:ss</returns>
        public static string ConvertDateTime(string DateTime) 
        {
            return ConvertDateTime(DateTime, "dd/MM/yyyy hh:mm:ss tt");
        }
        /// <summary>
        /// Convert string Datetime
        /// </summary>
        /// <param name="DateTime">string Datetime to convert</param>
        /// <param name="DateFormat">string format date</param>
        /// <returns>string Datetime format as DateFormat</returns>
        public static string ConvertDateTime(string DateTime, string DateFormat) 
        {
            if (DateTime.Length > 0)
            {
                DateTime dt = Convert.ToDateTime(DateTime);
                return dt.ToString(DateFormat);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Convert Datetime
        /// </summary>
        /// <param name="DateTime">Datetime to convert</param>
        /// <returns>Default dd/MM/yyyy HH:mm:ss</returns>
        public static string ConvertDateTime(DateTime DateTime)
        {
            return ConvertDateTime(DateTime, "dd/MM/yyyy HH:mm:ss tt");
        }
        /// <summary>
        /// Convert Datetime
        /// </summary>
        /// <param name="DateTime">Datetime to convert</param>
        /// <param name="DateFormat">string format date</param>
        /// <returns>string Datetime format as DateFormat</returns>
        public static string ConvertDateTime(DateTime DateTime, string DateFormat)
        {
            if (DateTime != null)
            {
                return DateTime.ToString(DateFormat);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        ///  Convert string Time
        /// </summary>
        /// <param name="Time">string Time to convert</param>
        /// <returns>Default HH:mm:ss</returns>
        public static string ConvertTime(string Time) 
        {
            return ConvertTime(Time, "HH:mm:ss");
        }

        /// <summary>
        ///  Convert string Time
        /// </summary>
        /// <param name="Time">string Time to convert</param>
        /// <param name="TimeFormat">string format time</param>
        /// <returns>string Time format as TimeFormat</returns>
        public static string ConvertTime(string Time, string TimeFormat)
        {
            if (Time.Length >0 )
            {
                DateTime dt = Convert.ToDateTime(Time);
                return dt.ToString(TimeFormat);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        ///  Convert Time
        /// </summary>
        /// <param name="Time">Time to convert</param>
        /// <returns>Default HH:mm:ss</returns>
        public static string ConvertTime(DateTime Time)
        {
            return ConvertTime(Time, "HH:mm:ss");
        }

        /// <summary>
        ///  Convert Time
        /// </summary>
        /// <param name="Time">Time to convert</param>
        /// <param name="TimeFormat">string format time</param>
        /// <returns>string Time format as TimeFormat</returns>
        public static string ConvertTime(DateTime Time, string TimeFormat)
        {
            if (Time != null)
            {
                return Time.ToString(TimeFormat);
            }
            else
            {
                return "";
            }
        }

        public static string DayOfWeek(string Date)
        {
            if (Date.Length > 0)
            {
                DateTime dt = Convert.ToDateTime(Date);
                return DayOfWeek(dt);
            }
            else
            {
                return "";
            }
        }

        public static string DayOfWeek(DateTime Date)
        {
            string strReturn = "";
            if (Date != null)
            {
                switch (Date.DayOfWeek.ToString())
                {
                    case "Sunday":
                        strReturn = "Chủ nhật";
                        break;
                    case "Monday":
                        strReturn = "Thứ 2";
                        break;
                    case "Tuesday":
                        strReturn = "Thứ 3";
                        break;
                    case "Wednesday":
                        strReturn = "Thứ 4";
                        break;
                    case "Thursday":
                        strReturn = "Thứ 5";
                        break;
                    case "Friday":
                        strReturn = "Thứ 6";
                        break;
                    case "Saturday":
                        strReturn = "Thứ 7";
                        break;
                }
            }
            return strReturn;
        }
    }
}
