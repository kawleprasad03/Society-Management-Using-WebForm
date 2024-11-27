<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="AddComplaintUser.aspx.cs" Inherits="SocietyManagement.AddComplaintUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center">
        <div class="card w-50">
            <div class="card-body">
                <h4 class="card-title">Add Complaint Description</h4>

                <div class="form-group">

                    <asp:TextBox ID="txtComplaintDescription" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="4" Columns="50" placeholder="Enter your complaint"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnAddComplaint" runat="server" Text="Add Complaint" CssClass="btn btn-primary" OnClick="btnAddComplaint_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
