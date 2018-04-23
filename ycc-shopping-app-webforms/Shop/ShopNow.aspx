<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopNow.aspx.cs" Inherits="ycc_shopping_app_webforms.Shop.ShopNow" MasterPageFile="~/Shop/Main.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="BreadComb">
    <asp:Literal runat="server" ID="BreadLiteral" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="btn-group">
        <a class="btn btn-success btn-lg active" href="#">Summary</a>
        <a class="btn btn-success btn-lg" href="#">Sign in</a>
        <a class="btn btn-success btn-lg" href="#">Current address</a>
        <a class="btn btn-success btn-lg" href="#">Payments</a>
    </div>
    <hr />
    <!-- product button-->
    <div class="card">
        <div class="card-body">
            <table id="cart" class="table table-hover">
                <thead>
                    <tr>
                        <th>Product</th>
                        <th class="text-center">Quantity</th>
                        <th>Price</th>
                        <th class="text-center">Total</th>
                        <th>&nbsp;</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal runat="server" ID="CartITemLiteral" />
                    <tr>
                        <td>&nbsp; </td>
                        <td>&nbsp; </td>
                        <td>&nbsp; </td>
                        <td>Subtotal</td>
                        <td class="text-right">
                            <strong><asp:Literal runat="server" ID="subTotal" /></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp; </td>
                        <td>&nbsp; </td>
                        <td>&nbsp; </td>
                        <td>Estimated TP</td>
                        <td class="text-right">
                            <strong>
                                <asp:Literal runat="server" ID="transportLiteral" /></strong>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp; </td>
                        <td>&nbsp; </td>
                        <td>&nbsp; </td>
                        <td>Total</td>
                        <td class="text-right">
                            <h5><strong>
                                <asp:Literal runat="server" ID="Total" /></strong></h5>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <td><a href="Default.aspx" class="btn btn-warning"><i class="fa fa-angle-left"></i>Continue Shopping</a></td>
                        <td colspan="2" class="hidden-xs"></td>
                        <td class="hidden-xs text-center"><strong></strong></td>
                        <!--total amount-->
                        <td><a href="Signin.aspx" class="btn btn-success btn-block">Next <i class="fa fa-angle-right"></i></a></td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>


</asp:Content>