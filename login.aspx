<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ComputerRepair.login" %>
<%@ MasterType VirtualPath="~/Site1.Master" %>

<asp:Content ID="link" ContentPlaceHolderID="head" runat="server">
    <title>Repair - Login</title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="beforeContainer" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
     <div class="col-sm-6 col-md-4">
        <h3 class="dark-grey">Login</h3>
		<div class="control-group form-group">
			<label class="control-label"  for="username">Username</label>
			<div class="controls">
                <asp:TextBox ID="usernameLogin" CssClass="form-control" runat="server" OnTextChanged="usernameLogin_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requireusernameLogin" runat="server" ErrorMessage="You must enter a username." ControlToValidate="usernameLogin" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
			</div>
		</div>
		<div class="control-group form-group">
			<label class="control-label" for="password">Password</label>
			<div class="controls">
			    <asp:TextBox ID="passwordLogin" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requirepasswordLogin" runat="server" ErrorMessage="You must enter a password." ControlToValidate="passwordLogin" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
			</div>
		</div>
		<div class="control-group form-group">
			<!-- Button -->
			<div class="controls">
                <asp:Button ID="buttonLogin" CssClass="btn btn-primary" runat="server" Text="Login" OnClick="buttonLogin_Click" />
			</div>
		</div>
	</div>
</asp:Content>
