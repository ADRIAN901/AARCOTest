USE [AutosBD]
GO

IF EXISTS(SELECT name FROM sys.objects WHERE name = 'spGetModeloSubMarca' AND type = 'P')
BEGIN
	DROP PROCEDURE [dbo].[spGetModeloSubMarca]
END
GO
CREATE PROCEDURE spGetModeloSubMarca(@piSubMarca AS INT)
AS
BEGIN
	SELECT MSM.[IdModeloSubMarca], MSM.[Descripcion] FROM ModeloSubMarca MSM WITH(NOLOCK)
	INNER JOIN Descripcion D WITH(NOLOCK) ON D.IdModeloSubMarca = MSM.IdModeloSubMarca
	WHERE D.IdSubMarca = @piSubMarca
	GROUP BY MSM.[IdModeloSubMarca], MSM.[Descripcion]
END

--EXEC spGetModeloSubMarca 401