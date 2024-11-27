<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditAllotment.aspx.cs" Inherits="SocietyManagement.EditAllotment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <asp:Label ID="Label1" runat="server" Text="Select User"></asp:Label>
<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
<br>
<asp:Label ID="Label2" runat="server" Text="Flat Number"></asp:Label>
<asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
<br>

<asp:Label ID="Label3" runat="server" Text="Move In Date"></asp:Label>

<asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>

<br>
    <asp:Label ID="Label4" runat="server" Text="Move Out Date"></asp:Label>

<asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
<asp:Button ID="Button1" runat="server" Text="Edit" OnClick="Button1_Click" />--%>

    <div class="container d-flex justify-content-center">
        <div class="card w-50">
            <div class="card-body">
                <h4 class="card-title">Edit Allotment</h4>
                <%--<p class="card-description">Basic form layout </p>--%>

                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Select User"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control"></asp:DropDownList>


                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Flat Number"></asp:Label>
                    <asp:DropDownList ID="DropDownList2" runat="server" class="form-control"></asp:DropDownList>


                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Move In Date"></asp:Label>

                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" class="form-control"></asp:TextBox>

                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Move Out Date"></asp:Label>

                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" class="form-control"></asp:TextBox>

                </div>
                <asp:Button ID="Button1" runat="server" Text="Edit" OnClick="Button1_Click" class="btn btn-primary mr-2" />


            </div>
        </div>
    </div>
</asp:Content>
