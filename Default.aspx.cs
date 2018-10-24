using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class admin_DefaultAdmin : System.Web.UI.Page
{
    string strUserName = string.Empty;
    string strPassword = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        //using (GenarateSessionThroughtCoockie checkSession = new GenarateSessionThroughtCoockie())
        //{
        //    bool hasSession = checkSession.SessionCheck(3);
        //    if (hasSession == false)
        //    {
        //        Response.Redirect("Default.aspx");
        //        Response.End();
        //    }
        //}
    }

    protected void SigninButton_Click(object sender, EventArgs e)
    {
        strUserName = UserNameTextBox.Text;
        strPassword = PasswordTextBox.Text;
        IsLoginValid();

        //using (UserLoginGateway objUserLoginGateway = new UserLoginGateway())
        //{
        //    int checkAccess = 0;
        //    DataTable dataTable = objUserLoginGateway.CheckLogin(strUserName);
        //    checkAccess = Convert.ToInt32(dataTable.Rows[0]["AllowOutsideAccess"].ToString());
        //    string pathLink = ResolveUrl("Default.aspx");
        //    string VisitorsIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();

        //    if (!((VisitorsIP == "103.36.100.154") || (VisitorsIP == "163.53.150.122")) || ((VisitorsIP == "103.36.100.154") || (VisitorsIP == "163.53.150.122")))
        //    {
        //        IsLoginValid();
        //    }

        //    else
        //    {
        //        Response.Redirect(pathLink, false);
        //    }
        //}
    }


    private void IsLoginValid()
    {
        try
        {
            using (UserLoginGateway ObjUserLoginGateway = new UserLoginGateway())
            {
                UserLoginProperty ObjUserLoginProperty = new UserLoginProperty();

                ObjUserLoginProperty.UserName = strUserName;
                ObjUserLoginProperty.Password = strPassword;

                if (!ObjUserLoginGateway.IsAdminLoginValid(ObjUserLoginProperty))
                {
                    lblSystemMessage.Text = "Access denied! Invalid Login Email or Password.";
                }
                else
                {
                    this.Session.Timeout = 300;
                    this.Session["AD_ADMIN_ID"] = ObjUserLoginProperty.UserId.ToString();
                    this.Session["AD_ADMIN_NAME"] = ObjUserLoginProperty.UserFullName.ToString();
                    this.Session["AD_ADMIN_USERNAME"] = ObjUserLoginProperty.UserName.ToString();
                    this.Session["AD_ADMIN_TYPE"] = ObjUserLoginProperty.AdminType.ToString();

                    Response.Cookies["CK_AD_ADMIN_ID"].Value = ObjUserLoginProperty.UserId.ToString();
                    Response.Cookies["CK_AD_ADMIN_ID"].Expires = DateTime.Now.AddDays(7);

                    if(Convert.ToInt32(Session["AD_ADMIN_TYPE"]) != null)
                    {
                        Response.Redirect("ControlPanel.aspx", false);
                    }
                    else if ((Convert.ToInt32(Session["AD_ADMIN_TYPE"]) == 1) || (Convert.ToInt32(Session["AD_ADMIN_TYPE"]) == 11) || (Convert.ToInt32(Session["AD_ADMIN_TYPE"]) == 2))
                    {
                        Response.Redirect("ControlPanel.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("ControlPanel.aspx", false);
                    }
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

}