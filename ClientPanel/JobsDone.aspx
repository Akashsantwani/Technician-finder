<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.master" AutoEventWireup="true" CodeFile="JobsDone.aspx.cs" Inherits="ClientPanel_JobsDone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHomeMaster" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphbody" Runat="Server">
     <asp:Repeater ID="rptworks" runat="server" OnItemDataBound="rptworks_ItemDataBound">
        <ItemTemplate>
            <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
                <!--begin:: Portlet-->
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="kt-widget kt-widget--user-profile-3">
                            <div class="kt-widget__top">
                                <div class="kt-widget__media kt-hidden-">
                                    <asp:Image runat="server" CssClass="kt-widget__img kt-hidden-" Style="border-radius: 50%; " ID="imgphoto" ImageUrl='<%#Eval("photoPath") %>' alt="../Content/assets/Images/bg-1.jpg" />
                                </div>
                                <div class="kt-widget__pic kt-widget__pic--danger kt-font-danger kt-font-boldest kt-font-light kt-hidden">
                                </div>
                                <div class="kt-widget__content">
                                    <div class="kt-widget__head">
                                        <a href="#" class="kt-widget__username">
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("CustomerName") %>'></asp:Label>
                                        </a>
                                    </div>
                                    <div class="kt-widget__subhead">
                                        <i class="flaticon2-phone"></i>
                                        <asp:Label runat="server" ID="lblPhone" Width="20%" Text='<%#Eval("PhoneNo") %>' />
                                        <i id="iconemail" runat="server" class="flaticon2-new-email"></i>
                                        <asp:Label runat="server" ID="lblEmail" Text='<%#Eval("Email") %>' Width="20%" />
                                    </div>
                                    <div class="kt-widget__info">
                                        <div class="kt-widget__desc">
                                            <asp:Label runat="server" ID="lblAdd" Text="Address: "></asp:Label><asp:Label runat="server" ID="lbladdress" Text='<%#Eval("Address") %>' />
                                        </div>
                                    </div>
                                    <div class="kt-widget__info">
                                        <div class="kt-widget__desc">
                                            <asp:Label runat="server" ID="lbldate" Text="Service provided on " /><asp:Label runat="server" ID="lblWorkDate" Text='<%#Eval("Workdate") %>' />
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

