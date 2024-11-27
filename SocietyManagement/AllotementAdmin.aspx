<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AllotementAdmin.aspx.cs" Inherits="SocietyManagement.AllotementAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-primary btn-sm" OnClick="Button1_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CssClass="table table-bordered">
    <Columns>
        <asp:BoundField DataField="allotedTo" HeaderText="Alloted To" />
        <asp:BoundField DataField="flatNumber" HeaderText="Flat Number" />
        <asp:BoundField DataField="type" HeaderText="Type" />
        <asp:BoundField DataField="moveInDate" HeaderText="Move In Date" />
        <asp:BoundField DataField="moveOutDate" HeaderText="Move Out Date" />
        
       
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-primary btn-sm" />
                <asp:Button ID="DeleteButton" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>--%>

    <div class="card">
        <div class="card-body">
            <h4 class="card-title">Allotment Management</h4>
            <p class="card-description">
                <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-primary btn-sm" OnClick="Button1_Click" />
            </p>
            <div class="table-responsive">

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" class="table table-hover">
                    <Columns>
                        <asp:BoundField DataField="allotedTo" HeaderText="Alloted To" />
                        <asp:BoundField DataField="flatNumber" HeaderText="Flat Number" />
                        <asp:BoundField DataField="type" HeaderText="Type" />
                        <asp:BoundField DataField="moveInDate" HeaderText="Move In Date" />
                        <asp:BoundField DataField="moveOutDate" HeaderText="Move Out Date" />


                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-primary btn-sm" />
                                <asp:Button ID="DeleteButton" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
