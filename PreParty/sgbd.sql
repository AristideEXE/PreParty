drop SCHEMA IF EXISTS preparty ;
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
    prix int,
	foreign key (organisateur) references utilisateur(idUtilisateur)
);

CREATE TABLE invites(
   idFete INT,
   idUtilisateur INT,
   FOREIGN KEY(idFete) REFERENCES fete(idFete),
   FOREIGN KEY(idUtilisateur) REFERENCES utilisateur(idUtilisateur),
   PRIMARY KEY(idFete, idUtilisateur)
);

create table post(
	idPost int primary key auto_increment,
	idFete int,
	titre varchar(255),
	datePost datetime default current_date,
	contenu text,
	foreign key (idFete) references fete(idFete)
);


CREATE TABLE Depense(
   idDepense int,
   nomDepense varchar(50),
   prix decimal(15,2),
   idFete int NOT NULL,
   PRIMARY KEY(idDepense),
   FOREIGN KEY(idFete) REFERENCES fete(idFete)
);

INSERT INTO utilisateur VALUES (1,'Proriol', 'Aristide', '2004-11-19', 'aristidepr@gmail.com', 'EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F'),
(2, 'Maitrot', 'Teo', '2002-03-14', 'teomaitr21@gmail.com', 'EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F'),
(3, 'Robinet', 'Simon', '2003-09-27', 'simonrobinet@gmail.com', 'EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F'),
(4, 'Moreau', 'Léandre', '2003-07-14', 'leoravageur@gmail.com', 'EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F'),
(5, 'Rodrigues', 'Hugo', '2003-03-01', 'hugordg@gmail.com', 'EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F'),
(6, 'Bouchot', 'Quentin', '2003-07-06', 'qb@gmail.com', 'EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F'),
(7, 'Dev', 'Dev', '2022-12-15', 'dev@gmail.com', 'EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F');


insert into fete values (1,1, 'Anniversaire toto', 'Venez à ma superbe fête d''anniversaire ça va être génial', '78 boulevard de Strasbourg', '107.0.0.1', '2022-11-19 17:00', '2022-11-20 05:00', 10),
(2,4, 'Fete chez léandre', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum tincidunt molestie eros, eget sodales mauris ullamcorper eu. Suspendisse condimentum augue eu lectus tempor, eu condimentum lorem pharetra. In gravida mollis libero, semper faucibus leo elementum ornare.', 'Adresse de léandre', '127.0.0.1', '2022-12-21 19:00', '2022-12-21 23:00', 2),
(3,1, 'Fete chez Aristide', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum tincidunt molestie eros, eget sodales mauris ullamcorper eu. Suspendisse condimentum augue eu lectus tempor, eu condimentum lorem pharetra. In gravida mollis libero, semper faucibus leo elementum ornare.', 'Adresse de Aristide', '127.0.0.1', '2022-12-21 19:00', '2022-12-21 23:00' ,0),
(4,3, 'Fete chez simon', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum tincidunt molestie eros, eget sodales mauris ullamcorper eu. Suspendisse condimentum augue eu lectus tempor, eu condimentum lorem pharetra. In gravida mollis libero, semper faucibus leo elementum ornare.', 'Adresse de simon', '127.0.0.1', '2022-12-21 19:00', '2022-12-21 23:00', 14),
(5,7, 'Nouvel an chez dev', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum tincidunt molestie eros, eget sodales mauris ullamcorper eu. Suspendisse condimentum augue eu lectus tempor, eu condimentum lorem pharetra. In gravida mollis libero, semper faucibus leo elementum ornare.', 'Adresse de dev', '127.0.0.1', '2022-12-31 19:00', '2023-01-01 10:00', 10)
;


insert into invites values (1,2),(1,3), (2,1),(2,5),(2,6), (3,4), (3,5), (3,6), (4,2), (2,7);

insert into post (idPost, idFete, titre, contenu) values (1, 2, 'Matelas', "J'ai qu'un seul matelas chez moi il faut en emmener + sacs de couchages / duvets si possible");