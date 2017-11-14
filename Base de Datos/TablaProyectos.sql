USE [TodoPallets]
GO

/****** Object:  Table [dbo].[TablaProyectos]    Script Date: 21/09/2015 03:26:47 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TablaProyectos](
	[id] [int] NOT NULL,
	[nombreProyecto] [varchar](50) NOT NULL,
	[autor] [varchar](50) NOT NULL,
	[fecha] [date] NOT NULL,
	[descripcionProyecto] [varchar](max) NOT NULL,
	[visitas] [int] NOT NULL,
	[puntaje] [float] NOT NULL,
 CONSTRAINT [PK_ProyectosDeUsuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


