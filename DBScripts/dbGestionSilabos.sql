/*
Creacion de tablas
*/


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


