using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static EL.Enums;
using Utilidades;

namespace DiseñoWeb
{
    public partial class Formulario_3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarSesion();
            if (!IsPostBack)
            {
                CargarGrid();
                CargarRoles();
            }
        }
        #region Metodos y Funciones
        private void Mensaje(string Message, eMessage tipoMensaje, string Encabezado = "", bool Html = false, bool Fondo = false, bool returnLogin = false, string UrlReturn = "", bool CerrarClick = true)
        {
            //icon -->      success,warning, error,  info
            //btnColor -->  #32A525,#E38618,#F27474,#3FC3EE

            //Parametros que recibe el metodo
            //function Mensaje(title, mensaje, icon = 'success', btnConfirmText = 'Aceptar', btnConfirmColor = '#32A525', html = false, fondo = false, ReturnLogin = false, UrlReturn)

            switch (tipoMensaje)
            {
                case eMessage.Exito:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Exito", "Mensaje('" + Encabezado + "', '" + Message + "','success','Aceptar','#32A525'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
                case eMessage.Alerta:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Alerta", "Mensaje('" + Encabezado + "', '" + Message + "','warning','Aceptar','#E38618'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
                case eMessage.Error:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Error", "Mensaje('" + Encabezado + "', '" + Message + "','error','Aceptar','#F27474'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
                case eMessage.Info:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Info", "Mensaje('" + Encabezado + "', '" + Message + "','info','Aceptar','#3FC3EE'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
            }
        }
        private string Justify(string msj)
        {
            string Html = "<div style = text-align:justify> " + msj + " </div>";
            return Html;
        }
        private void AbandonarSesion(bool MostrarMensaje = true)
        {
            Session.Abandon();
            Session.RemoveAll();
            HttpCookie CookieSesion = new HttpCookie("ASP.NET_SessionId", "");
            Response.Cookies.Add(CookieSesion);
            if (MostrarMensaje)
            {
                Mensaje("Inicie Sesión Nuevamente", eMessage.Info, "Datos de Sesión Incompletos", false, true, true, "/Login.aspx", false);
            }
        }
        private bool ValidarSesion()
        {
            try
            {
                int IdUsuarioGl = (int)General.ValidarEnteros(Session["IdUsuarioGl"]);
                int IdRolGl = (int)General.ValidarEnteros(Session["IdRolGl"]);
                if (!(IdUsuarioGl > 0))
                {
                    AbandonarSesion();
                    return false;
                }
                if (!(IdRolGl > 0))
                {
                    AbandonarSesion();
                    return false;
                }
                Usuarios user = BL_Usuarios.Registro(IdUsuarioGl);
                if (user == null)
                {
                    AbandonarSesion();
                    return false;
                }
                if (user.IdRol != IdRolGl)
                {
                    AbandonarSesion();
                    return false;
                }
                List<RolFormularios> FormulariosUser = BL_RolFormulario.List(IdRolGl);
                if (!(FormulariosUser.Count > 0))
                {
                    AbandonarSesion(false);
                    Mensaje("Estimado usuario, No cuenta con permisos necesarios para ingresar a ningun formulario", eMessage.Info, "", false, true, true, "/Login.aspx", false);
                    return false;
                }
                Session["RolFormularioGl"] = FormulariosUser;
                List<RolPermisos> PermisosUser = BL_RolPermiso.List(IdRolGl);
                panelBtnLimpiar.Visible = true;
                panelBtnGuardar.Visible = false;
                panelBtnAnular.Visible = false;
                if (PermisosUser.Count > 0)
                {
                    foreach (var PermisoUser in PermisosUser)
                    {
                        if (PermisoUser.IdPermiso == (int)ePermisos.Escritura)
                        {
                            panelBtnGuardar.Visible = true;
                        }
                        if (PermisoUser.IdPermiso == (int)ePermisos.Anular)
                        {
                            panelBtnAnular.Visible = true;
                        }
                    }
                }
                return true;
            }
            catch
            {
                AbandonarSesion();
                return false;
            }

        }
        private void CargarGrid()
        {
            if (!(string.IsNullOrEmpty(txtBuscar.Text) || string.IsNullOrWhiteSpace(txtBuscar.Text)) && txtBuscar.Text.Length > 2)
            {
                gvProductos.DataSource = BL_Productos.vProductos().Where(a => a.Descripcion.ToLower().Contains(txtBuscar.Text.ToLower()) || a.Marca.ToLower().Contains(txtBuscar.Text.ToLower())).ToList();
                gvProductos.DataBind();
                return;
            }
            gvProductos.DataSource = BL_Productos.vProductos();
            gvProductos.DataBind();
        }
        private void ResetControles()
        {
            txtDescripcion.Text = string.Empty;
            TxtCodigo.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtStock.Text = string.Empty;
            TxtPrecio.Text = string.Empty;
            ddlCategoria.SelectedIndex = 0;
            HF_IdProducto.Value = "0";
        }
        private void CargarControles(int IdRegistro)
        {
            try
            {
                vProducto vProducto = BL_Productos.vproducto(IdRegistro);
                if (vProducto == null)
                {
                    Mensaje("No se encontraron datos para el registro seleccionado", eMessage.Error);
                    return;
                }
                HF_IdProducto.Value = vProducto.IdProducto.ToString();
                TxtCodigo.Text = vProducto.CodigoBarra;
                txtDescripcion.Text = vProducto.Descripcion;
                txtMarca.Text = vProducto.Marca;
                ddlCategoria.SelectedValue = vProducto.IdCategoria.ToString();
                txtStock.Text = vProducto.Stock.ToString();
                TxtPrecio.Text= vProducto.Precio.ToString();

            }
            catch
            {
                Mensaje("Error al cargar el registro", eMessage.Error);
            }
        }
        private void CargarRoles()
        {
            try
            {
                ddlCategoria.Items.Clear();
                ddlCategoria.Items.Insert(0, new ListItem("--Seleccione--"));
                ddlCategoria.DataSource = BL_Categorias.List();
                ddlCategoria.DataValueField = "IdCategoria";
                ddlCategoria.DataTextField = "Categoria";
                ddlCategoria.DataBind();
            }
            catch
            {

                Mensaje("Error al cargar los roles", eMessage.Error);
            }
        }
        #endregion

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int RowIndex = gvProductos.SelectedRow.RowIndex;
                int IdRegistro = (int)General.ValidarEnteros(gvProductos.DataKeys[RowIndex]["IdProducto"].ToString());
                if (!(IdRegistro > 0))
                {
                    Mensaje("El ID del registro seleccionado fue cero", eMessage.Error);
                    return;
                }

                CargarControles(IdRegistro);

            }
            catch
            {
                Mensaje("Error al seleccionar el registro", eMessage.Error);
            }
        }

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            CargarGrid();
            ResetControles();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void lnkBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}