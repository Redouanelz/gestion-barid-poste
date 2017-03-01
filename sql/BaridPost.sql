
CREATE DATABASE BaridPost                         
-- 
GO 
USE BaridPost
CREATE TABLE Agent(
		ID_Agent int PRIMARY KEY,
		LoginAgent varchar(50),
		PasswordAgent varchar(50),
		ID_Agence int,
		Profile_Agent varchar(50),
		)
CREATE TABLE InformationsAbonnées(
		 ID_Client int PRIMARY KEY not null IDENTITY(0,1),	
		 CIN varchar(50),
		 TypeCIN varchar(50),
		 Civilite varchar(50),
		 DateValiditeCIN varchar(50),		 	
		 Nom varchar(50),
		 Prenom varchar(50),
		 Email varchar(50),
		 NumTel varchar(50),
		 )
CREATE TABLE AncienneAdresse (
		ID_AncienneAdresse int PRIMARY KEY IDENTITY(0,1),	
		ID_Client int FOREIGN KEY References InformationsAbonnées(ID_Client) ON DELETE CASCADE ON UPDATE CASCADE ,		
		ImmeubleResidenceBatiment varchar(50),
		CodePostal varchar(50),
		VilleLocalite varchar(50),
		TypeVoie varchar(50),
		Quartier varchar(50),
		NomVoie varchar(50),
		Numéro varchar(50),
		)
CREATE TABLE NouvelleAdresse (
		ID_NouvelleAdresse int PRIMARY KEY IDENTITY(0,1),	
		ID_Client int FOREIGN KEY References InformationsAbonnées(ID_Client) ON DELETE CASCADE ON UPDATE CASCADE  ,		
		ImmeubleResidenceBatiment varchar(50),
		CodePostal varchar(50),
		VilleLocalite varchar(50),
		TypeVoie varchar(50),
		Quartier varchar(50),
		NomVoie varchar(50),
		Numéro varchar(50),
		)
CREATE TABLE Benificiers(
		 ID_Benificier int PRIMARY KEY IDENTITY(0,1),	
		 ID_Client int FOREIGN KEY References InformationsAbonnées(ID_Client) ON DELETE CASCADE ON UPDATE CASCADE ,
		 Civilité varchar(50),
		 Nom varchar(50),
		 Prenom varchar(50),
		 CIN_Benificiers varchar(50) UNIQUE,
		 DateValiditéCIN varchar(50),
		 Email varchar(50),
		 )
CREATE TABLE Contrat(
		ID_Contrat int PRIMARY KEY IDENTITY(0,1),			
		ID_Client int FOREIGN KEY References InformationsAbonnées(ID_Client) ON DELETE CASCADE ON UPDATE CASCADE  ,	
		ID_Agent int foreign key references agent (ID_agent),
		EspeceCheque varchar(50),
		Banque varchar(50),
		NCompte varchar(50),
		NCheque varchar(50),
		Duree varchar(50),
		DateDebut date,
		DateFin date,
		MontantApaye varchar(50),				
		ID_Controle int,
		datecreation datetime,
		dateModification datetime,
		Profile_Agent varchar(50),		
		)	 
		
CREATE TABLE Agence(
		ID_Agence int PRIMARY KEY IDENTITY(0,1),
		Nom_Agence varchar(50),
		)
CREATE TABLE Centre(
		ID_Centre int PRIMARY KEY IDENTITY(0,1),			
		Ticket varchar(500),
	    ID_Client int FOREIGN KEY References InformationsAbonnées(ID_Client) ON DELETE CASCADE ON UPDATE CASCADE  ,	
	    Ville_Centre varchar(50),
	    )
create table historiquecontrat (
        ID_Contrat int FOREIGN key references contrat (ID_contrat),	
		ID_Payement int,
		ID_Client int FOREIGN KEY References InformationsAbonnées(ID_Client)  ,
		ID_agent int FOREIGN key references agent (ID_agent),	
		EspeceCheque varchar(50),
		Banque varchar(50),
		NCompte varchar(50),
		NCheque varchar(50),
		Duree varchar(50),
		DateDebut date,
		DateFin date,
		MontantApaye varchar(50),
		Controle_Ticket varchar(500),
		ID_Controle int,
		dateCreation datetime,
		dateModification datetime,
		)	    		
-- END CREATE --	

-- INSERT
		GO
		USE BaridPost			
INSERT INTO Agent (ID_Agent,LoginAgent,PasswordAgent,Profile_Agent) Values (1,'Agent','Agent','Agent');	
INSERT INTO Agent (ID_Agent,LoginAgent,PasswordAgent,Profile_Agent) Values (2,'Controle','Controle','Controle');	
