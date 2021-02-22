<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ComputerRepair.WebForm3" %>
<%@ MasterType VirtualPath="~/Site1.Master" %>

<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <title>Repair - Register</title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="beforeContainer" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <section class="container">
		<div class="col-sm-6 col-md-6">
			<h3 class="dark-grey">Registration</h3>
				
			<div class="form-group col-lg-12">
				<label>Username</label>
                <asp:TextBox ID="usernameRegister" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requireusernameRegister" Display="Dynamic" ControlToValidate="usernameRegister" CssClass="text-danger" runat="server" ErrorMessage="You must enter a username."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="validateusernameRegister" Display="Dynamic" ValidationExpression="^.{6,20}$" CssClass="text-danger" ControlToValidate="usernameRegister" runat="server" ErrorMessage="Username must be 6 characters and no more than 20."></asp:RegularExpressionValidator>
            </div>
				
			<div class="form-group col-lg-6">
				<label>Password</label>
				<asp:TextBox ID="passwordRegister" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requirepasswordRegister" Display="Dynamic" ControlToValidate="passwordRegister" CssClass="text-danger" runat="server" ErrorMessage="You must enter a password."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="validatepasswordRegister" Display="Dynamic" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$" CssClass="text-danger" ControlToValidate="passwordRegister" runat="server" ErrorMessage="Password must be 8 characters, contain atleast 1 alphabetical letter, 1 number and 1 special character."></asp:RegularExpressionValidator>
			</div>
				
			<div class="form-group col-lg-6">
				<label>Repeat Password</label>
                <asp:TextBox ID="confirmPasswordRegister" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>                
                <asp:RequiredFieldValidator ID="requireconfirmPasswordRegister" Display="Dynamic" CssClass="text-danger" ControlToValidate="confirmPasswordRegister" runat="server" ErrorMessage="You must match the password in the confirm password field."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="validateconfirmPasswordRegister" Display="Dynamic" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$" CssClass="text-danger" ControlToValidate="confirmPasswordRegister" runat="server" ErrorMessage="Password must be 8 characters, contain atleast 1 alphabetical letter, 1 number and 1 special character."></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="compareconfirmPasswordRegister" runat="server" Display="Dynamic" CssClass="text-danger" ErrorMessage="Passwords must match." ControlToCompare="passwordRegister" ControlToValidate="confirmPasswordRegister"></asp:CompareValidator>
            </div>
								
			<div class="form-group col-lg-12">
				<label>Email Address</label>
				<asp:TextBox ID="emailRegister" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requireemailRegister" Display="Dynamic" CssClass="text-danger" ControlToValidate="emailRegister" runat="server" ErrorMessage="You must enter an e-mail address."></asp:RequiredFieldValidator>      
                <asp:RegularExpressionValidator ID="validateemailRegister" runat="server" Display="Dynamic" CssClass="text-danger" ControlToValidate="emailRegister" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="You must enter a valid e-mail address."></asp:RegularExpressionValidator>        
			</div>		
            
            <div class="form-group col-lg-12">
                 <asp:Button ID="registerButton" CssClass="btn btn-primary" runat="server" Text="Register" OnClick="registerButton_Click" />		
            </div>
		</div>
		
		<div class="col-sm-6 col-md-6">
			<h3 class="dark-grey">Terms and Conditions</h3>
			<p>
				By clicking on "Register" you agree to the terms and conditions.
			</p>
			<p>
				While rare, prices are subject to change based on exchange rate fluctuations - 
				should such a fluctuation happen, we may request an additional payment. You have the option to request a full refund or to pay the new price. (Paragraph 13.5.8)
			</p>
			<p>
				Should there be an error in the description or pricing of a product, we will provide you with a full refund (Paragraph 13.5.6)
			</p>
			<p>
				Acceptance of an order by us is dependent on our suppliers ability to provide the product. (Paragraph 13.5.6)
			</p>
		</div>
	</section>
</asp:Content>
