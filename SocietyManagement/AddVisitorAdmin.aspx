<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddVisitorAdmin.aspx.cs" Inherits="SocietyManagement.AddVisitorAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center">
        <div class="card shadow-sm w-50">
            <div class="card-header bg-primary text-white">
                <h5 class="card-title mb-0"><i class="fas fa-user-plus"></i>Add Visitor</h5>
            </div>
            <div class="card-body">

                <div class="form-group">
                    <label for="DropDownList1">Flat Number</label>
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>

                <div class="form-group">
                    <label for="txtVisitorName">Visitor Name</label>
                    <asp:TextBox ID="txtVisitorName" CssClass="form-control" Placeholder="Enter Visitor Name" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtVisitorPhone">Visitor Phone</label>
                    <asp:TextBox ID="txtVisitorPhone" CssClass="form-control" Placeholder="Enter Visitor Phone" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtPersonToMeet">Person to Meet</label>
                    <asp:TextBox ID="txtPersonToMeet" CssClass="form-control" Placeholder="Enter Person to Meet" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtInTime">In Time</label>
                    <asp:TextBox ID="txtInTime" CssClass="form-control" TextMode="DateTimeLocal" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtReasonToVisit">Reason to Visit</label>
                    <asp:TextBox ID="txtReasonToVisit" CssClass="form-control" Placeholder="Enter Reason to Visit" runat="server"></asp:TextBox>
                </div>

                <div class="text-center">
                    <asp:Button ID="btnSave" CssClass="btn btn-primary" Text="Add Visitor" OnClick="btnSave_Click" runat="server" />
                    <%--<button type="button" class="btn btn-secondary ml-2" data-dismiss="modal">Cancel</button>--%>
                </div>

            </div>
        </div>
    </div>






</asp:Content>
