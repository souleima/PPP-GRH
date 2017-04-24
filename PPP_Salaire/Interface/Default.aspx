<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false" CodeBehind="Default.aspx.cs" Inherits="PPP_Salaire.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Startmin - Bootstrap Admin Theme</title>

    <!-- Bootstrap Core CSS -->
    <link href="../AdminTempL/css/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../AdminTempL/css/metisMenu.min.css" rel="stylesheet"/>

    <!-- Timeline CSS -->
    <link href="../AdminTempL/css/timeline.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../AdminTempL/css/startmin.css" rel="stylesheet"/>
    <!-- DataTables CSS -->
    <link href="../AdminTempL/css/dataTables.bootstrap.css" rel="stylesheet">

    <!-- DataTables Responsive CSS -->
    <link href="../AdminTempL/css/dataTables.responsive.css" rel="stylesheet">

    <!-- Morris Charts CSS -->
    <link href="../AdminTempL/css/morris.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="AdminTempL/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
    
<body runat="server">
    <form id="form1" runat="server">
    <div id="login" class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Please Sign In</h3>
                    </div>
                    <div class="panel-body">
                        <form role="form">
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox runat="server" ID="logintext"  class="form-control" placeholder="login" ></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="password" runat="server" class="form-control" placeholder="Password" name="password" type="password" value=""></asp:TextBox>
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <asp:Label runat="server" name="remember" type="checkbox" value="Remember Me"></asp:Label>
                                    </label>
                                </div>
                                <!-- Change this to a button or input when using this as a form -->
                                <asp:Button runat="server" Text="Login" OnClick="btn_login_Click" class="btn btn-lg btn-success btn-block" />
                                <asp:Label ID="Faillogin" runat="server" Text=""></asp:Label>
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </form>
    <!-- jQuery -->
    <script src="AdminTempL/js/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="AdminTempL/js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="AdminTempL/js/metisMenu.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="AdminTempL/js/startmin.js"></script>

</body></html>

