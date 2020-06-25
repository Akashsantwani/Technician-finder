<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="<%=ResolveClientUrl("~/Content/assets/css/custom.css") %>" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphHomeMaster" runat="Server">
    <%--<asp:ScriptManager runat="server" ID="home1"></asp:ScriptManager>--%>
    <div class="backimg container-fluid" style="height: auto">
        <div class="row justify-content-md-center" style="padding-top: 2%; text-align: center;">
            <h1><strong style="font-weight: bolder; color: #FFFFFF">Get Expert service at your home</strong></h1>
        </div>
        <div class="row justify-content-md-center" style="padding-top: 1%; text-align: center">
            <h3><strong style="font-weight: bolder; color: #FFFFFF">Instantly hire technician at your hands</strong></h3>
        </div>
        <div class="container" style="padding-bottom: 5%;">
            <div class="row justify-content-md-center" style="padding-top: 5%; margin: auto;">
                <div class="col-md-3 col-lg-3 col-sm-12">
                    <div class="form-group">
                        <%--<asp:UpdatePanel runat="server" ID="up1">
                            <ContentTemplate>--%>
                                <asp:DropDownList OnSelectedIndexChanged="ddlJobType_SelectedIndexChanged" runat="server" ID="ddlCity" CssClass="form-control kt-selectpicker" data-live-search="true" data-size="7" />
                                <asp:RequiredFieldValidator InitialValue="-1" ID="rfvCity" runat="server" ControlToValidate="ddlCity" ValidationGroup="search" ErrorMessage="please select city" ForeColor="Red" Display="Dynamic" />
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
                <div class="col-md-3 col-lg-3 col-sm-12">
                    <div class="form-group">
                       <%-- <asp:UpdatePanel runat="server" ID="up2">
                            <ContentTemplate>--%>
                                <%--<asp:TextBox runat="server" ID="txtSearch" class="form-control kt-selectpicker" AutoPostBack="true" placeholder="Enter Service name" OnTextChanged="txtSearch_TextChanged" />--%>
                                <asp:DropDownList OnSelectedIndexChanged="ddlJobType_SelectedIndexChanged" runat="server" ID="ddlJobType" CssClass="form-control kt-selectpicker" data-live-search="true" data-size="7" />
                                <span class="form-text text-muted" style="color: white;">Ex. AC Reparing, Plumber, Electrician etc.</span>
                                <%--<asp:RangeValidator ID="rvtype" runat="server" ValidationGroup="search" ControlToValidate="ddlJobType" ErrorMessage="please select service" ForeColor="Red" Display="Dynamic" MinimumValue="0" MaximumValue="99"></asp:RangeValidator>--%>
                                <asp:RequiredFieldValidator InitialValue="-1" ID="rfvJobtype" runat="server" ControlToValidate="ddlJobType" ValidationGroup="search" ErrorMessage="please select Service" ForeColor="Red" Display="Dynamic" />
                           <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
                <div class="justify-content-md-center col-md-1 col-lg-1 col-sm-12" style="text-align: center; width: 100%;">
                    <%--<asp:HyperLink runat="server" ID="btnSearch"  Text="Search" class="btn btn-brand btn-elevate btn-elevate-air"/>&nbsp;--%>
                    <asp:LinkButton runat="server" ID="lbSearch" Text="Search" ValidationGroup="search" OnClick="lbSearch_Click" CssClass="btn btn-brand btn-elevate btn-elevate-air"/><%--btn-tall--%>
                </div>
            </div>
            <asp:Label runat="server" ID="lblmessage"></asp:Label>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphbody" runat="Server">
</asp:Content>
