<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowReferences.aspx.cs" Inherits="Referenception.Website.sitecore_modules.Shell.Referenception.ShowReferences" %>

<%@ Import Namespace="Sitecore.Globalization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= Translate.Text("Referenception") %></title>
    <link href="assets/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">

        <asp:Panel runat="server" ID="panNoProviders" CssClass="alert alert-warning" Visible="False">
            <%= Translate.Text("There are no providers available for this item.") %>
        </asp:Panel>

        <asp:Panel runat="server" ID="panError" CssClass="alert alert-danger" Visible="False">
            <%= Translate.Text("Could not load references, please check the log for more informations.") %>
        </asp:Panel>

        <asp:PlaceHolder runat="server" ID="plhData" Visible="False">

            <div class="panel-group" id="accordion">

                <asp:Repeater runat="server" ID="repProviders">

                    <ItemTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h2 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse<%# DataBinder.Eval(Container, "ItemIndex") %>">
                                        <asp:Literal runat="server" ID="litTitle" />
                                    </a>
                                    <span class="badge pull-right">
                                        <asp:Literal runat="server" ID="litRowCount" />
                                    </span>
                                </h2>
                            </div>
                            <div id="collapse<%# DataBinder.Eval(Container, "ItemIndex") %>" class="panel-collapse collapse <%#FirstCssClass(Container.ItemIndex)%>">
                                
                                <asp:Panel runat="server" ID="panBody" CssClass="panel-body">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <asp:Repeater runat="server" ID="repColumns">
                                                    <ItemTemplate>
                                                        <th><%#Container.DataItem%></th>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            
                                            <asp:Repeater runat="server" ID="repRows">
                                                <ItemTemplate>
                                                    <tr>
                                                        <asp:Repeater runat="server" ID="repColumns">
                                                            <ItemTemplate>
                                                                <td><%#Container.DataItem%></td>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel runat="server" ID="panNoReferences" CssClass="alert alert-warning" Visible="False">
                                    <%= Translate.Text("No references found for this provider.") %>
                                </asp:Panel>
                            </div>
                        </div>
                    </ItemTemplate>

                </asp:Repeater>

            </div>
        </asp:PlaceHolder>
    </form>

    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
</body>
</html>
