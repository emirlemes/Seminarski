USE master
GO

IF EXISTS(select * from sys.databases where name='eFastFoodTest')
DROP DATABASE eFastFoodTest
GO

CREATE DATABASE eFastFoodTest
GO

USE eFastFoodTest
GO

CREATE TABLE Kategorija(
	KategorijaID int PRIMARY KEY IDENTITY(1,1),
	Naziv nvarchar(50) NOT NULL,
	Opis nvarchar(200),
)
GO

CREATE TABLE GotoviProizvod(
	GotoviProizvodID int PRIMARY KEY IDENTITY(1,1),
	Naziv nvarchar(50) NOT NULL,
	Opis nvarchar(200),
	Cijena decimal(18,2) NOT NULL,
	VrijemePripreme int,
	VidljivostMobile bit,
	Slika varbinary(max),
	SlikaUmanjeno varbinary(max),
	KategorijaID int FOREIGN KEY REFERENCES Kategorija(KategorijaID) NOT NULL
)
GO

CREATE TABLE Uloga(
	UlogaID int PRIMARY KEY IDENTITY(1,1),
	Naziv nvarchar(50),
	Opis nvarchar(200)
)
GO

CREATE TABLE Uposlenik(
	UposlenikID int PRIMARY KEY IDENTITY(1,1),
	Ime nvarchar(50) NOT NULL,
	Prezime nvarchar(50) NOT NULL,
	UserName nvarchar(50) NOT NULL CONSTRAINT CS_UserNameUposlenik UNIQUE,
	BrojTelefona nvarchar(20) CONSTRAINT CS_BrojTelefonaUpolsenik UNIQUE,
	Email nvarchar(50) CONSTRAINT CS_EmailUposlenik UNIQUE,
	LozinkaHash nvarchar(100),
	LozinkaSalt nvarchar(100),
	[Status] bit NOT NULL,
	UlogaID int FOREIGN KEY REFERENCES Uloga(UlogaID) NOT NULL
)
GO

CREATE TABLE Dobavljac(
	DobavljacID int PRIMARY KEY IDENTITY(1,1),
	Naziv nvarchar(50) NOT NULL,
	Adresa nvarchar(50) NOT NULL,
	BrojTelefona nvarchar(20),
	Email nvarchar(50) NOT NULL
)
GO

CREATE TABLE MjernaJedinica(
	MjernaJedinicaID int PRIMARY KEY IDENTITY(1,1),
	Naziv nvarchar(50),
	Opis nvarchar(100),
	Exponent int NOT NULL,
)
GO

CREATE TABLE Proizvod(
	ProizvodID int PRIMARY KEY IDENTITY(1,1),
	Naziv nvarchar(50) NOT NULL,
	Opis nvarchar(200),
	Kolicina decimal(18,2) NOT NULL DEFAULT 0,
	DonjaGranica decimal(18,2) NOT NULL DEFAULT 0,
	MjernaJedinicaID int FOREIGN KEY REFERENCES MjernaJedinica(MjernaJedinicaID) NOT NULL,
    DobavljacID int FOREIGN KEY REFERENCES Dobavljac(DobavljacID) NOT NULL
)
GO

CREATE TABLE GPProizvod(
    GotoviProizvodID int FOREIGN KEY REFERENCES GotoviProizvod(GotoviProizvodID) NOT NULL,
    ProizvodID int FOREIGN KEY REFERENCES Proizvod(ProizvodID) NOT NULL,
    KolicinaUtroska decimal(18,2) NOT NULL,
    MjernaJedinicaID int FOREIGN KEY REFERENCES MjernaJedinica(MjernaJedinicaID) NOT NULL,
	PRIMARY KEY(GotoviProizvodID,ProizvodID)
)
GO

CREATE TABLE Klijent(
	KlijentID int PRIMARY KEY IDENTITY(1,1),
	Ime nvarchar(50) NOT NULL,
	Prezime nvarchar(50) NOT NULL,
	BrojTelefona nvarchar(20) CONSTRAINT CS_BrojTelefonaKlijent UNIQUE,
	Email nvarchar(50) CONSTRAINT CS_EmailKlijent UNIQUE,
	LozinkaHash nvarchar(100),
	LozinkaSalt nvarchar(100),
	Adresa nvarchar(50) NOT NULL,
	[Status] bit NOT NULL,
	UlogaID int FOREIGN KEY REFERENCES Uloga(UlogaID) NOT NULL,
)
GO


CREATE TABLE Narudzba(
	NarudzbaID int PRIMARY KEY IDENTITY(1,1),
	VrstaNarudzbe nvarchar(50) NOT NULL,
	Datum datetime NOT NULL,
	UkupnaCijena decimal(18,2) NOT NULL,
	KlijentID int FOREIGN KEY REFERENCES Klijent(KlijentID) NOT NULL,
	[Status] nvarchar(50) NOT NULL,
)
GO

CREATE TABLE NarudzbaStavka(
	NarudzbaID int FOREIGN KEY REFERENCES Narudzba(NarudzbaID) NOT NULL,
	GotoviProizvodID int FOREIGN KEY REFERENCES GotoviProizvod(GotoviProizvodID) NOT NULL,
	Kolicina int NOT NULL,
	PRIMARY KEY(NarudzbaID,GotoviProizvodID)
)
GO



CREATE TABLE Racun(
	RacunID int PRIMARY KEY IDENTITY(1,1),
	BrojRacuna nvarchar(50) NOT NULL,
	DatumIzdavanja date NOT NULL,
	CijenaBezPDV decimal(18,2),
	CijenaSaPDV decimal(18,2),
	VrstaPlacanja nvarchar(20),
	IsPlaceno bit,
	UposlenikID int FOREIGN KEY REFERENCES Uposlenik(UposlenikID),
	NarudzbaID int FOREIGN KEY REFERENCES Narudzba(NarudzbaID),
)
GO

CREATE TABLE Dostava(
	Dostava int PRIMARY KEY IDENTITY(1,1),
	NarudzbaID int FOREIGN KEY REFERENCES Narudzba(NarudzbaID) NOT NULL,
	UposlenikID int FOREIGN KEY REFERENCES Uposlenik(UposlenikID),
	AdresaDostave nvarchar(50) NOT NULL,
	VrijemePreuzimanja date,
	VrijemeDostavljanja date,
)
GO

CREATE TABLE Ocjena(
	OcjenaID int PRIMARY KEY IDENTITY(1,1),
	NumerickaOcjena int NOT NULL,
	Komentar nvarchar(200),
	GotoviProizvodID int FOREIGN KEY REFERENCES GotoviProizvod(GotoviProizvodID) NOT NULL,
	KlijentID int FOREIGN KEY REFERENCES Klijent(KlijentID) NOT NULL,
)
GO

EXEC sp_changedbowner 'sa'
GO