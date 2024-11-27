<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditFlat.aspx.cs" Inherits="SocietyManagement.EditFlat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <h2>Edit flat </h2>

    <div class="form-group">
        <label class="label">Flat Number:</label>
        <asp:TextBox ID="txtFlatNumber" runat="server" CssClass="input-box"></asp:TextBox>
    </div>

    <div class="form-group">
        <label class="label">Floor Number:</label>
        <asp:TextBox ID="txtFloorNumber" runat="server" CssClass="input-box"></asp:TextBox>
    </div>

    <div class="form-group">
        <label class="label">Block Number:</label>
        <asp:TextBox ID="txtBlockNumber" runat="server" CssClass="input-box"></asp:TextBox>
    </div>

    <div class="form-group">
        <label class="label">Type:</label>
        <asp:DropDownList ID="ddlType" runat="server" CssClass="input-box">
            <asp:ListItem Text="1 RK" Value="1 RK" />
            <asp:ListItem Text="1 BHK" Value="1 BHK" />
            <asp:ListItem Text="2 BHK" Value="2 BHK" />
            <asp:ListItem Text="3 BHK" Value="3 BHK" />
        </asp:DropDownList>
    </div>

    <div class="button">
        <asp:Button ID="btnAdd" runat="server" Text="Edit" OnClick="btnEdit_Click" />
    </div>--%>

    <div class="container d-flex justify-content-center">
        <div class="card w-50">
            <div class="card-body">
                <h4 class="card-title">Edit flat </h4>
                <%--<p class="card-description">Basic form layout </p>--%>

                <div class="form-group">
                    <label class="label">Flat Number:</label>
                    <asp:TextBox ID="txtFlatNumber" runat="server" class="form-control"></asp:TextBox>


                </div>
                <div class="form-group">
                    <label class="label">Floor Number:</label>
                    <asp:TextBox ID="txtFloorNumber" runat="server" class="form-control"></asp:TextBox>


                </div>
                <div class="form-group">
                    <label class="label">Block Number:</label>
                    <asp:TextBox ID="txtBlockNumber" runat="server" class="form-control"></asp:TextBox>

                </div>
                <div class="form-group">
                    <label class="label">Type:</label>
                    <asp:DropDownList ID="ddlType" runat="server" class="form-control">
                        <asp:ListItem Text="1 RK" Value="1 RK" />
                        <asp:ListItem Text="1 BHK" Value="1 BHK" />
                        <asp:ListItem Text="2 BHK" Value="2 BHK" />
                        <asp:ListItem Text="3 BHK" Value="3 BHK" />
                    </asp:DropDownList>

                </div>
                <asp:Button ID="btnAdd" runat="server" Text="Edit" class="btn btn-primary mr-2" OnClick="btnEdit_Click" />

            </div>
        </div>
    </div>
</asp:Content>
