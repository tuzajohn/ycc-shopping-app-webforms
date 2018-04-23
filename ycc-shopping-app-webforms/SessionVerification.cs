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
        
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Key = "_H%^.#1g";
        RegExpression reg = new RegExpression();
        Encryption enc = new Encryption();
        public SessionVerification()
        {

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