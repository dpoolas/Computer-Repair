using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerRepair
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string[] computeritems = { "Processor", "Motherboard", "Graphics card", "RAM", "Operating System", "Virus", "Other" };
        string[] tabletitems = { "Screen cracked", "Faulty OS", "Touch screen" };
        string[] laptopitems = { "Screen cracked", "Faulty OS", "Touch screen" };

        string connection = ConfigurationManager.ConnectionStrings["Repair"].ConnectionString;

        protected void populateProblems()
        {
            serviceproblemDropdown.Items.Clear();
            List<string> items = new List<string>();
            items.Add("None");
            string selected = servicetypeDropdown.SelectedItem.Text;

            if (selected == "Desktop")
            {
                items.AddRange(computeritems);
            }
            else if (selected == "Tablet")
            {

                items.AddRange(tabletitems);
            }
            else if (selected == "Laptop")
            {

                items.AddRange(laptopitems);
            }


            for (int i = 0; i < items.Count; i++)
            {
                serviceproblemDropdown.Items.Add(items[i]);
            }
        }

        protected void servicetypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateProgress();
            populateProblems();
        }

        protected void serviceproblemDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateProgress();
            //populateProblems();
        }

        protected void detailsTextbox_TextChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(detailsTextbox.Text);
            calculateProgress();
            //populateProblems();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.linkServices.Attributes["class"] = "active";

            bool LoggedIn = false;

            if (Session["LoggedIn"] != null)
            {
                LoggedIn = (bool)Session["LoggedIn"];
            }

            if (LoggedIn != true)
            {
                serviceContent.Visible = false;
                Error.Visible = true;
                return;
            }
            else
            {
                Error.Visible = false;
            }


            if (!IsPostBack)
            {
                submitForm.Visible = false;

                string sid = Request.QueryString["id"];


                int id = -1;

                Int32.TryParse(sid, out id);

                if (id > -1 && id < 3)
                {
                    servicetypeDropdown.SelectedIndex = id;
                    populateProblems();
                    calculateProgress();
                }
            }
        }

        protected double calculateProgress()
        {
            double percentage = 1.0;
            if (servicetypeDropdown.SelectedItem != null && servicetypeDropdown.SelectedItem.Text != "None")
            {
                percentage += 33;
            }

            if (serviceproblemDropdown.SelectedItem != null && serviceproblemDropdown.SelectedItem.Text != "None")
            {
                percentage += 33;
            }

            if (detailsTextbox.Text != "")
            {
                percentage += 33;
            }

            textProgress.Text = percentage + "%";
            servicesProgress.Attributes["style"] = "width: " + percentage + "%";

            if (percentage >= 100)
            {
                submitForm.Visible = true;
            }
            else
            {
                submitForm.Visible = false;
            }

            return percentage;
        }

        protected void doQuery(string type, string problem, string details)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connection);
                int UID = -1;

                if (Session["UID"] != null)
                {
                    UID = (int)Session["UID"];
                }

                string checksql = "select count(*) from [Request] where Request_UserID = @UID and Request_Type = @Type;";

                SqlCommand valid = new SqlCommand(checksql, conn);

                SqlParameter uidCheck = new SqlParameter();
                uidCheck.ParameterName = "@UID";
                uidCheck.Value = UID;
                valid.Parameters.Add(uidCheck);

                SqlParameter typeCheck = new SqlParameter();
                typeCheck.ParameterName = "@Type";
                typeCheck.Value = type;
                valid.Parameters.Add(typeCheck);

                conn.Open();

                int count = (int)valid.ExecuteScalar();

                if (count > 0)
                {
                    Response.Write("<script>alert('A service request is already in place for you with that type.');</script>");
                    conn.Close();
                    return;
                }

                string sql = "INSERT INTO [Request](Request_UserID, Request_Type, Request_Problem, Request_Status, Request_Details) VALUES(@UID, @Type, @Problem, 'New', Replace(@Details,char(13),'<br />'));";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlParameter uid = new SqlParameter();
                uid.ParameterName = "@UID";
                uid.Value = UID;
                cmd.Parameters.Add(uid);

                SqlParameter servicetype = new SqlParameter();
                servicetype.ParameterName = "@Type";
                string typet = type.Trim();
                servicetype.Value = typet;
                cmd.Parameters.Add(servicetype);

                SqlParameter serviceproblem = new SqlParameter();
                serviceproblem.ParameterName = "@Problem";
                serviceproblem.Value = problem.Trim();
                cmd.Parameters.Add(serviceproblem);

                SqlParameter servicedetails = new SqlParameter();
                servicedetails.ParameterName = "@Details";
                servicedetails.Value = details.Trim();
                cmd.Parameters.Add(servicedetails);

                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Service request sent to administrators.');</script>");
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        protected void validateServiceorder()
        {
            if (String.IsNullOrEmpty(servicetypeDropdown.SelectedItem.Text) || servicetypeDropdown.SelectedItem.Text == "None")
            {
                return;
            }

            if (String.IsNullOrEmpty(serviceproblemDropdown.SelectedItem.Text) || serviceproblemDropdown.SelectedItem.Text == "None")
            {
                return;
            }

            if (String.IsNullOrEmpty(detailsTextbox.Text))
            {
                return;
            }

            double progress = calculateProgress();

            if (progress < 100)
            {
                return;
            }

            doQuery(servicetypeDropdown.SelectedItem.Text, serviceproblemDropdown.SelectedItem.Text, detailsTextbox.Text);
        }

        protected void serviceSubmitform_Click(object sender, EventArgs e)
        {
            validateServiceorder();
        }
    }
}