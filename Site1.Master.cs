using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerRepair
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool LoggedIn = false;
            if (Session["LoggedIn"] != null)
            {
                LoggedIn = (bool)Session["LoggedIn"];
                if (LoggedIn == true)
                {
                    signinDropdown.Visible = false;

                    if (Session["Username"] != null)
                    {
                        welcomeShow.Visible = true;
                        HyperLink hyp = new HyperLink();
                        hyp.ID = "welcomeText";
                        hyp.NavigateUrl = "usercp.aspx";
                        hyp.Text = "Welcome, " + Session["Username"];
                        hyp.ToolTip = "";
                        welcomeShow.Controls.Add(hyp);
                    }

                    if (Session["Admin"] != null)
                    {
                        if ((int)Session["Admin"] == 1)
                        {
                            linkAdmin.Visible = true;
                        }
                        else
                        {
                            linkAdmin.Visible = false;
                        }
                    }
                    else
                    {
                        linkAdmin.Visible = false;
                    }

                    logoutField.Visible = true;
                }
            }
            else
            {
                linkAdmin.Visible = false;
                welcomeShow.Visible = false;
                logoutField.Visible = false;
            }
        }
    }
}