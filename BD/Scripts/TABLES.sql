USE [AutosBD]
GO

IF EXISTS(SELECT name FROM sys.objects 
          WHERE name = 'Marca'  AND type = 'U')
BEGIN
	DROP TABLE Marca
END
GO
CREATE TABLE Marca(
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[Descripcion][varchar](MAX) NOT NULL
) ON [PRIMARY]
GO

IF EXISTS(SELECT name FROM sys.objects 
          WHERE name = 'SubMarca'  AND type = 'U')
BEGIN
	DROP TABLE SubMarca
END
GO
CREATE TABLE SubMarca(
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[Descripcion][varchar](MAX) NOT NULL
) ON [PRIMARY]
GO

IF EXISTS(SELECT name FROM sys.objects 
          WHERE name = 'ModeloSubMarca'  AND type = 'U')
BEGIN
	DROP TABLE ModeloSubMarca
END
GO
CREATE TABLE ModeloSubMarca(
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[Descripcion][varchar](MAX) NOT NULL
) ON [PRIMARY]
GO

IF EXISTS(SELECT name FROM sys.objects 
          WHERE name = 'Descripcion'  AND type = 'U')
BEGIN
	DROP TABLE Descripcion
END
GO
CREATE TABLE Descripcion(
    [Id] [int] IDENTITY(1, 1) NOT NULL,
	[DescripcionId] [varchar] (MAX) NOT NULL,
	[Descripcion][varchar](MAX) NOT NULL,
	[IdModeloSubMarca][int] NOT NULL,
	[IdSubMarca][int] NOT NULL,
	[IdMarca][int] NOT NULL,
) ON [PRIMARY]
GO


INSERT INTO Marca(Descripcion)
SELECT Marca FROM [dbo].[ListaDeAutos]
GROUP BY Marca
ORDER BY Marca

INSERT INTO SubMarca(Descripcion)
SELECT SubMarca FROM [dbo].[ListaDeAutos]
GROUP BY SubMarca
ORDER BY SubMarca

INSERT INTO ModeloSubMarca(Descripcion)
SELECT Modelo FROM [dbo].[ListaDeAutos]
GROUP BY Modelo
ORDER BY Modelo

INSERT INTO Descripcion(
	[DescripcionId],
	[Descripcion],
	[IdModeloSubMarca],
	[IdSubMarca],
	[IdMarca])
SELECT LDA.DescripcionId, LDA.Descripcion, MSM.Id, SM.Id, M.Id FROM [dbo].[ListaDeAutos] LDA
INNER JOIN ModeloSubMarca MSM ON LDA.Modelo = MSM.Descripcion
INNER JOIN SubMarca SM ON LDA.SubMarca = SM.Descripcion
INNER JOIN Marca M ON LDA.Marca = M.Descripcion

SELECT * FROM Descripcion
SELECT * FROM Marca
SELECT * FROM SubMarca
SELECT * FROM ModeloSubMarca
