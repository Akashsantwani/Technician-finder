using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WorkerFinder;
using WorkerFinder.BAL;
using WorkerFinder.DAL;
using WorkerFinder.ENT;
//using SmsClient;

public partial class ClientPanel_ClientRegister : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (PreviousPage != null){
                if (((TextBox)PreviousPage.FindControl("txtPhoneNo")) != null){
                }
            }
            if (Session["ClientID"] != null)
            {
                lblheading.Text = "Update profile";
                LoadControls(Convert.ToInt32(Session["ClientID"]));
                txtPhoneNo.Enabled = false;
                divpassword.Visible = false;
                rfvPassword.ValidationGroup = "";
                rfvconpassword.ValidationGroup = "";
                cvconfirmpass.ValidationGroup = "";
            }
            else
            {
                lblheading.Text = "Register";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "successalert();", true);
        }
    }
    #endregion Page_Load

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethod.FillDropDownListStateID(ddlState);
        CommonFillMethod.FillDropDownListJobTypeID(ddlJobType);
    }
    #endregion FillDropDownList

    #region LoadControls
    private void LoadControls(SqlInt32 ClientID)
    {
        ClientENT entclient = new ClientENT();
        ClientBAL balclient = new ClientBAL();
        entclient = balclient.SelectByPK(ClientID);

        rfvPassword.ValidationGroup = "";
        divddlcity.Visible = true;

        if (!entclient.ClientName.IsNull)
            txtClientName.Text = entclient.ClientName.Value.ToString();

        if (!entclient.PhoneNo.IsNull)
            txtPhoneNo.Text = entclient.PhoneNo.Value.ToString();

        if (!entclient.Gender.IsNull)
        {
            if (entclient.Gender == "Male")
            {
                rbmale.Checked = true;
            }
            else if (entclient.Gender == "Female")
            {
                rbfemale.Checked = true;
            }
        }

        if (!entclient.Email.IsNull)
            txtEmail.Text = entclient.Email.Value.ToString();

        if (!entclient.Address.IsNull)
            txtAddress.Text = entclient.Address.Value.ToString();

        if (!entclient.StateID.IsNull)
        {
            ddlState.SelectedValue = entclient.StateID.Value.ToString();
            ddlCity.Enabled = true;
            CommonFillMethod.FillDropDownListCityIDByStateID(ddlCity, ddlState.SelectedIndex);
        }

        if (!entclient.CityID.IsNull)
            ddlCity.SelectedValue = entclient.CityID.Value.ToString();

        if (!entclient.JobTypeID.IsNull)
            ddlJobType.SelectedValue = entclient.JobTypeID.Value.ToString();

        if (!entclient.BirthDate.IsNull)
        {
            kt_datepicker_2.Text = DateTime.Parse(entclient.BirthDate.ToString()).ToString("yyyy/MM/dd");
        }
        //kt_datepicker_2.Text = entclient.BirthDate.Value.ToString();

        if (!entclient.Skills.IsNull)
            txtSkills.Text = entclient.Skills.Value.ToString();

        if (!entclient.PhotoPath.IsNull)
            divimage.Style["background-image"] =   entclient.PhotoPath.ToString(); 

        // password left

        if (!entclient.Experience.IsNull)
            kt_touchspin_4.Text = entclient.Experience.Value.ToString();

    }

    #endregion LoadControls

    #region ddlState_SelectedIndexChanged
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        divddlcity.Visible = true;
        ddlCity.Enabled = true;
        CommonFillMethod.FillDropDownListCityIDByStateID(ddlCity, Convert.ToInt32(ddlState.SelectedValue));
    }
    #endregion ddlState_SelectedIndexChanged

    #region btnsubmit_Click
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        ClientBAL balClient = new ClientBAL();
        ClientENT entClient = new ClientENT();
        if (txtClientName.Text.Trim() != String.Empty)
            entClient.ClientName = txtClientName.Text.Trim();

        if (txtPhoneNo.Text.Trim() != String.Empty)
            entClient.PhoneNo = txtPhoneNo.Text.Trim();

        if (rbfemale.Checked)
            entClient.Gender = "Female";
        else if (rbmale.Checked)
            entClient.Gender = "Male";

        if (txtEmail.Text.Trim() != String.Empty)
            entClient.Email = txtEmail.Text.Trim();

        if (txtAddress.Text.Trim() != String.Empty)
            entClient.Address = txtAddress.Text.Trim();

        if (ddlCity.SelectedIndex > 0)
            entClient.CityID = Convert.ToInt32(ddlCity.SelectedValue);

        if (ddlJobType.SelectedIndex > 0)
            entClient.JobTypeID = Convert.ToInt32(ddlJobType.SelectedValue);

        if (kt_datepicker_2.Text.Trim() != String.Empty)
            entClient.BirthDate = DateTime.Parse(kt_datepicker_2.Text);
            //entClient.BirthDate = Convert.ToDateTime(kt_datepicker_2.Text);
            //entClient.BirthDate = DateTime.Parse(kt_datepicker_2.Text);
            
        if (txtSkills.Text.Trim() != String.Empty)
            entClient.Skills = txtSkills.Text.Trim();

        if (fuimage.HasFile)
        {
            String str = fuimage.FileName.ToString();
            fuimage.PostedFile.SaveAs(Server.MapPath("~/Content/assets/Images/")+ str);
            str = "~/Content/assets/Images/" + str;
            entClient.PhotoPath = str;
        }

        if (kt_touchspin_4.Text.Trim() != String.Empty)
            entClient.Experience = Convert.ToInt32(kt_touchspin_4.Text.Trim());

        entClient.IsActive = true;

        if (Session["ClientID"] == null)
        {
            if (txtpassword.Text.Trim() != String.Empty)
            {
                entClient.Password = txtpassword.Text.Trim();
            }
            entClient.RegistrationDate = DateTime.Now;
            Boolean registered = balClient.Insert(entClient);
            if (registered == false)
            {
                lblmessage.Text = balClient.Message + "<br/> Phone number already exist please enter another number or login.";
                txtPhoneNo.Focus();
            }
            //Response.Redirect(Request.UrlReferrer.ToString());
        }
        else
        {
            entClient.ClientID = Convert.ToInt32(Session["ClientID"]);
            Boolean update = balClient.Update(entClient);
            if (update == false)
            {
                lblmessage.Text = balClient.Message;
            }
            else
            {
                lblmessage.Text = "profile updated successfully";
            }
            //Response.Redirect(Request.UrlReferrer.ToString());
        }
        //            if (fuimage.HasFile)
        //            {
        //                String str = fuimage.FileName.ToString();
        //                String str2 = "~/Content/assets/Images/";
        //                fuimage.PostedFile.SaveAs(Server.MapPath("~/Content/assets/images/") + str);
        //                SqlCommand cmd = new SqlCommand("insert into test values ('" + str2 + str + "')", objConnection);
        //                cmd.ExecuteNonQuery();
    }
    #endregion btnsubmit_Click

}