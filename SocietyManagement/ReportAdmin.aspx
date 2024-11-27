<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ReportAdmin.aspx.cs" Inherits="SocietyManagement.ReportAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<br>
    <asp:DropDownList runat="server">
        <asp:ListItem Selected="True" disabled>Select Option</asp:ListItem>
        <asp:ListItem>Bills</asp:ListItem>
        <asp:ListItem>Complaints</asp:ListItem>
        <asp:ListItem>Visitor</asp:ListItem>
    </asp:DropDownList>
&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Start Date : "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="End Date : "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server" TextMode="DateTime"></asp:TextBox>
  
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Show data " />
  
    <br>
    <asp:Button ID="Button1" runat="server" Text="Export" />
    <br>
    <asp:GridView runat="server"></asp:GridView>--%>

    <%--<asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Selected="True" disabled>Select Option</asp:ListItem>
        <asp:ListItem>Bills</asp:ListItem>
        <asp:ListItem>Complaints</asp:ListItem>
        <asp:ListItem>Visitor</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Start Date : "></asp:Label>
    &nbsp;<asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="End Date : "></asp:Label>
    &nbsp;<asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Show Data" OnClick="Button2_Click" />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Export" OnClick="Button1_Click" />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True"></asp:GridView>

    &nbsp;--%>


    <div class="container mt-4">
        <div class="card">
            <div class="card-body">
                <h4 class="card-title">Generate Report</h4>
                <div class="form-group d-flex">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="20%">
                        <asp:ListItem Selected="True" disabled>Select Option</asp:ListItem>
                        <asp:ListItem>Bills</asp:ListItem>
                        <asp:ListItem>Complaints</asp:ListItem>
                        <asp:ListItem>Visitor</asp:ListItem>
                    </asp:DropDownList>&nbsp;&nbsp;
       
                    <label for="TextBox1" class="mr-2 mt-3">Start Date:</label>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" CssClass="form-control d-inline-block" Style="width: auto;"></asp:TextBox>&nbsp;&nbsp;
       
                    <label for="TextBox2" class="ml-3 mr-2 mt-3">End Date:</label>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" CssClass="form-control d-inline-block" Style="width: auto;"></asp:TextBox>&nbsp;&nbsp;
       
                    <asp:Button ID="Button2" runat="server" Text="Show Data" OnClick="Button2_Click" CssClass="btn btn-primary mr-2 mt-1" />
                </div>

                <div class="form-group">
                    <asp:Button ID="Button1" runat="server" Text="Export" OnClick="Button1_Click" CssClass="btn btn-success" />
                </div>

                <div class="form-group">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" class="table table-hover" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered mt-3"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
