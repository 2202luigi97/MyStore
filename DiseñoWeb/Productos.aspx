<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="DiseñoWeb.Formulario_3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid" style="margin-top: 15px">
                <div class="card">
                    <div class="card card-header" style="background-color: rgb(129, 208, 231)">
                        <h5>Listado de Productos</h5>
                    </div>
                    <div class="card-body">
                        <%-- Controles --%>
                        <div class="row">
                            <div class="col-md-2" style="margin-top: 10px">
                                <label>Cod.</label>
                                <asp:TextBox runat="server" ID="TxtCodigo" MaxLength="100" CssClass="form-control" />
                            </div>
                            <div class="col-md-4" style="margin-top: 10px">
                                <label>Descripcion</label><label style="color: firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtDescripcion" MaxLength="200" CssClass="form-control" />
                            </div>
                            <div class="col-md-2" style="margin-top: 10px">
                                <label>Marca</label><label style="color: firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtMarca" MaxLength="50" CssClass="form-control" />
                            </div>
                            <div class="col-md-2" style="margin-top: 10px">
                                <label>Categoria</label><label style="color: firebrick">*</label>
                                <asp:DropDownList runat="server" ID="ddlCategoria" AppendDataBoundItems="true" CssClass="form-control form-select">
                                    <asp:ListItem Text="--Seleccione--" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1" style="margin-top: 10px">
                                <label>Stock</label><label style="color: firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtStock" MaxLength="50" CssClass="form-control" />
                            </div>
                            <div class="col-md-1" style="margin-top: 10px">
                                <label>Precio</label><label style="color: firebrick">*</label>
                                <asp:TextBox runat="server" ID="TxtPrecio" MaxLength="50" CssClass="form-control" />
                            </div>
                            
                            
                        </div>
                        <%-- Botones --%>
                        <div class="row" style="margin-top: 15px">
                            <asp:Panel runat="server" ID="panelBtnVolver" CssClass="col-md-2">
                                <asp:LinkButton Text="Volver" runat="server" CssClass="w-100 btn btn-primary" ForeColor="White" ID="lnkVolver" />
                            </asp:Panel>
                            <asp:Panel runat="server" ID="panelBtnLimpiar" CssClass="col-md-2" Visible="false">
                                <asp:LinkButton Text="Limpiar" runat="server" CssClass="w-100 btn" BackColor="#ff6600" ForeColor="White" ID="lnkLimpiar" />
                            </asp:Panel>
                            <asp:Panel runat="server" ID="panelBtnGuardar" CssClass="col-md-2" Visible="false">
                                <asp:LinkButton Text="Guardar" runat="server" CssClass="w-100 btn" BackColor="#49bea5" ForeColor="White" ID="lnkGuardar" />
                            </asp:Panel>
                            <asp:Panel runat="server" ID="panelBtnAnular" CssClass="col-md-2" Visible="false">
                                <asp:LinkButton Text="Anular" runat="server" CssClass="w-100 btn" BackColor="#ede385" ForeColor="Black" ID="lnkAnular" />
                            </asp:Panel>
                        </div>
                        <%-- Grid --%>
                        <div class="row" style="margin-top:15px">
                            <div class="col-md-4" style="margin-top: 10px">
                                <label>Buscar</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtBuscar" TextMode="Search" MaxLength="20" CssClass="form-control" OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" />
                                    <asp:LinkButton runat="server" ID="lnkBuscar" CssClass="btn btn-primary" OnClick="lnkBuscar_Click">
                                        <i class="fas fa-search"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 10px; overflow: scroll">
                            <asp:HiddenField runat="server" ID="HF_IdProducto" Value="0" />
                            <asp:GridView runat="server"
                                ID="gvProductos"
                                AllowPaging="true"
                                PageSize="3"
                                CssClass="table table-bordered table-hover"
                                AutoGenerateColumns="false"
                                EmptyDataText="Sin registros para mostrar"
                                DataKeyNames="IdProducto,IdCategoria"
                                AutoGenerateSelectButton="true"
                              OnSelectedIndexChanged="gvProductos_SelectedIndexChanged" OnPageIndexChanging="gvProductos_PageIndexChanging">
                                <HeaderStyle BackColor="#ede385" HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#c0c0c0" />
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:BoundField DataField="CodigoBarra" HeaderText="Código" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                    <asp:BoundField DataField="Marca" HeaderText="Marca" />
                                    <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                </Columns>

                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
