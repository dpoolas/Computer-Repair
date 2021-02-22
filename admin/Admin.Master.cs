using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerRepair.admin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int admin = 0;
            if (Session["Admin"] != null)
            {
                admin = (int)Session["Admin"];
            }

            if (admin != 1)
            {
                Response.Redirect("../index.aspx");
            }
        }
    }
}