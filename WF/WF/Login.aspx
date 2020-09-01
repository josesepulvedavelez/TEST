<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WF.Login" %>

<!DOCTYPE html>
	<html>
		<head>
		    <title>sistema de login</title>
		    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">			
			<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
			<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" />
			<link rel="stylesheet" type="text/css" href="Content/estilo.css" rel="stylesheet" />
		</head>
		
		<body>
			<div id="Contenedor">
		 		<div class="Icon">                    
				   <span class="glyphicon glyphicon-user"></span>
				</div>
				<div class="ContentForm">
		 			<form runat="server">
						 <div class="opcioncontra"><h4>Sistema de retiros</h4></div>
		 				<div class="input-group input-group-lg">
							<span class="input-group-addon" id="sizing-addon1"><i class="glyphicon glyphicon-envelope"></i></span>
							<asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Usuario"></asp:TextBox>
						</div>
						<br>
						<div class="input-group input-group-lg">
							<span class="input-group-addon" id="sizing-addon1"><i class="glyphicon glyphicon-lock"></i></span>
							<asp:TextBox ID="txtContraseña" runat="server" class="form-control" TextMode="Password" placeholder="*******"></asp:TextBox>							
						</div>
						<br>
						<asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="btn btn-lg btn-primary btn-block btn-signin" OnClick="btnIngresar_Click" />					
		 			</form>
				</div>	
			</div>			

			<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>		
			<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
		</body>		
</html>
