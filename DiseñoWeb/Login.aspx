<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DiseñoWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>MyStore</title>
    <%-- Referencias CSS --%>
    <link href="asset/bootstrap-5.3.0-alpha3-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="asset/Fontawesome/css/all.min.css" rel="stylesheet" />
    <link href="asset/SweeAlert/sweetalert.min.css" rel="stylesheet" />
    <link href="asset/CSS/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="frmLogin" runat="server">

        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="Contenedor">
                    <div class="card" style="background-color: #F2F2F2; border-radius: 15px;">
                        <div class="card-body">
                            <div class="ImageTop">
                                <img src="asset/image/99b0e593f9237abf16df5cb1b1a87735.png" width="350" />
                            </div>
                            <%--<div class="Titulo">
                                <h1>MyStore</h1>
                            </div>--%>
                            <div class="form-floating mb-3">
                                <asp:TextBox runat="server" class="form-control" ID="txtUsuario" placeholder="Usuario"></asp:TextBox>
                                <label for="floatingInput">Usuario</label>
                            </div>
                            <div class="form-floating">
                                <asp:TextBox runat="server" TextMode="Password" class="form-control" ID="txtPassword" placeholder="Contraseña"></asp:TextBox>
                                <label for="floatingPassword">Contraseña</label>
                            </div>
                            <div class="row col-12 btnLogin">
                                <asp:Button runat="server" ID="btnIngresar" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="btnIngresar_Click" />

                            </div>
                        </div>
                    </div>

                </div>


            </ContentTemplate>
        </asp:UpdatePanel>



    </form>
    <%-- Referencias JS --%>
    <script src="asset/JQuery/jquery.min.js"></script>
    <script src="asset/bootstrap-5.2.0/js/bootstrap.min.js"></script>
    <script src="asset/SweeAlert/sweetalert.all.min.js"></script>
    <script src="asset/SweeAlert/sweetAlertStyle.js"></script>
</body>
</html>
