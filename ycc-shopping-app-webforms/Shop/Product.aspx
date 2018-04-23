<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="ycc_shopping_app_webforms.Shop.Product" MasterPageFile="~/Shop/Main.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="BreadComb">
    <asp:Literal runat="server" ID="BreadLiteral" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <asp:Literal runat="server" ID="MessageLiteral" />
    <div class="card">
        <div class="card-body" style="padding-top:50px;">
            <div class="row">
                <!-- Image -->
                <div class="col-12 col-lg-6">
                    <div class="card bg-light mb-3">
                        <div class="card-body">
                            <asp:Literal runat="server" ID="ModelITemLiteral" />
                            <script>
                                // Get the modal
                                var modal = document.getElementById('myModal');

                                // Get the image and insert it inside the modal - use its "alt" text as a caption
                                var img = document.getElementById('myImg');
                                var modalImg = document.getElementById("img01");
                                var captionText = document.getElementById("caption");
                                img.onclick = function(){
                                    modal.style.display = "block";
                                    modalImg.src = this.src;
                                    captionText.innerHTML = this.alt;
                                }

                                // Get the <span> element that closes the modal
                                var span = document.getElementsByClassName("close")[0];

                                // When the user clicks on <span> (x), close the modal
                                span.onclick = function() { 
                                  modal.style.display = "none";
                                }
                            </script>
                        </div>
                    </div>
                </div>
                <!-- Add to cart -->
                <div class="col-12 col-lg-6 add_to_cart_block">
                    <div class="card bg-light mb-3">
                        <div class="card-body">
                            <p class="price" runat="server" id="costText"></p>
                            <div>
                                <div class="form-group">
                                    <label>Quantity :</label>
                                    <select runat="server" id="qtySelect" class="form-control mb-3">
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                    </select>
                                    <asp:Literal runat="server" ID="ItemBtnCart" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <!-- Description -->
                <div class="col-12">
                    <div class="card border-light mb-3">
                        <div class="card-header bg-primary text-white text-uppercase"><i class="fa fa-align-justify"></i>Description</div>
                        <div class="card-body">
                            <p runat="server" id="desc" class="card-text">
                                
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
