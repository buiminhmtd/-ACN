using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWeb.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control ct;
            try
            {
                string mod;
                if (Request.QueryString["mod"] == null)
                {
                    ct = Page.LoadControl("Modules/uc_DisplayDefault.ascx");
                    controls.Controls.Add(ct);
                }
                else
                {
                    mod = Request.QueryString["mod"].ToString();


                    ct = Page.LoadControl("Modules/" + mod + ".ascx");
                    controls.Controls.Add(ct);
                }
            }
            catch
            {
            }
        }
    }
}