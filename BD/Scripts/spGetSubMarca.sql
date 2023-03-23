USE [AutosBD]
GO

IF EXISTS(SELECT name FROM sys.objects WHERE name = 'spGetSubMarca' AND type = 'P')
BEGIN
	DROP PROCEDURE [dbo].[spGetSubMarca]
END
GO
CREATE PROCEDURE spGetSubMarca(@piMarca AS INT)
AS
BEGIN
	SELECT [Id], SM.[Descripcion] FROM SubMarca SM WITH(NOLOCK)
	INNER JOIN Descripcion D WITH(NOLOCK) ON D.IdSubMarca = SM.Id
	WHERE D.IdMarca = @piMarca
	GROUP BY [Id], SM.[Descripcion]
END

--EXEC spGetSubMarca 8