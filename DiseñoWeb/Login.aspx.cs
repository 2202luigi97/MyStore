using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static EL.Enums;
using BL;
using System.Text;
using Utilidades;
using EL;

namespace DiseñoWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AbandonarSesion();
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
        private bool validarAccesos()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                Mensaje("Ingrese el Usuario", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                Mensaje("Ingrese la Contraseña", eMessage.Alerta);
                return false;
            }
            if (!BL_Usuarios.ExisteUserName(txtUsuario.Text))
            {
                Mensaje("Credenciales Incorrectas", eMessage.Alerta);
                return false;
            }
            if (BL_Usuarios.VerificarCuentaBloqueada(txtUsuario.Text))
            {
                Mensaje(Justify("Su cuenta ha sido bloqueada por multiples intentos fallidos de iniciar sesion"), eMessage.Error, "", true, true, false, "", false);
                return false;
            }
            byte[] password = BL_Usuarios.Encrypt(txtPassword.Text);
            if (!BL_Usuarios.ValidarCredenciales(txtUsuario.Text, password))
            {
                Mensaje(Justify("Credenciales Incorrectas, si supera 3 intentos fallidos de inicio de sesion su cuenta será bloqueada"), eMessage.Alerta, "", true);
                Usuarios user = BL_Usuarios.ExisteUsuario_x_UserName(txtUsuario.Text);
                if (BL_Usuarios.CantidadIntentosFallidos(txtUsuario.Text) >= 2)
                {
                    BL_Usuarios.BloquearCuentaUsuario(user.IdUsuario, true, user.IdUsuario);
                    Mensaje(Justify("Su cuenta ha sido bloqueada por multiples intentos fallidos de iniciar sesion, porfavor comuniquese con un admin. del sistema"), eMessage.Error, "", true, true, false, "", false);
                }
                if (user != null)
                {
                    BL_Usuarios.SumarIntentosFallido(user.IdUsuario);
                }
                return false;
            }
            Usuarios usuarioautenticado = BL_Usuarios.ExisteUsuario_x_UserName(txtUsuario.Text);
            if (usuarioautenticado != null)
            {
                if (usuarioautenticado.IntentosFallidos > 0)
                {
                    BL_Usuarios.RestablecerIntentosFallido(usuarioautenticado.IdUsuario, usuarioautenticado.IdUsuario);
                }
                if (!(usuarioautenticado.IdRol > 0))
                {
                    Mensaje("Estimado usuario usted no cuenta con un rol en el sistema, comuniquese con el administrador", eMessage.Alerta);
                    return false;
                }
                Session["IdUsuarioGl"] = usuarioautenticado.IdUsuario;
                Session["IdRolGl"] = usuarioautenticado.IdRol;
                Mensaje("Acceso Correcto", eMessage.Exito);
                Response.Redirect("~/Principal.aspx");
            }
            return true;
        }
        #endregion
        #region Eventos de Controles
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (validarAccesos()) { }
        }
        #endregion

    }
}