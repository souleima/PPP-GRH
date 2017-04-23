<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PPP_Salaire.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        body {
            background-color: #f4f4f4;
            color: #5a5656;
            font-family: 'Open Sans', Arial, Helvetica, sans-serif;
            font-size: 16px;
            line-height: 1.5em;
        }

        a {
            text-decoration: none;
        }

        h1 {
            font-size: 1em;
        }

        h1, p {
            margin-bottom: 10px;
        }

        strong {
            font-weight: bold;
        }

        .uppercase {
            text-transform: uppercase;
        }




        /* ---------- LOGIN ---------- */

        #login {
            margin: 50px auto;
            width: 300px;
        }

        form fieldset input[type="text"], input[type="password"] {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #e5e5e5;
            border-radius: 3px;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            color: #5a5656;
            font-family: 'Open Sans', Arial, Helvetica, sans-serif;
            font-size: 14px;
            outline: none;
            padding: 0px 10px;
            -webkit-appearance: none;
        }

        form asp:TextBox {
            background-color: #008dde;
            border: none;
            border-radius: 3px;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            color: #f4f4f4;
            cursor: pointer;
            font-family: 'Open Sans', Arial, Helvetica, sans-serif;
            height: 50px;
            text-transform: uppercase;
            width: 300px;
            -webkit-appearance: none;
        }

        form a {
            color: #5a5656;
            font-size: 10px;
        }

        form fieldset a:hover {
            text-decoration: underline;
        }

        .button {
            background-color: #4CAF50; /* Green */
            border: none;
            color: white;
            padding: 16px 32px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            -webkit-transition-duration: 0.4s; /* Safari */
            transition-duration: 0.4s;
            cursor: pointer;
        }

        .button5:hover {
            background-color: #555555;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="login">
            <p>Login :<asp:TextBox ID="logintext" runat="server" Height="26px" Width="135px"></asp:TextBox></p>
            <p>password:
                <asp:TextBox TextMode="Password" ID="password" runat="server" Height="39px"></asp:TextBox></p>
            <asp:Button runat="server" Text="Login" OnClick="btn_login_Click" CssClass="button button5" Height="46px" Width="262px" />
            <asp:Label ID="Faillogin" runat="server" Text=""></asp:Label>
        </div>
    </form>

</body>
</html>
