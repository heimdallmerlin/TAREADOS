

CREATE DATABASE BDDTAREAS
GO

USE BDDTAREAS
CREATE TABLE [dbo].[Colaborador](
	id_col int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombre_col nvarchar(100) NOT NULL,
	aPaterno_col nvarchar(100),
	aMaterno_col nvarchar(100)
)

CREATE TABLE [dbo].[Categoria] (
	id_cat int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	nombre_cat nvarchar(100) NOT NULL
)
--cambiar el campo de estatus_tar por numero
--Primero vamos probar usando directamente NUEVA, EN PROCESO, FINALIZADA

CREATE TABLE [dbo].[Tarea](
	id_tar int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombre_tar nvarchar(100) NOT NULL,
	descripcion_tar nvarchar(100),
	estatus_tar nvarchar(100) NOT NULL,
	id_col int NOT NULL,
	CONSTRAINT FK_id_colaborador FOREIGN KEY(id_col) 
	REFERENCES [dbo].[Colaborador](id_col),
	id_cat int NOT NULL, 
	CONSTRAINT FK_id_categoria FOREIGN KEY(id_cat) 
	REFERENCES [dbo].[Categoria](id_cat),
)

--Insertar Datos en tabla Categoria
SET IDENTITY_INSERT Categoria OFF
INSERT INTO Categoria VALUES ('Escuela')
INSERT INTO Categoria VALUES ('Trabajo')
INSERT INTO Categoria VALUES ('Hogar')

--Insertar Datos en tabla Colaborador
SET IDENTITY_INSERT Colaborador OFF
INSERT INTO Colaborador VALUES ('Jose','Mu�oz','Mu�oz')
INSERT INTO Colaborador VALUES ('Luis','Merlin','Merlin')
INSERT INTO Colaborador VALUES ('Efr�n','Ordaz','Ordaz')
INSERT INTO Colaborador VALUES ('Daniela','Mora','Mora')
INSERT INTO Colaborador VALUES ('Alfredo','Lara','Lara')
INSERT INTO Colaborador VALUES ('Miriam','P�rez','P�rez')
INSERT INTO Colaborador VALUES ('Sandra','Garc�a','Garc�a')
INSERT INTO Colaborador VALUES ('Oscar','Cruz','Cruz')
INSERT INTO Colaborador VALUES ('Mar','L�pez','L�pez')
INSERT INTO Colaborador VALUES ('Santiago','Flores','Flores')

--Insertar Datos en la tabla de Tareas
SET IDENTITY_INSERT Tarea OFF
INSERT INTO Tarea VALUES ('Tarea Uno','','Nueva','2','2')

