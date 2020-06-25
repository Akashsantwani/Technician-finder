<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="ClientPanel_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>Login Page</title>
    
    <meta name="description" content="Login page" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!--begin::Fonts -->
    <%--<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700|Roboto:300,400,500,600,700" />--%>
    <!--end::Fonts -->
    <!--begin::Page Custom Styles(used by this page) -->
    <link href="~/Content/assets/css/pages/login/login-4.css" rel="stylesheet" type="text/css" />
    <!--end::Page Custom Styles -->
    <!--begin::Global Theme Styles(used by all pages) -->
    <link href="~/Content/assets/plugins/global/plugins.bundle.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/assets/css/style.bundle.css" rel="stylesheet" type="text/css" />
    <!--end::Global Theme Styles -->
    <link href="~/Content/assets/css/skins/header/base/light.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/assets/css/skins/header/menu/light.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/assets/css/skins/brand/dark.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/assets/css/skins/aside/dark.css" rel="stylesheet" type="text/css" />
</head>
<body class="kt-quick-panel--right kt-demo-panel--right kt-offcanvas-panel--right kt-header--fixed kt-header-mobile--fixed kt-subheader--enabled kt-subheader--fixed kt-subheader--solid kt-aside--enabled kt-aside--fixed kt-page--loading">
    <div class="kt-grid kt-grid--ver kt-grid--root">
        <div class="kt-grid kt-grid--hor kt-grid--root kt-login kt-login--v4 kt-login--signin" id="kt_login">
            <div class="kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" style="background-image: url(Content/assets/media/bg/bg-2.jpg);">
                <%--<form id="form1" runat="server">--%>
                <div class="kt-grid__item kt-grid__item--fluid kt-login__wrapper">
                    <div class="kt-login__container">
                        <div class="kt-login__logo">
                            <a href="#">
                                <img src="Content/assets/media/logos/logo-5.png" />
                            </a>
                        </div>
                        <form class="kt-form" id="frm1" runat="server">
                            <!--Begin :: Login-->
                            <div class="kt-login__signin">
                                <div class="kt-login__head">
                                    <h3 class="kt-login__title">Sign In To Admin</h3>
                                </div>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtPhoneNo" class="form-control" MaxLength="10" TextMode="number" placeholder="Phone Number" name="PhoneNo" autocomplete="off" />
                                </div>
                                <div class="input-group col">
                                    <%--<asp:RequiredFieldValidator runat="server" ID="rfvphoneno" ForeColor="#FD397A" ControlToValidate="txtPhoneNo" ValidationGroup="login" Display="Dynamic" ErrorMessage="Enter phone number"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ID="revPhoneNo" ControlToValidate="txtPhoneNo" ValidationGroup="login" Display="Dynamic" ForeColor="#FD397A" ErrorMessage="Invalid Mobile Number" ValidationExpression="^(\d{10}){1}?$"/>--%><%--((\+)?(\d{2}))?--%>
                                </div>
                                <div class="input-group">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" placeholder="Password" name="password" />
                                </div>
                                <div class="input-group col">
                                    <%--<asp:RequiredFieldValidator runat="server" ID="rfvpassword" ForeColor="#FD397A" ControlToValidate="txtPassword" ValidationGroup="login" Display="Dynamic" ErrorMessage="Enter password"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ID="revpassword" ControlToValidate="txtPassword" ForeColor="#FD397A" ValidationExpression="^(?=.*\d).{4,8}$" Display="Dynamic" ErrorMessage="Password must be between 4 and 8 digits long and include at least one numeric digit." ValidationGroup="login" />--%>
                                </div>
                                <div class="row kt-login__extra">
                                    <div class="col kt-align-right">
                                        <a href="javascript:;" id="kt_login_forgot" class="kt-login__link">Forget Password ?</a>
                                    </div>
                                </div>
                                <div class="kt-login__actions">
                                    <%--<button id="kt_login_signin_submit" class="btn btn-brand btn-pill kt-login__btn-primary">Sign In</button>--%>
                                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-brand btn-pill kt-login__btn-primary" ValidationGroup="login" Text="Sign In" OnClick="btnLogin_Click" />
                                </div>
                                <%--</form>--%>
                                <div class="row kt-login__extra">
                                    <div class="col">
                                        <asp:Label align="center" runat="server" ID="lblerror" ForeColor="#FD397A"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <!--end :: Login-->
                            <!--Begin :: forgot password-->
                            <div class="kt-login__forgot">
                                <div class="kt-login__head">
                                    <h3 class="kt-login__title">Forgotten Password ?</h3>
                                    <div class="kt-login__desc">Enter your mobile number to reset your password:</div>
                                </div>
                                <%--<form runat="server" id="frm3" class="kt-form" action="#">--%>
                                <div class="input-group">
                                    <asp:TextBox runat="server" class="form-control" TextMode="Phone" placeholder="Phone number" name="phoneNo" ID="txtResetPhoneNo" autocomplete="off" />
                                </div>
                                <div class="input-group col">
                                    <asp:RequiredFieldValidator runat="server" ID="rfvPhoneReset" ForeColor="#FD397A" ControlToValidate="txtResetPhoneNo" ValidationGroup="Reset" Display="Dynamic" ErrorMessage="Enter phone number"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ID="revPhoneReset" ControlToValidate="txtResetPhoneNo" ValidationGroup="Reset" Display="Dynamic" ForeColor="#FD397A" ErrorMessage="Invalid Mobile Number" ValidationExpression="^(\d{10}){1}?$"/><%--((\+)?(\d{2}))?--%>
                                </div>
                                <div class="kt-login__actions">
                                    <%--<asp:Button runat="server" id="kt_login_forgot_submit" CssClass="btn btn-brand btn-pill kt-login__btn-primary" ValidationGroup="Reset" Text="Request" OnClick="btnsubmit_Click"></asp:Button>--%>&nbsp;&nbsp;
							        <asp:Button runat="server" id="btntest" class="btn btn-brand btn-pill kt-login__btn-primary" OnClick="btnsubmit_Click" Text="Request" ValidationGroup="Reset"></asp:Button>
                                    <button id="kt_login_forgot_cancel" class="btn btn-secondary btn-pill kt-login__btn-secondary">Cancel</button>
                                    
                                </div>
                                <div class="row kt-login__extra">
                                    <div class="col">
                                        <asp:Label align="center" runat="server" ID="lblmessage" ForeColor="#FD397A"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <!--end :: forgot password-->
                        </form>
                        <%--<div class="kt-login__account">
                                <span class="kt-login__account-msg">Don't have an account yet ?
                                </span>
                                &nbsp;&nbsp;
					                <a href="javascript:;" id="kt_login_signup" class="kt-login__account-link">Sign Up!</a>
                            </div>--%>
                    </div>
                </div>
                <%--</form>--%>
            </div>
        </div>
    </div>
    <!-- end:: Page -->
    <!-- begin::Global Config(global config for global JS sciprts) -->
    <script>
        var KTAppOptions = {
            "colors": {
                "state": {
                    "brand": "#5d78ff",
                    "dark": "#282a3c",
                    "light": "#ffffff",
                    "primary": "#5867dd",
                    "success": "#34bfa3",
                    "info": "#36a3f7",
                    "warning": "#ffb822",
                    "danger": "#fd3995"
                },
                "base": {
                    "label": [
                        "#c5cbe3",
                        "#a1a8c3",
                        "#3d4465",
                        "#3e4466"
                    ],
                    "shape": [
                        "#f0f3ff",
                        "#d9dffa",
                        "#afb4d4",
                        "#646c9a"
                    ]
                }
            }
        };
    </script>
    <!-- end::Global Config -->
    <!--begin::Global Theme Bundle(used by all pages) -->
    <script src="<%=ResolveClientUrl("~/Content/assets/plugins/global/plugins.bundle.js") %>" type="text/javascript"></script>
    <script src="<%=ResolveClientUrl("~/Content/assets/js/scripts.bundle.js")%>" type="text/javascript"></script>
    <!--end::Global Theme Bundle -->
    <!--begin::Page Scripts(used by this page) -->
    <script src="<%=ResolveClientUrl("~/Content/assets/js/pages/custom/login/login-general.js")%>" type="text/javascript"></script>
</body>
</html>
