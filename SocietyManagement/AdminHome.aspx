<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="SocietyManagement.AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-4 grid-margin">
            <div class="card">
                <div class="card-body">
                    <h4>Total Flats</h4>
                    <div class="row">
                        <div class="col-8 col-sm-12 col-xl-8 my-auto">
                            <div class="d-flex d-sm-block d-md-flex align-items-center">
                                <h5 class="mb-0">
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                </h5>
                                <%--<p class="text-success ml-2 mb-0 font-weight-medium">+3.5%</p>--%>
                            </div>
                            <%--<h6 class="text-muted font-weight-normal">11.38% Since last month</h6>--%>
                        </div>
                     <%--   <div class="col-4 col-sm-12 col-xl-4 text-center text-xl-right">
                            <i class="icon-lg mdi mdi-codepen text-primary ml-auto"></i>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-4 grid-margin">
            <div class="card">
                <div class="card-body">
                    <h4>Total Bills</h4>
                    <div class="row">
                        <div class="col-8 col-sm-12 col-xl-8 my-auto">
                            <div class="d-flex d-sm-block d-md-flex align-items-center">
                                <h5 class="mb-0">
                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                </h5>
                                <%--<p class="text-success ml-2 mb-0 font-weight-medium">+8.3%</p>--%>
                            </div>
                            <%--<h6 class="text-muted font-weight-normal">9.61% Since last month</h6>--%>
                        </div>
                       <%-- <div class="col-4 col-sm-12 col-xl-4 text-center text-xl-right">
                            <i class="icon-lg mdi mdi-wallet-travel text-danger ml-auto"></i>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-4 grid-margin">
            <div class="card">
                <div class="card-body">
                    <h4>Total Allotments</h4>
                    <div class="row">
                        <div class="col-8 col-sm-12 col-xl-8 my-auto">
                            <div class="d-flex d-sm-block d-md-flex align-items-center">
                                <h5 class="mb-0">
                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                </h5>
                                <%--<p class="text-danger ml-2 mb-0 font-weight-medium">-2.1% </p>--%>
                            </div>
                            <%--<h6 class="text-muted font-weight-normal">2.27% Since last month</h6>--%>
                        </div>
                       <%-- <div class="col-4 col-sm-12 col-xl-4 text-center text-xl-right">
                            <i class="icon-lg mdi mdi-monitor text-success ml-auto"></i>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
    <div class="col-sm-4 grid-margin">
        <div class="card">
            <div class="card-body">
                <h4>Total Visitors</h4>
                <div class="row">
                    <div class="col-8 col-sm-12 col-xl-8 my-auto">
                        <div class="d-flex d-sm-block d-md-flex align-items-center">
                            <h5 class="mb-0">
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                            </h5>
                            <%--<p class="text-success ml-2 mb-0 font-weight-medium">+3.5%</p>--%>
                        </div>
                        <%--<h6 class="text-muted font-weight-normal">11.38% Since last month</h6>--%>
                    </div>
                 <%--   <div class="col-4 col-sm-12 col-xl-4 text-center text-xl-right">
                        <i class="icon-lg mdi mdi-codepen text-primary ml-auto"></i>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="col-sm-4 grid-margin">
        <div class="card">
            <div class="card-body">
                <h4>Total Complaints</h4>
                <div class="row">
                    <div class="col-8 col-sm-12 col-xl-8 my-auto">
                        <div class="d-flex d-sm-block d-md-flex align-items-center">
                            <h5 class="mb-0">
                                <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                            </h5>
                            <%--<p class="text-success ml-2 mb-0 font-weight-medium">+8.3%</p>--%>
                        </div>
                        <%--<h6 class="text-muted font-weight-normal">9.61% Since last month</h6>--%>
                    </div>
                   <%-- <div class="col-4 col-sm-12 col-xl-4 text-center text-xl-right">
                        <i class="icon-lg mdi mdi-wallet-travel text-danger ml-auto"></i>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="col-sm-4 grid-margin">
        <div class="card">
            <div class="card-body">
                <h4>Total Resolved Complaints</h4>
                <div class="row">
                    <div class="col-8 col-sm-12 col-xl-8 my-auto">
                        <div class="d-flex d-sm-block d-md-flex align-items-center">
                            <h5 class="mb-0">
                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                            </h5>
                            <%--<p class="text-danger ml-2 mb-0 font-weight-medium">-2.1% </p>--%>
                        </div>
                        <%--<h6 class="text-muted font-weight-normal">2.27% Since last month</h6>--%>
                    </div>
                   <%-- <div class="col-4 col-sm-12 col-xl-4 text-center text-xl-right">
                        <i class="icon-lg mdi mdi-monitor text-success ml-auto"></i>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
</div>

        <div class="row">
    <div class="col-sm-4 grid-margin">
        <div class="card">
            <div class="card-body">
                <h4>Total UnResolved Complaints</h4>
                <div class="row">
                    <div class="col-8 col-sm-12 col-xl-8 my-auto">
                        <div class="d-flex d-sm-block d-md-flex align-items-center">
                            <h5 class="mb-0">
                                <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                            </h5>
                            <%--<p class="text-success ml-2 mb-0 font-weight-medium">+3.5%</p>--%>
                        </div>
                        <%--<h6 class="text-muted font-weight-normal">11.38% Since last month</h6>--%>
                    </div>
                 <%--   <div class="col-4 col-sm-12 col-xl-4 text-center text-xl-right">
                        <i class="icon-lg mdi mdi-codepen text-primary ml-auto"></i>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="col-sm-4 grid-margin">
        <div class="card">
            <div class="card-body">
                <h4>Total In Progress Complaints</h4>
                <div class="row">
                    <div class="col-8 col-sm-12 col-xl-8 my-auto">
                        <div class="d-flex d-sm-block d-md-flex align-items-center">
                            <h5 class="mb-0">
                                <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                            </h5>
                            <%--<p class="text-success ml-2 mb-0 font-weight-medium">+8.3%</p>--%>
                        </div>
                        <%--<h6 class="text-muted font-weight-normal">9.61% Since last month</h6>--%>
                    </div>
                   <%-- <div class="col-4 col-sm-12 col-xl-4 text-center text-xl-right">
                        <i class="icon-lg mdi mdi-wallet-travel text-danger ml-auto"></i>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    
</div>
</asp:Content>
