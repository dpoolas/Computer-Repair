<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="services.aspx.cs" Inherits="ComputerRepair.WebForm2"%>
<%@ MasterType VirtualPath="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="beforeContainer" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
    <%# Eval("detailsTextbox").ToString().Replace("\n","<br />") %>
    <div id="Error" runat="server">
        <h1 class="text-danger">Login to view this page.</h1>
    </div>
    <div id="row" runat="server">
        <div id="serviceContent" runat="server">
            <h3 class="text-info">Service Form Progress</h3>
                <asp:ScriptManager ID="progressScript" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="progressupdatePanel"  ChildrenAsTriggers="false" UpdateMode="Conditional" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="servicetypeDropdown" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="serviceproblemDropdown" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="detailsTextbox" EventName="TextChanged" />
                    </Triggers>
                    <ContentTemplate>
                        Percent: <asp:Label ID="textProgress" runat="server" Text="0%"></asp:Label>
                        <div class="progress">
                            <div runat="server" id="servicesProgress" class="progress-bar progress-bar-info progress-bar-striped active" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width:1%"></div>
                        </div>
                     </ContentTemplate>
                </asp:UpdatePanel>
                <div class="col-sm-6 col-md-4">
                <div class="control-group form-group">
                    <label class="control-label">Type</label>
                    <div class="controls">
                    <asp:DropDownList ID="servicetypeDropdown" runat="server" OnSelectedIndexChanged="servicetypeDropdown_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem>None</asp:ListItem>
                        <asp:ListItem>Desktop</asp:ListItem>
                        <asp:ListItem>Tablet</asp:ListItem>
                        <asp:ListItem>Laptop</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group form-group">
                    <label class="control-label">Problem</label>
                    <div class="controls">
                    <asp:UpdatePanel ID="problemUpdate"  ChildrenAsTriggers="false" UpdateMode="Conditional" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="servicetypeDropdown" EventName="SelectedIndexChanged" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:DropDownList ID="serviceproblemDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="serviceproblemDropdown_SelectedIndexChanged">
                                <asp:ListItem Value="None" Text="None"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                </div>
        </div>
        <div class="col-sm-6 col-md-10">
            <div class="control-group form-group">
                <label class="control-label">Details</label>
                <div class="controls">
                    <asp:TextBox ID="detailsTextbox" runat="server" TextMode="MultiLine" Rows="10" Columns="9" MaxLength="999" CssClass="form-control col-sm-6" AutoPostBack="true" Wrap="true" OnTextChanged="detailsTextbox_TextChanged"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-sm-6 col-md-10">
            <asp:UpdatePanel ID="UpdatePanel1"  ChildrenAsTriggers="true" UpdateMode="Always" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="servicetypeDropdown" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="serviceproblemDropdown" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="detailsTextbox" EventName="TextChanged" />
                    <asp:PostBackTrigger ControlID="serviceSubmitform"/>
                </Triggers>
                <ContentTemplate>
                   <div runat="server" id="submitForm" class="control-group form-group">
                        <div runat="server" class="controls">
                            <asp:Button ID="serviceSubmitform" runat="server" Text="Submit" CssClass="btn-primary" OnClick="serviceSubmitform_Click" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        </div>
    </div>
</asp:Content>
