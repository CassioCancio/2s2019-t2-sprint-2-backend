CREATE DATABASE M_AutoPecas

USE M_AutoPecas

CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR(200) NOT NULL UNIQUE,
	Senha VARCHAR(200) NOT NULL UNIQUE,
)

CREATE TABLE Fornecedores(
	IdFornecedor INT PRIMARY KEY IDENTITY,
	CNPJ VARCHAR(200) NOT NULL UNIQUE,
	RazaoSocial VARCHAR(200) NOT NULL UNIQUE,
	NomeFantasia VARCHAR(200) NOT NULL,
	Endereco VARCHAR(200) NOT NULL UNIQUE,
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario)
);

CREATE TABLE Peças(
	IdPeca INT PRIMARY KEY IDENTITY,
	CodigoPeca VARCHAR(200) NOT NULL UNIQUE,
	Descricao TEXT NOT NULL,
	Peso FLOAT NOT NULL,
	PrecoCusto FLOAT NOT NULL,
	PrecoVenda FLOAT NOT NULL,
	IdFonecedor INT FOREIGN KEY REFERENCES Fornecedores(IdFornecedor)
);

INSERT INTO Usuarios (Email,Senha)
VALUES	('empresaA@empresaA.com','empresaA'),
		('empresaB@empresaB.com','empresaB')

INSERT INTO Fornecedores (CNPJ,RazaoSocial,NomeFantasia,Endereco,IdUsuario)
VALUES	('34882473000181','Pecas de Carro de qualidade','AutoPecas','Av. Paulista 2048',1),
		('74127405000121','Pecas de inox de alto nível','InoxPecas','Av. Faria Lima 3009',2)

INSERT INTO Peças (CodigoPeca,Descricao,Peso,PrecoCusto,PrecoVenda,IdFonecedor)
VALUES	('QI123D22NCK332XCE278688P6FI64S','Para choque',1600,50,100,1),
		('445CK543554352XCE278688P6FI64S','Escapamento',5000,500,750,1),
		('FF56523D22NCK332XCE27865454545','Porta para FIAT',10000,2000,3000,2)

SELECT *
FROM Usuarios

SELECT *
FROM Peças

SELECT *
FROM Fornecedores