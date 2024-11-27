<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditUserAdmin.aspx.cs" Inherits="SocietyManagement.EditUserAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <h2>Edit User Details</h2>

    <div class="detail-row">
        <span class="details-label">User Name:</span>
        <asp:TextBox ID="txtusersname" runat="server" CssClass="details-input"></asp:TextBox>
    </div>

    <div class="detail-row">
        <span class="details-label">Email:</span>
        <asp:TextBox ID="txtemail" runat="server" CssClass="details-input"></asp:TextBox>
    </div>

    <div class="detail-row">
        <span class="details-label">Password:</span>
        <asp:TextBox ID="txtpass" runat="server" CssClass="details-input"></asp:TextBox>
    </div>

    <div class="detail-row">
        <asp:Button ID="btnBack" runat="server" Text="Save Changes" OnClick="btnBack_Click" CssClass="details-button" />
    </div>--%>
    <div class="container d-flex justify-content-center">
        <div class="card w-50">
            <div class="card-body">
                <h4 class="card-title">Edit User</h4>
                <%--<p class="card-description">Basic form layout </p>--%>

                <div class="form-group">
                    <span class="details-label">User Name:</span>
                    <asp:TextBox ID="txtusersname" runat="server" class="form-control"></asp:TextBox>

                </div>
                <div class="form-group">
                    <span class="details-label">Email:</span>
                    <asp:TextBox ID="txtemail" runat="server" class="form-control" ReadOnly="True" style="background: none;"></asp:TextBox>


                </div>
                <div class="form-group">
                    <span class="details-label">Password:</span>
                    <asp:TextBox ID="txtpass" runat="server" class="form-control"></asp:TextBox>

                </div>


                <asp:Button ID="btnBack" runat="server" Text="Save Changes" OnClick="btnBack_Click" class="btn btn-primary mr-2" />
            </div>
        </div>
    </div>
</asp:Content>
