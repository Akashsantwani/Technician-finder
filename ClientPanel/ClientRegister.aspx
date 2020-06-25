<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.master" AutoEventWireup="true" CodeFile="ClientRegister.aspx.cs" Inherits="ClientPanel_ClientRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Content/assets/js/pages/components/extended/sweetalert2.js"></script>
    <script type="text/javascript">
        function successalert() {
            swal.fire({
                title: "Welcome back!",
                text: "welcome ",
                timer: 2e3,
                type: "success",
                showCloseButton: true,
                onOpen: function () {
                    swal.showLoading()
                }
            }).then(function (e) { "timer" === e.dismiss && console.log("I was closed by the timer") })
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHomeMaster" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphSubheader" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphbody" runat="Server">
    <asp:Label runat="server" ID="lblmessage"></asp:Label>
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <!--begin::Portlet-->
            <div class="kt-portlet">
                <div class="kt-portlet__head">
                    <div class="kt-portlet__head-label">
                        <h3 class="kt-portlet__head-title"><asp:Label runat="server" ID="lblheading"></asp:Label>
                        </h3>
                    </div>
                </div>
                <!--begin::Form-->
                <div class="kt-portlet__body">
                    <div class="form-group">
                        <label>Name</label>
                        <asp:TextBox runat="server" ID="txtClientName" ClientIDMode="Static" TextMode="SingleLine" CssClass="form-control" placeholder="Enter your name"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvClientName" ControlToValidate="txtClientName" ErrorMessage="Please Enter your name" ForeColor="#FD397A" ValidationGroup="Reg" Display="Dynamic" />
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Phone number</label>
                                <div class="input-group">
                                    <div class="input-group-prepend"><span class="input-group-text">+91</span></div>
                                    <asp:TextBox runat="server" ID="txtPhoneNo" TextMode="number" CssClass="form-control" aria-describedby="basic-addon1" placeholder="Enter your phone number" /><br />
                                </div>
                                <asp:RequiredFieldValidator runat="server" ID="rfvPhoneNo" ControlToValidate="txtPhoneNo" ErrorMessage="Please enter your Mobile number" ValidationGroup="Reg" Display="Dynamic" ForeColor="#FD397A" />
                                <asp:RegularExpressionValidator runat="server" ID="revPhoneNo" ControlToValidate="txtPhoneNo" ValidationGroup="Reg" Display="Dynamic" ForeColor="#FD397A" ErrorMessage="Invalid Mobile Number" ValidationExpression="^(\d{10}){1}?$" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Gender</label>
                                <div class="kt-radio-inline">
                                    <label class="kt-radio">
                                        <asp:RadioButton GroupName="gender" runat="server" ID="rbmale" Text="male" />
                                        <span></span>
                                    </label>
                                    <label class="kt-radio">
                                        <asp:RadioButton GroupName="gender" runat="server" ID="rbfemale" Text="female" />
                                        <span></span>
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Email</label>
                        <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" CssClass="form-control" placeholder="Enter your email address" />
                    </div>
                    <div class="form-group">
                        <label>Address</label>
                        <asp:TextBox runat="server" ID="txtAddress" TextMode="multiline" CssClass="form-control" placeholder="Enter your address" />
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <label>select state</label>
                                <asp:DropDownList runat="server" ID="ddlState" AutoPostBack="true" CssClass="form-control kt-selectpicker" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" data-live-search="true" data-size="7" />
                                <asp:RequiredFieldValidator runat="server" ID="rfvState" ControlToValidate="ddlState" ErrorMessage="Please select State" InitialValue="-1" ValidationGroup="Reg" Display="Dynamic" ForeColor="#FD397A" />
                            </div>
                            <br />
                            <div class="col-md-6" runat="server" id="divddlcity" visible="false">
                                <label>select city</label>
                                <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-control kt-selectpicker" Enabled="false" data-live-search="true" data-size="7" />
                                <asp:RequiredFieldValidator runat="server" ID="rfvCity" ControlToValidate="ddlCity" ErrorMessage="Please select City" InitialValue="-1" ValidationGroup="Reg" Display="Dynamic" ForeColor="#FD397A" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Your Service</label>
                                <asp:DropDownList runat="server" ID="ddlJobType" CssClass="form-control kt-selectpicker" data-live-search="true" data-size="7" />
                                <asp:RequiredFieldValidator runat="server" ID="rfvJobType" ControlToValidate="ddlJobType" ErrorMessage="Please select Your Service" InitialValue="-1" ValidationGroup="Reg" Display="Dynamic" ForeColor="#FD397A" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Birthdate</label>
                                <div class="input-group date">
                                    <asp:TextBox runat="server" CssClass="form-control" TextMode="DateTime" placeholder="Select date" ID="kt_datepicker_2" ClientIDMode="Static" />
                                    <div class="input-group-append">
                                        <span class="input-group-text">
                                            <i class="la la-calendar-check-o"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Your Skills</label>
                        <asp:TextBox runat="server" ID="txtSkills" TextMode="multiline" CssClass="form-control" placeholder="enter your skills in your field" />
                    </div>
                    <div class="form-group row">
                        <label class="col-xl-3 col-lg-3 col-form-label">Select your photo</label>
                        <div class="col-lg-9 col-xl-6">
                            <div class="kt-avatar kt-avatar--outline kt-avatar--circle-" id="kt_user_edit_avatar">
                                <div class="kt-avatar__holder" runat="server" id="divimage" ></div>
                                <%--this upper div --style="background-image: url('../Content/assets/media/users/300_20.jpg');" style="background-image : url('../Content/assets/Images/IMG_20200213_195904_479.jpg');"--%> 
                                <label class="kt-avatar__upload" data-toggle="kt-tooltip" title="" data-original-title="Change avatar">
                                    <i class="fa fa-pen"></i>
                                    <asp:FileUpload runat="server" ID="fuimage" name="profile_avatar" accept=".png, .jpg, .jpeg" />
                                </label>
                                <span class="kt-avatar__cancel" data-toggle="kt-tooltip" title="" data-original-title="Cancel avatar">
                                    <i class="fa fa-times"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row" runat="server" id="divpassword">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Password</label>
                                <asp:TextBox runat="server" ID="txtpassword" type="password" CssClass="form-control" placeholder="Enter password" />
                                <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtpassword" ErrorMessage="Please enter password" ValidationGroup="Reg" Display="Dynamic" ForeColor="#FD397A" />
                                <asp:RegularExpressionValidator runat="server" ID="revpass" ControlToValidate="txtpassword" ForeColor="#FD397A" ValidationExpression="^(?=.*\d).{4,8}$" Display="Dynamic" ErrorMessage="Password must be between 4 and 8 digits long and include at least one numeric digit." ValidationGroup="Reg" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Re-confirm password</label>
                                <asp:TextBox runat="server" ID="txtconfirmpassword" type="password" CssClass="form-control" placeholder="re-confirm password" />
                                <asp:RequiredFieldValidator runat="server" ID="rfvconpassword" ControlToValidate="txtconfirmpassword" ErrorMessage="Please enter password" ValidationGroup="Reg" Display="Dynamic" ForeColor="#FD397A" />
                                <asp:CompareValidator runat="server" ID="cvconfirmpass" Display="Dynamic" ForeColor="#FD397A" ValidationGroup="Reg" ControlToValidate="txtconfirmpassword" ControlToCompare="txtpassword" ErrorMessage="password does not match" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Experience</label>
                        <asp:TextBox runat="server" ID="kt_touchspin_4" ClientIDMode="Static" type="number" name="demo1" CssClass="form-control bootstrap-touchspin-vertical-btn" placeholder="enter your work experience in years" />
                    </div>
                </div>
                <div class="kt-portlet__foot">
                    <div class="kt-form__actions">
                        <asp:Button runat="server" ID="btnsubmit" Text="submit" ValidationGroup="Reg" CssClass="btn btn-primary" OnClick="btnsubmit_Click" />
                        <%--<asp:Button runat="server" ID="btnregister" Text="register" CssClass="btn btn-primary" OnClick="btnregister_Click" />--%>
                        <asp:HyperLink runat="server" ID="btncancle" Text="Cancle" NavigateUrl="~/ClientPanel/home.aspx" CssClass="btn btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScripts" runat="Server">
    <script src="<%=ResolveClientUrl("~/Content/assets/js/pages/crud/forms/widgets/bootstrap-datepicker.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/assets/js/pages/crud/forms/widgets/bootstrap-touchspin.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/assets/js/pages/custom/user/edit-user.js")%>"></script>
</asp:Content>
