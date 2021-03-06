USE [Manufactura]
GO
/****** Object:  Table [dbo].[MateriaPrima]    Script Date: 24/05/2022 01:24:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MateriaPrima](
	[IdMateriaPrima] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Precio] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMateriaPrima] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 24/05/2022 01:24:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [varchar](100) NULL,
	[Precio] [money] NULL,
	[IdMateriaPrima] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MateriaPrima] ON 

INSERT [dbo].[MateriaPrima] ([IdMateriaPrima], [Nombre], [Precio]) VALUES (1, N'Seda', 150.0000)
INSERT [dbo].[MateriaPrima] ([IdMateriaPrima], [Nombre], [Precio]) VALUES (2, N'Leche', 150.0000)
INSERT [dbo].[MateriaPrima] ([IdMateriaPrima], [Nombre], [Precio]) VALUES (3, N'Agua', 15.0000)
INSERT [dbo].[MateriaPrima] ([IdMateriaPrima], [Nombre], [Precio]) VALUES (4, N'Hierro', 25.0000)
INSERT [dbo].[MateriaPrima] ([IdMateriaPrima], [Nombre], [Precio]) VALUES (5, N'Madera', 35.0000)
SET IDENTITY_INSERT [dbo].[MateriaPrima] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [Precio], [IdMateriaPrima]) VALUES (1, N'Playera', N'Playera de Seda morada', 560.0000, 1)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [Precio], [IdMateriaPrima]) VALUES (2, N'Yogurt', N'Natural', 5.0000, 2)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [Precio], [IdMateriaPrima]) VALUES (3, N'Gelatina', N'Gelatina con sabor uva', 7.0000, 3)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [Precio], [IdMateriaPrima]) VALUES (4, N'Estante', N'Estante para libros pesados', 450.0000, 4)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [Precio], [IdMateriaPrima]) VALUES (5, N'Escritorio', N'Escritorio de estancia', 4500.0000, 5)
INSERT [dbo].[Producto] ([IdProducto], [Nombre], [Descripcion], [Precio], [IdMateriaPrima]) VALUES (6, N'Leche', N'Sabor Chocolate', 30.0000, 2)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([IdMateriaPrima])
REFERENCES [dbo].[MateriaPrima] ([IdMateriaPrima])
GO
