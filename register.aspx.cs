using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerRepair
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        string connection = ConfigurationManager.ConnectionStrings["Repair"].ConnectionString;

        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        public bool IsAlphaNumeric(string text)
        {
            return Regex.IsMatch(text, "^[a-zA-Z0-9]+$");
        }

        private void ValidateCredentials(string userName, string password, string email)
        {

            if (this.IsAlphaNumeric(userName) && userName.Length <= 50 && password.Length <= 50)
            {
                SqlConnection conn = null;

                try
                {
                    string checksql = "select count(*) from [User] where User_Username = @username;";

                    conn = new SqlConnection(connection);
                    SqlCommand valid = new SqlCommand(checksql, conn);

                    SqlParameter userCheck = new SqlParameter();
                    userCheck.ParameterName = "@username";
                    userCheck.Value = userName.Trim();
                    valid.Parameters.Add(userCheck);

                    conn.Open();

                    int count = (int)valid.ExecuteScalar();

                    if (count > 0)
                    {
                        Response.Write("<script>alert('Username already exists.');</script>");
                        conn.Close();
                        return;
                    }

                    string sql = "INSERT INTO [User](User_Username, User_Password, User_Email, User_Admin) VALUES(@Username, @Password, @Email, 0);";

                    conn = new SqlConnection(connection);
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlParameter user = new SqlParameter();
                    user.ParameterName = "@Username";
                    user.Value = userName.Trim();
                    cmd.Parameters.Add(user);

                    SqlParameter pass = new SqlParameter();
                    pass.ParameterName = "@Password";
                    string passcheck = password.Trim();
                    pass.Value = encryption(passcheck);
                    cmd.Parameters.Add(pass);

                    SqlParameter emailadd = new SqlParameter();
                    emailadd.ParameterName = "@Email";
                    emailadd.Value = email;
                    cmd.Parameters.Add(emailadd);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    Session["LoggedIn"] = true;
                    Session["Username"] = userName;
                    Session["Admin"] = 0;

                    string getuid = "SELECT User_ID from [User] where User_Username = @username;";

                    conn = new SqlConnection(connection);
                    SqlCommand retrieve = new SqlCommand(getuid, conn);

                    SqlParameter userID = new SqlParameter();
                    userID.ParameterName = "@username";
                    userID.Value = userName.Trim();
                    retrieve.Parameters.Add(userID);

                    conn.Open();

                    int uid = (int)retrieve.ExecuteScalar();

                    if (uid > 0)
                    {
                        Session["UID"] = uid;
                    }


                    Response.Redirect("index.aspx");
                }
                finally
                {
                    if (conn != null) conn.Close();
                }
            }
            else
            {

            }
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            ValidateCredentials(usernameRegister.Text, passwordRegister.Text, emailRegister.Text);
        }
    }
}