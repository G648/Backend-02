USE Filmes;

INSERT INTO Genero (Nome) VALUES
('Terror'),
('A��o');

INSERT INTO Filme (IdGenero, NomeFilme) VALUES 
(1, 'A freira'),
(2, 'Indiana Jones');

SELECT * FROM Filme