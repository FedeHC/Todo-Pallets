USE [TodoPallets]
GO

/****** Object:  Table [dbo].[TablaProductos]    Script Date: 21/09/2015 03:26:06 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TablaProductos](
	[id] [int] NOT NULL,
	[nombreProducto] [varchar](50) NOT NULL,
	[fecha] [date] NOT NULL,
	[precio] [int] NOT NULL,
	[descripcionProducto] [varchar](max) NOT NULL,
	[visitas] [int] NOT NULL,
	[puntaje] [float] NOT NULL,
 CONSTRAINT [PK_MueblesEnVenta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


