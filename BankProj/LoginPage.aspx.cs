using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void login_Click(object sender, EventArgs e)
    {
        ServiceReference1.Service1Client obj = new ServiceReference1.Service1Client();
        string result = obj.checkCre(userId.Text, password.Text);
        if (result == "Manager")
        {
            Response.Redirect("Manager.aspx");
        }
        else if(result=="Customer")
        {
            Response.Redirect("Customer.aspx");

        }







    }
}