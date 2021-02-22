using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerRepair
{
    public partial class login : System.Web.UI.Page
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

        private void ValidateCredentials(string userName, string password)
        {

            if (this.IsAlphaNumeric(userName) && userName.Length <= 50 && password.Length <= 50)
            {
                SqlConnection conn = null;

                try
                {
                    string sql = "Select User_ID, User_Admin from [User] where User_Username = @username and User_Password = @password;";

                    conn = new SqlConnection(connection);
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlParameter user = new SqlParameter();
                    user.ParameterName = "@username";
                    user.Value = userName.Trim();
                    cmd.Parameters.Add(user);

                    SqlParameter pass = new SqlParameter();
                    pass.ParameterName = "@password";

                    string decryptedPassword = password.Trim();

                    pass.Value = encryption(decryptedPassword);
                    System.Diagnostics.Trace.WriteLine(pass.Value);
                    cmd.Parameters.Add(pass);

                    conn.Open();

                    int id = -1;
                    int admin = 0;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader.GetInt32(0);
                            admin = reader.GetInt32(1);
                        }
                    }

                    if (id > -1)
                    {
                        Session["LoggedIn"] = true;
                        Session["Username"] = userName;
                        Session["UID"] = id;
                        Session["Admin"] = admin;
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid login information');</script>");
                    }
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

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            ValidateCredentials(usernameLogin.Text, passwordLogin.Text);
        }

        protected void usernameLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}