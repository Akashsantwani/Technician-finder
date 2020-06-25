using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkerFinder;
using WorkerFinder.BAL;
using WorkerFinder.ENT;

public partial class CustomerPanel_RegisterCustomer : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (Session["CustomerID"] != null)
            {
                LoadControls(Convert.ToInt32(Session["CustomerID"]));
                txtPhoneNo.Enabled = false;
                //rfvPassword.ValidationGroup = "";
                //rfvconpassword.ValidationGroup = "";
                //cvconfirmpass.ValidationGroup = "";
                //divpassword.Visible = false;
            }
        }
    }
    #endregion Page_Load

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethod.FillDropDownListStateID(ddlState);
    }
    #endregion FillDropDownList

    #region LoadControls
    private void LoadControls(SqlInt32 CustomerID)
    {
        CustomerENT entcustomer = new CustomerENT();
        CustomerBAL balcustomer = new CustomerBAL();
        entcustomer = balcustomer.SelectByPK(CustomerID);
        divddlcity.Visible = true;

        if (!entcustomer.CustomerName.IsNull)
            txtCustomerName.Text = entcustomer.CustomerName.Value.ToString();

        if (!entcustomer.PhoneNo.IsNull)
            txtPhoneNo.Text = entcustomer.PhoneNo.Value.ToString();


        if (!entcustomer.Email.IsNull)
            txtEmail.Text = entcustomer.Email.Value.ToString();

        if (!entcustomer.Address.IsNull)
            txtAddress.Text = entcustomer.Address.Value.ToString();

        if (!entcustomer.StateID.IsNull)
        {
            ddlState.SelectedValue = entcustomer.StateID.Value.ToString();
            ddlCity.Enabled = true;
            CommonFillMethod.FillDropDownListCityIDByStateID(ddlCity, ddlState.SelectedIndex);
        }

        if (!entcustomer.CityID.IsNull)
            ddlCity.SelectedValue = entcustomer.CityID.Value.ToString();
        
        if (!entcustomer.PhotoPath.IsNull)
            divimage.Style["background-image"] = entcustomer.PhotoPath.ToString();

        // password left
    }

    #endregion LoadControls

    #region ddlState_SelectedIndexChanged
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        divddlcity.Visible = true;
        ddlCity.Enabled = true;
        CommonFillMethod.FillDropDownListCityIDByStateID(ddlCity, ddlState.SelectedIndex);
    }
    #endregion ddlState_SelectedIndexChanged

    #region Button : Add
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        CustomerBAL balcustomer = new CustomerBAL();
        CustomerENT entcustomer = new CustomerENT();

        if (txtCustomerName.Text.Trim() != String.Empty)
            entcustomer.CustomerName = txtCustomerName.Text.Trim();

        if (txtPhoneNo.Text.Trim() != String.Empty)
            entcustomer.PhoneNo = txtPhoneNo.Text.Trim();

        if (txtEmail.Text.Trim() != String.Empty)
            entcustomer.Email = txtEmail.Text.Trim();

        if (txtAddress.Text.Trim() != String.Empty)
            entcustomer.Address = txtAddress.Text.Trim();

        if (ddlCity.SelectedIndex > 0)
            entcustomer.CityID = Convert.ToInt32(ddlCity.SelectedValue);

        if (fuimage.HasFile)
        {
            String str = fuimage.FileName.ToString();
            fuimage.PostedFile.SaveAs(Server.MapPath("~/Content/assets/Images/") + str);
            str = "~/Content/assets/Images/" + str;
            entcustomer.PhotoPath = str;
        }

        if (Session["CustomerID"] == null)
        {
            if (txtpassword.Text.Trim() != String.Empty)
            {
                entcustomer.Password = txtpassword.Text.Trim();
            }
            entcustomer.RegistrationDate = DateTime.Now;
            balcustomer.Insert(entcustomer);
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        else
        {
            entcustomer.CustomerID = Convert.ToInt32(Session["CustomerID"]);
            balcustomer.Update(entcustomer);
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
    #endregion Button : Add

}