<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ycc_shopping_app_webforms.Shop.Default" MasterPageFile="~/Shop/Main.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="BreadComb">
    <asp:Literal runat="server" ID="BreadLiteral" />
</asp:Content>
<asp:Content ContentPlaceHolderID="body" runat="server">
    <asp:Literal runat="server" ID="MessageLiteral" />
    <asp:Literal runat="server" ID="ITemLiteral" />

    <div class="row">
        <div class="col-md-12">
            <nav aria-label="...">
                <ul class="pagination">
                    <li class="page-item ">
                        <a class="page-link" href="#" tabindex="-1">Previous</a>
                    </li>
                    <li class="page-item"><a class="page-link" href="#">1</a></li>
                    <li class="page-item ">
                        <a class="page-link" href="#">2</a>
                    </li>
                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                    <li class="page-item">
                        <a class="page-link" href="#" tabindex="+1">Next</a>
                    </li>
                </ul>
            </nav>
        </div>
    </div>
</asp:Content>
