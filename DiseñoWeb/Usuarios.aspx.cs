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
                panelBtnLock.Visible = false;
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
                        if (PermisoUser.IdPermiso == (int)ePermisos.Bloqueo)
                        {
                            panelBtnLock.Visible = true;
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
            if (!(string.IsNullOrEmpty(txtBuscar.Text)||string.IsNullOrWhiteSpace(txtBuscar.Text)) && txtBuscar.Text.Length > 2)
            {
                gvUsuarios.DataSource = BL_Usuarios.vUsuarios().Where(a=>a.NombreCompleto.ToLower().Contains(txtBuscar.Text.ToLower()) ||a.Correo.ToLower().Contains(txtBuscar.Text.ToLower()) ||a.UserName.ToLower().Contains(txtBuscar.Text.ToLower())).ToList();
                gvUsuarios.DataBind();
                return;
            }
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
        private void CargarControles(int IdRegistro)
        {
            try
            {
                vUsuarios vusuario = BL_Usuarios.vUsuario(IdRegistro);
                if (vusuario == null)
                {
                    Mensaje("No se encontraron datos para el registro seleccionado", eMessage.Error);
                    return;
                }
                HF_IdUsuario.Value = vusuario.IdUsuario.ToString();
                txtNombre.Text = vusuario.NombreCompleto;
                txtCorreo.Text = vusuario.Correo;
                txtUsuario.Text = vusuario.UserName;
                txtContraseña.Text = string.Empty;
                ddlRol.SelectedValue = vusuario.IdRol.ToString();
                lnkLock.Text = (vusuario.Bloqueado) ? "Desbloquear" : "Bloquear";

            }
            catch
            {
                Mensaje("Error al cargar el registro", eMessage.Error);
            }
        }
        private void ResetControles()
        {
            txtNombre.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtContraseña.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            ddlRol.SelectedIndex = 0;
            HF_IdUsuario.Value = "0";
            lnkLock.Text = "Bloquear";
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
            if (!General.CorreoEsValido(txtCorreo.Text))
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
            if (ddlRol.SelectedIndex == 0)
            {
                Mensaje("Seleccione el rol del usuario", eMessage.Alerta);
                return false;
            }
            return true;
        }
        private bool ValidarActualizar(int IdRegistro)
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
            if (!General.CorreoEsValido(txtCorreo.Text))
            {
                Mensaje("Ingrese un correo válido", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                Mensaje("Ingrese el login del usuario", eMessage.Alerta);
                return false;
            }
            if (BL_Usuarios.ExisteUserNameUpdate(txtUsuario.Text,IdRegistro))
            {
                Mensaje("El login Ya existe en el Sistema", eMessage.Alerta);
                return false;
            }
            if (!(string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text)))
            {
                if (!General.validarComplejidadPassword(txtContraseña.Text))
                {
                    Mensaje("La contraseña no cumple con los requisitos", eMessage.Alerta);
                    return false;
                }
            }
            if (ddlRol.SelectedIndex == 0)
            {
                Mensaje("Seleccione el rol del usuario", eMessage.Alerta);
                return false;
            }
            return true;
        }
        private void Guardar()
        {
            try
            {
                int IdUsuarioSistema = (int)General.ValidarEnteros(Session["IdUsuarioGl"]);
                if (!(IdUsuarioSistema > 0))
                {
                    Mensaje("Datos del usuario no encontrados", eMessage.Alerta);
                    return;
                }
                int IdRegistro = (int)General.ValidarEnteros(HF_IdUsuario.Value);
                Usuarios user = new Usuarios();
                if (IdRegistro > 0)
                {
                    //Actualizando
                    if(ValidarActualizar(IdRegistro)) 
                    {
                        bool UpdatePassword = false;
                        user.IdUsuario = IdRegistro;
                        user.NombreCompleto = txtNombre.Text;
                        user.Correo = txtCorreo.Text;
                        user.UserName = txtUsuario.Text;
                        if (!(string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text)))
                        { 
                            user.Password = BL_Usuarios.Encrypt(txtContraseña.Text);
                            UpdatePassword= true;
                        }
                        user.IdRol = (int)General.ValidarEnteros(ddlRol.SelectedValue);
                        user.IdUsuarioActualiza = IdUsuarioSistema;
                        if (BL_Usuarios.Update(user,UpdatePassword))
                        {
                            ResetControles();
                            CargarGrid();
                            Mensaje("Registro Actualizado Correctamente", eMessage.Exito);
                            return;
                        }
                        Mensaje("Registro no Actualizado", eMessage.Error);
                        return;
                    }
                    return;
                }
                //Agregando
                if (ValidarInsertar())
                {
                    
                    user.NombreCompleto = txtNombre.Text;
                    user.Correo = txtCorreo.Text;
                    user.UserName = txtUsuario.Text;
                    user.Password = BL_Usuarios.Encrypt(txtContraseña.Text);
                    user.IdRol = (int)General.ValidarEnteros(ddlRol.SelectedValue);
                    user.IdUsuarioRegistra = IdUsuarioSistema;
                    if (BL_Usuarios.Insert(user).IdUsuario > 0)
                    {
                        ResetControles();
                        CargarGrid();
                        Mensaje("Registro Guardado Correctamente", eMessage.Exito);
                        return;
                    }
                    Mensaje("Registro no Guardado", eMessage.Error);
                    return;
                }
                Mensaje("No se realizó ninguna operación", eMessage.Error);
            }
            catch
            {
                Mensaje("Error en el sistema", eMessage.Error);
            }
        }
        private void Anular()
        {
            try
            {
                int IdUsuarioSistema = (int)General.ValidarEnteros(Session["IdUsuarioGl"]);

                if (!(IdUsuarioSistema > 0))
                {
                    Mensaje("Datos del Usuario de sistema no encontrados", eMessage.Alerta);
                    return;
                }

                int IdRegistro = (int)General.ValidarEnteros(HF_IdUsuario.Value);
                Usuarios User = new Usuarios();

                if (IdRegistro > 0)
                {
                    User.IdUsuario = IdRegistro;
                    User.IdUsuarioActualiza = IdUsuarioSistema;
                    if (BL_Usuarios.Delete(User))
                    {
                        ResetControles();
                        CargarGrid();
                        Mensaje("Registro anulado Correctamente", eMessage.Exito);
                        return;
                    }
                    Mensaje("Error al anular el registro", eMessage.Error);
                    return;
                }
                Mensaje("Asegurese de seleccionar un registro para anular", eMessage.Alerta);
            }
            catch
            {
                Mensaje("Error al anular el registro", eMessage.Error);
            }
        }
        private void Bloqueo()
        {
            try
            {
                int IdUsuarioSistema = (int)General.ValidarEnteros(Session["IdUsuarioGl"]);

                if (!(IdUsuarioSistema > 0))
                {
                    Mensaje("Datos del Usuario de sistema no encontrados", eMessage.Alerta);
                    return;
                }
                int IdRegistro = (int)General.ValidarEnteros(HF_IdUsuario.Value);
                bool Bloqueo = (lnkLock.Text == "Desbloquear") ? false : true;

                if (BL_Usuarios.BloquearCuentaUsuario(IdRegistro, Bloqueo, IdUsuarioSistema))
                {
                    string Operacion = (Bloqueo) ? "Bloqueado" : "Desbloqueado";
                    CargarGrid();
                    ResetControles();
                    Mensaje($"Registro {Operacion} Correctamente", eMessage.Exito);
                    return;
                }
                Mensaje("Error al realizar la operación en el registro", eMessage.Error);
            }
            catch
            {
                Mensaje("Error al realizar la operación en el registro", eMessage.Error);
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
            ResetControles();
        }
        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        protected void lnkAnular_Click(object sender, EventArgs e)
        {
            Anular();
        }
        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int RowIndex = gvUsuarios.SelectedRow.RowIndex;
                int IdRegistro = (int)General.ValidarEnteros(gvUsuarios.DataKeys[RowIndex]["IdUsuario"].ToString());
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
        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;
            CargarGrid();
            ResetControles();
        }
        protected void lnkLock_Click(object sender, EventArgs e)
        {
            Bloqueo();
        }
        protected void lnkBuscar_Click(object sender, EventArgs e)
        {
                CargarGrid();
        }
        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtBuscar.Text) || string.IsNullOrWhiteSpace(txtBuscar.Text)) && txtBuscar.Text.Length > 2)
            {
                CargarGrid();
            }
        }
        #endregion


    }
}