/****** Object:  Database [dbGestionSilabos]    Script Date: 24/11/2021 13:04:32 ******/

/****** Object:  Table [dbo].[TCurso]    Script Date: 24/11/2021 13:04:32 ******/

--drop table TCurso ------------------------------------------------------------------------------------------------
IF EXISTS (SELECT *  FROM SYSOBJECTS WHERE NAME = 'TCurso')
	DROP TABLE TCurso
GO
CREATE TABLE [dbo].[TCurso](
	[CodCurso] [varchar](10) NOT NULL PRIMARY KEY,
	[Nombre] [varchar](100) NOT NULL,
	[Creditos] [int] NOT NULL,
	[Categoria] [varchar](10) NULL,
)
GO
/****** Object:  Table [dbo].[TRegimen]    Script Date: 24/11/2021 13:04:32 ******/

--drop table TRegimen ------------------------------------------------------------------------------------------------
IF EXISTS (SELECT *  FROM SYSOBJECTS WHERE NAME = 'TRegimen')
	DROP TABLE TRegimen
GO
CREATE TABLE [dbo].[TRegimen](
	[CodRegimen] [varchar](6) NOT NULL PRIMARY KEY,
	[NroHoras] [int] NULL,
)
GO
/****** Object:  Table [dbo].[TDocente]    Script Date: 24/11/2021 13:04:32 ******/

--drop table TDocente ------------------------------------------------------------------------------------------------
IF EXISTS (SELECT *  FROM SYSOBJECTS WHERE NAME = 'TDocente')
	DROP TABLE TDocente
GO
CREATE TABLE [dbo].[TDocente](
	[CodDocente] [varchar](6) PRIMARY KEY,
	[Paterno] [varchar](30) NULL,
	[Materno] [varchar](30) NULL,
	[Nombres] [varchar](100) NOT NULL,
	[Regimen] [varchar](6) FOREIGN KEY REFERENCES TRegimen(CodRegimen),
	[Correo] [varchar](30) NULL,
	[Telefono] [varchar](20) NULL,
)
GO

/****** Object:  Table [dbo].[TUsuarios]    Script Date: 24/11/2021 13:04:32 ******/

--drop table TUsuarios ------------------------------------------------------------------------------------------------
IF EXISTS (SELECT *  FROM SYSOBJECTS WHERE NAME = 'TUsuarios')
	DROP TABLE TUsuarios
GO
CREATE TABLE [dbo].[TUsuarios](
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CodDocente] [varchar](6) NOT NULL FOREIGN KEY REFERENCES TDOCENTE(CodDocente),
	[Usuario] [varchar](20) NOT NULL,
	[Contraseña] [varchar](25) NOT NULL,
	[Acceso] [varchar](25) NULL,
)
GO
/****** Object:  Table [dbo].[TSemestre]    Script Date: 24/11/2021 13:04:32 ******/

--drop table TSemestre ------------------------------------------------------------------------------------------------
IF EXISTS (SELECT *  FROM SYSOBJECTS WHERE NAME = 'TSemestre')
	DROP TABLE TSemestre
GO
CREATE TABLE [dbo].[TSemestre](
	[Semestre] [varchar](10) PRIMARY KEY,
	[Fecha_inicio] [DATE] NOT NULL,
	[Fecha_fin] [DATE] NOT NULL,
)
GO

/****** Object:  Table [dbo].[TAsignacion]    Script Date: 24/11/2021 13:04:32 ******/

/*--drop table TAsignacion
CREATE TABLE [dbo].[TAsignacion](
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Semestre] [varchar](10) NOT NULL FOREIGN KEY REFERENCES TSemestre(Semestre),
	[CodDocente] [varchar](6) NOT NULL FOREIGN KEY REFERENCES TDocente(CodDocente),
	[CodCurso] [varchar](10) NOT NULL FOREIGN KEY REFERENCES TCurso(CodCurso),
	[Tipo] [varchar](2) NOT NULL,
	[Grupo] [varchar](2) NOT NULL,
	[HT] [int] NOT NULL,
	[HP] [int] NOT NULL,
	[Dia] [varchar](15) NOT NULL,
	[HR_inicio] [int] NOT NULL,
	[HR_fin] [int] NOT NULL,
	[Aula] [varchar](15) NOT NULL,
)
GO*/
--drop table TAsignacion ------------------------------------------------------------------------------------------------
IF EXISTS (SELECT *  FROM SYSOBJECTS WHERE NAME = 'TAsignacion')
	DROP TABLE TAsignacion
