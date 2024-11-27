<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddBillDataAdmin.aspx.cs" Inherits="SocietyManagement.AddBillDataAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex justify-content-center">
        <div class="card w-50">
            <div class="card-body">
                <h4 class="card-title">Add Bill</h4>
                <%--<p class="card-description">Basic form layout </p>--%>

                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Bill Title"></asp:Label>
                    <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>


                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Flat Number"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" class="form-control" runat="server"></asp:DropDownList>


                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Amount"></asp:Label>
                    <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>

                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Month"></asp:Label>
                    <asp:TextBox ID="TextBox3" class="form-control" runat="server" TextMode="Month"></asp:TextBox>

                </div>
                <%--<div class="form-check form-check-flat form-check-primary">
                    <label class="form-check-label">
                        <input type="checkbox" class="form-check-input">
                        Remember me
                    </label>
                </div>--%>
                <%--<button type="submit" class="btn btn-primary mr-2">Submit</button>--%>
                <asp:Button ID="Button1" runat="server" class="btn btn-primary mr-2" Text="Add" OnClick="Button1_Click" />

            </div>
        </div>
    </div>
</asp:Content>
