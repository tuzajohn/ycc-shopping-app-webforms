using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingLibrary;

namespace ycc_shopping_app_webforms.Shop
{
    public partial class ShopNow : System.Web.UI.Page
    {
        HtmlElements elements = new HtmlElements();
        Dictionary<string, string> bcomb = new Dictionary<string, string>();
        SessionVerification SV;
        Encryption enc;
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            enc = new Encryption() { Key = SV.Key };
            bcomb.Add("Default.aspx", "Home");
            bcomb.Add("Shopnow.aspx", "Cart");
            BreadLiteral.Text = elements.BreadComd(bcomb);
            var id = Request.Params.Get("delete");
            var qty = Request.Params.Get("qty");
            if (!string.IsNullOrEmpty(id))
            {
                DeleteItemFromCart(id, qty);
            }
            DisplayCartContent();
            NextNav();
        }
        void DisplayCartContent()
        {
            var Cartlist = (List<Cart>)Session["cartList"];
            var d = string.Empty;
            if (Cartlist == null) { d = "<p>Cart is empty!<p>"; }
            else
            {
                var tempTotal = 0;
                var tp = 0;
                foreach (var item in Cartlist)
                {
                    var cart = new Item(item.ItemID);
                    var subtotal =int.Parse(cart.Price) * int.Parse(item.Qty);
                    tempTotal += subtotal;
                    d += elements.GetCartItemRows(enc.EncryptString(cart.Id, SV.Key), SV.GetImage(cart.Picture), item.Qty, cart.Name, cart.Price, subtotal.ToString());
                }
                subTotal.Text = tempTotal.ToString();
                transportLiteral.Text = tp.ToString();
                Total.Text = (tp + tempTotal).ToString();
            }
            Session["total"] = Total;
            CartITemLiteral.Text = d;
        }
        void DeleteItemFromCart(string id, string qty)
        {
            var Cartlist = (List<Cart>)Session["cartList"];
            
            var c = Cartlist.FindIndex(r => r.ItemID == enc.DecryptString(id, SV.Key));
            Cartlist.RemoveAt(c);
            Response.Redirect("~/Shop/Shopnow.aspx");
        }
        void NextNav()
        {
            if (String.IsNullOrEmpty(SV.Id)) { Response.Redirect("~/Shop/Signin.aspx"); }
            else { Response.Redirect("~/Shop/Address.aspx"); }
        }
    }
}