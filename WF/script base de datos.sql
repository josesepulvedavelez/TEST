CREATE DATABASE TEST;
USE TEST;

CREATE TABLE Cliente
(
	Nombres VARCHAR(100),
	Usuario VARCHAR(15),
	Contraseña VARCHAR(10),
	Exento BIT,
	ClienteId INT IDENTITY(1, 1) PRIMARY KEY
)

CREATE TABLE Banco
(
	Banco VARCHAR(50),
	Ciudad VARCHAR(50),
	
	BancoId INT IDENTITY(1, 1) PRIMARY KEY
)

CREATE TABLE Cuenta 
(
	Numero VARCHAR(15),
	Tipo VARCHAR(10),
	Saldo FLOAT,

	ClienteId INT FOREIGN KEY REFERENCES Cliente(ClienteId),
	BancoId INT FOREIGN KEY REFERENCES Banco(BancoId),
	CuentaId INT IDENTITY(1, 1) PRIMARY KEY
)

CREATE TABLE Movimiento
(
	Tipo VARCHAR(15),
	Fecha DATE, 
	Valor FLOAT,
	Gmf FLOAT,
	CuentaOrigen INT FOREIGN KEY REFERENCES Cuenta(CuentaId),
	CuentaDestino INT FOREIGN KEY REFERENCES Cuenta(CuentaId) NULL
)

INSERT INTO Cliente(Nombres, Usuario, Contraseña, exento) VALUES('Jennifer Villa', 'jvilla', '1234567', 'false')
INSERT INTO Cliente(Nombres, Usuario, Contraseña, exento) VALUES('Jose Sepulveda Velez', 'jsepulveda', '123', 'true')

INSERT INTO Banco(Banco, Ciudad) VALUES('BBVA', 'BOGOTA')
INSERT INTO Banco(Banco, Ciudad) VALUES('BANORTE', 'BOGOTA')

INSERT INTO Cuenta(Numero, Tipo, Saldo, ClienteId, BancoId) VALUES('A', 'AHORROS', 110000000, 1, 1)
INSERT INTO Cuenta(Numero, Tipo, Saldo, ClienteId, BancoId) VALUES('B', 'AHORROS', 65000000, 1, 2)
INSERT INTO Cuenta(Numero, Tipo, Saldo, ClienteId, BancoId) VALUES('C', 'AHORROS', 500000, 1, 2)
INSERT INTO Cuenta(Numero, Tipo, Saldo, ClienteId, BancoId) VALUES('D', 'CORRIENTE', 1700000000, 2, 2)

CREATE VIEW ClienteCuentaView
AS 
SELECT Cliente.Nombres,
	   Cliente.Usuario,
	   Cliente.ClienteId,
	   Banco.Banco,
	   Banco.BancoId,
	   Cuenta.Numero,
	   Cuenta.Tipo,
	   Cuenta.Saldo,
	   Cuenta.CuentaId
FROM Cliente INNER JOIN Cuenta 
		ON Cliente.ClienteId = Cuenta.ClienteId 
			INNER JOIN banco ON Banco.BancoId = Cuenta.BancoId
			
CREATE VIEW MovimientoView
AS
SELECT ClienteId, Movimiento.Tipo, Fecha, Valor, Gmf, Numero as CuentaOrigen, (SELECT Cuenta.Numero FROM Cuenta where Cuenta.CuentaId = Movimiento.CuentaDestino) as CuentaDestino
FROM Cuenta, Movimiento
WHERE Cuenta.CuentaId = Movimiento.CuentaOrigen
			
