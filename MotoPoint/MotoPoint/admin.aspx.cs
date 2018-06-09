using System;
using System.Web.Security;

namespace MotoPoint
{
    public partial class admin : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["dbEstado"] = 2;


            if (User.IsInRole("Usuario"))
            {

                Response.Redirect("home.aspx");
            }

        }
        /// <summary>
        /// REDIRECCIONO HACIA EL HOME PAGE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
        /// <summary>
        ///  ARQ.BASE: GESTION DE PERFILES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkGestionPerfiles_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminGestionPerfiles.aspx");
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }
    }
}