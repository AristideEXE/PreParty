DROP SCHEMA IF EXISTS preparty ;
CREATE SCHEMA preparty;
use preparty;

CREATE TABLE utilisateur(
	idUtilisateur int primary key auto_increment,
	nom VARCHAR(255) NOT NULL,
	prenom VARCHAR(255) NOT NULL,
	dateNaissance DATETIME NOT NULL,
	mail VARCHAR(255) NOT NULL,
	hash VARCHAR(255) NOT NULL
);

CREATE TABLE fete(
	idFete int primary key auto_increment,
	organisateur int not null,
	nom varchar(255) not null,
	description text,
	lieu varchar(255),
	coordonneesGPS varchar(255),
	debutFete datetime,
	finFete datetime,
	foreign key (organisateur) references utilisateur(idUtilisateur)
);

CREATE TABLE invites(
   idFete INT,
   idUtilisateur INT,
   FOREIGN KEY(idFete) REFERENCES fete(idFete),
   FOREIGN KEY(idUtilisateur) REFERENCES utilisateur(idUtilisateur),
   PRIMARY KEY(idFete, idUtilisateur)
);


CREATE TABLE Depense(
   idDepense int,
   nomDepense varchar(50),
   prix decimal(15,2),
   idFete int NOT NULL,
   PRIMARY KEY(idDepense),
   FOREIGN KEY(idFete) REFERENCES fete(idFete)
);

INSERT INTO utilisateur VALUES (1,'Proriol', 'Aristide', '2004-11-19', 'aristidepr@gmail.com', 'f2d81a260dea8a100dd517984e53c56a7523d96942a834b9cdc249bd4e8c7aa9'),
(2,'Maitrot', 'Teo', '2002-03-14', 'teomaitr21@gmail.com', 'f2d81a260dea8a100dd517984e53c56a7523d96942a834b9cdc249bd4e8c7aa9'),
(3,'Robinet', 'Simon', '2003-09-27', 'simonrobinet@gmail.com', 'f2d81a260dea8a100dd517984e53c56a7523d96942a834b9cdc249bd4e8c7aa9');
insert into fete values (1,1, 'Anniversaire toto', 'Venez à ma superbe fête d''anniversaire ça va être génial', '78 boulevard de Strasbourg', '107.0.0.1', '2022-11-19 17:00', '2022-11-20 05:00');
insert into invites values (1,2),(1,3);