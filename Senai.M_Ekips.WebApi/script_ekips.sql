CREATE DATABASE M_Ekips

Use M_Ekips

CREATE TABLE Departamentos(
	IdDepartamento INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Status (
	IdStatus INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Cargos(
	IdCargo INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(200) NOT NULL,
	IdStatus INT FOREIGN KEY REFERENCES Status(IdStatus) NOT NULL
);

CREATE TABLE Permissoes(
	IdPermissao INT PRIMARY KEY IDENTITY,
	TipoPermissao VARCHAR(200) NOT NULL
);

CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR(200) NOT NULL UNIQUE,
	Senha VARCHAR(200) NOT NULL,
	IdPermissao INT FOREIGN KEY REFERENCES Permissoes(IdPermissao)
);

Create TABLE Funcionarios(
	IdFuncionario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(200) NOT NULL,
	CPF VARCHAR(200) NOT NULL UNIQUE,
	DataNascimento DATE NOT NULL,
	Salario FLOAT NOT NULL,
	IdDepartamento INT FOREIGN KEY REFERENCES Departamentos(IdDepartamento) NOT NULL,
	IdCargo INT FOREIGN KEY REFERENCES Cargos(IdCargo) NOT NULL,
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario) NOT NULL
);

INSERT INTO Permissoes (TipoPermissao)
	VALUES	('ADMINISTRADOR'),
			('COMUM')

INSERT INTO Status (Nome)
	VALUES	('Ativo'),
			('Desativado'),
			('Aguardando')

INSERT INTO Departamentos (Nome)
	VALUES	('Tecnologia aplicada'),
			('Projetos'),
			('Administração'),
			('Telemarketing')

INSERT INTO Cargos (Nome,IdStatus)
	VALUES	('Scrum Master', 1),
			('Product Owner', 1),
			('Gerenciador de FAX', 2),
			('Web Designer', 3),
			('Diretor', 1)

INSERT INTO Usuarios (Email,Senha,IdPermissao)
	VALUES	('adm@email.com','12345678',1)
			,('joao@email.com','12345678',2)
			,('maria@email.com','12345678',2)

INSERT INTO Funcionarios (Nome,CPF,DataNascimento,Salario,IdDepartamento,IdCargo,IdUsuario)
	VALUES	('Roberto Azevedo','111.111.111-11','1980-02-23',5000,3,5,1)
			,('João Silva','222.222.222-22','1990-07-17',2500,2,1,2)
			,('Maria Souza','333.333.333-33','1984-11-24',3000,1,2,3)

SELECT *
FROM Funcionarios

SELECT *
FROM Departamentos

SELECT *
FROM Cargos

SELECT *
FROM Status

SELECT *
FROM Permissoes

SELECT *
FROM Usuarios

SELECT F.IdFuncionario, F.Nome, F.CPF, F.Salario, D.IdDepartamento,D.Nome, C.IdCargo, C.Nome, U.IdUsuario,U.Email,U.Senha,P.IdPermissao,P.TipoPermissao,S.IdStatus, S.Nome
FROM Funcionarios F
INNER JOIN Departamentos D
ON F.IdDepartamento = D.IdDepartamento
INNER JOIN Cargos C
ON F.IdCargo = C.IdCargo
INNER JOIN Usuarios U
ON F.IdUsuario = U.IdUsuario
INNER JOIN Status S
ON C.IdStatus = S.IdStatus
INNER JOIN Permissoes P
ON U.IdPermissao = P.IdPermissao

SELECT F.IdFuncionario, F.Nome, F.CPF, F.Salario, F.DataNascimento, D.IdDepartamento,D.Nome, C.IdCargo, C.Nome
FROM Funcionarios F
INNER JOIN Departamentos D
ON F.IdDepartamento = D.IdDepartamento
INNER JOIN Cargos C
ON F.IdCargo = C.IdCargo