USE Filmes;

INSERT INTO Genero (Nome) VALUES
('Terror'),
('Ação');

INSERT INTO Filme (IdGenero, NomeFilme) VALUES 
(1, 'A freira'),
(2, 'Indiana Jones');

SELECT * FROM Filme