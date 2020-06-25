using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkerFinder.BAL;
using WorkerFinder.ENT;

public partial class CustomerPanel_MyServicesnew : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["CustomerID"] != null)
            {
                FillClientList(Convert.ToInt32(Session["CustomerID"]));
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
        }
    }
    #endregion Page_Load

    #region FillClientList
    private void FillClientList(Int32 CustomerID)
    {
        try
        {
            WorkBAL BalWork = new WorkBAL();
            rptservices.DataSource = BalWork.SelectByCustomerID(CustomerID);
            rptservices.DataBind();

        }
        catch (Exception ex)
        {
            Response.Redirect("Errors");
        }
    }
    #endregion FillClientList

    #region rptworks_ItemDataBound
    protected void rptservices_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
        Label lblJobType = (Label)e.Item.FindControl("lblJobType");
        if (lblJobType.Text == "")
        {
            e.Item.FindControl("lbltype").Visible = false;
        }
        else
        {
            e.Item.FindControl("lbltype").Visible = true;
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

    #region rptworks_ItemCommand
    protected void rptworks_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label lblEmail = (Label)e.Item.FindControl("lblEmail");
        
        if (Session["CustomerID"] != null)
        {
            if (lblEmail.Text != null)
            {
                try
                {
                    #region create client bal/ent
                    ClientBAL balclient = new ClientBAL();
                    ClientENT entclient = new ClientENT();
                    Label lblClientID = (Label)e.Item.FindControl("lblClientID");
                    Label ClientName = (Label)e.Item.FindControl("lblName");
                    entclient.ClientID = Convert.ToInt32(lblClientID.Text);
                    entclient.ClientName = ClientName.Text;
                    entclient.Email = lblEmail.Text;
                    #endregion create client bal/ent

                    #region ent/bal customer
                    CustomerBAL balcustomer = new CustomerBAL();
                    CustomerENT entcustomer = new CustomerENT();
                    entcustomer = balcustomer.SelectByPK(Convert.ToInt32(Session["CustomerID"]));
                    #endregion ent/bal customer

                    Boolean mail = balclient.SendNewJobMail(entclient, entcustomer);
                    if (mail == true)
                    {
                        lblmessage.Text = "sent mail successfully";
                        #region work insert
                        WorkBAL balwork = new WorkBAL();
                        WorkENT entwork = new WorkENT();
                        entwork.ClientID = Convert.ToInt32(lblClientID.Text);
                        entwork.CustomerID = Convert.ToInt32(Session["CustomerID"]);
                        entwork.Workdate = DateTime.Now;
                        balwork.Insert(entwork);
                        #endregion work insert
                    }
                    else
                    {
                        lblmessage.Text = "something went wrong please try again";
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Congratulations, Technician is hired successfully');", true);
                }
                catch (Exception ex)
                {
                    lblmessage.Text = ex.Message.ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Sorry, There Was An Error');", true);
                }
            }
        }
        else
        {
            //Response.Redirect("~/Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            //data-target="#kt_modal_6"
            //data-toggle="modal"
            //Button hlHire = (Button)e.Item.FindControl("hlHire");
            //hlHire.Attributes["data-toggle"] = "modal";
            //hlHire.Attributes["data-target"] = "#kt_modal_6";
        }
    }
    #endregion rptworks_ItemCommand
    protected void hlHire_Click(object sender, EventArgs e)
    {

    }
}