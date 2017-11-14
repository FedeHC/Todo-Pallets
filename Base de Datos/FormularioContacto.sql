USE [TodoPallets]
GO

/****** Object:  Table [dbo].[FormularioContacto]    Script Date: 17/09/2015 01:25:19 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FormularioContacto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[edad] [int] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[emailPadres] [varchar](50) NULL,
	[consulta] [varchar](1000) NOT NULL,
	[deleted] [bit] NOT NULL,
 CONSTRAINT [PK_FormularioContacto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[FormularioContacto] ADD  CONSTRAINT [DF_FormularioContacto_deleted]  DEFAULT ((0)) FOR [deleted]
GO


