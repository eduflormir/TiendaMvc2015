/****** Object:  Table [dbo].[Almacen]    Script Date: 06/11/2015 10:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacen](
	[id_almacen] [int] IDENTITY(1,1) NOT NULL,
	[ciudad] [nvarchar](250) NOT NULL,
	[codigo_postal] [int] NOT NULL,
 CONSTRAINT [PK_Almacen] PRIMARY KEY CLUSTERED 
(
	[id_almacen] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Almacen_Producto]    Script Date: 06/11/2015 10:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacen_Producto](
	[id_almacen] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[existencias] [int] NOT NULL,
 CONSTRAINT [PK_Almacen_Producto] PRIMARY KEY CLUSTERED 
(
	[id_almacen] ASC,
	[id_producto] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 06/11/2015 10:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Etiqueta]    Script Date: 06/11/2015 10:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etiqueta](
	[id_etiqueta] [int] IDENTITY(1,1) NOT NULL,
	[texto] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Etiqueta] PRIMARY KEY CLUSTERED 
(
	[id_etiqueta] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 06/11/2015 10:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[fabricante_nombre] [nvarchar](250) NOT NULL,
	[descripcion_corta] [nvarchar](150) NOT NULL,
	[precio_coste] [decimal](18, 0) NOT NULL,
	[precio_venta] [decimal](18, 0) NOT NULL,
	[id_categoria] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Producto_Etiqueta]    Script Date: 06/11/2015 10:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto_Etiqueta](
	[id_producto] [int] NOT NULL,
	[id_etiqueta] [int] NOT NULL,
 CONSTRAINT [PK_Producto_Etiqueta] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC,
	[id_etiqueta] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
ALTER TABLE [dbo].[Almacen_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Almacen_Producto_Almacen] FOREIGN KEY([id_almacen])
REFERENCES [dbo].[Almacen] ([id_almacen])
GO
ALTER TABLE [dbo].[Almacen_Producto] CHECK CONSTRAINT [FK_Almacen_Producto_Almacen]
GO
ALTER TABLE [dbo].[Almacen_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Almacen_Producto_Producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Producto] ([id_producto])
GO
ALTER TABLE [dbo].[Almacen_Producto] CHECK CONSTRAINT [FK_Almacen_Producto_Producto]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([id_categoria])
REFERENCES [dbo].[Categoria] ([id_categoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Producto_Etiqueta]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Etiqueta_Etiqueta] FOREIGN KEY([id_etiqueta])
REFERENCES [dbo].[Etiqueta] ([id_etiqueta])
GO
ALTER TABLE [dbo].[Producto_Etiqueta] CHECK CONSTRAINT [FK_Producto_Etiqueta_Etiqueta]
GO
ALTER TABLE [dbo].[Producto_Etiqueta]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Etiqueta_Producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Producto] ([id_producto])
GO
ALTER TABLE [dbo].[Producto_Etiqueta] CHECK CONSTRAINT [FK_Producto_Etiqueta_Producto]
GO
