CREATE DATABASE LibrosDb
GO
USE LibrosDb
GO

CREATE TABLE Libros
(
	Id int primary key identity,
	Descripcion Varchar(max),
	Siglas Varchar(15),
	TipoId int
	
);

select *from Libros