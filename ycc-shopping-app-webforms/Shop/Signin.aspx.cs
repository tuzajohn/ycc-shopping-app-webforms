using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingLibrary;

namespace ycc_shopping_app_webforms.Shop
{
    public partial class Signin : System.Web.UI.Page
    {
        HtmlElements elements = new HtmlElements();
        Encryption enc;
        SessionVerification SV;
        Dictionary<string, string> bcomb = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            enc = new Encryption() { Key = SV.Key };
            bcomb.Add("Default.aspx", "Home");
            bcomb.Add("Signin.aspx", "Sign In");
            BreadLiteral.Text = elements.BreadComd(bcomb);
        }
        private void LoginEvent()
        {
            loginBtn.ServerClick += delegate
            {
                var logins = new Login_table().Load_record_with(Login_table_support.Column.Username, Login_table_support.LogicalOperator.EQUAL_TO, username.Value);
                if (!string.IsNullOrEmpty(logins.Id))
                {
                    if (enc.GetMD5(password.Value) == logins.Password)
                    {
                        var uDetails = new Buyer(logins.Id);
                        //logins, then go to address
                    }
                    else { }
                }
                else { }
            };
        }
    }
}