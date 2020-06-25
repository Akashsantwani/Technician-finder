using System;
using System.Data;
using WorkerFinder.BAL;
using WorkerFinder.ENT;

public partial class ClientPanel_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region page Button: Login
    
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";
        if (txtPhoneNo.Text.Trim() == "")
        {
            strErrorMessage += "  -  Enter Phone Number<br/>";
        }
        if (txtPassword.Text.Trim() == "")
        {
            strErrorMessage += "  -  Enter Password<br/>";
        }
        if (strErrorMessage != "")
        {
            lblerror.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        //String str = txtPhoneNo.Text.Trim();
        //String str1 = str.Split('+')[10];
        //List<string> countries_list = new List<string>();
        //countries_list.Add("91");
        //countries_list.Add("+91-");
        //countries_list.Add("+91");
        //countries_list.Add("91-");
        //countries_list.Add("0");
        //foreach (var country in countries_list)
        //{
        //    str = str.Replace(country, "");
        //}
        ClientBAL balclient = new ClientBAL();
        DataTable dtCustomer = new DataTable();
        DataTable dtClient = balclient.SelectByPhonePassword(txtPhoneNo.Text.Trim(), txtPassword.Text.Trim());
        if (dtClient != null && dtClient.Rows.Count > 0)
        {
            foreach (DataRow drUser in dtClient.Rows)
            {
                if (!drUser["ClientID"].Equals(DBNull.Value))
                {
                    Session["ClientID"] = drUser["ClientID"].ToString();
                }
                if (!drUser["ClientName"].Equals(DBNull.Value))
                {
                    Session["ClientName"] = drUser["ClientName"].ToString();
                }
                if (!drUser["PhotoPath"].Equals(DBNull.Value))
                {
                    Session["PhotoPath"] = drUser["PhotoPath"].ToString();
                }
                break;
            }
            Session.Timeout = 1000;
            string url = Convert.ToString(Request.QueryString["url"]);
            Response.Redirect("~/ClientPanel/JobsDone.aspx");
            //Server.Transfer("~/ClientPanel/JobsDone.aspx");
        }
        else
        {
            CustomerBAL balcustomer = new CustomerBAL();
            dtCustomer = balcustomer.SelectByphonePassword(txtPhoneNo.Text.Trim(), txtPassword.Text.Trim());
            if (dtCustomer != null && dtCustomer.Rows.Count > 0)
            {
                foreach (DataRow drCustomer in dtCustomer.Rows)
                {
                    if (!drCustomer["CustomerID"].Equals(DBNull.Value))
                    {
                        Session["CustomerID"] = drCustomer["CustomerID"].ToString();
                    }
                    if (!drCustomer["CustomerName"].Equals(DBNull.Value))
                    {
                        Session["CustomerName"] = drCustomer["CustomerName"].ToString();
                    }
                    if (!drCustomer["PhotoPath"].Equals(DBNull.Value))
                    {
                        Session["PhotoPath"] = drCustomer["PhotoPath"].ToString();
                    }
                    break;
                }
                Session.Timeout = 1000;
                string url = Convert.ToString(Request.QueryString["url"]);
                if (url == null)
                {
                    Response.Redirect("~/Home.aspx");
                }
                else
                {
                    Response.Redirect(url);
                }
            }
        }
        if (dtCustomer.Rows.Count == 0 && dtClient.Rows.Count == 0)
        {
            lblerror.Text = "Either username or password is incorrect";
            txtPassword.Text = "";
            txtPhoneNo.Text = "";
            txtPhoneNo.Focus();
        }
    }
    #endregion page Button: Login

    #region Button : Forget
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        ClientBAL balClient = new ClientBAL();
        ClientENT entClient = new ClientENT();
        entClient = balClient.SelectByPhoneNo(txtResetPhoneNo.Text.Trim());
        if (entClient.ClientName != null)
        {
            String password = balClient.RandomPassword();
            entClient.Password = password;
            Boolean updated = balClient.UpdatePasswordByPK(entClient);
            if (updated == true)
            {
                if (entClient.Email != null)
                {
                    Boolean mailsent = balClient.SendResetPasswordMail(entClient);
                    if (mailsent == true)
                    {
                        lblmessage.Text = "password reset successfully";
                    }
                    else
                    {
                        lblmessage.Text = "Something went wrong please try again(client)<br>";
                        lblmessage.Text += balClient.Message;
                    }
                }
            }
            else
            {
                lblmessage.Text = "Password was not updated, please try again(client)<br>";
                lblmessage.Text += balClient.Message;
            }
        }
        else
        {
            CustomerBAL balCustomer = new CustomerBAL();
            CustomerENT entCustomer = new CustomerENT();
            entCustomer = balCustomer.SelectByPhoneNo(txtResetPhoneNo.Text.Trim());
            if (entCustomer.CustomerName != null)
            {
                String password = balCustomer.RandomPassword();
                entCustomer.Password = password;
                Boolean updated = balCustomer.UpdatePasswordByPK(entCustomer);
                if (updated == true)
                {
                    if (entCustomer.Email != null)
                    {
                        Boolean mailsent = balCustomer.SendResetPasswordMail(entCustomer);
                        if (mailsent == true)
                        {
                            lblmessage.Text = "password reset successfully";
                        }
                        else
                        {
                            lblmessage.Text = "Something went wrong please try again(customer)<br>";
                            lblmessage.Text += balCustomer.Message;
                        }
                    }

                }
                else
                {
                    lblmessage.Text = "Password was not updated, please try again(customer)<br>";
                    lblmessage.Text += balCustomer.Message;
                }
            }
            else
            {
                lblmessage.Text = "Phone number does not exist please try again";
            }
        }
        //DataTable Client = balClient.SelectByPhoneNo(txtResetPhoneNo.Text.Trim());
        //String ClientName = Client.Rows[0][1].ToString();
        //Int32 ClientID = Convert.ToInt32(Client.Rows[0][0]);
        //String Email = Client.Rows[0][2].ToString();
    }
    #endregion Button : Forget
}