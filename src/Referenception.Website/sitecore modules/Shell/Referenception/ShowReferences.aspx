<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowReferences.aspx.cs" Inherits="Referenception.Website.SitecoreModules.Shell.Referenception.ShowReferences" %>

<%@ Import Namespace="Sitecore.Globalization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= Translate.Text("Referenception") %></title>
    <link href="assets/css/bootstrap.min.css" rel="stylesheet">
    <link href="assets/css/referenception.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        
        <h1 class="title">
            <asp:Literal runat="server" ID="litTitle" />    
        </h1>

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
                            <div class="panel-heading" data-toggle="collapse" data-parent="#accordion" href="#collapse<%# DataBinder.Eval(Container, "ItemIndex") %>">
                                <h2 class="panel-title">
                                    <asp:Literal runat="server" ID="litTitle" />
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
                                                
                                                <th></th>
                                                <th></th>
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
                                                        
                                                        <td align="right">
                                                            <asp:PlaceHolder runat="server" ID="plhTooltip" Visible="<%#HasTooltip(Container)%>">
                                                                <span class="glyphicon glyphicon-info-sign popover-icon" rel="popover-html" id="<%#GetTooltipId(Container)%>"></span>
                                                                <div id="<%#GetTooltipId(Container)%>-content" class="popover-content-container">
                                                                    <div class="popover-title"><%= Translate.Text("Additional informations") %></div>
                                                                    <div class="popover-content">
                                                                        <table class="table">
                                                                            <asp:Repeater runat="server" ID="repTooltip">
                                                                                <ItemTemplate>
                                                                                    <tr>
                                                                                        <th><%#((KeyValuePair<string,string>)Container.DataItem).Key %>:</th>
                                                                                        <td><%#((KeyValuePair<string,string>)Container.DataItem).Value %></td>
                                                                                    </tr>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </asp:PlaceHolder>
                                                        </td>

                                                        <td>
                                                            <asp:PlaceHolder runat="server" ID="plhItemLink" Visible="<%#HasItemLink(Container)%>">
                                                                <span class="glyphicon glyphicon-circle-arrow-right popover-icon" rel="popover" data-content="<%= Translate.Text("Go to item") %>" data-trigger="hover" data-placement="top" onclick='javascript:parent.scForm.invoke("item:load(id=<%#GetLinkItemId(Container)%>)"); return false;'></span>
                                                            </asp:PlaceHolder>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>
                                </asp:Panel>
                                
                                <asp:Panel runat="server" ID="panNoReferences" CssClass="alert alert-warning" Visible="False">
                                    <%= Translate.Text("No references found.") %>
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
    <script type="text/javascript">
        $(function () {

            $("[rel=popover-html]").each(function () {
                var elem = $(this);
                var container = "#" + $(elem).attr('id') + '-content';
                elem.popover(
                    {
                        html: true,
                        placement: 'left',
                        title: $(container).children('.popover-title').first().text(),
                        content: $(container).children('.popover-content').first().html(),
                        template: '<div class="popover popover-item-information"><div class="arrow"></div><div class="popover-inner"><h3 class="popover-title"></h3><div class="popover-content"><p></p></div></div></div>'
                    }
                );
                elem.click(function () {
                    $("[rel=popover-html]").not(elem).popover('hide');
                });
            });

            $('[rel=popover]').popover();
        });
    </script>
</body>
</html>
