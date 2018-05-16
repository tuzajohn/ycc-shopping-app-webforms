using ShoppingLibrary;
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
        Encryption enc;
        Dictionary<string, string> bcomb = new Dictionary<string, string>();
        SessionVerification SV;
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            enc = new Encryption() { Key = SV.Key };
            bcomb.Add("Default.aspx", "Home");
            bcomb.Add("Address.aspx", "Address");
            BreadLiteral.Text = elements.BreadComd(bcomb);
            if (Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
            Check();
            LoadDetails();
            if (!IsPostBack) { Update(); }
            Proceed();
        }
        
        void Check()
        {
            if (string.IsNullOrEmpty(SV.Id)) { Response.Redirect("~/"); }
        }
        void LoadDetails()
        {
            fname.InnerText = SV.Fname;
            lname.InnerText = SV.Lname;
            contact.Value = SV.Contact;
            email.Value = SV.Email;
            shippingAddress.Value = SV.ShippingAddress;
            billingAddress.Value = SV.BillingAddress;
        }
        void Update()
        {
            confirmBtn.ServerClick += delegate
            {
                var buyer = new Buyer(SV.Id)
                {
                    PhoneNumber = contact.Value,
                    EmailAddress = email.Value,
                    ShippingAddress = shippingAddress.Value,
                    BillingAddress = billingAddress.Value
                };
                LoadDetails();
                Session["message"] = elements.GetBasicMessage("You have confirmed the following information, you can now proceed to payemnt!");
                Response.Redirect("~/Shop/Address.aspx");
            };
        }
        void Proceed()
        {
            proceedBtn.ServerClick += delegate
            {
                Response.Redirect("~/Shop/Payment.aspx");
            };
        }
    }
}