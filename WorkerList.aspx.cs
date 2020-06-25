using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WorkerFinder;
using WorkerFinder.BAL;
using WorkerFinder.ENT;

public partial class masterpagedemo : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["JobTypeID"] != null && Request.QueryString["CityID"] != null)
            {
                FillWorkerList(Convert.ToInt32(Request.QueryString["JobTypeID"]), Convert.ToInt32(Request.QueryString["CityID"]));
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
            HttpCookie search = Request.Cookies["search"];
            if (search != null)
            {
                lblCity.Text = search["city"].ToString();
                lblJobType.Text = search["jobtype"].ToString();
            }
            //HttpCookie city = Request.Cookies["city"];
            //HttpCookie jobtype = Request.Cookies["jobtype"];
            //lblCity.Text = Request.Cookies["city"].Value;
        }
    }
    #endregion Page_Load

    #region FillWorkerList
    private void FillWorkerList(Int32 JobTypeID, Int32 CityID)
    {
        try
        {
            ClientBAL BalClient = new ClientBAL();
            rptworks.DataSource = BalClient.SelectByJobTypeID(JobTypeID, CityID);
            rptworks.DataBind();
            if (rptworks.Items.Count > 0)
            {
                divalert.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //Response.Redirect("Errors");
            lblmessage.Text = ex.Message.ToString();
        }
    }
    #endregion FillWorkerList

    #region rptworks_ItemDataBound
    protected void rptworks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //String Client = e.Item.FindControl("hlHire").ToString();
        Image imgphoto = (Image)e.Item.FindControl("imgphoto");
        if (imgphoto.ImageUrl == "")
        {
            imgphoto.ImageUrl = "../Content/assets/Images/Default-User.png";
        }
        Label lblEmail = (Label)e.Item.FindControl("lblEmail");
        if (lblEmail.Text == "")
        {
            e.Item.FindControl("iconemail").Visible = false;
        }
        else
        {
            e.Item.FindControl("iconemail").Visible = true;
        }
        Label lblExperience = (Label)e.Item.FindControl("lblExperience");
        if (lblExperience.Text == "")
        {
            e.Item.FindControl("lblExp").Visible = false;
            e.Item.FindControl("divexperience").Visible = false;
        }
        else
        {
            e.Item.FindControl("lblExp").Visible = true;
            e.Item.FindControl("divexperience").Visible = true;
        }
        Label lblSkills = (Label)e.Item.FindControl("lblskills");
        if (lblSkills.Text == "")
        {
            e.Item.FindControl("divskills").Visible = false;
        }
        else
        {
            e.Item.FindControl("divskills").Visible = true;
        }
        Label lblPhone = (Label)e.Item.FindControl("lblPhone");
        if (lblPhone.Text != "")
        {
            HyperLink anc = (HyperLink)e.Item.FindControl("ancphone");
            anc.NavigateUrl = "tel:+91" + lblPhone;
        }
        //Int32 lblServices = Convert.ToInt32(e.Item.FindControl("lblServiceCount"));
        //Int32 lblComplains = Convert.ToInt32(e.Item.FindControl("lblComplainsCount"));
        //Int32 diff = lblServices - lblComplains;
        //Int32 efficiency = (diff * 100) / lblServices;
        Label lblServices = (Label)e.Item.FindControl("lblServiceCount");
        if (Convert.ToInt32(lblServices.Text) > 0)
        {
            Label lblComplains = (Label)e.Item.FindControl("lblComplainsCount");
            Int32 diff = Convert.ToInt32(lblServices.Text) - Convert.ToInt32(lblComplains.Text);
            Int32 efficiency = (diff * 100) / Convert.ToInt32(lblServices.Text);
            HtmlContainerControl divprogress = (HtmlContainerControl)e.Item.FindControl("divprogress");
            divprogress.Style.Add("width", efficiency.ToString() + "%");
            Label lblprogress = (Label)e.Item.FindControl("lblprogress");
            lblprogress.Text = efficiency.ToString() + "%";
            if (efficiency < 50)
            {
                divprogress.Attributes["class"] = "kt-bg-danger";
            }
        }
        Button hlHire = (Button)e.Item.FindControl("hlHire");
        HtmlButton btnHire = (HtmlButton)e.Item.FindControl("btnHire");
        if (Session["CustomerID"] == null)
        {
            btnHire.Visible = true;
            hlHire.Visible = false;
            //hlHire.Attributes["data-toggle"] = "modal";
            //hlHire.Attributes["data-target"] = "#cphbody_kt_modal_6";
        }
        else
        {
            btnHire.Visible = false;
            hlHire.Visible = true;
            //hlHire.Attributes["OnClientClick"].Remove() = "return true;";
            //hlHire.Attributes["OnClientClick"].Replace("return false;", "");
        }
        
        //hlHire.OnClientClick = false;

        //HtmlButton btnHire = (HtmlButton)e.Item.FindControl("btnHire");
        //btnHire.Attributes["data-toggle"] = "modal";
        //btnHire.Attributes["data-target"] = "#cphbody_kt_modal_6";
        
    }
    #endregion rptworks_ItemDataBound

    #region rptworks_ItemCommand
    protected void rptworks_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Hire")
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
    }
    #endregion rptworks_ItemCommand

    #region button hire
    protected void hlHire_Click(object sender, EventArgs e)
    {
        if (Session["CustomerID"] == null)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#cphbody_kt_modal_6').modal('show');</script>", false);
        }
    }
    #endregion button hire

}