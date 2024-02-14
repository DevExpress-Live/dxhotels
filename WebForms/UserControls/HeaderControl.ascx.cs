using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_HeaderControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLoginNow_Click(object sender, EventArgs e) {
        if(Captcha.IsValid)
            LogonControl.ShowOnPageLoad = false;
    }
}
