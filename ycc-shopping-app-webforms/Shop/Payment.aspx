<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="ycc_shopping_app_webforms.Shop.Payment" MasterPageFile="~/Shop/Main.Master"%>
<asp:Content runat="server" ContentPlaceHolderID="BreadComb">
    <asp:Literal runat="server" ID="BreadLiteral" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="btn-group">
        <a class="btn btn-success btn-lg" href="#">Summary</a>
        <a class="btn btn-success btn-lg" href="#">Sign in</a>
        <a class="btn btn-success btn-lg" href="#">Current address</a>
        <a class="btn btn-success btn-lg active" href="#">Payments</a>
    </div>
    <hr />
    <div class="card">
        <div class="card-body">
            <h1>Payment</h1>
            <div id="">
				My payment stuff will go here
			</div>
        </div>
    </div>
</asp:Content>