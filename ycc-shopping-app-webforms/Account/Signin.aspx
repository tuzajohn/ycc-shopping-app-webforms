<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="ycc_shopping_app_webforms.Account.Signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create an Account</title>
    <link href="~/Styles/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="~/Styles/Scripts/bootstrap.min.js"></script>
    <script src="~/Styles/Scripts/jquery.min.js"></script>
</head>
<body style="background:lightgrey;">
    <div class="container pl-5 pr-5 pb-5 pt-5">
        <asp:Literal runat="server" ID="MessageLiteral" />
        <div class="card">
            <div class="card-body">
                <form runat="server" class="form-horizontal">
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
                                        <input runat="server" type="text" id="fname" name="fname" placeholder="First name" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <!-- Username -->
                                    <label class="control-label" for="lname">Last Name</label>
                                    <div class="controls">
                                        <input runat="server" type="text" id="lname" name="lname" placeholder="Last Name" class="form-control" />
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
                            <div class="col-md-12">
                                <div class="form-group">
                                    <!-- Password-->
                                    <label class="control-label" for="username">Username</label>
                                    <div class="controls">
                                        <input runat="server" type="text" id="username" name="username" placeholder="Username" class="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <!-- Password-->
                                    <label class="control-label" for="password">Password</label>
                                    <div class="controls">
                                        <input runat="server" type="password" id="password" name="password" placeholder="Password" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <!-- Password -->
                                    <label class="control-label" for="password_confirm">Password (Confirm)</label>
                                    <div class="controls">
                                        <input runat="server" type="password" id="password_confirm" name="password_confirm" placeholder="Confirm password" class="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <!-- Button -->
                                    <div class="controls">
                                        <button runat="server" id="loginBtn" class="btn btn-success">Register</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
