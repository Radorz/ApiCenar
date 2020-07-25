Create database ApiCenar
go
USE [ApiCenar]
GO

/****** Object:  Table [dbo].[Ingredientes]    Script Date: 25/7/2020 10:03:07 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ingredientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Ingredientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [ApiCenar]
GO

/****** Object:  Table [dbo].[Platos]    Script Date: 25/7/2020 10:04:03 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Platos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](100) NULL,
	[Precio] [decimal](19, 2) NULL,
	[Personas] [int] NULL,
	[Categoria] [nchar](20) NULL,
 CONSTRAINT [PK_Platos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [ApiCenar]
GO

/****** Object:  Table [dbo].[IngredientesPlato]    Script Date: 25/7/2020 10:04:19 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IngredientesPlato](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdIngrediente] [int] NULL,
	[IdPlato] [int] NULL,
 CONSTRAINT [PK_IngredientesPlato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IngredientesPlato]  WITH CHECK ADD  CONSTRAINT [FK_IngredientesPlato_Ingredientes] FOREIGN KEY([IdIngrediente])
REFERENCES [dbo].[Ingredientes] ([Id])
GO

ALTER TABLE [dbo].[IngredientesPlato] CHECK CONSTRAINT [FK_IngredientesPlato_Ingredientes]
GO

ALTER TABLE [dbo].[IngredientesPlato]  WITH CHECK ADD  CONSTRAINT [FK_IngredientesPlato_Platos] FOREIGN KEY([IdPlato])
REFERENCES [dbo].[Platos] ([Id])
GO

ALTER TABLE [dbo].[IngredientesPlato] CHECK CONSTRAINT [FK_IngredientesPlato_Platos]
GO

USE [ApiCenar]
GO

/****** Object:  Table [dbo].[Mesas]    Script Date: 25/7/2020 10:04:36 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Mesas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Personas] [int] NULL,
	[Descripcion] [nchar](100) NULL,
	[Estado] [nchar](20) NULL,
 CONSTRAINT [PK_Mesas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [ApiCenar]
GO

/****** Object:  Table [dbo].[Ordenes]    Script Date: 25/7/2020 10:04:48 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ordenes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMesa] [int] NULL,
	[Subtotal] [decimal](19, 2) NULL,
	[Estado] [nchar](15) NULL,
 CONSTRAINT [PK_Ordenes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Ordenes]  WITH CHECK ADD  CONSTRAINT [FK_Ordenes_Mesas] FOREIGN KEY([IdMesa])
REFERENCES [dbo].[Mesas] ([Id])
GO

ALTER TABLE [dbo].[Ordenes] CHECK CONSTRAINT [FK_Ordenes_Mesas]
GO

USE [ApiCenar]
GO

/****** Object:  Table [dbo].[OrdenPlatos]    Script Date: 25/7/2020 10:04:58 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrdenPlatos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPlato] [int] NULL,
	[IdOrden] [int] NULL,
 CONSTRAINT [PK_OrdenPlatos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OrdenPlatos]  WITH CHECK ADD  CONSTRAINT [FK_OrdenPlatos_Ordenes] FOREIGN KEY([IdOrden])
REFERENCES [dbo].[Ordenes] ([Id])
GO

ALTER TABLE [dbo].[OrdenPlatos] CHECK CONSTRAINT [FK_OrdenPlatos_Ordenes]
GO

ALTER TABLE [dbo].[OrdenPlatos]  WITH CHECK ADD  CONSTRAINT [FK_OrdenPlatos_Platos] FOREIGN KEY([IdPlato])
REFERENCES [dbo].[Platos] ([Id])
GO

ALTER TABLE [dbo].[OrdenPlatos] CHECK CONSTRAINT [FK_OrdenPlatos_Platos]
GO



