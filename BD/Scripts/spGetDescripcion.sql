USE [AutosBD]
GO

IF EXISTS(SELECT name FROM sys.objects WHERE name = 'spGetDescripcion' AND type = 'P')
BEGIN
	DROP PROCEDURE [dbo].[spGetDescripcion]
END
GO
CREATE PROCEDURE spGetDescripcion(@piMarca AS INT,
                                  @piSubMarca AS INT,
								  @piModeloSubMarca AS INT)
AS
BEGIN
	SELECT [DescripcionId], [Descripcion] FROM Descripcion  WITH(NOLOCK)
	WHERE IdMarca = @piMarca
	AND IdSubMarca = @piSubMarca
	AND IdModeloSubMarca = @piModeloSubMarca
END

--EXEC spGetDescripcion 8, 401, 8