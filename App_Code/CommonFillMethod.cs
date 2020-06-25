using System.Data.SqlTypes;
using System.Web.UI.WebControls;
using WorkerFinder.BAL;

/// <summary>
/// Summary description for CommonFillMethod
/// </summary>
namespace WorkerFinder
{
    public class CommonFillMethod
    {
        #region fillDropDownCityID
        public static void FillDropDownListCityID(DropDownList ddl)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectDropDownList();
            ddl.DataTextField = "CityName";
            ddl.DataValueField = "CityID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select City", "-1"));
            ddl.Items[0].Selected = true;
            ddl.Items[0].Attributes["Disabled"] = "Disabled";
        }
        #endregion fillDropDownCityID

        #region fillDropDownCityIDByStateID
        public static void FillDropDownListCityIDByStateID(DropDownList ddl, SqlInt32 StateID)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectDropDownListByStateID(StateID);
            ddl.DataTextField = "CityName";
            ddl.DataValueField = "CityID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select City", "-1"));
        }
        #endregion fillDropDownCityIDByStateID

        #region fillDropDownStateID
        public static void FillDropDownListStateID(DropDownList ddl)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectDropDownList();
            ddl.DataTextField = "StateName";
            ddl.DataValueField = "StateID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select state", "-1"));
            ddl.Items[0].Selected = true;
            ddl.Items[0].Attributes["Disabled"] = "Disabled";
        }
        #endregion fillDropDownStateID

        #region fillDropDownJobTypeID
        public static void FillDropDownListJobTypeID(DropDownList ddl)
        {
            JobTypeBAL balJobType = new JobTypeBAL();
            ddl.DataSource = balJobType.SelectDropDownList();
            ddl.DataTextField = "JobTypeName";
            ddl.DataValueField = "JobTypeID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select Service", "-1"));
            ddl.Items[0].Selected = true;
            ddl.Items[0].Attributes["Disabled"] = "Disabled";
        }
        #endregion fillDropDownJobTypeID
    }
}