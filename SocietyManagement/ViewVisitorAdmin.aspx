<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewVisitorAdmin.aspx.cs" Inherits="SocietyManagement.ViewVisitorAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <div class="container d-flex justify-content-center">
        <div class="card w-50">
            <div class="card-body">
                <h4 class="card-title">Visitor Details</h4>
                <label><strong>Flat Number:</strong></label>
                <asp:Label ID="lblFlatNumber" runat="server" /><br />
                <label><strong>Visitor Name:</strong></label>
                <asp:Label ID="lblVisitorName" runat="server" /><br />
                <label><strong>Visitor Phone:</strong></label>
                <asp:Label ID="lblVisitorPhone" runat="server" /><br />
                <label><strong>Person to Visit:</strong></label>
                <asp:Label ID="lblPersonToVisit" runat="server" /><br />
                <label><strong>In Time:</strong></label>
                <asp:Label ID="lblInTime" runat="server" /><br />
                <%--<label><strong>Address:</strong></label>
        <asp:Label ID="lblAddress" runat="server" /><br />--%>
                <label><strong>Reason to Visit:</strong></label>
                <asp:Label ID="lblReasonToVisit" runat="server" /><br />
                <label><strong>Status:</strong></label>
                <asp:Label ID="lblStatus" runat="server" /><br />
                <label><strong>Created At:</strong></label>
                <asp:Label ID="lblCreatedAtDate" runat="server" /><br />


                <asp:Panel ID="panelOutDetails" runat="server" Visible="false">
                    <label><strong>Out Time:</strong></label>
                    <asp:Label ID="lblOutTime" runat="server" /><br />
                    <label><strong>Out Remark:</strong></label>
                    <asp:Label ID="lblOutRemark" runat="server" /><br />
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
