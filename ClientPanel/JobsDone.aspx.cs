using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkerFinder.BAL;

public partial class ClientPanel_JobsDone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["ClientID"] != null)
            {
                FillCustomerList(Convert.ToInt32(Session["ClientID"]));
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
        }
    }

    #region FillCustomerList
    private void FillCustomerList(Int32 ClientID)
    {
        try
        {
            WorkBAL BalWork = new WorkBAL();
            rptworks.DataSource = BalWork.SelectByClientID(ClientID);
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
        Label name = (Label)e.Item.FindControl("lblName");
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
        Label lblWorkDate = (Label)e.Item.FindControl("lblWorkDate");
        if (lblWorkDate.Text == "")
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