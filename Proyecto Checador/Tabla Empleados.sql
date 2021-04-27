USE [Checador]
GO

/****** Object:  Table [dbo].[Empleados]    Script Date: 01/07/2020 22:56:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Empleados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[Apellidos] [nvarchar](20) NOT NULL,
	[Numero] [nvarchar](5) NOT NULL,
	[Foto] [nvarchar](14) NOT NULL,
	[Huella] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

