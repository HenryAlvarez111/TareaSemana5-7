
go
CREATE PROCEDURE sp_ObtenerUsuarios
AS
BEGIN
    SELECT Usuarios.*, Roles.Detalle 
    FROM Roles 
    INNER JOIN Usuarios ON Roles.Rol_Id = Usuarios.Roles_id 
    WHERE Usuarios.Disponibilidad = 1
END

go
CREATE PROCEDURE sp_ObtenerUsuarioPorId
    @Id_User INT
AS
BEGIN
    SELECT Usuarios.*, Roles.Detalle 
    FROM Roles 
    INNER JOIN Usuarios ON Roles.Rol_Id = Usuarios.Roles_id 
    WHERE Usuarios.Disponibilidad = 1 AND Usuarios.Id_User = @Id_User
END
go

CREATE PROCEDURE sp_InsertarUsuario
    @Username NVARCHAR(50),
    @Password NVARCHAR(MAX),
    @Disponibilidad INT,
    @Roles_id INT
AS
BEGIN
    INSERT INTO Usuarios (Username, Password, Disponibilidad, Roles_id)
    VALUES (@Username, @Password, @Disponibilidad, @Roles_id)
END

go
CREATE PROCEDURE sp_ActualizarUsuario
    @Id_User INT,
    @Username NVARCHAR(50),
    @Password NVARCHAR(MAX),
    @Disponibilidad INT,
    @Roles_id INT
AS
BEGIN
    UPDATE Usuarios
    SET Username = @Username,
        Password = @Password,
        Disponibilidad = @Disponibilidad,
        Roles_id = @Roles_id
    WHERE Id_User = @Id_User
END
go
CREATE PROCEDURE sp_EliminarUsuario
    @Id_User INT
AS
BEGIN
    UPDATE Usuarios
    SET Disponibilidad = 0
    WHERE Id_User = @Id_User
END
go
CREATE PROCEDURE sp_ObtenerRoles
AS
BEGIN
    SELECT * FROM Roles
END

go
CREATE PROCEDURE sp_InsertarRol
    @Detalle NVARCHAR(50)
AS
BEGIN
    INSERT INTO Roles (Detalle)
    VALUES (@Detalle)
END

go
CREATE PROCEDURE sp_ActualizarRol
    @Rol_Id INT,
    @Detalle NVARCHAR(50)
AS
BEGIN
    UPDATE Roles
    SET Detalle = @Detalle
    WHERE Rol_Id = @Rol_Id
END

go
CREATE PROCEDURE sp_EliminarRol
    @Rol_Id INT
AS
BEGIN
    DELETE FROM Roles
    WHERE Rol_Id = @Rol_Id
END
go
CREATE PROCEDURE sp_ObtenerRolPorId
    @Rol_Id INT
AS
BEGIN
    SELECT Rol_Id, Detalle
    FROM Roles
    WHERE Rol_Id = @Rol_Id
END
go