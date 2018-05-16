using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ShoppingLibrary;


namespace ycc_shopping_app_webforms
{
    public class SessionVerification:System.Web.UI.Page
    {
        
        public string Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Username { get; set; }
        public string Key = "_H%^.#1g";
        RegExpression reg = new RegExpression();
        Encryption enc = new Encryption();
        public SessionVerification()
        {
            try
            {
                Id = Session["userId"].ToString();
                Fname = Session["fname"].ToString();
                Lname = Session["lname"].ToString();
                Contact = Session["contact"].ToString();
                ShippingAddress = Session["shipping_address"].ToString();
                BillingAddress = Session["billing_address"].ToString();
                Email = Session["email"].ToString();
            }
            catch (Exception) { }
        }
        public string GetImage(string itemUrl)
        {
            switch (string.IsNullOrEmpty(itemUrl))
            {
                case true: itemUrl = "noimage.jpg"; break;
                default: break;
            }
            if (File.Exists(Server.MapPath($"~/Images/{itemUrl}"))) return itemUrl;
            else { return "noimage.jpg"; }
        }
        public string GetUGX(string cost)
        {
            var n = "";
            var count = 0;
            var cArray = cost.ToCharArray();
            for (int i = cArray.Length - 1; i >= 0; i--)
            {
                count++;
                n += cArray[i];
                if (count % 3 == 0) { n += ","; }
            }
            cArray = n.ToCharArray(); n = "";
            for (int i = cArray.Length - 1; i >= 0; i--)
            {
                n += cArray[i].ToString();
            }
            return ("Ugx " + n);
        }

    }
    public class Cart
    {
        public string ItemID { get; set; }
        public string Qty { get; set; }
    }
}