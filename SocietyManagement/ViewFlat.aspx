<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewFlat.aspx.cs" Inherits="SocietyManagement.ViewFlat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center">
        <div class="card w-50">
            <div class="card-body">
                <h4 class="card-title">Flat Details</h4>


                <div class="form-group">
                    <span class="details-label">Flat Number:</span>
                    <asp:Label ID="lblFlatNumber" runat="server"></asp:Label>
                </div>

                <div class="form-group">
                    <span class="details-label">Floor Number:</span>
                    <asp:Label ID="lblFloorNumber" runat="server"></asp:Label>
                </div>

                <div class="form-group">
                    <span class="details-label">Block Number:</span>
                    <asp:Label ID="lblBlockNumber" runat="server"></asp:Label>
                </div>

                <div class="form-group">
                    <span class="details-label">Type:</span>
                    <asp:Label ID="lblType" runat="server"></asp:Label>
                </div>

                <%-- <div class="form-group">
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            </div>--%>
            </div>
        </div>
    </div>
</asp:Content>
