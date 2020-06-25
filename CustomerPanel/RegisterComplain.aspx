<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.master" AutoEventWireup="true" CodeFile="RegisterComplain.aspx.cs" Inherits="CustomerPanel_RegisterComplain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHomeMaster" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSubheader" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphbody" runat="Server">
    <div class="container">
        <asp:Label runat="server" ID="lblmessage"></asp:Label>
            <div class="kt-portlet justify-content-md-center" style="width:100%; margin:auto;">
                <div class="kt-portlet__head">
                    <div class="kt-portlet__head-label">
                        <span class="kt-portlet__head-icon kt-hidden">
                            <i class="la la-gear"></i>
                        </span>
                        <h3 class="kt-portlet__head-title">Pill Buttons
                        </h3>
                    </div>
                </div>
                <div class="kt-portlet__body">
                    <div class="form-group">
                        <label>Client Name</label>
                        <asp:TextBox runat="server" ID="txtClientName" ClientIDMode="Static" TextMode="SingleLine" CssClass="form-control" placeholder="Enter client name" Enabled="false"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvClientName" ControlToValidate="txtClientName" ErrorMessage="Please Enter your name" ForeColor="#FD397A" Display="Dynamic" />
                    </div>
                    <div class="form-group">
                        <label>Client Name</label>
                        <asp:TextBox runat="server" ID="txtComplain" ClientIDMode="Static" TextMode="MultiLine" CssClass="form-control" placeholder="Enter Your Complain"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvComplain" ControlToValidate="txtComplain" ErrorMessage="Please enter your complain" ForeColor="#FD397A" Display="Dynamic" />
                    </div>
                </div>
                <div class="kt-portlet__foot">
                    <div class="kt-form__actions">
                        <asp:Button runat="server" ID="btnsubmit" Text="submit" CssClass="btn btn-primary" OnClick="btnsubmit_Click" />
                        <asp:HyperLink runat="server" ID="btncancle" Text="Cancle" NavigateUrl="~/CustomerPanel/MyServices.aspx" CssClass="btn btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

