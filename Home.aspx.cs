using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WorkerFinder;
using WorkerFinder.BAL;
using WorkerFinder.ENT;

public partial class Home : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
        }
        //ddldemo.Items[0].Attributes.Add("style", "color:red;");
    }

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethod.FillDropDownListCityID(ddlCity);
        CommonFillMethod.FillDropDownListJobTypeID(ddlJobType);
    }
    #endregion FillDropDownList

    //    List<string> empResult = new List<string>();
    //    while (ENTJobtype != null)
    //    {
    //        empResult.Add(ENTJobtype.JobTypeName.ToString());
    //    }
    //    return empResult;
    protected void ddlJobType_SelectedIndexChanged(object sender, EventArgs e)
    {
        HttpCookie search = new HttpCookie("search");
        search["city"] = ddlCity.SelectedItem.ToString();
        search["jobtype"] = ddlJobType.SelectedItem.ToString();
        search.Expires.Add(new TimeSpan(0, 1, 0));
        Response.Cookies.Add(search);
        //Response.Cookies["city"].Value = ddlCity.SelectedItem.ToString();
        //Response.Cookies["jobtype"].Value = ddlJobType.SelectedItem.ToString();
    }
    protected void lbSearch_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlJobType.SelectedValue) > 0 && Convert.ToInt32(ddlCity.SelectedValue) > 0)
            Response.Redirect("~/WorkerList.aspx?JobTypeID=" + ddlJobType.SelectedValue + "&CityID=" + ddlCity.SelectedValue);
    }
}