﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="manageservices.aspx.cs" Inherits="ComputerRepair.admin.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="beforeContainer" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
    <div class="well top-buffer table-responsive">
        <asp:GridView ID="requestsGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="Request_ID" DataSourceID="Requests" AllowPaging="True" AllowSorting="True" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" CssClass="table table-bordered table-responsive" OnSelectedIndexChanged="requestsGrid_SelectedIndexChanged" ValidateRequestMode="Disabled">
            <Columns>
                <asp:BoundField DataField="Request_ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Request_ID" />
                <asp:BoundField DataField="Request_UserID" HeaderText="UserID" SortExpression="Request_UserID" />
                <asp:BoundField DataField="Request_Type" HeaderText="Type" SortExpression="Request_Type" />
                <asp:BoundField DataField="Request_Problem" HeaderText="Problem" SortExpression="Request_Problem" />
                <asp:BoundField DataField="Request_Status" HeaderText="Status" SortExpression="Request_Status" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Requests" runat="server" ConnectionString="<%$ ConnectionStrings:ComputerRepairServiceConnectionString %>" DeleteCommand="DELETE FROM [Request] WHERE [Request_ID] = @Request_ID" InsertCommand="INSERT INTO [Request] ([Request_UserID], [Request_Type], [Request_Problem], [Request_Status]) VALUES (@Request_UserID, @Request_Type, @Request_Problem, @Request_Status)" SelectCommand="SELECT [Request_ID], [Request_UserID], [Request_Type], [Request_Problem], [Request_Status] FROM [Request]" UpdateCommand="UPDATE [Request] SET [Request_UserID] = @Request_UserID, [Request_Type] = @Request_Type, [Request_Problem] = @Request_Problem, [Request_Status] = @Request_Status WHERE [Request_ID] = @Request_ID">
            <DeleteParameters>
                <asp:Parameter Name="Request_ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Request_UserID" Type="Int32" />
                <asp:Parameter Name="Request_Type" Type="String" />
                <asp:Parameter Name="Request_Problem" Type="String" />
                <asp:Parameter Name="Request_Status" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Request_UserID" Type="Int32" />
                <asp:Parameter Name="Request_Type" Type="String" />
                <asp:Parameter Name="Request_Problem" Type="String" />
                <asp:Parameter Name="Request_Status" Type="String" />
                <asp:Parameter Name="Request_Details" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </div>
</asp:Content>
