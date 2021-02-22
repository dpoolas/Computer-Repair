using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ComputerRepair
{
    public partial class usercp : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["Repair"].ConnectionString;

        protected void doComment(int rid, string message)
        {
            int UserID = -1;
            if (Session["UID"] != null)
            {
                UserID = (int)Session["UID"];
            }

            if (UserID < 0)
            {
                return;
            }

            string Username = "";
            if (Session["Username"] != null)
            {
                Username = (string)Session["Username"];
            }

            if (String.IsNullOrEmpty(Username))
            {
                return;
            }

            if (String.IsNullOrEmpty(message))
            {
                return;
            }

            SqlConnection connection3 = null;

            try
            {
                string insertComment = "INSERT INTO [Comment](Request_ID, Comment_UID, Comment_Username, Comment_Date, Comment_Message) VALUES(@RID, @UserID, @Username, @Date, @Message);";
                connection3 = new SqlConnection(connection);
                SqlCommand insertion = new SqlCommand(insertComment, connection3);

                SqlParameter passRID = new SqlParameter();
                passRID.ParameterName = "@RID";
                passRID.Value = rid;
                insertion.Parameters.Add(passRID);

                SqlParameter passUID = new SqlParameter();
                passUID.ParameterName = "@UserID";
                passUID.Value = UserID;
                insertion.Parameters.Add(passUID);

                SqlParameter passUsername = new SqlParameter();
                passUsername.ParameterName = "@Username";
                passUsername.Value = Username;
                insertion.Parameters.Add(passUsername);

                SqlParameter passDate = new SqlParameter();
                passDate.ParameterName = "@Date";
                passDate.Value = DateTime.Now;
                insertion.Parameters.Add(passDate);

                SqlParameter passMessage = new SqlParameter();
                passMessage.ParameterName = "@Message";
                passMessage.Value = message;
                insertion.Parameters.Add(passMessage);

                connection3.Open();

                insertion.ExecuteNonQuery();
            }
            finally
            {
                connection3.Close();
                Response.Redirect("usercp.aspx");
            }
        }

        protected void createTable(int rid, string type, string problem, string status, string details)
        {
            HtmlGenericControl division = new HtmlGenericControl("div");
            division.ID = "Division_" + rid;
            division.Attributes["class"] = "well top-buffer table-responsive";

            HtmlGenericControl tab = new HtmlGenericControl("table");
            tab.Attributes["class"] = "table table-responsive table-bordered";

            TableRow row1 = new TableRow();

            Label label1 = new Label();
            label1.Text = "<strong>Type</strong>";

            TableCell cell1 = new TableCell();

            cell1.Controls.Add(label1);
            cell1.Attributes["class"] = "text-center col-md-1";

            row1.Controls.Add(cell1);

            Label labeltype = new Label();
            labeltype.Text = type;

            TableCell celltype = new TableCell();

            celltype.Controls.Add(labeltype);
            celltype.Attributes["class"] = "text-center";

            row1.Controls.Add(celltype);

            tab.Controls.Add(row1);

            TableRow row2 = new TableRow();

            TableCell cell2 = new TableCell();
            cell2.Attributes["class"] = "text-center col-md-1";

            Label label2 = new Label();
            label2.Text = "<strong>Problem</strong>";

            cell2.Controls.Add(label2);

            row2.Controls.Add(cell2);

            Label labelproblem = new Label();
            labelproblem.Text = problem;

            TableCell cellproblem = new TableCell();

            cellproblem.Controls.Add(labelproblem);
            cellproblem.Attributes["class"] = "text-center";

            row2.Controls.Add(cellproblem);

            tab.Controls.Add(row2);

            TableRow row3 = new TableRow();

            Label label3 = new Label();
            label3.Text = "<strong>Status</strong>";

            TableCell cell3 = new TableCell();
            cell3.Attributes["class"] = "text-center col-md-1";

            cell3.Controls.Add(label3);

            cell3.Controls.Add(label3);

            row3.Controls.Add(cell3);

            Label labelstatus = new Label();
            labelstatus.Text = status;

            TableCell cellstatus = new TableCell();
            cellstatus.Attributes["class"] = "text-center";

            cellstatus.Controls.Add(labelstatus);

            row3.Controls.Add(cellstatus);

            tab.Controls.Add(row3);

            TableRow row4 = new TableRow();

            Label label4 = new Label();
            label4.Text = "<strong>Details</strong>";

            TableCell cell4 = new TableCell();
            cell4.Attributes["class"] = "text-center col-md-1";

            cell4.Controls.Add(label4);

            row4.Controls.Add(cell4);

            Label labeldetails = new Label();
            details.Replace(Environment.NewLine, "<br />");
            labeldetails.Text = details;

            TableCell celldetails = new TableCell();

            celldetails.Controls.Add(labeldetails);

            row4.Controls.Add(celldetails);

            tab.Controls.Add(row4);

            TableRow comments = new TableRow();

            Label label5 = new Label();
            label5.Text = "<strong>Comments</strong>";

            TableCell cell5 = new TableCell();
            cell5.Attributes["class"] = "text-center";

            cell5.Controls.Add(label5);

            comments.Controls.Add(cell5);

            TableCell commentcell = new TableCell();
            comments.Controls.Add(commentcell);

            string sql = "SELECT Comment_UID, Comment_Username, Comment_Message FROM [Comment] where Request_ID = @RID ORDER BY Comment_Date DESC";

            SqlConnection connection2 = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(sql, connection2);

            SqlParameter RID = new SqlParameter();
            RID.ParameterName = "@RID";
            RID.Value = rid;
            cmd.Parameters.Add(RID);

            connection2.Open();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string username = reader.GetString(1);
                    string message = reader.GetString(2);

                    HtmlGenericControl commentdiv = new HtmlGenericControl("div");
                    commentdiv.Attributes["class"] = "table-responsive";

                    HtmlGenericControl commenttable = new HtmlGenericControl("table");
                    commenttable.Attributes["class"] = "table table-bordered table-responsive top-buffer";

                    TableRow ct1 = new TableRow();

                    TableCell userRow = new TableCell();
                    userRow.Attributes["class"] = "col-md-1";

                    Label userLabel = new Label();
                    userLabel.Attributes["class"] = "text-center";
                    userLabel.Text = "<strong>Username</strong>";

                    userRow.Controls.Add(userLabel);

                    ct1.Controls.Add(userRow);

                    TableCell usernamecontentholder = new TableCell();
                    Label usernameContent = new Label();
                    usernameContent.Text = username;

                    usernamecontentholder.Controls.Add(usernameContent);

                    ct1.Controls.Add(usernamecontentholder);

                    TableRow ct2 = new TableRow();

                    TableCell messageRow = new TableCell();
                    messageRow.Attributes["class"] = "col-md-1";

                    Label messageLabel = new Label();
                    messageLabel.Attributes["class"] = "text-center";
                    messageLabel.Text = "<strong>Message</strong>";


                    messageRow.Controls.Add(messageLabel);

                    ct2.Controls.Add(messageRow);

                    TableCell messagecontentHolder = new TableCell();

                    Label messageContent = new Label();
                    messageContent.Text = message;

                    messagecontentHolder.Controls.Add(messageContent);

                    ct2.Controls.Add(messagecontentHolder);

                    commenttable.Controls.Add(ct1);
                    commenttable.Controls.Add(ct2);

                    commentdiv.Controls.Add(commenttable);
                    commentcell.Controls.Add(commentdiv);
                }
            }

            tab.Controls.Add(comments);

            TableRow addComment = new TableRow();

            TableCell addlabelholder = new TableCell();
            addlabelholder.Attributes["class"] = "text-center col-md-1";

            Label addlabel = new Label();
            addlabel.Attributes["class"] = "text-center";
            addlabel.Text = "<strong>Add Comment</strong>";

            addlabelholder.Controls.Add(addlabel);

            addComment.Controls.Add(addlabelholder);

            TableCell addlabelfunctions = new TableCell();
            addlabelfunctions.Attributes["class"] = "col-md-1";
            addlabelfunctions.Attributes["style"] = "display: block; border: 0px";

            TextBox addcommenttext = new TextBox();
            addcommenttext.TextMode = TextBoxMode.MultiLine;
            addcommenttext.ID = "Text_" + rid;
            addcommenttext.Rows = 5;
            addcommenttext.Columns = 100;
            addcommenttext.MaxLength = 500;

            addlabelfunctions.Controls.Add(addcommenttext);

            Button commentsubmit = new Button();
            commentsubmit.ID = "Control_" + rid;
            commentsubmit.Attributes["class"] = "btn-primary";

            commentsubmit.Click += (s, e) => {
                doComment(rid, addcommenttext.Text);
            };

            commentsubmit.Attributes["style"] = "display: block;";
            commentsubmit.Text = "Submit";

            addlabelfunctions.Controls.Add(commentsubmit);


            addComment.Controls.Add(addlabelfunctions);



            tab.Controls.Add(addComment);

            division.Controls.Add(tab);



            Master.FindControl("mainContent").Controls.Add(division);

            connection2.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["LoggedIn"] != true)
            {
                Response.Redirect("index.aspx");
            }

            int UID = -1;

            if (Session["UID"] != null)
            {
                UID = (int)Session["UID"];
            }

            if (UID > -1)
            {
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(connection);

                    string sql = "Select Request_ID, Request_Type, Request_Problem, Request_Status, Request_Details from [Request] where Request_UserID = @UID and Request_Status != 'Finished';";

                    conn = new SqlConnection(connection);
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlParameter userid = new SqlParameter();
                    userid.ParameterName = "@UID";
                    userid.Value = UID;
                    cmd.Parameters.Add(userid);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int rid = reader.GetInt32(0);
                            string type = reader.GetString(1);
                            string problem = reader.GetString(2);
                            string status = reader.GetString(3);
                            string details = reader.GetString(4);

                            createTable(rid, type, problem, status, details);
                        }
                    }
                }
                finally
                {
                    if (conn != null) conn.Close();
                }
            }
        }
    }
}