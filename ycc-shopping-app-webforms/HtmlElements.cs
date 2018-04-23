using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ycc_shopping_app_webforms
{
    public class HtmlElements
    {
        public HtmlElements() { }
        public string DisplayItems(string id, string url, string name, string description, string cost)
        {
            string d = string.Empty;

            d = "<div class='col-md-4 '>" +
                "    <div class='card'>" +
               $"        <img alt='caption' src='../images/{url}' class='img-responsive' />" +
                "" +
                "        <div class='card-body'>" +
               $"            <h4 class='card-title'><a href='product.html' title='View Product'>{name}</a></h4>" +
               $"            <p class='card-text'>{description}</p>" +
                "            <hr />" +
                "            <div class='row'>" +
                "               <div class='col'>" +
               $"                   <p class='btn btn-info btn-block '>{cost}</p>" +
                "               </div>" +
                "                <div class='col'>" +
               $"                   <a href='../../Shop/Product.aspx?&id={id}' class='btn btn-success btn-block'>View</a>" +
                "               </div>" +
                "            </div>" +
                "        </div>" +
                "    </div>" +
                "</div>";

            return d;
        }
        public string BreadComd(Dictionary<string, string> breadcomb)
        {
            var d = string.Empty;
            foreach (var bread in breadcomb)
            {
                d += $"<li class='breadcrumb-item'><a href='{bread.Key}'>{bread.Value}</a></li>";
            }
            return d;
        }
        public string GetDismissibleMessage(string text)
        {
            var d = string.Empty;
            d = $@"
            <div class=alert alert-primary alert-dismissible fade show role=alert>
              <strong>{text}</strong>
              <button type=button class=close data-dismiss=alert aria-label=Close>
                <span aria-hidden=true>&times;</span>
              </button>
            </div>";
            return d;
        }
        public string GetBasicMessage(string text)
        {
            var d = string.Empty;
            d = $@"
            <div class='alert alert-primary' role='alert'>
              <strong>{text}</strong>
            </div>";
            return d;
        }
        public string GetCartItemRows(string id, string url, string qty, string name, string cost, string subTotal)
        {
            var d = string.Empty;
            d = $@"
            <tr>
                <td class='col-sm-8 col-md-6'>
                <div class='media'>
                    <a class='thumbnail pull-left' href='#'> <img class='media-object' src='../images/{url}' style='width: 72px; height: 72px;'> </a>
                    <div class='media-body'>
                        <h4 class='media-heading'><a href='../Shop/Product.aspx?id={id}'>{name}</a></h4>
                    </div>
                </div></td>
                <td class='col-sm-1 col-md-1 text-center'><strong>{qty}</strong></td>
                <td class='col-sm-1 col-md-1 text-center'><strong>{cost}</strong></td>
                <td class='col-sm-1 col-md-1 text-center'><strong>{subTotal}</strong></td>
                <td class='col-sm-1 col-md-1'>
                <a href='../Shop/Shopnow.aspx?delete={id}&qty={qty}' class='btn btn-danger'>
                    <span class='glyphicon glyphicon-remove'></span> Remove
                </a></td>
            </tr>";
            return d;
        }
        public string GetItemToCart(string id, string url)
        {
            var d = string.Empty;
            d = $@"
            <!-- Trigger the Modal -->
            <img id='myImg' src='../images/{url}' alt='Trolltunga, Norway' width='300' height='200'/>

            <!-- The Modal -->
            <div id='myModal' class='modal'>
                <!-- The Close Button -->
                <span class='close'>&times;</span>
                <!-- Modal Content (The Image) -->
                <img class='modal-content' id='img01'/>
                <!-- Modal Caption (Image Text) -->
                <div id='caption'></div>
            </div>";
            return d;
        }
        public string BtnAddToCart(string id)
        {
            var d = string.Empty;
            d = $@"
            <a href='../../Shop/Product.aspx?action=add&id={id}' class='btn btn-success btn-lg btn-block text-uppercase'>
                <i class='fa fa-shopping-cart'></i>Add To Cart
            </a>";
            return d;
        }
    }
}