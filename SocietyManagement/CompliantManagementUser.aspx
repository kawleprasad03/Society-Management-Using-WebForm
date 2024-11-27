<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CompliantManagementUser.aspx.cs" Inherits="SocietyManagement.CompliantManagementUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>User Complaint Management</h2>
    <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-primary btn-sm" OnClick="Button1_Click" />
    <asp:GridView ID="gvAdminComplaints" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvAdminComplaints_RowDataBound" OnRowCommand="gvAdminComplaints_RowCommand" CssClass="table table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Complaint ID" SortExpression="id" />
            <asp:BoundField DataField="userName" HeaderText="User Name" SortExpression="userName" />
            <asp:BoundField DataField="flatNumber" HeaderText="Flat Number" SortExpression="flatNumber" />
            <asp:BoundField DataField="complaintDescription" HeaderText="Complaint Description" SortExpression="complaintDescription" />
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status") %>' CssClass='<%# GetBadgeClass(Eval("status").ToString()) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-info" />
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-warning" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="Delete" CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('Are you sure you want to delete this complaint?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
   
</asp:Content>
