using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WF.Cliente;
using WF.Movimiento;


namespace WF
{
    public partial class _Default : Page
    {
        ClienteWCFClient clienteWCFClient = new ClienteWCFClient();
        ClienteENT clienteENT = new ClienteENT();
        ClienteCuentaView clienteCuentaView = new ClienteCuentaView();

        MovimientoClient movimientoClient = new MovimientoClient();
        MovimientoView movimientoView = new MovimientoView();
        MovimientoENT movimientoENT = new MovimientoENT();
        int result;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargar();
            }
        }
        protected void Cargar()
        {
            lblUsuario.Text = Session["usuario"].ToString();
            clienteCuentaView.Usuario = lblUsuario.Text;

            gvCuentaClienteView.DataSource = clienteWCFClient.GetClienteCuenta(clienteCuentaView);            
            gvCuentaClienteView.DataBind();

            clienteENT.Usuario = clienteCuentaView.Usuario;
            clienteENT = clienteWCFClient.GetClienteSesion(clienteENT);

            lblNombres.Text = clienteENT.Nombres;
            lblExento.Text = clienteENT.Exento.ToString();

            movimientoView.ClienteId = clienteENT.ClienteId;
            gvMovimientoView.DataSource = movimientoClient.GetMovimientos(movimientoView);
            gvMovimientoView.DataBind();
        }

        protected void gvCuentaClienteView_RowDataBound(object sender, GridViewRowEventArgs e)
        {            
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[8].Visible = false;
        }

        protected void btnVerMovimientos_Click(object sender, EventArgs e)
        {
            divMovimientos.Visible = true;
            divCuentas.Visible = false;
        }

        protected void btnVerCuentas_Click(object sender, EventArgs e)
        {
            divCuentas.Visible = true;
            divMovimientos.Visible = false;
        }

        protected void gvCuentaClienteView_SelectedIndexChanged(object sender, EventArgs e)
        {
            divTransferirRetirar.Visible = true;
            divCuentas.Visible = false;

            lblCuentaOrigen.Text = gvCuentaClienteView.SelectedRow.Cells[6].Text;

            ddlCuenta.DataSource = clienteWCFClient.GetCuentas(gvCuentaClienteView.SelectedRow.Cells[6].Text);
            ddlCuenta.DataTextField = "Numero";
            ddlCuenta.DataValueField = "CuentaId";
            ddlCuenta.DataBind();
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipo.SelectedValue == "efectivo")
            {
                ddlCuenta.Enabled = false;
                txtValor.Focus();
            }

            else if(ddlTipo.SelectedValue == "transferencia")
            {                
                ddlCuenta.Enabled = true;
            }
        }

        protected void btnTransferir_Click(object sender, EventArgs e)
        {
            int cuentaOrigen = Convert.ToInt32(gvCuentaClienteView.SelectedRow.Cells[4].Text);
            double valor = Convert.ToDouble(txtValor.Text);
            double saldo = Convert.ToDouble(gvCuentaClienteView.SelectedRow.Cells[7].Text);

            if (Convert.ToInt32(ddlCuenta.SelectedValue) == cuentaOrigen || valor <= 0 || valor > saldo)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('OPERACION INCORRECTA: A)LA CUENTA ORIGEN ES IGUAL A LA CUENTA DESTINO. B)EL VALOR A TRANSFERIR ES MENOR QUE 0. C) EL VALOR A TRANSFERIR ES MAYOR QUE LA CUENTA ORIGEN ')", true);
            }
            else
            {
                MovimientoClient movimientoClient = new MovimientoClient();
                
                movimientoENT.Tipo = ddlTipo.Text;
                movimientoENT.Fecha = DateTime.Now.Date;
                movimientoENT.Valor = Convert.ToDouble(txtValor.Text);

                movimientoENT.CuentaOrigen = cuentaOrigen;
                movimientoENT.CuentaDestino = Convert.ToInt32(ddlCuenta.SelectedValue);

                result = movimientoClient.Transferir(movimientoENT, Convert.ToBoolean(lblExento.Text));

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + result + "' + ' Transferencia / retiro realizados')", true);

                divCuentas.Visible = true;
                divTransferirRetirar.Visible = false;
                Cargar();
            }
        }
        
    }
}