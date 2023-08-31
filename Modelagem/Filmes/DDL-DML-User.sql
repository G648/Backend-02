USE Filmes;

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	EmailUser VARCHAR (255),
	SenhaUser VARCHAR (255),
	PermissaoUser VARCHAR (255)
);

INSERT INTO Usuario (EmailUser, SenhaUser, PermissaoUser) VALUES
('user@user.com', '123456', 'Admin'),
('user2@user2.com', '1234567', 'Padrão');

