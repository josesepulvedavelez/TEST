<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WF._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
		<table>
			<tr>
				<td>Nombres: </td>
				<td><b><asp:Label ID="lblNombres" runat="server" Text="Label"></asp:Label></b></td>
			</tr>
			<tr>
				<td>Usuario: </td>
				<td><b><asp:Label ID="lblUsuario" runat="server" Text="Label"></asp:Label></b></td>
			</tr>
			<tr>
				<td>Exento: </td>
				<td><b><asp:Label ID="lblExento" runat="server" Text="Label"></asp:Label></b></td>
			</tr>
		</table>

		<br />
		
		<div id="divCuentas" runat="server" visible="true">
			<asp:GridView ID="gvCuentaClienteView" runat="server" CssClass="table table-hover" OnRowDataBound="gvCuentaClienteView_RowDataBound" Font-Size="Larger" Caption="CUENTAS" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvCuentaClienteView_SelectedIndexChanged">
				<Columns>
					<asp:BoundField DataField="Banco" HeaderText="Banco" />
					<asp:BoundField DataField="BancoId" HeaderText="BancoId" />
					<asp:BoundField DataField="ClienteId" HeaderText="ClienteId" />
					<asp:BoundField DataField="CuentaId" HeaderText="CuentaId" />
					<asp:BoundField DataField="Nombres" HeaderText="Nombres" />
					<asp:BoundField DataField="Numero" HeaderText="Numero" />
					<asp:BoundField DataField="Saldo" HeaderText="Saldo" />
					<asp:BoundField DataField="Tipo" HeaderText="Tipo" />
					<asp:BoundField DataField="Usuario" HeaderText="Usuario" />					
				</Columns>
				
			</asp:GridView>
			<p><asp:Button ID="btnVerMovimientos" runat="server" Text="Ver movimientos" class="btn btn-lg btn-primary btn-block btn-signin" OnClick="btnVerMovimientos_Click" /></p>
		</div>

		<div id="divMovimientos" runat="server" visible="false">
			<asp:GridView ID="gvMovimientoView" runat="server" CssClass="table table-hover" Font-Size="Larger" Caption="MOVIMIENTOS" AutoGenerateColumns="False">
				<Columns>
					<asp:BoundField DataField="ClienteId" HeaderText="CuentaId" Visible="false"/>
					<asp:BoundField DataField="Fecha" HeaderText="Fecha" />
					<asp:BoundField DataField="CuentaOrigen" HeaderText="CuentaOrigen" />
					<asp:BoundField DataField="CuentaDestino" HeaderText="CuentaDestino" />
					<asp:BoundField DataField="Tipo" HeaderText="Tipo" />
					<asp:BoundField DataField="Valor" HeaderText="Valor" />
					<asp:BoundField DataField="Gmf" HeaderText="Gmf" />					
				</Columns>
			</asp:GridView>
			<p><asp:Button ID="btnVerCuentas" runat="server" Text="Volver a mis cuentas" class="btn btn-lg btn-primary btn-block btn-signin" OnClick="btnVerCuentas_Click" /></p>			
		</div>

		<div id="divTransferirRetirar" runat="server" visible="false">
			<table>
				<tr>
					<td>Cuenta Origen</td>
					<td><asp:Label ID="lblCuentaOrigen" runat="server" Text="Label" class="form-control"></asp:Label></td>
				</tr>
				<tr>
					<td>Tipo</td>
					<td>
						<asp:DropDownList ID="ddlTipo" runat="server" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="true" class="form-control">
							<asp:ListItem>transferencia</asp:ListItem>
							<asp:ListItem>efectivo</asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>				
				<tr>
					<td>Cuenta Destino: </td>
					<td><b><asp:DropDownList ID="ddlCuenta" runat="server" class="form-control" AutoPostBack="True" >
						</asp:DropDownList></b></td>
				</tr>
				<tr>
					<td>Valor: </td>
					<td><b><asp:TextBox ID="txtValor" runat="server" TextMode="Number">0</asp:TextBox></b></td>
				</tr>				
			</table>
			<br />
			<p>
				<asp:Button ID="btnTransferir" runat="server" Text="Aceptar" class="btn btn-lg btn-primary btn-block btn-signin" OnClick="btnTransferir_Click" />				
			</p>
		</div>

	</div>    

</asp:Content>
