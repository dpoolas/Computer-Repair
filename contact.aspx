<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="ComputerRepair.contact" %>
<%@ MasterType VirtualPath="~/Site1.Master" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <title>Repair - Contact</title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="beforeContainer" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="col-md-6">
        <h3>Contact Us</h3>
            <div class="control-group form-group">
                <div class="controls">
                    <label>Full Name:</label>
                    <asp:TextBox ID="fullName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requireFullname" ControlToValidate="fullName" runat="server" ErrorMessage="You must enter your name." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="control-group form-group">
                <div class="controls">
                    <label>Phone Number:</label>
                    <asp:TextBox ID="phoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requirephoneNumber" ControlToValidate="phoneNumber" runat="server" ErrorMessage="You must enter a phone number." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="validatephoneNumber" runat="server" ErrorMessage="You must enter a valid phone number." ControlToValidate="phoneNumber" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" CssClass="text-danger" Display="Dynamic" ></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="control-group form-group">
                <div class="controls">
                    <label>Email Address:</label>
                    <asp:TextBox ID="emailAddress" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requireemailAddress" ControlToValidate="emailAddress" runat="server" ErrorMessage="You must enter an e-mail address." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="validateemailAddress" ControlToValidate="emailAddress" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="You must enter a valid e-mail address." CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="control-group form-group">
                <div class="controls">
                    <label>Message:</label>
                    <asp:TextBox ID="messageBox" TextMode="MultiLine" Rows="10" Columns="10" MaxLength="999" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requiremessageBox" ControlToValidate="messageBox" runat="server" ErrorMessage="You must enter a message." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div id="success"></div>
            <!-- For success/fail messages -->
            <div class="control-group form-group">
                <asp:Button ID="contactButton" CssClass="btn btn-primary" runat="server" Text="Send Message" OnClick="contactButton_Click" />
            </div>
    </div>
</asp:Content>
