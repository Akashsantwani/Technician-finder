using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkerFinder.BAL;

public partial class ClientPanel_MyComplains : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillComplainList(Convert.ToInt32(Session["ClientID"]));
        }
    }

    #region FillComplainList
    private void FillComplainList(Int32 ClientID)
    {
        try
        {
            ComplainBAL BalComplain = new ComplainBAL();
            rptworks.DataSource = BalComplain.SelectByClientID(ClientID);
            rptworks.DataBind();

        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error");
        }
    }
    #endregion FillComplainList

    #region rptworks_ItemDataBound
    protected void rptworks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblComplainDate = (Label)e.Item.FindControl("lblComplainDate");
        if (lblComplainDate.Text == "")
        {
            e.Item.FindControl("lbldate").Visible = false;
        }
        else
        {
            e.Item.FindControl("lbldate").Visible = false;
        }
        Label lblComplainMessage = (Label)e.Item.FindControl("lblComplainMessage");
        if (lblComplainMessage.Text == "")
        {
            e.Item.FindControl("lblmessage").Visible = false;
        }
        else
        {
            e.Item.FindControl("lblmessage").Visible = true;
        }
    }
    #endregion rptworks_ItemDataBound
}