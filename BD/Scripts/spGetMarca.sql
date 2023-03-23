USE [AutosBD]
GO

IF EXISTS(SELECT name FROM sys.objects WHERE name = 'spGetMarca' AND type = 'P')
BEGIN
	DROP PROCEDURE [dbo].[spGetMarca]
END
GO
CREATE PROCEDURE spGetMarca
AS
BEGIN
	SELECT [Id], [Descripcion] FROM Marca WITH(NOLOCK)
END

--EXEC spGetMarca