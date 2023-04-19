using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;
using static EL.Enums;

namespace DiseñoWeb
{
    public partial class Formulario_31 : System.Web.UI.Page
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
            gvUsuarios.DataSource = BL_Usuarios.vUsuarios();
            gvUsuarios.DataBind();
        }
        private void CargarRoles()
        {
            try
            {
                ddlRol.Items.Clear();
                ddlRol.Items.Insert(0, new ListItem("--Seleccione--"));
                ddlRol.DataSource = BL_Roles.List();
                ddlRol.DataValueField = "IdRol";
                ddlRol.DataTextField = "Rol";
                ddlRol.DataBind();
            }
            catch
            {

                Mensaje("Error al cargar los roles", eMessage.Error);
            }
        }
        private bool ValidarInsertar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                Mensaje("Ingrese el nombre completo", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                Mensaje("Ingrese el Correo del usuario", eMessage.Alerta);
                return false;
            }
            if(!General.CorreoEsValido(txtCorreo.Text))
            {
                Mensaje("Ingrese un correo válido", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                Mensaje("Ingrese el login del usuario", eMessage.Alerta);
                return false;
            }
            if (BL_Usuarios.ExisteUserName(txtUsuario.Text)) 
            {
                Mensaje("El login Ya existe en el Sistema", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                Mensaje("Ingrese la contraseña del usuario", eMessage.Alerta);
                return false;
            }
            if (!General.validarComplejidadPassword(txtContraseña.Text))
            {
                Mensaje("La contraseña no cumple con los requisitos", eMessage.Alerta);
                return false;
            }
            if (ddlRol.SelectedIndex== 0) 
            {
                Mensaje("Seleccione el rol del usuario", eMessage.Alerta);
                return false;
            }
            return true;
        }
        private bool ValidarActualizar()
        {
            return true;
        }
        private void Guardar()
        {
            try
            {
                int IdRegistro = (int)General.ValidarEnteros(HF_IdUsuario.Value);
                if (IdRegistro > 0)
                {
                    //Actualizando
                    return;
                }
                //Agregando
                if (ValidarInsertar())
                {
                    return;
                }
            }
            catch 
            {
           
            }         
        }
        #endregion

        #region Eventos
        protected void MostrarContraseña_Click(object sender, EventArgs e)
        {
            if (txtContraseña.TextMode == TextBoxMode.SingleLine)
            {
                txtContraseña.TextMode = TextBoxMode.Password;
                IconoConstraseña.Attributes.Remove("fas fa-eye-slash");
                IconoConstraseña.Attributes.Add("class", "fas fa-eye");
                return;
            }
            txtContraseña.TextMode = TextBoxMode.SingleLine;
            IconoConstraseña.Attributes.Remove("fas fa-eye");
            IconoConstraseña.Attributes.Add("class", "fas fa-eye-slash");

        }
        protected void lnkVolver_Click(object sender, EventArgs e)
        {

        }
        protected void lnkLimpiar_Click(object sender, EventArgs e)
        {

        }
        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        protected void lnkAnular_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}