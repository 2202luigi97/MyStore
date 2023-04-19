<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="DiseñoWeb.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link href="asset/CSS/Principal.css" rel="stylesheet" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:Panel runat="server" ID="PanelVenta" CssClass="col-md-3 cardMenu" Visible="true">
                    <asp:LinkButton Text="Ventas" runat="server" ID="lnkVenta" OnClick="lnkVenta_Click">
            <div class="card flex-column" style="background-color:rgb(22 167 30/0.5);">
                <div class="card-body">
                    <div class="d-inline-flex">
                        <div class="col-sm-5">
                            <i class="fas fa-cart-shopping icono"></i>
                        </div>                       
                        <div class="col-sm-8 tituloCard">
                            <h3>Ventas</h3>
                   </div>                     
                    </div>
                </div>
            </div>
                    </asp:LinkButton>
                </asp:Panel>
                <asp:Panel runat="server" ID="PanelProducto" CssClass="col-md-3 cardMenu" Visible="true">
                    <asp:LinkButton Text="Productos" runat="server" ID="lnkProducto" OnClick="lnkProducto_Click">
            <div class="card flex-column" style="background-color:rgb(4 161 208/0.5);">
                <div class="card-body">
                    <div class="d-inline-flex">
                        <div class="col-sm-4">
                            <i class="fas fa-book icono"></i>
                        </div>                       
                        <div class="col-sm-8 tituloCard">
                            <h3>Productos</h3>
                   </div>                     
                    </div>
                </div>
            </div>
                    </asp:LinkButton>
                </asp:Panel>
                <asp:Panel runat="server" ID="PanelUsuario" CssClass="col-md-3 cardMenu" Visible="true">
                    <asp:LinkButton Text="Usuarios" runat="server" ID="lnkUsuario" OnClick="lnkUsuario_Click">
            <div class="card flex-column" style="background-color:rgb(220 200 12/0.5);">
                <div class="card-body">
                    <div class="d-inline-flex">
                        <div class="col-sm-4">
                            <i class="fas fa-user icono"></i>
                        </div>                       
                        <div class="col-sm-8 tituloCard">
                            <h3>Usuarios</h3>
                   </div>                     
                    </div>
                </div>
            </div>
                    </asp:LinkButton>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
