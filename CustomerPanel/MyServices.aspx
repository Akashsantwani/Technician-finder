<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.master" AutoEventWireup="true" CodeFile="MyServices.aspx.cs" Inherits="CustomerPanel_MyServicesnew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHomeMaster" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphbody" Runat="Server">
    <asp:Label runat="server" ID="lblmessage"></asp:Label>
    <asp:Repeater ID="rptservices" runat="server" OnItemDataBound="rptservices_ItemDataBound">
        <ItemTemplate>
            <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
                <div class="kt-portlet">
                    <div class="kt-portlet__body">
                        <div class="kt-widget kt-widget--user-profile-3">
                            <div class="kt-widget__top">
                                <div class="kt-widget__media kt-hidden-">
                                    <asp:Image runat="server" CssClass="kt-widget__img kt-hidden-" Style="border-radius: 50%;" ID="imgphoto" ImageUrl='<%#Eval("photopath") %>' alt="../Content/assets/Images/bg-1.jpg" />
                                </div>
                                <div class="kt-widget__pic kt-widget__pic--danger kt-font-danger kt-font-boldest kt-font-light kt-hidden">
                                </div>
                                <div class="kt-widget__content">
                                    <div class="kt-widget__head">
                                        <a href="#" class="kt-widget__username">
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("ClientName") %>'></asp:Label><asp:HiddenField runat="server" ID="CientID" />
                                        </a>
                                        <div class="kt-widget__action">
                                            <asp:Button runat="server" ID="hlHire" Text="Hire again" CssClass="btn btn-brand btn-sm btn-upper btn-pill" OnClick="hlHire_Click"/>
                                            <asp:HyperLink runat="server" ID="hlComplain" Text="Complain" NavigateUrl='<%# "~/CustomerPanel/RegisterComplain.aspx?ClientID=" + Eval("ClientID") %>' CssClass="btn btn-danger btn-sm btn-upper btn-pill"/>
                                            <asp:HyperLink runat="server" ID="hlCancle" Text="cancle" CssClass="btn btn-brand btn-sm btn-upper btn-pill"/>
                                        </div>
                                    </div>
                                    <div class="kt-widget__subhead">
                                        <a>
                                            <i class="flaticon2-phone"></i>
                                            <asp:Label runat="server" ID="lblPhone" Width="20%" Text='<%#Eval("PhoneNo") %>' />
                                        </a>
                                        <a>
                                            <i id="iconemail" runat="server" class="flaticon2-new-email"></i>
                                            <asp:Label runat="server" ID="lblEmail" Text='<%#Eval("Email") %>' Width="20%" />
                                        </a>
                                    </div>
                                    <div class="kt-widget__info">
                                        <div class="kt-widget__desc">
                                            <asp:Label runat="server" ID="lbltype" Text="Service type: " /><asp:Label runat="server" ID="lblJobType" Text='<%#Eval("JobTypeName") %>' />
                                        </div>
                                    </div>
                                    <div class="kt-widget__info">
                                        <div class="kt-widget__desc">
                                            <asp:Label runat="server" ID="lbldate" Text="Service Date: "></asp:Label><asp:Label runat="server" ID="lblWorkDate" Text='<%#Eval("WorkDate") %>' />
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

