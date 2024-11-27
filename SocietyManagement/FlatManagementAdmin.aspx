<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="FlatManagementAdmin.aspx.cs" Inherits="SocietyManagement.FlatManagementAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:GridView ID="GridViewFlats" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewFlats_RowCommand">
            <columns>
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="FlatNumber" HeaderText="Flat Number" />
                <asp:BoundField DataField="FloorNumber" HeaderText="Floor Number" />
                <asp:BoundField DataField="BlockNumber" HeaderText="Block Number" />
                <asp:BoundField DataField="Type" HeaderText="Type" />

                <asp:TemplateField HeaderText="Actions">
                    <itemtemplate>
                        <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                        <asp:Button ID="btnView" runat="server" CommandName="View" Text="View" CommandArgument='<%# Eval("Id") %>' />
                        <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CommandArgument='<%# Eval("Id") %>' />
                    </itemtemplate>
                </asp:TemplateField>
            </columns>
        </asp:GridView>
    </div>--%>

    <div class="card">
        <div class="card-body">
            <h4 class="card-title">Flat Management</h4>
            <p class="card-description">
                <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" CssClass="btn btn-primary btn-sm" />
            </p>
            <div class="table-responsive">

                <asp:GridView ID="GridViewFlats" runat="server" class="table table-hover" AutoGenerateColumns="False" OnRowCommand="GridViewFlats_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="FlatNumber" HeaderText="Flat Number" />
                        <asp:BoundField DataField="FloorNumber" HeaderText="Floor Number" />
                        <asp:BoundField DataField="BlockNumber" HeaderText="Block Number" />
                        <asp:BoundField DataField="Type" HeaderText="Type" />

                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary btn-sm"/>
                                <asp:Button ID="btnView" runat="server" CommandName="View" Text="View" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-warning btn-sm"/>
                                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this data?');"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
