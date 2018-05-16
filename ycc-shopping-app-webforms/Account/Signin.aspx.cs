using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingLibrary;

namespace ycc_shopping_app_webforms.Account
{
    public partial class Signin : System.Web.UI.Page
    {
        Encryption enc;
        SessionVerification SV;
        HtmlElements elements = new HtmlElements();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            enc = new Encryption() { Key = SV.Key };
            if(Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
            LoginEvent();
        }
        void LoginEvent()
        {
            loginBtn.ServerClick += delegate
            {
                var login = new ShoppingLibrary.Login().Load_record_with(Login_support.Column.Username, Login_support.LogicalOperator.EQUAL_TO, username.Value);
                if (string.IsNullOrEmpty(login.Id))
                {
                    if (password.Value == password_confirm.Value)
                    {
                        login.insert(username.Value, enc.GetMD5(enc.StrongEncrypt(password.Value)));
                        var buyer = new Buyer();
                        buyer.insert(fname.Value, lname.Value, email.Value, shippingAddress.Value, billingAddress.Value, contact.Value);
                        if (Session["item_id"] != null) { Response.Redirect($"~/Shop/Signin.aspx"); }
                        else { Response.Redirect($"~/Shop/"); }
                    }
                    else { Session["message"] = elements.GetBasicMessage("Passwords do not match!"); Response.Redirect($"~/Account/Signin.aspx"); }
                }
                else { Session["message"] = elements.GetBasicMessage("Username not available"); Response.Redirect($"~/Account/Signin.aspx"); }
            };
        }
    }
}