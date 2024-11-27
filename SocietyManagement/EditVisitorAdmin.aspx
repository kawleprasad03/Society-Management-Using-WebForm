<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditVisitorAdmin.aspx.cs" Inherits="SocietyManagement.EditVisitorAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center">

        <div class="card w-50">
            <div class="card-body">
                <h4 class="card-title">Visitor Details</h4>

                <!-- Display visitor details -->
                <div class="form-group">
                    <label>Flat Number:</label>
                    <asp:Label ID="lblFlatNumber" runat="server"></asp:Label>
                </div>
                <div class="form-group">
                    <label>Visitor Name:</label>
                    <asp:Label ID="lblVisitorName" runat="server"></asp:Label>
                </div>
                <div class="form-group">
                    <label>Visitor Phone:</label>
                    <asp:Label ID="lblVisitorPhone" runat="server"></asp:Label>
                </div>
                <div class="mb-3">
                    <label>Person to Meet:</label>
                    <asp:Label ID="lblPersonToMeet" runat="server"></asp:Label>
                </div>
                <div class="form-group">
                    <label>In Time:</label>
                    <asp:Label ID="lblInTime" runat="server"></asp:Label>
                </div>

                <div class="form-group">
                    <label>Reason to Visit:</label>
                    <asp:Label ID="lblReasonToVisit" runat="server"></asp:Label>
                </div>

                <div class="form-group">
                    <label>Status:</label>
                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                </div>

                <div class="form-group">
                    <label>Out Time:</label>
                    <asp:TextBox ID="txtOutTime" runat="server" CssClass="form-control" require="required" TextMode="DateTimeLocal"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Out Remark:</label>
                    <asp:TextBox ID="txtOutRemark" runat="server" CssClass="form-control" require="required" Placeholder="Enter Out Remark"></asp:TextBox>
                </div>

                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