GO
CREATE TABLE [dbo].[TAsignacion](
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Semestre] [varchar](10) NOT NULL FOREIGN KEY REFERENCES TSemestre(Semestre),
	[CodDocente] [varchar](6) NOT NULL FOREIGN KEY REFERENCES TDocente(CodDocente),
	[CodCurso] [varchar](10) NOT NULL FOREIGN KEY REFERENCES TCurso(CodCurso),
	[Grupo] [varchar](2) NOT NULL,
	[Aula] [varchar](15) NOT NULL,
	[Carrera] [varchar](200) NOT NULL
)
GO
 
--drop table TDia ------------------------------------------------------------------------------------------------
IF EXISTS (SELECT *  FROM SYSOBJECTS WHERE NAME = 'TDia')
	DROP TABLE TDia
GO
CREATE TABLE [dbo].[TDia](
	[ID] [int] IDENTITY(1,1) not null  primary key,
	[Asignacion] [int] not null foreign key references TAsignacion(ID),
	[Dia] [varchar](20) not null,
	[HR_inicio] [int] NOT NULL,
	[HR_fin] [int] NOT NULL,
	[Tipo] [varchar] not null,
)

--drop table TSilabo ------------------------------------------------------------------------------------------------
IF EXISTS (SELECT *  FROM SYSOBJECTS WHERE NAME = 'TSilabo')
	DROP TABLE TSilabo
GO
CREATE TABLE [dbo].[TSilabo](
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Asignacion] [int] NOT NULL FOREIGN KEY REFERENCES TAsignacion(ID),
	[Unidad] [varchar](100) NOT NULL,
	[Capitulo] [varchar](100) NOT NULL,
	[Tema] [varchar](100) NOT NULL,
	[NroHoras] [int] NOT NULL,
)
GO

--drop table TAlumno ------------------------------------------------------------------------------------------------
IF EXISTS (SELECT *  FROM SYSOBJECTS WHERE NAME = 'TAlumno')
	DROP TABLE TAlumno
GO
CREATE TABLE [dbo].[TAlumno](
	[CodAlumno] [varchar](6) NOT NULL PRIMARY KEY,
	[Nombres] [varchar](100) NOT NULL,
)
GO
--drop table TAlumnoCurso ------------------------------------------------------------------------------------------------
IF EXISTS (SELECT *  FROM SYSOBJECTS WHERE NAME = 'TAlumnoCurso')
	DROP TABLE TAlumnoCurso
GO
CREATE TABLE [dbo].[TAlumnoCurso](
	[Asignacion] [int] NOT NULL FOREIGN KEY REFERENCES TAsignacion(ID),
	[NRO] [int] NOT NULL,
	[CodAlumno] [varchar](6) NOT NULL FOREIGN KEY REFERENCES TAlumno(CodAlumno),
	PRIMARY KEY ([Asignacion], [CodAlumno])
)
GO

--drop table TRegistroAvance ------------------------------------------------------------------------------------------------
IF EXISTS (SELECT *  FROM SYSOBJECTS WHERE NAME = 'TRegistroAvance')
	DROP TABLE TRegistroAvance
GO
CREATE TABLE [dbo].[TRegistroAvance](
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ID_Silabo] [int] NOT NULL FOREIGN KEY REFERENCES TSilabo(ID),
	[Fecha] datetime NOT NULL,
	[Observacion] [varchar](200) NOT NULL,
)
GO

--drop table TAsistencia ------------------------------------------------------------------------------------------------
IF EXISTS (SELECT *  FROM SYSOBJECTS WHERE NAME = 'TAsistencia')
	DROP TABLE TAsistencia
