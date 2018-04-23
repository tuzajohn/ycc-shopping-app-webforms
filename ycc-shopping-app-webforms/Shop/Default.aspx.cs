using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingLibrary;

namespace ycc_shopping_app_webforms.Shop
{
    public partial class Default : System.Web.UI.Page
    {
        HtmlElements elements = new HtmlElements();
        SessionVerification SV;
        Encryption enc = new Encryption() { Key = "_H%^.#1g" };
        Dictionary<string, string> bcomb = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            bcomb.Add("Default.aspx", "Home");
            BreadLiteral.Text = elements.BreadComd(bcomb);
            enc = new Encryption() { Key = SV.Key };

            if(Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
            var cat = Request.Params.Get("category");
            var query = Request.Params.Get("q");
            if (!string.IsNullOrEmpty(cat)) { ItemByCategory(cat); }
            else if (!string.IsNullOrEmpty(query)) { SearchedItem(query); }            
            else { Item(); }            
        }
        private void Item()
        {
            int pos = 0;
            string d = string.Empty;
            var itemList = new Item().getAllRecords(Item_support.Column.Name, Item_support.Order.ASCENDING);
            foreach (var item in itemList)
            {
                if (pos % 3 == 0) { d += "<div class='row'>"; }                
                d += elements.DisplayItems(enc.EncryptString(item.Id, SV.Key),SV.GetImage(item.Picture), item.Name, item.Description, SV.GetUGX(item.Price));
                if (pos % 3 == 2) { d += "</div>"; }
                pos++;
            }
            if (pos%3!=0){ d += "</div>"; }
            ITemLiteral.Text = d;
        }
        private void ItemByCategory(string category)
        {
            int pos = 0;
            string d = string.Empty;
            var cat = new Category().Load_record_with(Category_support.Column.Name, Category_support.LogicalOperator.EQUAL_TO, category);
            var itemList = new Item().Search_For(Item_support.Column.CategoryId, Item_support.LogicalOperator.EQUAL_TO, cat.Id);
            foreach (var item in itemList)
            {
                if (pos % 3 == 0) { d += "<div class='row'>"; }
                d += elements.DisplayItems(enc.EncryptString(item.Id, SV.Key), SV.GetImage(item.Picture), item.Name, item.Description, SV.GetUGX(item.Price));
                if (pos % 3 == 2) { d += "</div>"; }
                pos++;
            }
            if (pos % 3 != 0) { d += "</div>"; }
            ITemLiteral.Text = d;
        }
        private void SearchedItem(string query)
        {
            int pos = 0;
            string d = string.Empty;
            var itemSearchedList = new Item().Search_For(Item_support.Column.Name, Item_support.LogicalOperator.LIKE, query, Item_support.Relation.OR, Item_support.Column.Description, Item_support.LogicalOperator.LIKE, query, Item_support.Column.Name, Item_support.Order.ASCENDING);
            foreach (var item in itemSearchedList)
            {
                if (pos % 3 == 0) { d += "<div class='row'>"; }
                d += elements.DisplayItems(enc.EncryptString(item.Id, SV.Key), SV.GetImage(item.Picture), item.Name, item.Description, SV.GetUGX(item.Price));
                if (pos % 3 == 2) { d += "</div>"; }
                pos++;
            }
            if (pos % 3 != 0) { d += "</div>"; }
            if(itemSearchedList.Count <= 0) { MessageLiteral.Text = elements.GetBasicMessage($"No result found for {query}!"); }
            else { ITemLiteral.Text = d; }            
        }
    }
}