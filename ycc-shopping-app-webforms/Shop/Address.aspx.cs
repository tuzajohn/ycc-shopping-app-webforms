using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ycc_shopping_app_webforms.Shop
{
    public partial class Address : System.Web.UI.Page
    {
        HtmlElements elements = new HtmlElements();
        Dictionary<string, string> bcomb = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            bcomb.Add("Defaul.aspx", "Home");
            bcomb.Add("Address.aspx", "Address");
            BreadLiteral.Text = elements.BreadComd(bcomb);
        }
    }
}