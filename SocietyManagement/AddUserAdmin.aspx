<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddUserAdmin.aspx.cs" Inherits="SocietyManagement.AddUserAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div>
     <h2>Add Users</h2>

  
    <div class="form-group">
        <label class="label">Enter UserName:</label>
        <asp:TextBox ID="txtusersname" runat="server" CssClass="input-box"></asp:TextBox>
    </div>

    <div class="form-group">
        <label class="label">Enter User Email</label>
        <asp:TextBox ID="txtemail" runat="server" CssClass="input-box"></asp:TextBox>
    </div>

    
    <div class="form-group">
        <label class="label">Enter password</label>
        <asp:TextBox ID="txtpass" runat="server" CssClass="input-box"></asp:TextBox>
    </div>

    

    <div class="button">
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
    </div>

  
</div>--%>
    <div class="container d-flex justify-content-center">
        <div class="card w-50" >
            <div class="card-body">
                <h4 class="card-title">Add Users</h4>
                <%--<p class="card-description">Basic form layout </p>--%>

                <div class="form-group">
                    <label class="label">Enter UserName:</label>
                    <asp:TextBox ID="txtusersname" runat="server" class="form-control"></asp:TextBox>

                </div>
                <div class="form-group">
                    <label class="label">Enter User Email</label>
                    <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>


                </div>
                <div class="form-group">
                    <label class="label">Enter password</label>
                    <asp:TextBox ID="txtpass" runat="server" class="form-control"></asp:TextBox>

                </div>

                <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-primary mr-2" OnClick="btnAdd_Click" />

            </div>
        </div>
    </div>
</asp:Content>
