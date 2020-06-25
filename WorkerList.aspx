<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.master" AutoEventWireup="true" CodeFile="WorkerList.aspx.cs" Inherits="masterpagedemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="<%=ResolveClientUrl("~/Content/assets/css/custom.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphHomeMaster" runat="Server">
    <div class="backimg" style="height: auto;">
        <div class="container-fluid" style="padding-bottom: 2%;">
            <div class="row justify-content-md-center" style="padding-top: 2%; text-align: center;">
                <h1>
                    <strong style="font-weight: bolder; color: #000000;">
                        <%--ac repair and service providers in rajkot--%>
                        <asp:Label runat="server" ID="lblJobType" />
                        and service provider in 
                        <asp:Label runat="server" ID="lblCity" />
                    </strong>
                </h1>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphbody" runat="Server">
    <asp:Label runat="server" ID="lblmessage"></asp:Label>
    <div runat="server" id="divpro"></div>
   <%-- <div class="kt-portlet">
        <div class="kt-portlet__body">
            <div class="form-group form-group-last">
                <div class="alert alert-secondary" role="alert">
                    <div class="alert-icon"><i class="flaticon-warning kt-font-brand"></i></div>
                    <div class="alert-text">
                        Add the disabled or readonly boolean attribute on an input to prevent user interactions. 
								Disabled inputs appear lighter and add a <code>not-allowed</code> cursor.
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <%--<div class="form-group form-group-last">
        <div class="alert alert-secondary" role="alert">
            <div class="alert-icon"><i class="flaticon-warning kt-font-brand"></i></div>
            <div class="alert-text">
                Add the disabled or readonly boolean attribute on an input to prevent user interactions. 
								Disabled inputs appear lighter and add a <code>not-allowed</code> cursor.
            </div>
        </div>
    </div>--%>
    <div class="alert alert-light alert-elevate fade show" role="alert" runat="server" id="divalert" visible="true">
        <div class="alert-icon"><i class="flaticon-warning kt-font-brand"></i></div>
        <div class="alert-text">
            <%--A datepicker for twitter bootstrap (@twbs).<br /> For more info please visit the plugin's
             <a class="kt-link kt-font-bold" href="https://uxsolutions.github.io/bootstrap-datepicker/" target="_blank">Demo Page</a> or 
            <a class="kt-link kt-font-bold" href="https://github.com/uxsolutions/bootstrap-datepicker" target="_blank">Github Repo</a>.--%>
            No data found currently in your city for the service you require.<br />
            Please try again after some time.
        </div>
    </div>
    <asp:Repeater ID="rptworks" runat="server" OnItemDataBound="rptworks_ItemDataBound" OnItemCommand="rptworks_ItemCommand">
        <ItemTemplate>
            <!--begin:: Portlet-->
            <div class="kt-portlet">
                <div class="kt-portlet__body">
                    <div class="kt-widget kt-widget--user-profile-3">
                        <div class="kt-widget__top">
                            <div class="kt-widget__media kt-hidden-">
                                <%--<img style="-o-object-fit: cover; height:200px; width:200px; border-radius:50%;" down-- height: 200px; width: 200px src="../Content/assets/Images/20180624_190753.jpg" />--%>
                                <asp:Image runat="server" CssClass="kt-widget__img kt-hidden-" Style="border-radius: 50%;" ID="imgphoto" ImageUrl='<%#Eval("photopath") %>' alt="../Content/assets/Images/bg-1.jpg" />
                            </div>
                            <div class="kt-widget__pic kt-widget__pic--danger kt-font-danger kt-font-boldest kt-font-light kt-hidden">
                            </div>
                            <div class="kt-widget__content">
                                <div class="kt-widget__head">
                                    <a href="#" class="kt-widget__username">
                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("ClientName") %>'></asp:Label>
                                        <asp:Label ID="lblClientID" runat="server" Text='<%#Eval("ClientID") %>' Visible="false"></asp:Label>
                                        <%--<i class="flaticon2-correct kt-font-success"></i>--%>
                                    </a>
                                    <div class="kt-widget__action">
                                        <%--<button type="button" class="btn btn-label-success btn-sm btn-upper">ask</button>&nbsp;--%>
                                        <asp:Button runat="server" ID="hlHire" Text="Hire" CssClass="btn btn-brand btn-sm btn-upper btn-pill" OnClick="hlHire_Click" CommandName="Hire"></asp:Button>
                                        <button type="button" runat="server" id="btnHire" class="btn btn-brand btn-sm btn-upper btn-pill" visible="false" data-toggle="modal" data-target="#modalhire">Hire</button>
                                        <%--<asp:LinkButton runat="server" ID="btnHire" OnClick="btnHire_Click" UseSubmitBehavior="false" Text="test"/>--%>
                                    </div>
                                </div>

                                <div class="kt-widget__subhead">
                                    <asp:HyperLink runat="server" ID="ancphone" href='tel:+91'>
                                        <i class="flaticon2-phone"></i>
                                        <asp:Label runat="server" ID="lblPhone" Text='<%#Eval("PhoneNo") %>' /><%--Width="20%"--%>
                                    </asp:HyperLink>
                                    <a><i id="iconemail" runat="server" class="flaticon2-new-email"></i>
                                        <asp:Label runat="server" ID="lblEmail" Text='<%#Eval("Email") %>' /><%--Width="20%"--%></a>
                                    <%--<a href="#"><i class="flaticon2-calendar-3"></i>PR Manager </a>
                                            <a href="#"><i class="flaticon2-placeholder"></i>Melbourne</a>--%>
                                </div>
                                <%--<div class="kt-widget__subhead">
                                        </div>--%>
                                <div class="kt-widget__info" runat="server" id="divskills">
                                    <div class="kt-widget__desc">
                                        <asp:Label runat="server" ID="lblskills" Text='<%#Eval("Skills") %>' />
                                    </div>
                                </div>
                                <div class="kt-widget__info" runat="server" id="divexperience">
                                    <div class="kt-widget__desc">
                                        <asp:Label runat="server" ID="lblExperience" Text='<%#Eval("Experience") %>' /><asp:Label runat="server" ID="lblExp" Text=" years experience" />
                                    </div>

                                </div>
                                <div class="kt-widget__info">
                                    <div class="kt-widget__desc">
                                        <strong>
                                            <asp:Label runat="server" ID="lblServiceCount" Text='<%#Eval("Services") %>' ForeColor="ForestGreen" /></strong>
                                        <asp:Label runat="server" ID="lblServices" Text=" Services provided till now having" />
                                        <strong>
                                            <asp:Label runat="server" ID="lblComplainsCount" Text='<%#Eval("Complains") %>' ForeColor="DarkRed" /></strong>
                                        <asp:Label runat="server" ID="lblComplains" Text=" complains" />
                                    </div>
                                    <div class="kt-widget__progress">
                                        <div class="kt-widget__text">
                                            Progress
                                        </div>
                                        <div class="progress" style="height: 5px; width: 100%;">
                                            <div runat="server" id="divprogress" class="progress-bar kt-bg-success" role="progressbar" style="width: 0%;" aria-valuenow="65" aria-valuemin="0" aria-valuemax="100"></div>
                                        </div>
                                        <div class="kt-widget__stats">
                                            <asp:Label runat="server" ID="lblProgress" Text="0%" />
                                        </div>
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
        </ItemTemplate>
    </asp:Repeater>


    <div class="modal fade" id="modalhire" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">customer Register</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Phone number</label>
                        <div class="input-group">
                            <div class="input-group-prepend"><span class="input-group-text">+91</span></div>
                            <asp:TextBox runat="server" ID="txtPhoneNo" TextMode="number" CssClass="form-control" aria-describedby="basic-addon1" placeholder="Enter your phone number" /><br />
                        </div>
                        <asp:RequiredFieldValidator runat="server" ID="rfvPhoneNo" ControlToValidate="txtPhoneNo" ErrorMessage="Please enter your Mobile number" ValidationGroup="Register" Display="Dynamic" ForeColor="#FD397A" />
                        <asp:RegularExpressionValidator runat="server" ID="revPhoneNo" ControlToValidate="txtPhoneNo" ValidationGroup="Register" Display="Dynamic" ForeColor="#FD397A" ErrorMessage="Invalid Mobile Number" ValidationExpression="^(\d{10}){1}?$" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <%--<asp:Button runat="server" ID="btnSavePhoneNo" class="btn btn-primary" Text="Save" OnClick="btnSavePhoneNo_Click" ValidationGroup="Register"></asp:Button>--%>
                </div>
            </div>
        </div>
    </div>
    <%--<div class="kt-portlet__body">
            <div class="form-group row">
                <label class="col-form-label col-lg-3 col-sm-12">Modal Demos</label>
                <div class="col-lg-4 col-md-9 col-sm-12">
                    <a href="#" class="btn btn-brand btn-pill" data-toggle="modal" data-target="#kt_maxlength_modal">Launch maxlength inputs on modal</a>
                </div>
            </div>
        </div>--%>
    <%--popup--%>
    <%--<div class="modal fade" id="kt_maxlength_modal" tabindex="-1" role="dialog" aria-labelledby="" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="">Bootstrap Maxlength Examples</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true" class="la la-remove"></span>
                        </button>
                    </div>
                    <form class="kt-form kt-form--fit kt-form--label-right">
                        <div class="modal-body">
                            <div class="form-group row kt-margin-t-20">
                                <label class="col-form-label col-lg-3 col-sm-12">Default Usage</label>
                                <div class="col-lg-9 col-md-9 col-sm-12">
                                    <input type="text" class="form-control" id="kt_maxlength_1_modal" maxlength="3" placeholder="" />
                                    <span class="form-text text-muted">The badge will show up by default when the remaining chars are 3 or less</span>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-form-label col-lg-3 col-sm-12">Threshold Demo</label>
                                <div class="col-lg-9 col-md-9 col-sm-12">
                                    <input type="text" class="form-control" id="kt_maxlength_2_modal" maxlength="7" placeholder="" />
                                    <span class="form-text text-muted">Set threshold value to show there are 5 chars or less</span>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-form-label col-lg-3 col-sm-12">Textarea Example</label>
                                <div class="col-lg-9 col-md-9 col-sm-12">
                                    <textarea class="form-control" id="kt_maxlength_5_modal" maxlength="8" placeholder="" rows="6"></textarea>
                                    <span class="form-text text-muted">Bootstrap maxlength supports textarea as well as inputs</span>
                                </div>
                            </div>
                            <div class="form-group row kt-margin-b-20">
                                <label class="col-form-label col-lg-3 col-sm-12">Custom Text</label>
                                <div class="col-lg-9 col-md-9 col-sm-12">
                                    <input type="text" class="form-control" id="kt_maxlength_4_modal" maxlength="8" placeholder="" />
                                    <span class="form-text text-muted">Display custom text on input focus</span>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-brand" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-secondary">Submit</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>--%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphscripts" runat="Server">
    <script src="Content/assets/plugins/custom/datatables/datatables.bundle.js"></script>
    <%--<script src="Content/assets/js/pages/crud/datatables/basic/paginations.js"></script>--%>
    <script src="Content/assets/js/custompagination.js"></script>
</asp:Content>
