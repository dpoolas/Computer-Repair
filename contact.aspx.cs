using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputerRepair
{
    public partial class contact : System.Web.UI.Page
    {
        MailMessage msg = new MailMessage();
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.linkContact.Attributes["class"] = "active";
        }



        protected void SendMail(string fullname, string phonenumber, string message, string email)
        {
            try
            {
                string fullmessage = fullname + "\n\n\n" + phonenumber + "\n\n\n" + message;

                msg.Subject = "Customer Service - " + email;
                msg.Body = fullmessage;
                msg.From = new MailAddress("email");
                msg.To.Add("email");
                msg.IsBodyHtml = false;
                client.Host = "smtp.gmail.com";
                System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("email", "password");
                client.Port = int.Parse("587");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicauthenticationinfo;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(msg);
                Response.Write("<script>alert('Your message has been sent to the administrators.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error has occured, sorry about that.');</script>");
            }
        }



        protected void contactButton_Click(object sender, EventArgs e)
        {
            SendMail(fullName.Text, phoneNumber.Text, messageBox.Text, emailAddress.Text);
        }
    }
}