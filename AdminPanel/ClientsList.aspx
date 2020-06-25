<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.master" AutoEventWireup="true" CodeFile="ClientsList.aspx.cs" Inherits="AdminPanel_ClientsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHomeMaster" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSubheader" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphbody" runat="Server">
    <asp:UpdatePanel ID="pnlHelloWorld" runat="server">
        <ContentTemplate>
            <asp:Repeater ID="rptworks" runat="server" OnItemDataBound="rptworks_ItemDataBound">
                <ItemTemplate>
                    <div class="kt-container  kt-container--fluid  kt-grid__item kt-grid__item--fluid">
                        <!--begin:: Portlet-->
                        <div class="kt-portlet">
                            <div class="kt-portlet__body">
                                <div class="kt-widget kt-widget--user-profile-3">
                                    <div class="kt-widget__top">
                                        <div class="kt-widget__media kt-hidden-">
                                            <%--<img style="-o-object-fit: cover; height:200px; width:200px; border-radius:50%;" src="../Content/assets/Images/20180624_190753.jpg" />--%>
                                            <asp:Image runat="server" CssClass="kt-widget__img kt-hidden-" Style="border-radius: 50%;" ID="imgphoto" ImageUrl='<%#Eval("photopath") %>' alt="../Content/assets/Images/bg-1.jpg" />
                                        </div>
                                        <div class="kt-widget__pic kt-widget__pic--danger kt-font-danger kt-font-boldest kt-font-light kt-hidden">
                                        </div>
                                        <div class="kt-widget__content">
                                            <div class="kt-widget__head">
                                                <a href="#" class="kt-widget__username">
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("ClientName") %>'></asp:Label>
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
                                                    <asp:Label runat="server" ID="lblskills" Text='<%#Eval("Skills") %>' />
                                                </div>
                                            </div>
                                            <div class="kt-widget__info">
                                                <div class="kt-widget__desc">
                                                    <asp:Label runat="server" ID="lblExperience" Text='<%#Eval("Experience") %>' /><asp:Label runat="server" ID="lblExp" Text=" years experience" />
                                                </div>
                                            </div>
                                            <div class="kt-widget__info">
                                                <div class="kt-widget__desc">
                                                    <asp:Label runat="server" ID="lblJoin" Text="Joined us on " /><asp:Label runat="server" ID="lblJoiningDate" Text='<%#Eval("RegistrationDate","{0:d MMM yyyy}") %>' />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="tab-content" style="padding-left: 2%">
        <!--begin: Section-->
        <div class="kt-section">
            <p class="kt-section__content">
                <div class="kt-pagination kt-pagination--brand">
                    <ul class="kt-pagination__links">
                        <li>
                            <asp:LinkButton ID="lbFirst" CssClass="kt-pagination__link--first" runat="server" OnClick="lbFirst_Click"><i class="fa fa-angle-double-left kt-font-brand"></i></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lbPrevious" CssClass="kt-pagination__link--next" runat="server" OnClick="lbPrevious_Click"><i class="fa fa-angle-left kt-font-brand"></i></asp:LinkButton>
                        </li>
                        <asp:DataList ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand" OnItemDataBound="rptPaging_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <li>
                                    <asp:LinkButton ID="lbPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>' CommandName="newPage" Text='<%# Eval("PageText") %> '></asp:LinkButton>
                                </li>
                            </ItemTemplate>
                        </asp:DataList>
                        <li>
                            <asp:LinkButton ID="lbNext" CssClass="kt-pagination__link--prev" runat="server" OnClick="lbNext_Click"><i class="fa fa-angle-right kt-font-brand"></i></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lbLast" CssClass="kt-pagination__link--last" runat="server" OnClick="lbLast_Click"><i class="fa fa-angle-double-right kt-font-brand"></i></asp:LinkButton>
                        </li>
                        <asp:Label ID="lblpage" runat="server" Text=""></asp:Label>
                    </ul>
                    <div class="kt-pagination__toolbar">
                        <asp:DropDownList runat="server" ID="ddlList" AutoPostBack="true" OnTextChanged="ddlList_SelectedIndexChanged" CssClass="form-control kt-font-brand" Style="width: 60px;">
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                            <asp:ListItem Value="20">20</asp:ListItem>
                            <asp:ListItem Value="25">25</asp:ListItem>
                        </asp:DropDownList>
                        <span class="pagination__desc"><%--Displaying 10 of 230 records--%><asp:Label runat="server" ID="lblRecords" Text=""></asp:Label>
                        </span>
                    </div>
                </div>
            </p>
        </div>
    </div>

    <!--begin: Pagination-->
    <%--<div class="kt-pagination  kt-pagination--brand">
                <ul class="kt-pagination__links">
                    <li class="kt-pagination__link--first">
                        <asp:LinkButton ID="LinkButton1" CssClass="kt-pagination__link--first" runat="server" OnClick="lbFirst_Click"><i class="fa fa-angle-double-left kt-font-brand"></i></asp:LinkButton>
                    </li>
                    <li class="kt-pagination__link--next">
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lbPrevious_Click"><i class="fa fa-angle-left kt-font-brand"></i></asp:LinkButton>
                    </li>
                    <li class="kt-pagination__link--active">
                        <a href="#">32</a>
                    </li>
                    <li>
                        <asp:DataList ID="rptPaging1" runat="server" OnItemCommand="rptPaging_ItemCommand" OnItemDataBound="rptPaging_ItemDataBound" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbPaging1" runat="server" CommandArgument='<%# Eval("PageIndex") %>' CommandName="newPage" Text='<%# Eval("PageText") %> '></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>
                    </li>
                    <li class="kt-pagination__link--prev">
                        <a href="#"><i class="fa fa-angle-right kt-font-brand"></i></a>
                    </li>
                    <li class="kt-pagination__link--last">
                        <a href="#"><i class="fa fa-angle-double-right kt-font-brand"></i></a>
                    </li>
                </ul>

                <div class="kt-pagination__toolbar">
                    <select class="form-control kt-font-brand" style="width: 60px;">
                        <option value="10">10</option>
                        <option value="20">20</option>
                        <option value="30">30</option>
                        <option value="50">50</option>
                        <option value="100">100</option>
                    </select>
                    <span class="pagination__desc">Displaying 10 of 230 records
                    </span>
                </div>
            </div>--%>
    <!--end: Pagination-->

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

