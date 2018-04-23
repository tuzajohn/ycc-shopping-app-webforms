<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="ycc_shopping_app_webforms.Shop.Signin" MasterPageFile="~/Shop/Main.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="BreadComb">
    <asp:Literal runat="server" ID="BreadLiteral" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="btn-group">
        <a class="btn btn-success btn-lg" href="#">Summary</a>
        <a class="btn btn-success btn-lg active" href="#">Sign in</a>
        <a class="btn btn-success btn-lg" href="#">Current address</a>
        <a class="btn btn-success btn-lg" href="#">Payments</a>
    </div>
    <hr />
    <div class="card">
        <div class="card-body">
            <!--sign in-->
            <div class="omb_login">

                <div class="row omb_row-sm-offset-3">
                    <div class="col-md-12 col-sm-6">
                        <form runat="server">
                            <div class="form-group">
                                <label for="username">Username</label>
                                <input runat="server" type="text" class="form-control" id="username" placeholder="Username" />
                            </div>
                            <div class="form-group">
                                <label for="password">Password</label>
                                <input runat="server" type="password" class="form-control" id="password" placeholder="Password" />
                            </div>
                            <button runat="server" id="loginBtn" class="btn btn-primary">Login, and proceed.</button>
                        </form>
                        <a href="#" class="alert-link">don't have an account yet?</a>
                    </div>
                </div>

            </div>

        </div>
    </div>

</asp:Content>
