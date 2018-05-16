<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Address.aspx.cs" Inherits="ycc_shopping_app_webforms.Shop.Address" MasterPageFile="~/Shop/Main.Master"%>
<asp:Content runat="server" ContentPlaceHolderID="BreadComb">
    <asp:Literal runat="server" ID="BreadLiteral" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="btn-group">
        <a class="btn btn-success btn-lg" href="#">Summary</a>
        <a class="btn btn-success btn-lg" href="#">Sign in</a>
        <a class="btn btn-success btn-lg active" href="#">Current address</a>
        <a class="btn btn-success btn-lg" href="#">Payments</a>
    </div>
    <hr />
    <!--current address-->
    <asp:Literal runat="server" ID="MessageLiteral" />
    <div class="card">
        <div class="card-body">
            <h1>Current location</h1>
            <form runat="server">
                <fieldset>
                    <div id="legend">
                        <h3 class="">Register</h3>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <!-- Username -->
                                <label class="control-label" for="fname">First Name</label>
                                <div class="controls">
                                    <label runat="server" id="fname"></label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <!-- Username -->
                                <label class="control-label" for="lname">Last Name</label>
                                <div class="controls">
                                    <label runat="server" id="lname"></label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <!-- Username -->
                                <label class="control-label" for="contact">Contact</label>
                                <div class="controls">
                                    <input runat="server" type="text" id="contact" name="contact" placeholder="Contact" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <!-- E-mail -->
                                <label class="control-label" for="email">E-mail</label>
                                <div class="controls">
                                    <input runat="server" type="text" id="email" name="email" placeholder="Email" class="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <!-- E-mail -->
                                <label class="control-label" for="shippingAddress">Shipping Address</label>
                                <div class="controls">
                                    <input runat="server" type="text" id="shippingAddress" name="shippingAddress" placeholder="Email" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <!-- E-mail -->
                                <label class="control-label" for="shippingAddress">Billing Address</label>
                                <div class="controls">
                                    <input runat="server" type="text" id="billingAddress" name="shippingAddress" placeholder="Email" class="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <button runat="server" id="confirmBtn" class="btn btn-success">Confirm Info</button>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <button runat="server" id="proceedBtn" class="btn btn-success">Proceed</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>

    </div>

</asp:Content>