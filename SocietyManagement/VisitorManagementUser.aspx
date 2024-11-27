<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="VisitorManagementUser.aspx.cs" Inherits="SocietyManagement.VisitorManagementUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body">
            <h4 class="card-title">Visitor Management</h4>
            <div class="table-responsive">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="table table-hover" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <%-- <asp:BoundField DataField="VisitorID" HeaderText="ID" />--%>
                        <asp:BoundField DataField="FlatNumber" HeaderText="Flat Number" />
                        <asp:BoundField DataField="VisitorName" HeaderText="Visitor Name" />
                        <asp:BoundField DataField="VisitorPhone" HeaderText="Visitor Phone" />
                        <asp:BoundField DataField="personToVisit" HeaderText="Person to Meet" />
                        <asp:BoundField DataField="InTime" HeaderText="In Time" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                        <asp:BoundField DataField="OutTime" HeaderText="Out Time" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                        <asp:BoundField DataField="reasonToVisit" HeaderText="Reason To Visit" />
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status") %>' CssClass='<%# GetBadgeClass(Eval("status").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <%--<asp:Button ID="btnView" CommandArgument='<%# Eval("VisitorID") %>' runat="server" Text="View" CssClass="btn btn-warning btn-sm" OnClick="btnView_Click" />--%>
                                <asp:Button ID="btnView" CommandArgument='<%# Eval("id") %>' runat="server" Text="View" CommandName="View" CssClass="btn btn-warning btn-sm" />
                                <%-- <asp:Button ID="btnEdit" CommandArgument='<%# Eval("id") %>' runat="server" Text="Edit"  CommandName="Edit" CssClass="btn btn-primary btn-sm"  Enabled='<%# Session["VisitorEditingCompleted"] == null %>' />--%>
                                <%--<asp:Button ID="btnEdit" CommandArgument='<%# Eval("id") %>' runat="server" Text="Edit" CommandName="Edit" CssClass="btn btn-primary btn-sm" />--%>
                                <%--<asp:Button ID="btnDelete" CommandArgument='<%# Eval("id") %>' runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger btn-sm" />--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
