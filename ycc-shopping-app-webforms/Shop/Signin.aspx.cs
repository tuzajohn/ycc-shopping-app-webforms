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
            if(Session["message"] != null) { MesageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
            LoginEvent();
        }
        private void LoginEvent()
        {
            loginBtn.ServerClick += delegate
            {
                var logins = new ShoppingLibrary.Login().Load_record_with(Login_support.Column.Username, Login_support.LogicalOperator.EQUAL_TO, username.Value);
                if (!string.IsNullOrEmpty(logins.Id))
                {
                    if (enc.GetMD5(enc.StrongEncrypt(password.Value)) == logins.Password)
                    {
                        var uDetails = new Buyer(logins.Id);
                        Session["userId"] = logins.Id;
                        Session["fname"] = uDetails.Fname;
                        Session["lname"] = uDetails.Lname;
                        Session["contact"] = uDetails.PhoneNumber;
                        Session["shipping_address"] = uDetails.ShippingAddress;
                        Session["billing_address"] = uDetails.BillingAddress;
                        Session["email"] = uDetails.EmailAddress;

                        Response.Redirect("~/Shop/Address.aspx");
                    }
                    else { Session["message"] = elements.GetBasicMessage("Wrong username or password"); }
                }
                else { Session["message"] = elements.GetBasicMessage("Wrong username or password"); }
                Response.Redirect("~/Shop/Signin.aspx");
            };
        }
    }
}