-- Crea la base de datos si no existe
CREATE DATABASE Squadmakersdb;
USE Squadmakersdb;
CREATE TABLE usuarios (
  id INT IDENTITY(1,1) PRIMARY KEY, -- Usamos IDENTITY para la clave autoincremental
  nombre VARCHAR(255) NOT NULL,
  contrasena VARCHAR(255) NOT NULL
);

CREATE TABLE chistes (
  id INT IDENTITY(1,1) PRIMARY KEY, -- Usamos IDENTITY para la clave autoincremental
  titulo VARCHAR(255) NOT NULL,
  cuerpo TEXT NOT NULL,
  autor INT NOT NULL FOREIGN KEY REFERENCES usuarios(id),
  activo bit DEFAULT 1, 
  fecha_creacion DATETIME2 DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE tematicas (
  id INT IDENTITY(1,1) PRIMARY KEY, -- Usamos IDENTITY para la clave autoincremental
  nombre VARCHAR(255) NOT NULL
);

CREATE TABLE chistes_tematicas (
  chiste_id INT NOT NULL FOREIGN KEY REFERENCES chistes(id),
  tematica_id INT NOT NULL FOREIGN KEY REFERENCES tematicas(id),
  PRIMARY KEY (chiste_id, tematica_id)
);


INSERT INTO usuarios (nombre, contrasena) VALUES
('Juan', 'contrasena1'),
('Pedro', 'contrasena2'),
('Manolito', 'contrasena3'),
('María', 'contrasena4');

INSERT INTO tematicas (nombre) VALUES
('humor negro'),
('humor amarillo'),
('chistes verdes');

 INSERT INTO chistes(titulo,cuerpo,autor) VALUES
 ('Amarillo','Un nino le dice a otro nino gritando de color es tu coche y el otro le dice por que me gritas y el nino le contesta porque es amarillo chillon',1),
 ('Los chinos','¿Sabes por que los chinos son amarillos?Porque mean contraviento.JaJaJaJaJa',2),
 ('creacion de colores','Que color sale si le aprietan los testículos a un chino, amarillo chillon',3),
 ('Lepro','¿Cuál es el colmo de un leproso? Que se le caiga la cara de vergüenza.',4);


 INSERT INTO chistes_tematicas(chiste_id,tematica_id) VALUES
 (1,2),
 (2,2),
 (4,1),
 (3,2);


 SELECT * FROM chistes INNER JOIN usuarios as u on chistes.autor = u.id WHERE u.nombre = 'Manolito'

 SELECT * FROM chistes as c INNER JOIN chistes_tematicas as ct on ct.chiste_id = c.id INNER JOIN tematicas as t ON t.id = ct.tematica_id
 WHERE t.nombre = 'Humor negro';

 SELECT * FROM chistes as c INNER JOIN chistes_tematicas 
 as ct on ct.chiste_id = c.id INNER JOIN tematicas 
 as t ON t.id = ct.tematica_id INNER JOIN usuarios 
 as u on c.autor = u.id WHERE u.nombre = 'Manolito' AND t.nombre = 'Humor negro';