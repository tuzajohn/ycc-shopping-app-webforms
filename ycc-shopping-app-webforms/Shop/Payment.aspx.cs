using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ycc_shopping_app_webforms.Shop
{
    public partial class Payment : System.Web.UI.Page
    {
        HtmlElements elements = new HtmlElements();
        Dictionary<string, string> bcomb = new Dictionary<string, string>();
        SessionVerification SV;
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            bcomb.Add("Default.aspx", "Home");
            bcomb.Add("Payment.aspx", "Payment");
            BreadLiteral.Text = elements.BreadComd(bcomb);
            Check();
        }
        void Check()
        {
            if (string.IsNullOrEmpty(SV.Id))
            {
                Response.Redirect("~/");
            }
        }

    }
}