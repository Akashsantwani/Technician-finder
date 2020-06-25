<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.master" AutoEventWireup="true" CodeFile="MyComplains.aspx.cs" Inherits="ClientPanel_MyComplains" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHomeMaster" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphbody" Runat="Server">
    <asp:Repeater ID="rptworks" runat="server" OnItemDataBound="rptworks_ItemDataBound">
        <ItemTemplate>
            <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="kt-widget kt-widget--user-profile-3">
                            <div class="kt-widget__top">
                                <div class="kt-widget__pic kt-widget__pic--danger kt-font-danger kt-font-boldest kt-font-light kt-hidden">
                                </div>
                                <div class="kt-widget__content">
                                    <div class="kt-widget__head">
                                        <a href="#" class="kt-widget__username">
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("CustomerName") %>'></asp:Label>
                                        </a>
                                    </div>
                                    <div class="kt-widget__info">
                                        <div class="kt-widget__desc">
                                            <asp:Label runat="server" ID="lbldate" Text="Complain Date: "></asp:Label><asp:Label runat="server" ID="lblComplainDate" Text='<%#Eval("ComplainDate") %>' />
                                        </div>
                                    </div>
                                    <div class="kt-widget__info">
                                        <div class="kt-widget__desc">
                                            <asp:Label runat="server" ID="lblmessage" Text="Issue: " /><asp:Label runat="server" ID="lblComplainMessage" Text='<%#Eval("ComplainMessage") %>' />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

