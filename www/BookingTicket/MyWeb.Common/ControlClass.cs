using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FredCK.FCKeditorV2;

namespace MyWeb.Common
{
    public class ControlClass : System.Web.UI.UserControl
    {
        public static void SetPostBackUrlLinkControl(Control parent) 
        {
            foreach (Control c in parent.Controls)
            {
                string abc = c.ID;
                if (c.Controls.Count > 0)
                {
                    SetPostBackUrlLinkControl(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.LinkButton":
                            ((LinkButton)c).PostBackUrl = c.ID.Replace("lbt", "/Admin/") + ".aspx";
                            break;
                    }
                }
            }
        }
        public static void ResetControlValues(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                string abc = c.ID;
                if (c.Controls.Count > 0)
                {
                    if (c.GetType().ToString() == "FredCK.FCKeditorV2.FCKeditor") {
                        ((FCKeditor)c).Value = "";
                        break;
                    }
                    else {
                        ResetControlValues(c);
                    }
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.DropDownList":
                            ((DropDownList)c).Items.Clear();
                            break;   
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).Text = "";
                            break;
                        case "System.Web.UI.WebControls.CheckBox":
                            ((CheckBox)c).Checked = ((CheckBox)c).ID.ToLower().Contains("actite") ? true : false;
                            break;
                        case "System.Web.UI.WebControls.RadioButton":
                            ((RadioButton)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.Image":
                            ((Image)c).ImageUrl = null;
                            ((Image)c).Width = 0;
                            break;
                        case "FredCK.FCKeditorV2.FCKeditor":
                            ((FCKeditor)c).Value = "";
                            break;
                    }
                }
            }
        }
    }
}
