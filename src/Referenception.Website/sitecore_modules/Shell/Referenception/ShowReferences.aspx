<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowReferences.aspx.cs" Inherits="Referenception.Website.sitecore_modules.Shell.Referenception.ShowReferences" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>References</title>
    <link href="assets/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel-group" id="accordion">
          <div class="panel panel-default">
            <div class="panel-heading">
              <h2 class="panel-title">
                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
                  Klone
                </a>
                <span class="badge pull-right">3</span>
              </h2>
            </div>
            <div id="collapseOne" class="panel-collapse collapse in">
              <div class="panel-body">
                <table class="table">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Display Name</th>
                            <th>Pfad</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>{0f8fad5b-d9cb-469f-a165-70867728950e}</td>
                            <td>Test Item</td>
                            <td>/sitecore/content/Home/Test Item</td>
                        </tr>
                        <tr>
                            <td>{0f8fad5b-d9cb-469f-a165-70867728950e}</td>
                            <td>Test Item</td>
                            <td>/sitecore/content/Home/Test Item</td>
                        </tr>
                        <tr>
                            <td>{0f8fad5b-d9cb-469f-a165-70867728950e}</td>
                            <td>Test Item</td>
                            <td>/sitecore/content/Home/Test Item</td>
                        </tr>
                    </tbody>
                </table>
              </div>
            </div>
          </div>
          <div class="panel panel-default">
            <div class="panel-heading">
              <h2 class="panel-title">
                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                  In Items referenziert
                </a>
                <span class="badge pull-right">30</span>
              </h2>
            </div>
            <div id="collapseTwo" class="panel-collapse collapse">
              <div class="panel-body">
                <table class="table">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Display Name</th>
                            <th>Pfad</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>{0f8fad5b-d9cb-469f-a165-70867728950e}</td>
                            <td>Test Item</td>
                            <td>/sitecore/content/Home/Test Item</td>
                        </tr>
                        <tr>
                            <td>{0f8fad5b-d9cb-469f-a165-70867728950e}</td>
                            <td>Test Item</td>
                            <td>/sitecore/content/Home/Test Item</td>
                        </tr>
                        <tr>
                            <td>{0f8fad5b-d9cb-469f-a165-70867728950e}</td>
                            <td>Test Item</td>
                            <td>/sitecore/content/Home/Test Item</td>
                        </tr>
                    </tbody>
                </table>
              </div>
            </div>
          </div>
          <div class="panel panel-default">
            <div class="panel-heading">
              <h2 class="panel-title">
                <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
                  Referenzierte Items
                </a>
                <span class="badge pull-right">17</span>
              </h2>
            </div>
            <div id="collapseThree" class="panel-collapse collapse">
              <div class="panel-body">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Feld</th>
                            <th>ID</th>
                            <th>Display Name</th>
                            <th>Pfad</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Droplink 1</td>
                            <td>{0f8fad5b-d9cb-469f-a165-70867728950e}</td>
                            <td>Test Item</td>
                            <td>/sitecore/content/Home/Test Item</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>{0f8fad5b-d9cb-469f-a165-70867728950e}</td>
                            <td>Test Item</td>
                            <td>/sitecore/content/Home/Test Item</td>
                        </tr>
                        <tr>
                            <td>Droplink 2</td>
                            <td>{0f8fad5b-d9cb-469f-a165-70867728950e}</td>
                            <td>Test Item</td>
                            <td>/sitecore/content/Home/Test Item</td>
                        </tr>
                    </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
    </form>

    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
</body>
</html>
