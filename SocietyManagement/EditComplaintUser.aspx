<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="EditComplaintUser.aspx.cs" Inherits="SocietyManagement.EditComplaintUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center">
        <div class="card w-50">
            <div class="card-body">
                <h4 class="card-title">Edit Complaint</h4>

                <asp:Label ID="lblComplaintId" runat="server" Text="Complaint ID: " />
                <asp:Label ID="lblComplaintIdValue" runat="server" />

                <div class="form-group">
                    <label for="txtComplaint">Complaint Description:</label>
                    <asp:TextBox ID="txtComplaint" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
                </div>

                <!-- Status section removed -->

                <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
