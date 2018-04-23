using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingLibrary;


namespace ycc_shopping_app_webforms.Shop
{
    public partial class Product : System.Web.UI.Page
    {
        HtmlElements elements = new HtmlElements();
        SessionVerification SV;
        Encryption enc = new Encryption() { Key = "_H%^.#1g" };
        Dictionary<string, string> bcomb = new Dictionary<string, string>();
        List<Cart> Carts;
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            Carts = new List<Cart>();
            bcomb.Add("Default.aspx", "Home");
            bcomb.Add("#", "Product");
            BreadLiteral.Text = elements.BreadComd(bcomb);

            if(Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }

            var add = Request.Params.Get("action");
            var itemId = Request.Params.Get("id");
            if (!string.IsNullOrEmpty(itemId))
            {
                ItemInfoDisplay(itemId);
            }
            if (!string.IsNullOrEmpty(add))
            {
                AddToCart(enc.DecryptString(itemId, SV.Key));
            }
            if(string.IsNullOrEmpty(add) && string.IsNullOrEmpty(itemId)) { Response.Redirect("~/Shop/Default.aspx"); }
        }
        void ItemInfoDisplay(string id)
        {
            var item = new Item(enc.DecryptString(id, SV.Key));
            Session["item"] = item.Name;
            costText.InnerText = SV.GetUGX(item.Price);
            desc.InnerText = item.Description;
            ModelITemLiteral.Text = elements.GetItemToCart(item.Id, SV.GetImage(item.Picture));
            ItemBtnCart.Text = elements.BtnAddToCart(enc.EncryptString(item.Id, SV.Key));
        }
        private void AddToCart(string id)
        {
            if (Session["cartList"] != null)
            {
                var list = (List<Cart>)Session["cartList"];                
                foreach (var cart in list)
                {
                    if(cart.ItemID == id)
                    {
                        Session["message"] = elements.GetBasicMessage($"This product is already in the cart!");
                        Response.Redirect($"~/Shop/Product.aspx?id={enc.EncryptString(id, SV.Key)}");
                    }
                    Carts.Add(new Cart { ItemID = cart.ItemID, Qty = cart.Qty });
                }
                Carts.Add(new Cart { ItemID = id, Qty = qtySelect.Value });
                Session["cartList"] = null;
                Session["cartList"] = Carts;
            }
            else
            {
                Carts.Add(new Cart { ItemID = id, Qty = qtySelect.Value });
                Session["cartList"] = Carts;
            }
            Session["message"] = elements.GetBasicMessage($"Added to cart!");
            Response.Redirect($"~/Shop/Product.aspx?id={enc.EncryptString(id, SV.Key)}");
        }

    }
}