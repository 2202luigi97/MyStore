<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="DiseñoWeb.Formulario_31" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid" style="margin-top: 15px">
                <div class="card">
                    <div class="card card-header" style="background-color: rgb(220 200 12/0.5)">
                        <h5>Administración de Usuarios</h5>
                    </div>
                    <div class="card-body">
                        <%-- Controles --%>
                        <div class="row">
                            <div class="col-md-6" style="margin-top: 10px">
                                <label>Nombre Completo</label><label style="color: firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtNombre" MaxLength="200" CssClass="form-control" />
                            </div>
                            <div class="col-md-6" style="margin-top: 10px">
                                <label>Correo</label><label style="color: firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtCorreo" MaxLength="200" CssClass="form-control" />
                            </div>
                            <div class="col-md-4" style="margin-top: 10px">
                                <label>Login</label><label style="color: firebrick">*</label>
                                <asp:TextBox runat="server" ID="txtUsuario" MaxLength="50" CssClass="form-control" />
                            </div>
                            <div class="col-md-4" style="margin-top: 10px">
                                <label>Contraseña</label><label style="color: firebrick">*</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtContraseña" MaxLength="50" TextMode="Password" CssClass="form-control" />
                                    <asp:LinkButton runat="server" ID="MostrarContraseña" CssClass="btn btn-primary" OnClick="MostrarContraseña_Click">
                                        <i runat="server" id="IconoConstraseña" class="fas fa-eye"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>
                            <div class="col-md-4" style="margin-top: 10px">
                                <label>Rol</label><label style="color: firebrick">*</label>
                                <asp:DropDownList runat="server" ID="ddlRol" AppendDataBoundItems="true" CssClass="form-control form-select">
                                    <asp:ListItem Text="--Seleccione--" />
                                    <asp:ListItem Text="text2" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%-- Botones --%>
                        <div class="row" style="margin-top: 15px">
                            <asp:Panel runat="server" ID="panelBtnVolver" CssClass="col-md-2">
                                <asp:LinkButton Text="Volver" runat="server" CssClass="w-100 btn btn-primary" ForeColor="White" ID="lnkVolver" OnClick="lnkVolver_Click" />
                            </asp:Panel>
                            <asp:Panel runat="server" ID="panelBtnLimpiar" CssClass="col-md-2" Visible="false">
                                <asp:LinkButton Text="Limpiar" runat="server" CssClass="w-100 btn" BackColor="#ff6600" ForeColor="White" ID="lnkLimpiar" OnClick="lnkLimpiar_Click" />
                            </asp:Panel>
                            <asp:Panel runat="server" ID="panelBtnGuardar" CssClass="col-md-2" Visible="false">
                                <asp:LinkButton Text="Guardar" runat="server" CssClass="w-100 btn" BackColor="#49bea5" ForeColor="White" ID="lnkGuardar" OnClick="lnkGuardar_Click" />
                            </asp:Panel>
                            <asp:Panel runat="server" ID="panelBtnAnular" CssClass="col-md-2" Visible="false">
                                <asp:LinkButton Text="Anular" runat="server" CssClass="w-100 btn" BackColor="#fd4839" ForeColor="White" ID="lnkAnular" OnClick="lnkAnular_Click" />
                            </asp:Panel>
                        </div>
                        <%-- Grid --%>
                        <div class="row" style="margin-top:15px;overflow:scroll">
                            <asp:HiddenField runat="server" ID="HF_IdUsuario" Value="0" />
                            <asp:GridView runat="server" 
                                ID="gvUsuarios"
                                 AllowPaging="true"
                                 PageSize="5"
                                 CssClass="table table-bordered table-hover"
                                 AutoGenerateColumns="false"
                                 EmptyDataText="Sin registros para mostrar"
                                 DataKeyNames="IdUsuario,IdRol"
                                 AutoGenerateSelectButton="true">
                                <HeaderStyle BackColor="#ede385" HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#c0c0c0"/>
                                <Columns>
                                    <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre y Apellido" />
                                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                                    <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                    <asp:BoundField DataField="CuentaBloqueada" HeaderText="Bloqueado" />
                                    <asp:BoundField DataField="IntentosFallidos" HeaderText="Intentos Fallidos" />
                                    <asp:BoundField DataField="Rol" HeaderText="Rol" />
                                </Columns>

                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
