<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewBillAdmin.aspx.cs" Inherits="SocietyManagement.ViewBillAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:Label ID="LabelBillTitle" runat="server" Text="Bill Title:"></asp:Label>
    <asp:Label ID="LabelBillTitleValue" runat="server"></asp:Label>
    <br />

    <asp:Label ID="LabelFlatNumber" runat="server" Text="Flat Number:"></asp:Label>
    <asp:Label ID="LabelFlatNumberValue" runat="server"></asp:Label>
    <br />

    <asp:Label ID="LabelBillAmount" runat="server" Text="Bill Amount:"></asp:Label>
    <asp:Label ID="LabelBillAmountValue" runat="server"></asp:Label>
    <br />

    <asp:Label ID="LabelBillMonth" runat="server" Text="Bill Month:"></asp:Label>
    <asp:Label ID="LabelBillMonthValue" runat="server"></asp:Label>
    <br />

  
    <asp:Panel ID="PanelPaymentDetails" runat="server" Visible="false">
        <asp:Label ID="LabelPaidAmount" runat="server" Text="Paid Amount:"></asp:Label>
        <asp:Label ID="LabelPaidAmountValue" runat="server"></asp:Label>
        <br />

        <asp:Label ID="LabelPaymentDate" runat="server" Text="Payment Date:"></asp:Label>
        <asp:Label ID="LabelPaymentDateValue" runat="server"></asp:Label>
        <br />

        <asp:Label ID="LabelPaymentMethod" runat="server" Text="Payment Method:"></asp:Label>
        <asp:Label ID="LabelPaymentMethodValue" runat="server"></asp:Label>
    </asp:Panel>--%>

    <div class="container d-flex justify-content-center">
        <!-- Card for Bill Details -->
        <div class="card w-50" style="color: white">
            <div class="card-header">
                <h4>Bill Details</h4>
            </div>
            <div class="card-body">
                <div class="form-group">

                    <asp:Label ID="LabelBillTitle" runat="server" Text="Bill Title:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelBillTitleValue" runat="server"></asp:Label>
                </div>

                <div class="form-group">

                    <asp:Label ID="LabelFlatNumber" runat="server" Text="Flat Number:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelFlatNumberValue" runat="server"></asp:Label>
                </div>

                <div class="form-group">
                    <asp:Label ID="LabelBillAmount" runat="server" Text="Bill Amount:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelBillAmountValue" runat="server"></asp:Label>
                </div>

                <div class="form-group">
                    <asp:Label ID="LabelBillMonth" runat="server" Text="Bill Month:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelBillMonthValue" runat="server"></asp:Label>
                </div>


                <asp:Panel ID="PanelPaymentDetails" runat="server" Visible="false">
                    <div class="form-group">
                        <asp:Label ID="LabelPaidAmount" runat="server" Text="Paid Amount:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="LabelPaidAmountValue" runat="server"></asp:Label>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="LabelPaymentDate" runat="server" Text="Payment Date:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="LabelPaymentDateValue" runat="server"></asp:Label>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="LabelPaymentMethod" runat="server" Text="Payment Method:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="LabelPaymentMethodValue" runat="server"></asp:Label>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>


</asp:Content>
