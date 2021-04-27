USE [Checador]
GO

/****** Object:  StoredProcedure [dbo].[MuestraEmpleados]    Script Date: 01/07/2020 22:59:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MuestraEmpleados]
AS
SELECT * FROM Empleados
GO

