USE [AutosBD]
GO
IF EXISTS(SELECT name FROM sys.objects 
          WHERE name = 'Auxiliar'  AND type = 'U')
BEGIN
	DROP TABLE Auxiliar
END
GO
CREATE TABLE Auxiliar(
    [Id] [int] IDENTITY(1, 1) NOT NULL,
	[Marca] [varchar] (MAX) NOT NULL,
	[SubMarca][varchar](MAX) NOT NULL,
	[ModeloSubMarca][varchar](MAX) NOT NULL,
	[Descripcion][varchar](MAX) NOT NULL,
	[DescripcionId][varchar](MAX) NOT NULL
) ON [PRIMARY]
GO

SELECT * FROM Auxiliar