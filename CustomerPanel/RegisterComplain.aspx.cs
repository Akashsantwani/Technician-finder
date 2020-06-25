using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkerFinder.BAL;
using WorkerFinder.ENT;

public partial class CustomerPanel_RegisterComplain : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("Login");
            }
            ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            fillClientName();
            //String name = (Label)PreviousPage.FindControl("lblClientName").ToString();
        }
    }
    #endregion Page_Load

    #region fillClientName
    private void fillClientName()
    {
        ClientBAL balclient = new ClientBAL();
        ClientENT entclient = new ClientENT();
        entclient = balclient.SelectByPK(Convert.ToInt32(Request.QueryString["ClientID"]));
        txtClientName.Text = entclient.ClientName.ToString();
    }
    #endregion fillClientName

    #region btnsubmit_Click
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        ComplainBAL balcomplain = new ComplainBAL();
        ComplainENT entComplain = new ComplainENT();
        entComplain.ClientID = Convert.ToInt32(Request.QueryString["ClientID"]);
        entComplain.CustomerID = Convert.ToInt32(Session["CustomerID"]);
        entComplain.ComplainMessage = txtComplain.ToString();
        entComplain.ComplainDate = DateTime.Now;
        Boolean register = balcomplain.Insert(entComplain);
        if (register == true)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Congratulations, Complain has been registered');", true);
            object refUrl = ViewState["RefUrl"];
            if (refUrl != null)
            {
                Response.Redirect((string)refUrl);
            }
            else
            {
                Response.Redirect("~/CustomerPanel/MyServices.aspx");
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Sorry, something weny wrong');", true);
            object refUrl = ViewState["RefUrl"];
            if (refUrl != null)
            {
                Response.Redirect((string)refUrl);
            }
            else
            {
                Response.Redirect("~/CustomerPanel/MyServices.aspx");
            }
        }
    }
    #endregion btnsubmit_Click
}