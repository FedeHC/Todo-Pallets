USE [TodoPallets]
GO
/****** Object:  Table [dbo].[TablaProductos]    Script Date: 21/09/2015 03:31:59 a.m. ******/
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
/****** Object:  Table [dbo].[TablaProyectos]    Script Date: 21/09/2015 03:31:59 a.m. ******/
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
INSERT [dbo].[TablaProductos] ([id], [nombreProducto], [fecha], [precio], [descripcionProducto], [visitas], [puntaje]) VALUES (1, N'Sillón de 2 cuerpos', CAST(N'2015-10-10' AS Date), 3000, N'Este hermoso sillón de 2 cuerpos, con respaldo y mesa incluída, está en su mayor parte hecha de pallets enteros seleccionados. Lo hemos adornado con un hermoso juego de 6 pequeños almohadones y 2 grandes, además del generoso colchón de 2 plazas. Este puede doblarse sin problemas, tal como se observa en las fotos, así como también puede estirarse para acostarse. ¡No se pierda esta oportunidad de comprarse este hermoso sillón a un precio increíble!  ', 3456, 4.5)
INSERT [dbo].[TablaProductos] ([id], [nombreProducto], [fecha], [precio], [descripcionProducto], [visitas], [puntaje]) VALUES (2, N'Macetero Cúbico', CAST(N'2015-09-07' AS Date), 500, N'¿Acaso nunca hace falta uno? Lo bien que nos viene un macetero generoso en casa! Bueno, ahora puede comprar uno a un buen precio. Con este macetero ud. puede plantar prácticamente cualquier plata o arbusto en cualquier lugar de su casa, incluso para exteriores. No deje pasar la oportunidad, lleve ud. este enorme macetero a este módico precio y no se va a arrepentir en lo absoluto!', 1809, 4.4)
INSERT [dbo].[TablaProductos] ([id], [nombreProducto], [fecha], [precio], [descripcionProducto], [visitas], [puntaje]) VALUES (3, N'Mesa rectangular vintage', CAST(N'2015-08-13' AS Date), 1800, N'Siempre hace falta una. Y siempre queremos algo lindo, algo que combine en nuestro comedor. Y esta mesa rectangular vintage de 1,80m x 1,40m puede ser la solución que andabas buscando. Realizado con decenas de maderas en su superficie, esta mesa va a brindarle una clásica y acojedora sensación que no puede fallar ni faltar en ningún hogar.  Y seguramente a su familia le va a encantar demasiado!', 2267, 4.4)
INSERT [dbo].[TablaProductos] ([id], [nombreProducto], [fecha], [precio], [descripcionProducto], [visitas], [puntaje]) VALUES (4, N'Mesa ratona con ruedas', CAST(N'2015-08-29' AS Date), 1200, N'Alta mesa ratona! Y con ruedas encima!  Y encima hermosa ¿Se puede pedir algo más? Bueno, si se puede: que sea útil y económica. Ideal para adornar, ideal para utilizar como mesa auxiliar, ideal para cualquier cosa que se te ocurra. Esta mesita ratona podrá parecerse a muchos proyectos que habrás visto, pero ninguno en alma se le compara. Compralo ya!', 1451, 4.3)
INSERT [dbo].[TablaProductos] ([id], [nombreProducto], [fecha], [precio], [descripcionProducto], [visitas], [puntaje]) VALUES (5, N'Mesa con dos entantes', CAST(N'2015-09-30' AS Date), 2200, N'Wow, nada mal! Con esta mesa de doble estantería incorporada vas a tener lugar de sobra para apoyar tus cosas habituales del hogar, además de contar finalmente con un espacio amplio para utilizar como mesa o mueble expositor. Creemos que esta doble función la hace enormemente práctica, así que si andabas buscando por separados ambas cosas entonces acabas de encontrar tu 2-en-1. Ni lo dudes, compralo e instalalo en tu casa cuanto antes!', 2787, 4.3)
INSERT [dbo].[TablaProductos] ([id], [nombreProducto], [fecha], [precio], [descripcionProducto], [visitas], [puntaje]) VALUES (6, N'Mesa de taller', CAST(N'2015-07-25' AS Date), 1500, N'Era hora de que alguien pensara en nuestro tallercito hogareño. Con esta mesa de doble estantería vas a tener lugar de sobra para guardar todas tus herramientas de trabajo, amén de contar con una superficie amplia para trabajar tranquilo con estas últimas. Hasta incluso la podes usar a modo de escritorio, si te parece mejor opción: el último piso puede usarse para apoyar los pies sin problemas. Una ganga, realmente.', 2145, 4.3)
INSERT [dbo].[TablaProductos] ([id], [nombreProducto], [fecha], [precio], [descripcionProducto], [visitas], [puntaje]) VALUES (7, N'Mesa con piso', CAST(N'2015-09-01' AS Date), 1600, N'Una nueva adición a nuestro top10 de productos: la mesa rectangular con piso bajo incorporado. Si con esta mesa no te ganas la simpatía de tus comensales entonces no lo vas a lograr de ninguna otra forma! Ideal para el exterior, la mesa te permite una nada despreciable superficie para usarla como mesa auxiliar para esos platos que ocupan lugar, o ensaladeras, postres, bebias, copas, paneras o demás cosas que no queres que te quiten lugar en tu mesa principal.', 1997, 4.3)
INSERT [dbo].[TablaProductos] ([id], [nombreProducto], [fecha], [precio], [descripcionProducto], [visitas], [puntaje]) VALUES (8, N'Alacena rectangular chica', CAST(N'2015-06-29' AS Date), 1400, N'Más para nuestra cocina o quincho! La nueva alacena pequeña que andaba pidiendo muchos en nuestra web ahora ya se ha materializado en nuestro top 10 de mejores productos. Con este mueble vas a poder guardar tus copas o aquellas cosas a los que queres reservarle su lugarcito exclusivo. Si andabas buscando una la encontraste, no lo dudes en adquirir: esta hecha para durar.', 2933, 4.3)
INSERT [dbo].[TablaProductos] ([id], [nombreProducto], [fecha], [precio], [descripcionProducto], [visitas], [puntaje]) VALUES (9, N'Portavinos elegante', CAST(N'2015-08-19' AS Date), 900, N'Por fin un portavinos! ¿Porque no se nos habia ocurrido incorporar uno acá? Con lo útil que es tener uno en casa, sea para nuestras propias selecciones de vinos más queridos o también incluso para emplear a modo de decoración en algún rinconcito. De seguro no te va a ocupar mucho lugar y vas a tener para unos cuantos vinitos!', 1305, 4.2)
INSERT [dbo].[TablaProductos] ([id], [nombreProducto], [fecha], [precio], [descripcionProducto], [visitas], [puntaje]) VALUES (10, N'Cama de 2 plazas', CAST(N'2015-07-09' AS Date), 1850, N'¿Asi que querian una cama? He aquí una cama. Y una de dos plazas, nada menos. Porque con esta cama van a poder acostarse los dos con toda la comodidad, ya que esta hecha para colchones tamaño king o queen size. ¿Queda algo más para decir? Ah, si! Es re económica, y re duradera: está hecha con maderas seleccionadas y su construcción fue reforzada para durar décadas. Esta cama está hecha para no dejarnos excusas, comprala ya!', 3149, 4.2)
INSERT [dbo].[TablaProyectos] ([id], [nombreProyecto], [autor], [fecha], [descripcionProyecto], [visitas], [puntaje]) VALUES (1, N'Mi baulera grandota', N'Pablo T.', CAST(N'2015-09-02' AS Date), N'Queria largar con algo ya! No veía la hora de hacer una baulera para todas las cosas que tengo dando vueltas en casa. Por fin pude juntar los materiales y construirme una con mis propias herramientas y mis magros conocimientos de carpinteria. Al final a mi mujer le encantó, y a mi me re sirvió!', 980, 4.5)
INSERT [dbo].[TablaProyectos] ([id], [nombreProyecto], [autor], [fecha], [descripcionProyecto], [visitas], [puntaje]) VALUES (2, N'El mini-macetero alargado', N'Mariano C.', CAST(N'2015-10-09' AS Date), N'¿Vale la pena hacer un macetero para nuestras plantitas chiquitas que tenemos dando vueltas por casa? Yo creo que si, y por eso me puse manos a la obra para hacerlo. Total, no necesité grandes conocimientos y tampoco me llevó demasiado tiempo. Con un poco de maña todo se puede (y cómo!).', 798, 4.4)
INSERT [dbo].[TablaProyectos] ([id], [nombreProyecto], [autor], [fecha], [descripcionProyecto], [visitas], [puntaje]) VALUES (3, N'El percherito estantero', N'Laura C.', CAST(N'2015-10-18' AS Date), N'Bueno, yo no tengo mucha experiencia con esto de hacer muebles o cosas de palletas, pero queria intentar con algo ya que se algo de diseño de interiores. Así que fui con algo sencillo: este mini-percherito, como le digo yo. Con esto ahora puedo colgar mis cositas en la entrada de casa y no tener que dejarlas tiradas por ahí.', 834, 4.2)
INSERT [dbo].[TablaProyectos] ([id], [nombreProyecto], [autor], [fecha], [descripcionProyecto], [visitas], [puntaje]) VALUES (4, N'La baulera pintada', N'Mariana G.', CAST(N'2015-11-22' AS Date), N'Para mi bebota de 6 años, que andaba necesitando guardar muñecas viejas y algo grandes para dejarlas en cualquier parte de su cuarto. Ahora ya tienen un bonito lugar para guardarlas todas, y seguramente estarán a buen resguardo por mucho tiempo.', 610, 4.1)
INSERT [dbo].[TablaProyectos] ([id], [nombreProyecto], [autor], [fecha], [descripcionProyecto], [visitas], [puntaje]) VALUES (5, N'Estanteria de pallets', N'Ariel A.', CAST(N'2015-08-19' AS Date), N'Tenia unos pallets en perfecto estado y queria hacer algo. Entonces después de pensarlo un buen rato se me ocurrió hacer una estantería para mis fotos y de paso para que mi señora lo adornarse con otras cositas. Y esto quedó. ¿No les parece genial?', 509, 4)
INSERT [dbo].[TablaProyectos] ([id], [nombreProyecto], [autor], [fecha], [descripcionProyecto], [visitas], [puntaje]) VALUES (6, N'Tablero hecho con pallets', N'Mariana y Jorge F.', CAST(N'2015-07-23' AS Date), N'Mi marido y yo andábamos necesitando un tablero chico para colgar herramientas y demás cosas relacionadas con nuestro tallercito. Entonces buscamos unos pallets que teniamos por ahí y en un fin de semana armamos esto. Creo que quedó genial y encima nos va a resultar re útil!', 421, 4)
INSERT [dbo].[TablaProyectos] ([id], [nombreProyecto], [autor], [fecha], [descripcionProyecto], [visitas], [puntaje]) VALUES (7, N'El piso de pallets para exterior', N'Eduardo Z.', CAST(N'2015-07-06' AS Date), N'Ultimamente andaba con la idea fija de restaurar un poco mi pequeño patio de atrás. Entonces como recordé que tenía unos cuantos pallets en lo de mi hermano, decidí usarlos para crear un piso de estos y darle una apariencia más linda al patio. Al final me llevó bastante más de lo que pensaba, pero estoy muy conforme.', 376, 3.9)
INSERT [dbo].[TablaProyectos] ([id], [nombreProyecto], [autor], [fecha], [descripcionProyecto], [visitas], [puntaje]) VALUES (8, N'Mini-mesa paqueta', N'Carlos B.', CAST(N'2015-08-29' AS Date), N'Mi señora andaba queriendo comprar una mesita chiquita para adornar un poco el comedor, pero todo lo que veía le resultaba caro. Entonces le dije que no tenía problemas en hacerle uno, siempre y cuando después ella lo adornara un poco. Y al final logré esto que uds. ven en las fotos. Tanto ella como yo estamos satisfechos', 309, 3.8)
INSERT [dbo].[TablaProyectos] ([id], [nombreProyecto], [autor], [fecha], [descripcionProyecto], [visitas], [puntaje]) VALUES (9, N'Escritorio para la mac', N'Juan A.', CAST(N'2015-10-01' AS Date), N'El otro dia encontre un montón de pallets cerca de mi casa, y justo recordé que uno de mis hijos andaba necesitando un escritorio para su nueva mac. Entonces pensé ¿porqué no fabricar una nosotros mismos? Y en un finde lo hicimos: elegimos uno lindo, conseguimos cuatro tirantes gruesos, y al final nos salió este bonito escritorio.', 301, 3.7)
INSERT [dbo].[TablaProyectos] ([id], [nombreProyecto], [autor], [fecha], [descripcionProyecto], [visitas], [puntaje]) VALUES (10, N'Baulera y mesita pintada', N'Alicia N.', CAST(N'2015-07-01' AS Date), N'Estaba pensando el otro día que necesitaba una baulera para mis viejas cosas. Pero como no tengo mucho lugar en el dpto, entonces pensé que también tenía que ser a su vez una mesa para apoyar cosas, así se justificaba más. Y con ayuda de mi familia pudimos construir y pintar este hermoso mueble, tal como lo ven.', 289, 3.7)
