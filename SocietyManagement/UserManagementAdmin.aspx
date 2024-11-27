<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserManagementAdmin.aspx.cs" Inherits="SocietyManagement.UserManagementAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<asp:Button ID="Button1" runat="server" Text="Add Users" class="btn btn-primary mr-2" OnClick="Button1_Click" />
    <asp:GridView ID="GridViewFlats" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewFlats_RowCommand">
        <columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="userName" HeaderText="UserName" />
            <asp:BoundField DataField="email" HeaderText="email" />
            <asp:BoundField DataField="password" HeaderText="password" />
            <asp:BoundField DataField="urole" HeaderText="urole" />

            <asp:TemplateField HeaderText="Actions">
                <itemtemplate>
                    <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" CommandArgument='<%# Eval("Id") %>' />
                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CommandArgument='<%# Eval("Id") %>' />
                </itemtemplate>
            </asp:TemplateField>
        </columns>
    </asp:GridView>--%>

     <div class="card">
     <div class="card-body">
         <h4 class="card-title">User Management</h4>
         <p class="card-description">
            <asp:Button ID="Button1" runat="server" Text="Add Users" class="btn btn-primary mr-2" OnClick="Button1_Click" />
         </p>
         <div class="table-responsive">
              <asp:GridView ID="GridViewFlats" class="table table-hover" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewFlats_RowCommand">
     <columns>
         <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
         <asp:BoundField DataField="userName" HeaderText="UserName" />
         <asp:BoundField DataField="email" HeaderText="email" />
         <asp:BoundField DataField="password" HeaderText="password" />
         <asp:BoundField DataField="urole" HeaderText="urole" />

         <asp:TemplateField HeaderText="Actions">
             <itemtemplate>
                 <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary btn-sm"/>
                 <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this data?');"/>
             </itemtemplate>
         </asp:TemplateField>
     </columns>
 </asp:GridView>
            
         </div>
     </div>
 </div>



    
</asp:Content>
