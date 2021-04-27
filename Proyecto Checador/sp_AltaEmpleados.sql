USE [Checador]
GO
/****** Object:  StoredProcedure [dbo].[AltaEmpleados]    Script Date: 01/07/2020 22:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AltaEmpleados]
(
	@Nombre nvarchar(20),
	@Apellidos nvarchar(20),
	@Numero nvarchar(5),
	@Foto nvarchar(14),
	@Huella varbinary(max) = NULL,
	@Id int OUTPUT
)
AS
INSERT INTO Empleados(Nombre, Apellidos, Numero, Foto, Huella)
VALUES (@Nombre, @Apellidos, @Numero, @Foto, @Huella)

SET @Id = SCOPE_IDENTITY();