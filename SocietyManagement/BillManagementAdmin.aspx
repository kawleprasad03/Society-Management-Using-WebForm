<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="BillManagementAdmin.aspx.cs" Inherits="SocietyManagement.BillManagementAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #GridView1 {
            border: none;
        }
    </style>

    <br>


    <div class="card">
        <div class="card-body">
            <h4 class="card-title">Bill Management</h4>
            <p class="card-description">
                <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" CssClass="btn btn-primary btn-sm" />
            </p>
            <div class="table-responsive">

                <asp:GridView ID="GridView1" class="table table-hover" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" BorderStyle="None" BorderWidth="0px" OnRowDataBound="GridView1_RowDataBound">
                    <%--AllowPaging="True" PageSize="1" OnPageIndexChanging="GridView1_PageIndexChanging"--%>
                    <Columns>
                        <asp:BoundField DataField="billTitle" HeaderText="Bill Title" />
                        <asp:BoundField DataField="flatNumber" HeaderText="Flat Number" />
                        <asp:BoundField DataField="billAmount" HeaderText="Bill Amount" />

                        <asp:TemplateField HeaderText="Paid Amount">
                            <ItemTemplate>
                                <asp:Label ID="LabelPaidAmount" runat="server"
                                    Text='<%# Eval("paidAmount") == DBNull.Value ? "Not Paid" : Eval("paidAmount").ToString() %>'
                                    CssClass='<%# Eval("paidAmount") == DBNull.Value ? "badge badge-danger" : "" %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="billMonth" HeaderText="Bill Month" />

                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("id") %>' Text="Edit" CssClass="btn btn-primary btn-sm" />
                                <asp:Button ID="btnView" runat="server" CommandName="View" CommandArgument='<%# Eval("id") %>' Text="View" CssClass="btn btn-warning btn-sm" />
                                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("id") %>' Text="Delete" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this data?');" />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>




</asp:Content>
