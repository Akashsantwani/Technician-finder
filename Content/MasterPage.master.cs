using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkerFinder.BAL;
using WorkerFinder.ENT;

public partial class Content_MasterPage : System.Web.UI.MasterPage
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            hllogin.DataBind();
            hllogin.NavigateUrl = "~/Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri);
            if (Session["ClientID"] != null || Session["CustomerID"] != null)
            {
                divlogin.Visible = false;
                divuser.Visible = true;
            }
            else
            {
                divlogin.Visible = true;
                divuser.Visible = false;
            }
            if (Session["ClientID"] != null)
            {
                lijobsdone.Visible = true;
                limycomplains.Visible = true;
                limyservices.Visible = false;
                hlprofile.DataBind();
                hlprofile.NavigateUrl = "~/ClientPanel/ClientRegister.aspx";
                if (Session["ClientName"] != null)
                {
                    lblClient.Text = Session["ClientName"].ToString();
                    lblClientName.Text = Session["ClientName"].ToString();
                }
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "successalert();", true);
            }
            if(Session["CustomerID"] != null)
            {
                lijobsdone.Visible = false;
                limycomplains.Visible = false;
                limyservices.Visible = true;
                hlprofile.DataBind();
                hlprofile.NavigateUrl = "~/CustomerPanel/RegisterCustomer.aspx";
                if (Session["CustomerName"] != null)
                {
                    lblClient.Text = Session["CustomerName"].ToString();
                    lblClientName.Text = Session["CustomerName"].ToString();
                }
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "successalert();", true);
            }
            
            if (Session["PhotoPath"] != null)
            {
                imgClient.ImageUrl = Session["PhotoPath"].ToString();
                imgDP.ImageUrl = Session["PhotoPath"].ToString();
                imginnerImg.ImageUrl = Session["PhotoPath"].ToString(); ;
            }
            else
            {
                imgClient.ImageUrl = "../Content/assets/Images/Default-User.png";
                imgDP.ImageUrl = "../Content/assets/Images/Default-User.png";
                imginnerImg.ImageUrl = "../Content/assets/Images/Default-User.png";
            }
        }
    }
    #endregion Page_Load

    #region Button: Logout
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        if (Session["ClientID"] != null || Session["CustomerID"] != null)
        {
            divlogin.Visible = false;
            divuser.Visible = true;
        }
        else
        {
            divlogin.Visible = true;
            divuser.Visible = false;
        }
        if (Session["ClientID"] != null)
        {
            lijobsdone.Visible = true;
            limycomplains.Visible = true;
            limyservices.Visible = false;
            hlprofile.DataBind();
            hlprofile.NavigateUrl = String.Format("~/ClientPanel/RegisterClient.aspx?ClientID={0}", Session["ClientID"].ToString());
        }
        else
        {
            lijobsdone.Visible = false;
            limycomplains.Visible = false;
            limyservices.Visible = false;   
        }
        if (Session["CustomerID"] != null)
        {
            lijobsdone.Visible = false;
            limycomplains.Visible = false;
            limyservices.Visible = true;
        }
        else
        {
            lijobsdone.Visible = false;
            limycomplains.Visible = false;
            limyservices.Visible = false;
        }
        Response.Redirect("~/Home.aspx");
    }
    #endregion Button: Logout

    #region Changepassword
    protected void btnChangepassword_Click(object sender, EventArgs e)
    {
        if (Session["CustomerID"] != null)
        {
            CustomerBAL balcustomer = new CustomerBAL();
            String oldpass = balcustomer.SelectPasswordByPK(Convert.ToInt32(Session["CustomerID"]));
            if (oldpass != txtoldpassword.Text)
            {
                rfvoldpassword.Text = "old password do not match please try again";
            }
            else
            {
                CustomerENT entCustomer = new CustomerENT();
                entCustomer.CustomerID = Convert.ToInt32(Session["CustomerID"]);
                entCustomer.Password = txtnewpassword.Text.Trim();
                balcustomer.UpdatePasswordByPK(entCustomer);
            }
        }
        else if (Session["ClientID"] != null)
        {
            ClientBAL balclient = new ClientBAL();
            String oldpass = balclient.SelectPasswordByPK(Convert.ToInt32(Session["ClientID"]));
            if (oldpass != txtoldpassword.Text)
            {
                rfvoldpassword.Text = "old password do not match please try again";
            }
            else
            {
                ClientENT entClient = new ClientENT();
                entClient.ClientID = Convert.ToInt32(Session["ClientID"]);
                entClient.Password = txtnewpassword.Text.Trim();
                balclient.UpdatePasswordByPK(entClient);
            }
        }
    }
    #endregion Changepassword

    #region btnSavePhoneNo
    protected void btnSavePhoneNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ClientPanel/ClientRegister.aspx");
    }
    #endregion btnSavePhoneNo

    #region btnUpdatePhoneNo
    protected void BtnUpdatePhoneNo_Click(object sender, EventArgs e)
    {
        if (txtConfirmOTP.Text == "1234")
        {
            ClientBAL BalClient = new ClientBAL();
            ClientENT EntClient = new ClientENT();
            EntClient.ClientID = Convert.ToInt32(Session["ClientID"]);
            EntClient.PhoneNo = txtUpdatePhoneNo.Text.Trim();
            BalClient.UpdatePhoneNoByPK(EntClient);
            lblmessage.Text = "hello";
            modalresetphone.Attributes.Remove("show");
            modalresetphone.Attributes.Add("class", "modal fade");
            modalresetphone.Attributes.Add("style", "display:none");
        }
        else
        {
            lblWrongOTP.Text = "Incorrect OTP please try again.";
        }
    }
    #endregion btnUpdatePhoneNo

    #region btnSendOTP
    protected void BtnSendOTP_Click(object sender, EventArgs e)
    {
        txtUpdatePhoneNo.Visible = false;
        BtnSendOTP.Visible = false;
        lblPhoneNo.Visible = false;
        divnumberprefix.Visible = false;
        lblOTP.Visible = true;
        txtConfirmOTP.Visible = true;
        BtnUpdatePhoneNo.Visible = true;
        modalresetphone.Attributes.Add("class", "modal fade show");
        modalresetphone.Attributes.Add("style", "display:block");
    }
    #endregion btnSendOTP
}