GO
CREATE TABLE [dbo].[TAsistencia](
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ID_Registro] [int] NOT NULL FOREIGN KEY REFERENCES TRegistroAvance(ID),
	[CodAlumno] [varchar](6) NOT NULL FOREIGN KEY REFERENCES TAlumno(CodAlumno),
	[Asistio] [bit] NOT NULL,
)
GO

/****** Object:  Table [dbo].[TSilabo]    Script Date: 24/11/2021 13:04:32 ******/

/*--drop table TSilabo
CREATE TABLE [dbo].[TSilabo](
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Semestre] [varchar](10) NOT NULL FOREIGN KEY REFERENCES TSemestre(Semestre),
	[CodCurso] [varchar](10) NOT NULL FOREIGN KEY REFERENCES TCurso(CodCurso),
	[Unidad] [varchar](100) NOT NULL,
	[Capitulo] [varchar](100) NOT NULL,
	[Tema] [varchar](100) NOT NULL,
	[NroHoras] [int] NOT NULL,
)
GO*/
/********************* TRIGGERS *****************/
-- insertion docente
CREATE TRIGGER trDocenteInsercion
	ON TDocente
	FOR INSERT
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla INSERTED
	CREATE TABLE #INSERTED
	(
		[CodDocente] [varchar](6),
		[Paterno] [varchar](30),
		[Materno] [varchar](30),
		[Nombres] [varchar](100),
		[Regimen] [varchar](6),
		[Correo] [varchar](30),
		[Telefono] [varchar](20),
	);

	-- Copiar la tabla INSERTED en la tabla temporal #INSERTED
	INSERT INTO #INSERTED
		SELECT * 
			FROM INSERTED

	-- Determinar el numero de tuplas de la tabla #INSERTED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #INSERTED;

	-- Recorrer las tuplas de la tabla #INSERTED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estaran los atributos de la tabla #INSERTED
		DECLARE @CodDocente varchar (6);
		DECLARE @Paterno varchar (30);
		DECLARE @Materno varchar (30);
		DECLARE @Nombres varchar (100);
		DECLARE @Regimen varchar (6);
		DECLARE @Correo varchar (30);
		DECLARE @Telefono varchar (20);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodDocente = CodDocente,
			   @Paterno = Paterno,
			   @Materno = Materno,
			   @Nombres = Nombres,
			   @Regimen = Regimen,
			   @Correo = Correo,
			   @Telefono = Telefono
			FROM (SELECT TOP(1) * FROM #INSERTED) AS Insertado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #INSERTED
		INSERT TUsuarios (CodDocente, Usuario, Contraseña, Acceso) VALUES (@CodDocente,@CodDocente,@CodDocente,'Docente')
		
		-- Eliminar la tupla insertada de la tabla #INSERTED
		DELETE TOP (1) FROM #INSERTED

		-- Actualizar el numero de tuplas
		SELECT @NroTuplas = COUNT(*) FROM #INSERTED;
	END;
END;
GO
-- Delete Docente
CREATE TRIGGER trDocenteEliminacion
	ON TDocente
	FOR DELETE
AS
BEGIN
	-- Crear una tabla temporal para copiar la tabla DELETED
	CREATE TABLE #DELETED
	(
		[CodDocente] [varchar](6),
		[Paterno] [varchar](30),
		[Materno] [varchar](30),
		[Nombres] [varchar](100),
		[Regimen] [varchar](6),
		[Correo] [varchar](30),
		[Telefono] [varchar](20),
	);

	-- Copiar la tabla DELETED en la tabla temporal #DELETED
	INSERT INTO #DELETED
		SELECT * 
			FROM DELETED

	-- Determinar el numero de tuplas de la tabla #DELETED
	DECLARE @NroTuplas INT;
	SELECT @NroTuplas = COUNT(*) FROM #DELETED;

	-- Recorrer las tuplas de la tabla #DELETED
	WHILE @NroTuplas > 0
	BEGIN
		-- Declarar variables donde estaran los atributos de la tabla #DELETED
		DECLARE @CodDocente varchar (6);
		DECLARE @Paterno varchar (30);
		DECLARE @Materno varchar (30);
		DECLARE @Nombres varchar (100);
		DECLARE @Regimen varchar (6);
		DECLARE @Correo varchar (30);
		DECLARE @Telefono varchar (20);

		-- Recuperar los datos de una tupla en las variables declaradas
		SELECT @CodDocente = CodDocente,
			   @Paterno = Paterno,
			   @Materno = Materno,
			   @Nombres = Nombres,
			   @Regimen = Regimen,
			   @Correo = Correo,
			   @Telefono = Telefono
			FROM (SELECT TOP(1) * FROM #DELETED) AS Eliminado

		---- Determinar el IdHistorial
		--DECLARE @IdHistorial INT;
		--EXEC spuObtenerIdHistorial @IdHistorial OUTPUT;

		-- Insertar a la tabla Historial, la tupla insertada de la tabla #DELETED
		DELETE TUsuarios WHERE CodDocente = @CodDocente
		
		-- Eliminar la tupla insertada de la tabla #DELETED
		DELETE TOP (1) FROM #DELETED

		-- Actualizar el n�mero de las tuplas
		SELECT @NroTuplas = COUNT(*) FROM #DELETED;
	END;
END;
GO


INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF060', N'MUSICA', 2, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF063', N'QUECHUA', 2, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF107', N'PROGRAMACION DIGITAL I', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF109', N'PROGRAMACION DIGITAL II', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF167', N'PROGRAMACION CIENTIFICA', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF210', N'PLANEAMIENTO ESTRATEGICO', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF212', N'ANALISIS NUMERICO', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF391', N'SISTEMA DE BASE DE DATOS', 2, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF401', N'PROGRAMACION DIGITAL', 2, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF450', N'ABSTRACCION DE DATOS Y OBJETOS', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF451', N'PROGRAMACION I', 2, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF452', N'ALGORITMOS Y ESTRUCTURAS DE DATOS', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF453', N'PROGRAMACION II', 2, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF454', N'TEORIA DE LA COMPUTACION', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF455', N'ALGORITMOS PARALELOS Y DISTRIBUIDOS', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF456', N'ALGORITMOS AVANZADOS', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF457', N'METODOS NUMERICOS', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF458', N'COMPUTACION GRAFICA I', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF459', N'COMPUTACION GRAFICA II', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF466', N'COMPILADORES', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF467', N'ANALISIS Y DISEÑO DE ALGORITMOS', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF468', N'FUNDAMENTOS DE LA PROGRAMACION', 4, NULL)
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF470', N'LENGUAJE DE PROGRAMACION', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF480', N'ADMINISTRACION DE TECNOLOGÍAS DE LA INFORMACIÓN', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF481', N'INGENIERIA ECONOMICA', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF482', N'PLANEAMIENTO Y DIRECCION ESTRATEGICA DE TECNOLOGIA DE INFORMACION', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF483', N'FORMULACION DE PROYECTOS DE TECNOLOGIAS DE LA INFORMACION', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF484', N'EMPRENDIMIENTO E INNOVACION', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF550', N'ORGANIZACION Y ARQUITECTURA DEL COMPUTADOR', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF551', N'SISTEMAS OPERATIVOS', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF552', N'REDES DE COMPUTADORAS I', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF554', N'REDES DE COMPUTADORAS II', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF603', N'ROBOTICA Y PROCESAMIENTO DE SEÑAL', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF610', N'ANALISIS Y DISEÑO DE SISTEMAS DE INFORMACION', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF611', N'METODOLOGIA DE DESARROLLO DE SOFTWARE', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF612', N'FUNDAMENTOS Y DISEÑO DE BASE DE DATOS', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF613', N'DESARROLLO DE SOFTWARE I', 2, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF614', N'INGENIERIA DE SOFTWARE I', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF617', N'INGENIERIA DE SOFTWARE II', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF618', N'TOPICOS AVANZADOS EN INGENIERIA DE SOFTWARE', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF650', N'MODELOS PROBABILISTICOS', 4, N'OEES')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF651', N'INTELIGENCIA ARTIFICIAL', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF652', N'APRENDIZAJE AUTOMATICO', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF653', N'MINERIA DE DATOS', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF654', N'ROBOTICA', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF656', N'PROCESAMIENTO DE LENGUAJE NATURAL', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF657', N'VISION COMPUTACIONAL', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF658', N'REDES NEURONALES ARTIFICIALES', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF662', N'DEEP LEARNING', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF664', N'BIOINFORMATICA', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF669', N'MODELADO Y SIMULACION', 4, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF710', N'SEMINARIO DE INVESTIGACION I', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF711', N'SEMINARIO DE INVESTIGACION II', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF758', N'METODOS NUMERICOS', 3, N'')
GO
INSERT [dbo].[TCurso] ([CodCurso], [Nombre], [Creditos], [Categoria]) VALUES (N'IF902', N'TECNOLOGIAS DE LA INFORMACION Y LA COMUNICACION', 3, N'')
GO


INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'A1', 16)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'AS-DE', 10)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'AS-TC', 10)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'AS-TP', 10)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'AU-TC', 10)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'B1', 16)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'B2', 8)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'B3', 4)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'JP-10H', 8)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'JP-20H', 12)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'JP-40H', 14)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'JP10H', 8)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'JP20H', 12)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'JP40H', 14)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'no-re', 0)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'PR-DE', 10)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'PR-TC', 10)
GO
INSERT [dbo].[TRegimen] ([CodRegimen], [NroHoras]) VALUES (N'PR-TP', 10)
GO



--Docente
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'716753', N'ACURIO', N'USCA', N'NILA ZONIA', N'PR-DE', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'553642', N'ROZAS', N'HUACHO', N'JAVIER ARTURO', N'PR-DE', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'746199', N'FLORES', N'PACHECO', N'LINO PRISCILIANO', N'PR-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'737719', N'CARRASCO', N'POBLETE', N'EDWIN', N'PR-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'984424', N'PALOMINO', N'OLIVERA', N'EMILIO', N'PR-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'320665', N'GAMARRA', N'SALDIVAR', N'ENRIQUE', N'PR-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'123676', N'TICONA', N'PARI', N'GUZMÁN', N'AS-DE', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'185297', N'ORMEÑO', N'AYALA', N'YESHICA ISELA', N'AS-DE', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'465559', N'MEDRANO', N'VALENCIA', N'IVÁN CESAR', N'AS-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'699192', N'PALMA', N'TTITO', N'LUIS BELTRÁN', N'AS-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'594458', N'ALZAMORA', N'PAREDES', N'ROBERT WILBERT', N'AS-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'647272', N'CANDIA', N'OVIEDO', N'DENNIS IVÁN', N'AS-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'780342', N'VILLAFUERTE', N'SERNA', N'RONY', N'AS-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'114617', N'IBARRA', N'ZAMBRANO', N'WALDO ELIO', N'AS-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'765125', N'CHÁVEZ', N'CENTENO', N'JAVIER DAVID', N'AS-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'413599', N'MEDINA', N'MIRANDA', N'KARELIA', N'AS-TP', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'958746', N'PEÑALOZA', N'FIGUEROA', N'MANUEL AURELIO', N'AS-TP', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'605030', N'PILLCO', N'QUISPE', N'JOSÉ MAURO', N'AU-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'334171', N'BACA', N'CARDENAS', N'LINO AQUILES', N'AU-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'704404', N'PACHECO', N'VÁSQUEZ', N'ESTHER CRISTINA', N'AU-TC', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'543379', N'CHULLO', N'LLAVE', N'BORIS', N'A1', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'691376', N'QUINTANILLA', N'PORTUGAL', N'ROXANA LISETTE', N'A1', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'754279', N'CUTIPA', N'ARAPA', N'EFRAINA GLADYS', N'B1', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'535879', N'SEGUNDO', N'CARPIO', N'LISETH URPY', N'B1', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'854187', N'QUISPE', N'ONOFRE', N'CARLOS RAMÓN', N'B1', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'734138', N'IRPANOCA', N'CUSIMAYTA', N'MARITZA KATHERINE', N'B1', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'542493', N'ZAMALLOA', N'PARO', N'WILLIAN', N'B1', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'250497', N'VENEGAS', N'VERGARA', N'MARÍA DEL PILAR', N'B1', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'359310', N'SOSA', N'JAUREGUI', N'VÍCTOR DARIO', N'B1', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'637223', N'UGARTE', N'ROJAS', N'HÉCTOR EDUARDO', N'B1', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'359087', N'CUSIHUAMAN', N'PHOCCO', N'ROGER MARIO', N'B1', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'959941', N'DUEÑAS', N'DE LA CRUZ', N'HENRY SAMUEL', N'B2', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'804510', N'CHOQUE', N'SOTO', N'VANESSA MARIBEL', N'B2', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'664065', N'CHÁVEZ', N'ESPINOZA', N'WILLIAM ALBERTO', N'B2', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'517073', N'QUISPE', N'SOTA', N'JULIO VLADIMIR', N'B2', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'355018', N'VILLALBA', N'VILLALBA', N'TANY', N'B3', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'184245', N'AGUIRRE', N'CARBAJAL', N'DORIS SABINA', N'B3', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'976528', N'FALCÓN', N'HUALLPA', N'ÉLIDA', N'B2', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'479091', N'DUEÑAS', N'BUSTINZA', N'DARIO FRANCISCO', N'B2', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'179903', N'MONZÓN', N'CONDORI', N'LUIS ALVARO', N'B3', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'230593', N'GAMARRAS', N'SALAS', N'JISBAJ', N'B3', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'750534', N'MONTOYA', N'CUBAS', N'CARLOS FERNANDO', N'B2', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'216139', N'VERA', N'OLIVERA', N'HARLEY', N'B3', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'153047', N'DUEÑAS', N'JIMÉNEZ', N'RAY', N'B1', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'456243', N'HUANCAHUIRE', N'BRAVO', N'CLAUDIO ISAIAS', N'B1', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'648948', N'RODRÍGUEZ', N'AYLLONE', N'AVELUZ', N'JP-40H', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'515898', N'LAVILLA', N'ALVAREZ', N'VANESA', N'JP-10H', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'643483', N'VILLENA', N'LEON', N'OLMER CLAUDIO', N'JP-10H', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'108757', N'ÁLVAREZ', N'MAMANI', N'EDWIN', N'JP-10H', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'370754', N'ABARCA', N'MORA', N'RAIMAR', N'JP-10H', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'951890', N'ALAGÓN', N'MARTÍNEZ', N'WUILLIAN', N'JP-10H', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'119815', N'ZÚÑIGA', N'ROJAS', N'GABRIELA', N'JP-20H', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'274225', N'MERMA', N'QUISPE', N'MARCIO FERNANDO', N'JP-20H', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'970531', N'DIAZ', N'CACERES', N'LISHA SABAH', N'JP-10H', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'913460', N'ENCISO', N'RODAS', N'LAURO', N'PR-DE', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'499417', N'CARBAJAL', N'LUNA', N'JULIO CESAR', N'PR-DE', N'', N'')
INSERT TDocente ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'140156', N'HUAMAN', N'MENDOZA', N'JOHAN WILFREDO', N'PR-DE', N'140156@unsaac.edu.pe', N'')
go
--select * from TUsuarios


--INSERT [dbo].[TDocente] ([CodDocente], [Paterno], [Materno], [Nombres], [Regimen], [Correo], [Telefono]) VALUES (N'000000', N'', N'', N'docente', N'PR-DE', N'', N'')
--GO
--INSERT [dbo].[TUsuarios] ([CodDocente], [Usuario], [Contraseña], [Acceso]) VALUES (N'000000', N'docente', N'docente', N'Docente')
--GO
INSERT [dbo].[TUsuarios] ([CodDocente], [Usuario], [Contraseña], [Acceso]) VALUES (N'716753', N'administrador', N'administrador', N'Administrador')
GO

INSERT [dbo].[TSemestre] ([Semestre], [Fecha_inicio], [Fecha_fin]) VALUES ('2021-I', CONVERT(DATE,'31-5-2021',105), CONVERT(DATE,'27-9-2021',105))
INSERT [dbo].[TSemestre] ([Semestre], [Fecha_inicio], [Fecha_fin]) VALUES ('2021-II', CONVERT(DATE,'18-10-2021',105), CONVERT(DATE,'14-2-2022',105))
GO
