/*
Creacion de tablas
*/
---------------------------------------------------------------------------------------
----------------------- Tabla para Docentes--------------------------------------------
---------------------------------------------------------------------------------------
create table TDocente
( -- lista de atributos
    CodDocente         varchar (6),
    Paterno             Varchar(30)       not null,
    Materno             Varchar(30)       not null,
    Nombres             Varchar(30)       not null,
    Departamento         varchar(30)      not null,
	Condicion			varchar(20)   check (Condicion in ('NOMBRADO','CONTRATADO')),
    Correo				varchar(30)		not null,
	Telefono	        varchar(20),
-- definicion de la clave principal 
Primary key (CodDocente)
)
Go
---------------------------------------------------------------------------------------
----------------------- Tabla para Curso-----------------------------------------------
---------------------------------------------------------------------------------------
create table TCurso
( -- lista de atributos
    CodCurso            varchar (10),
    Nombre              Varchar(100)       not null,
    CodDocente          VARCHAR(10)		   not null,
	Creditos            INT				   not null,
	Categoria           VARCHAR(10),
-- definicion de la clave principal 
Primary key (CodCurso)
foreign key(CodDocente) references TDocente(CodDocente)
)
Go

/*
Creacion de Funciones
*/


/*
Creacion de Procedimientos
*/

/**** Tabla Docente ****/

/**** Tabla Curso ****/
-- Crear Curso
CREATE PROCEDURE spuCreateCurso @CodCurso VARCHAR(10),
                                @Nombre VARCHAR(100),
                                @CodDocente  VARCHAR(10),
                                @Creditos INT,
                                @Categoria VARCHAR(10)
AS
BEGIN
    -- Insertar un curso en la tabla TCurso
    INSERT INTO TCurso
        VALUES (@CodCurso, @Nombre, @CodDocente, @Creditos, @Categoria)
END;
GO
-- Leer Curso
CREATE PROCEDURE spuReadCurso @Busqueda VARCHAR(100)
AS
BEGIN
    -- Buscar por codigo o nombre
    SELECT * FROM TCURSO
    WHERE CodCurso LIKE @Busqueda OR
        Nombre LIKE @Busqueda
END;
GO
-- Actualizar Curso
CREATE PROCEDURE spuUpdateCurso @CodCurso VARCHAR(10),
                                @Nombre VARCHAR(100),
                                @CodDocente VARCHAR(10),
                                @Creditos INT,
                                @Categoria VARCHAR(10)
AS
BEGIN
    -- Actualizar curso po CodCurso
    UPDATE TCurso
        SET Nombre = @Nombre, CodDocente = @CodDocente, 
            Creditos = @Creditos, Categoria = @Categoria
        WHERE CodCurso = @CodCurso
END;
GO
-- Eliminar curso
CREATE PROCEDURE spuDeleteCurso @CodCurso VARCHAR(10)
AS
BEGIN
    -- Elminar curso por CodCurso
    DELETE FROM TCurso
        WHERE CodCurso = @CodCurso
END;
GO
/*
Creacion de Triggers
*/


