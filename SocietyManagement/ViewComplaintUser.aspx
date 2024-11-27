<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewComplaintUser.aspx.cs" Inherits="SocietyManagement.ViewComplaintUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <h2 class="mb-4">View Complaint</h2>

    </div>
    <div class="container d-flex justify-content-center">


        <!-- Message Label for displaying errors or messages -->
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

        <!-- Link to navigate back to Complaint Management page -->
        <%--<asp:HyperLink ID="lnkBackToComplaints" runat="server" NavigateUrl="~/ComplaintManagement.aspx" class="btn btn-secondary mb-4">Back to Complaints</asp:HyperLink>--%>

        <!-- Complaint Details Section -->
        <div class="card w-50">
            <div class="card-header">
                <h3 class="mb-0">Complaint Details</h3>
            </div>
            <div class="card-body">
                <!-- Displaying user name -->
                <div class="mb-3">
                    <strong>User Name:</strong>
                    <asp:Label ID="lblUserName" runat="server" class="ml-2"></asp:Label>
                </div>

                <!-- Displaying flat number -->
                <div class="mb-3">
                    <strong>Flat Number:</strong>
                    <asp:Label ID="lblFlatNumber" runat="server" class="ml-2"></asp:Label>
                </div>

                <!-- Displaying complaint details -->
                <div class="mb-3">
                    <strong>Complaint Details:</strong>
                    <asp:Label ID="lblComplaintDescription" runat="server" class="ml-2"></asp:Label>
                </div>

                <!-- Displaying status -->
                <div class="mb-3">
                    <strong>Status:</strong>
                    <asp:Label ID="lblStatus" runat="server" class="ml-2"></asp:Label>
                </div>

                <!-- Comments Section -->
                <div>
                    <h4>Master Comments</h4>

                    <!-- Repeater for displaying comments -->
                    <asp:Repeater ID="rptComments" runat="server">
                        <ItemTemplate>
                            <div class="border p-2 mb-2">
                                <!-- Display Comment Date & Time -->
                                <div><strong>Comment Date & Time:</strong> <%# Eval("createdAtDate", "{0:MM/dd/yyyy HH:mm:ss}") %></div>

                                <!-- Display Comment -->
                                <div><strong>Comment:</strong> <%# Eval("comment") %></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
