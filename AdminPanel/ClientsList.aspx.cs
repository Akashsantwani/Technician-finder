using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkerFinder.BAL;

public partial class AdminPanel_ClientsList : System.Web.UI.Page
{
    #region global variables
    readonly PagedDataSource _pgsource = new PagedDataSource();
    int _firstIndex, _lastIndex;
    private int _pageSize = 10;
    private int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] == null)
            {
                return 0;
            }
            return ((int)ViewState["CurrentPage"]);
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }
    #endregion global variables

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //FillWorkerList();
            BindDataIntoRepeater();
        }
    }
    #endregion Page_Load

    #region GetDataFromDb 
    static DataTable GetDataFromDb()
    {
        ClientBAL BalClient = new ClientBAL();
        var dt = new DataTable();
        dt = BalClient.SelectAll();
        return dt;
    }
    #endregion GetDataFromDb

    // Bind PagedDataSource into Repeater
    #region BindDataIntoRepeater
    private void BindDataIntoRepeater()
    {
        var dt = GetDataFromDb();
        _pgsource.DataSource = dt.DefaultView;
        _pgsource.AllowPaging = true;
        // Number of items to be displayed in the Repeater
        _pgsource.PageSize = _pageSize;
        _pgsource.CurrentPageIndex = CurrentPage;   
        lblRecords.Text = " Displaying " + _pageSize + " of " + _pgsource.DataSourceCount.ToString() + " records";
        // Keep the Total pages in View State
        ViewState["TotalPages"] = _pgsource.PageCount;
        // Example: "Page 1 of 10"
        lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
        // Enable First, Last, Previous, Next buttons
        lbPrevious.Enabled = !_pgsource.IsFirstPage;
        lbNext.Enabled = !_pgsource.IsLastPage;
        lbFirst.Enabled = !_pgsource.IsFirstPage;
        lbLast.Enabled = !_pgsource.IsLastPage;
        // Bind data into repeater
        rptworks.DataSource = _pgsource;
        rptworks.DataBind();
        // Call the function to do paging
        HandlePaging();
    }
    #endregion BindDataIntoRepeater

    #region HandlePaging
    private void HandlePaging()
    {
        var dt = new DataTable();
        dt.Columns.Add("PageIndex"); //Start from 0
        dt.Columns.Add("PageText"); //Start from 1

        _firstIndex = CurrentPage - 5;
        if (CurrentPage > 5)
            _lastIndex = CurrentPage + 5;
        else
            _lastIndex = 10;

        // Check last page is greater than total page then reduced it 
        // to total no. of page is last index
        if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
        {
            _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
            _firstIndex = _lastIndex - 10;
        }

        if (_firstIndex < 0)
            _firstIndex = 0;

        // Now creating page number based on above first and last page index
        for (var i = _firstIndex; i < _lastIndex; i++)
        {
            var dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }

        rptPaging.DataSource = dt;
        rptPaging.DataBind();
        
    }
    #endregion HandlePaging

    #region lbFirst_Click
    protected void lbFirst_Click(object sender, EventArgs e)
    {
        CurrentPage = 0;
        BindDataIntoRepeater();
    }
    #endregion lbFirst_Click

    #region lbLast_Click
    protected void lbLast_Click(object sender, EventArgs e)
    {
        CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
        BindDataIntoRepeater();
    }
    #endregion lbLast_Click

    #region lbPrevious_Click
    protected void lbPrevious_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        BindDataIntoRepeater();
    }
    #endregion lbPrevious_Click

    #region lbNext_Click
    protected void lbNext_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        BindDataIntoRepeater();
    }
    #endregion lbNext_Click

    #region rptPaging_ItemCommand
    protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (!e.CommandName.Equals("newPage")) return;
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        BindDataIntoRepeater();
    }
    #endregion rptPaging_ItemCommand

    #region rptPaging_ItemDataBound
    protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
        if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
        lnkPage.Enabled = false;
        //lnkPage.BackColor = Color.FromName("#00FF00");
        lnkPage.CssClass = "kt-pagination__link--active";
    }
    #endregion rptPaging_ItemDataBound

    #region ddlList_SelectedIndexChanged
    protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
    {
        _pageSize = Convert.ToInt32(ddlList.SelectedValue);
        lblRecords.Text = " Displaying " + ddlList.SelectedValue + " of " + _pgsource.DataSourceCount.ToString() + " records";
        BindDataIntoRepeater();
    }
    #endregion ddlList_SelectedIndexChanged

    #region FillWorkerList
    private void FillWorkerList()
    {
        ClientBAL BalClient = new ClientBAL();
        rptworks.DataSource = BalClient.SelectAll();
        rptworks.DataBind();
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
        Label lblExperience = (Label)e.Item.FindControl("lblExperience");
        if (lblExperience.Text == "")
        {
            e.Item.FindControl("lblExp").Visible = false;
        }
        else
        {
            e.Item.FindControl("lblExp").Visible = true;
        }
        System.Web.UI.WebControls.Image imgphoto = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgphoto");
        if (imgphoto.ImageUrl == "")
        {
            imgphoto.ImageUrl = "../Content/assets/Images/Default-User.png";
        }
    }
    #endregion rptworks_ItemDataBound
    
}