<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditComplaintAdmin.aspx.cs" Inherits="SocietyManagement.EditComplaintAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container d-flex justify-content-center">
        <div class="card w-50">
            <div class="card-body">
                <h4 class="card-title">Edit Complaint</h4>
              

                <!-- Message display -->
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>


                <!-- Display User Name -->
                <div class="form-group">
                    <label for="lblUserName">User Name:</label>
                    <asp:Label ID="lblUserName" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <!-- Display Flat Number -->
                <div class="form-group">
                    <label for="lblFlatNumber">Flat Number:</label>
                    <asp:Label ID="lblFlatNumber" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <!-- Display Complaint Description -->
                <div class="form-group">
                    <label for="lblComplaintDescription">Complaint Description:</label>
                    <asp:Label ID="lblComplaintDescription" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <!-- Display Current Status -->
                <div class="form-group">
                    <label for="lblStatus">Status:</label>
                    <asp:Label ID="lblStatus" runat="server" ReadOnly="true"></asp:Label>
                </div>

                <!-- Textbox for Master Comment -->
                <div class="form-group">
                    <label for="txtMasterComment">Master Comment:</label>
                    <asp:TextBox ID="txtMasterComment" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Enter your comment"></asp:TextBox>
                </div>

                <!-- Dropdown for Status Update -->
                <div class="form-group">
                    <label for="ddlStatus">Status Update:</label>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                        <%--<asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>--%>
                        <asp:ListItem Text="In Process" Value="In Process"></asp:ListItem>
                        <asp:ListItem Text="Resolved" Value="Resolved"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <!-- Button for Updating Status -->
                <div class="form-group">
                    <asp:Button ID="btnUpdateStatus" runat="server" Text="Update Status" OnClick="btnUpdateStatus_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
