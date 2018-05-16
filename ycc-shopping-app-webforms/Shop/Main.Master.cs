using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingLibrary;

namespace ycc_shopping_app_webforms.Shop
{
    public partial class Main : System.Web.UI.MasterPage
    {
        SessionVerification SV;
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            Check();
            SetCategories();
            if(Session["cartList"] != null)
            {
                var carts = (List<Cart>)Session["cartList"];
                CartItemCounterLiteral.Text = carts.Count.ToString();
            }
            else { CartItemCounterLiteral.Text = "0"; }
        }
        void Check()
        {
            if (string.IsNullOrEmpty(SV.Id))
            {
                logout.Style.Add("display", "none");
                signup.Style.Remove("display");
            }
            else
            {
                logout.Style.Remove("display");
                signup.Style.Add("display", "none");
            }
        }
        private void SetCategories()
        {
            var d = string.Empty;
            var cat = new Category().getAllRecords(Category_support.Column.Name, Category_support.Order.ASCENDING);
            foreach (var item in cat)
            {
                d += $@"
                <a href='../../Shop/Default.aspx?category={item.Name}' class='list-group-item'>
                    {item.Name}
                </a>";
            }
            CatLiteral.Text = d;
        }
    }
}