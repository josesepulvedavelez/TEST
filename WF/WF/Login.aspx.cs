using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WF.Cliente;

namespace WF
{
    public partial class Login : System.Web.UI.Page
    {
        ClienteWCFClient clienteWCFClient;
        ClienteENT clienteENT;
        int result;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            clienteWCFClient = new ClienteWCFClient();
            clienteENT = new ClienteENT();

            clienteENT.Usuario = txtUsuario.Text;
            clienteENT.Contraseña = txtContraseña.Text;

            result = clienteWCFClient.Loguear(clienteENT);

            if (result == 1)
            {
                Session["usuario"] = txtUsuario.Text;
                Response.Redirect("Default.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuario o contraseña incorrectos')", true);
            }
        }
    }
}