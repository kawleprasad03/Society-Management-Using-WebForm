<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="BillPay.aspx.cs" Inherits="SocietyManagement.BillPay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
    <div class="container d-flex justify-content-center">

        <!-- Card for Bill Details -->
        <div class="card w-50" style="color: white">
            <div class="card-header">
                <h4>Pay Bill</h4>
            </div>
            <div class="card-body">
                <%--<asp:Label ID="billid" runat="server"></asp:Label>--%>
                <asp:HiddenField ID="HiddenField1" runat="server" />
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


                <%--   <asp:Panel ID="PanelPaymentDetails" runat="server" Visible="false">--%>
                <div class="form-group">
                    <asp:Label ID="LabelPaidAmount" runat="server" Text="Paid Amount:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                <%--<asp:Label ID="LabelPaidAmountValue" runat="server" ></asp:Label>--%>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="LabelPaymentDate" runat="server" Text="Payment Date:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                <%--<asp:Label ID="LabelPaymentDateValue" runat="server" ></asp:Label>--%>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" class="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="LabelPaymentMethod" runat="server" Text="Payment Method:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                <%--<asp:Label ID="LabelPaymentMethodValue" runat="server" ></asp:Label>--%>
                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                        <asp:ListItem Selected="True" disabled>Select Option</asp:ListItem>
                        <asp:ListItem>Cash</asp:ListItem>
                        <asp:ListItem>Online</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Button ID="Button1" runat="server" class="btn btn-primary mr-2" Text="Pay" OnClick="Button1_Click" />

            </div>
        </div>
    </div>

</asp:Content>
