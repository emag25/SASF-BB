--create database tienda
--drop database tienda

USE [tienda]
GO


CREATE TABLE [fabricantes](
	[idFabricante] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[nombre] varchar(100) NOT NULL
)

CREATE TABLE [productos](
	[idProducto] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[nombre] varchar(100) NOT NULL,
	[precio] float NOT NULL,
	[idFabricante] int FOREIGN KEY (idFabricante) REFERENCES [fabricantes]([idFabricante])
)

INSERT INTO fabricantes (nombre)
VALUES ('Asus'),
       ('Lenovo'),
       ('Hewlett-Packard'),
       ('Samsung'),
       ('Seagate'),
       ('Crucial'),
       ('Gigabyte'),
       ('Huawei'),
       ('Xiaomi');

INSERT INTO productos (nombre, precio, idFabricante)
VALUES ('Disco duro SATA3 1TB', 86.99, 5),
       ('Memoria RAM DDR4 8GB', 120, 6),
       ('Disco SSD 1 TB', 150.99, 4),
       ('GeForce GTX 1050Ti', 185, 7),
       ('GeForce GTX 1080 Xtreme', 755, 6),
       ('Monitor 24 LED Full HD', 202, 1),
       ('Monitor 27 LED Full HD', 245.99, 1),
       ('Portátil Yoga 520', 559, 2),
       ('Portátil Ideapd 320', 444, 2),
       ('Impresora HP Deskjet 3720', 59.99, 3),
       ('Impresora HP Laserjet Pro M26nw', 180, 3);


