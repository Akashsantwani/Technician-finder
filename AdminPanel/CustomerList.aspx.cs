using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkerFinder.BAL;

public partial class AdminPanel_CustomerList : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCustomerList();
        }
    }
    #endregion Page_Load

    #region FillCustomerList
    private void FillCustomerList()
    {
        try
        {
            CustomerBAL balcustomer = new CustomerBAL();
            rptworks.DataSource = balcustomer.SelectAll();
            rptworks.DataBind();

        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error/Error.html");
        }
    }
    #endregion FillWorkerList

    #region rptworks_ItemDataBound
    protected void rptworks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblEmail = (Label)e.Item.FindControl("lblEmail");
        if (lblEmail.Text == "")
        {
            e.Item.FindControl("iconemail").Visible = false;
        }
        else
        {
            e.Item.FindControl("iconemail").Visible = true;
        }
        Label lbladdress = (Label)e.Item.FindControl("lbladdress");
        if (lbladdress.Text == "")
        {
            e.Item.FindControl("lblAdd").Visible = false;
        }
        else
        {
            e.Item.FindControl("lblAdd").Visible = true;
        }
        Label lblRegistrationDate = (Label)e.Item.FindControl("lblRegistrationDate");
        if (lblRegistrationDate.Text == "")
        {
            e.Item.FindControl("lbldate").Visible = false;
        }
        else
        {
            e.Item.FindControl("lbldate").Visible = true;
        }
        Image imgphoto = (Image)e.Item.FindControl("imgphoto");
        if (imgphoto.ImageUrl == "")
        {
            imgphoto.ImageUrl = "../Content/assets/Images/Default-User.png";
        }
    }
    #endregion rptworks_ItemDataBound
}