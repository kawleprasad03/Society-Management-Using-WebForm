<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="invoice.aspx.cs" Inherits="SocietyManagement.invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center">
        <div class="card text-white w-50">
            <div class="card-header">
                <h4>Invoice</h4>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label class="font-weight-bold">Bill Title:</label>

                    <asp:Label ID="LabelBillTitle" runat="server" Text=""></asp:Label>
                </div>
                <div class="form-group">
                    <label class="font-weight-bold">Flat Number:</label>
                    <asp:Label ID="LabelFlatNumber" runat="server" Text=""></asp:Label>
                </div>
                <div class="form-group">
                    <label class="font-weight-bold">Bill Amount:</label>
                    <asp:Label ID="LabelBillAmount" runat="server" Text=""></asp:Label>
                </div>
                <div class="form-group">
                    <label class="font-weight-bold">Paid Amount:</label>
                    <asp:Label ID="LabelPaidAmount" runat="server" Text=""></asp:Label>
                </div>
                <div class="form-group">
                    <label class="font-weight-bold">Bill Month:</label>
                    <asp:Label ID="LabelBillMonth" runat="server" Text=""></asp:Label>
                </div>
                <div class="form-group">
                    <label class="font-weight-bold">Payment Date:</label>
                    <asp:Label ID="LabelPaymentDate" runat="server" Text=""></asp:Label>
                </div>
                <div class="form-group">
                    <label class="font-weight-bold">Payment Method:</label>
                    <asp:Label ID="LabelPaymentMethod" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
