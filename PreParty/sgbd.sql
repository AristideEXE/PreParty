DROP SCHEMA IF EXISTS preparty;
CREATE SCHEMA preparty;
use preparty;

CREATE TABLE utilisateur(
	idUtilisateur int primary key auto_increment,
	nom VARCHAR(255) NOT NULL,
	prenom VARCHAR(255) NOT NULL,
	dateNaissance DATE NOT NULL,
	mail VARCHAR(255) NOT NULL,
	motDePasse VARCHAR(255) NOT NULL
);

INSERT INTO utilisateur VALUES (1,'Proriol', 'Aristide', '2004-11-19', 'aristidepr@gmail.com', 'azerty'),
(2,'Maitrot', 'Teo', '2002-03-14', 'teomaitr21@gmail.com', 'azerty'),
(3,'Robinet', 'Simon', '2003-09-27', 'simonrobinet@gmail.com', 'azerty');

CREATE TABLE fete(
	idFete int primary key auto_increment,
	idUtilisateur int,
	nom varchar(255),
	description text,
	lieu varchar(255),
	coordonneesGPS varchar(255),
	dateFete date,
	heureDebut time,
	heureFin time,
	foreign key (idUtilisateur) references utilisateur(idUtilisateur)
);

insert into fete values (1,1, 'Anniversaire toto', 'Venez à ma superbe fête d''anniversaire ça va être génial', '78 boulevard de Strasbourg', '107.0.0.1', '2022-11-19', '19:00', '01:00');