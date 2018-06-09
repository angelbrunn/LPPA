using System;
using System.Collections.Generic;
using System.Web.Security;

namespace MotoPoint
{
    public partial class login : System.Web.UI.Page
    {
        /// <summary>
        /// Instancio la clase de arquitectura base | MultiUsuario
        /// </summary>
        BLL.SIS.BUSINESS.INegMultiUsuario interfazNegocioUsuario = new BLL.SIS.BUSINESS.NegMultiUsuario();

        FormsAuthenticationTicket authTicket;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = txtUsuario.Text;
            Session["Contraseña"] = txtContrasenia.Text;
            
            //VALIDAR LOGIN | + INTENTOS

            //REDIREC SEGUN ROL
            //Response.Redirect("Respuesta_EjercicioVarSession.aspx");

            
            var resultadoLogin = 0;
            BE.SIS.ENTIDAD.Usuario user = new BE.SIS.ENTIDAD.Usuario();

            user.usuario = txtUsuario.Text;
            user.password = txtContrasenia.Text;

            if (txtUsuario.Text != null && txtContrasenia.Text != null)
            {
                //OBTENGO ID DEL USER SI EXISTE
                resultadoLogin = interfazNegocioUsuario.login(user.usuario, user.password);
            }

            //EVALUO EL RESULTDO DEL LOGIN | SI ES 0 NO EXISTE -> CREAR USUARIO
            if (resultadoLogin != 0)
            {
                //BUSCO EL USUARIO POR SU ID
                var usuario = interfazNegocioUsuario.obtenerUsuario(resultadoLogin);
                //GUARDO EL USUARIO CONECTADO EN SESSION
                Session["Usuario"] = usuario.usuario;
                Session["UsuarioId"] = usuario.idUsuario;
                //ME GUARDO LOS GRUPOS PARA EL USUARIO LOGEADO
                List<BE.SIS.ENTIDAD.Grupo> lstGrupos = usuario.listadoGrupos;
                //NIVEL DE ACCESO DEL USUARIO LOGEADO
                var nVisibilidad = "";

                foreach (BE.SIS.ENTIDAD.Grupo g in lstGrupos)
                {
                    //TOMO LA VISIBILIDAD ASIGNADA A DICHO USUARIO
                    nVisibilidad = g.grupo;
                }

                if (nVisibilidad == "Admin")
                {
                    //SI USUARIO ADMIN -> PANTALLA ADMIN
                    /*
                    authTicket = new FormsAuthenticationTicket(1, usuario.usuario, DateTime.Now, DateTime.Now.AddMinutes(20), false, nVisibilidad);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    */
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    //SI USUARIO ES JERARQUICO O USUARIO -> PANTALLA HOME
                    /*
                    authTicket = new FormsAuthenticationTicket(1, usuario.usuario, DateTime.Now, DateTime.Now.AddMinutes(20), false, nVisibilidad);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    */
                    Response.Redirect("home.aspx");
                }
            }
            else
            {
                //MOSTRAR PANTALLA LOGIN | AVISAR USER INVALIDO
                Session["loginEstado"] = 1;
                FormsAuthentication.SignOut();
            }












        }
    }
}