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
            var cd = qty.Value;
            if(Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
            try { Session["item_id"] = enc.DecryptString(Request.Params.Get("id"), SV.Key); }
            catch (Exception) { Response.Redirect("~/Shop/"); }
            ItemInfoDisplay();
            AddToCart();
        }
        void ItemInfoDisplay()
        {
            var item = new Item(Session["item_id"].ToString());
            var instockMsg = string.Empty;
            var instock = new Stockitem().Load_record_with(Stockitem_support.Column.ItemId, Stockitem_support.LogicalOperator.EQUAL_TO, item.Id);
            if(int.TryParse(instock.UnitQuantity, out int qty))
            {
                if(qty < 10) { avlable.Attributes.Add("class", "text-danger"); instockMsg = $" out of stock!"; }
                else if (qty < 20) { avlable.Attributes.Add("class", "text-warning"); instockMsg = $" {qty} in stock!"; }
                else { avlable.Attributes.Add("class", "text-success"); instockMsg = $" in stock!"; }
            }
            else { avlable.Attributes.Add("class", "text-danger"); instockMsg = $" out of stock!"; }
            avlable.InnerText += instockMsg;
            Session["item"] = item.Name;

            costText.InnerText = SV.GetUGX(item.Price);
            desc.InnerText = item.Description;
            ModelITemLiteral.Text = elements.GetItemToCart(item.Id, SV.GetImage(item.Picture));
        }
        private void AddToCart()
        {
            addBtn.ServerClick += delegate
            {
                if (string.IsNullOrEmpty(qty.Value) && (int.TryParse(qty.Value, out int Qty) && Qty > 0))
                {
                    if (Session["cartList"] != null && ((List<Cart>)Session["cartList"]).Count != 0)
                    {
                        var list = (List<Cart>)Session["cartList"];
                        foreach (var cart in list)
                        {
                            if (cart.ItemID == Session["item_id"].ToString())
                            {
                                Session["message"] = elements.GetBasicMessage($"This product is already in the cart!");
                                Response.Redirect($"~/Shop/Product.aspx?id={enc.EncryptString(Session["item_id"].ToString(), SV.Key)}");
                            }
                            Carts.Add(new Cart { ItemID = cart.ItemID, Qty = cart.Qty });
                        }
                        Carts.Add(new Cart { ItemID = Session["item_id"].ToString(), Qty = qty.Value });
                        Session["cartList"] = null;
                        Session["cartList"] = Carts;
                    }
                    else
                    {
                        Carts.Add(new Cart { ItemID = Session["item_id"].ToString(), Qty = qty.Value });
                        Session["cartList"] = Carts;
                    }
                    Session["message"] = elements.GetBasicMessage($"Added to cart!");
                }
                else { Session["message"] = elements.GetBasicMessage($"Product out of stock!"); }
                Response.Redirect($"~/Shop/Product.aspx?id={enc.EncryptString(Session["item_id"].ToString(), SV.Key)}");
            };
        }

    }
}