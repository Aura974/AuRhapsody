-- Artist table
CREATE TABLE Artist(
   ArtistID INT AUTO_INCREMENT,
   ArtistName VARCHAR(50)  NOT NULL,
   DateOfBirth DATE,
   ArtistBiography TEXT,
   ArtistWebsite VARCHAR(100) ,
   ArtistImage VARCHAR(150)  NOT NULL,
   ArtistActive BOOLEAN NOT NULL DEFAULT 1,
   PRIMARY KEY(ArtistID)
);

-- Band table
CREATE TABLE Band(
   BandID INT AUTO_INCREMENT,
   BandName VARCHAR(50)  NOT NULL,
   DateOfCreation DATE,
   BandBiography TEXT,
   BandWebsite VARCHAR(100) ,
   BandImage VARCHAR(150)  NOT NULL,
   BandActive BOOLEAN NOT NULL DEFAULT 1,
   PRIMARY KEY(BandID)
);

-- Album table
CREATE TABLE Album(
   AlbumID INT AUTO_INCREMENT,
   AlbumTitle VARCHAR(50)  NOT NULL,
   AlbumPrice DECIMAL(6,2) NOT NULL,
   AlbumQuantity INT NOT NULL,
   AlbumImage VARCHAR(150)  NOT NULL,
   AlbumReleaseDate DATE,
   PRIMARY KEY(AlbumID)
);

-- Single table
CREATE TABLE Single(
   SingleID INT AUTO_INCREMENT,
   SingleTitle VARCHAR(50)  NOT NULL,
   SinglePrice DECIMAL(6,2) NOT NULL,
   SingleQuantity INT NOT NULL,
   SingleImage VARCHAR(150)  NOT NULL,
   SingleReleaseDate DATE,
   PRIMARY KEY(SingleID)
);

-- Merch table
CREATE TABLE Merch(
   MerchID INT AUTO_INCREMENT,
   MerchType VARCHAR(50) ,
   MerchName VARCHAR(50)  NOT NULL,
   MerchDate DATE,
   MerchPrice DECIMAL(6,2) NOT NULL,
   MerchQuantity INT NOT NULL,
   MerchImage VARCHAR(150)  NOT NULL,
   PRIMARY KEY(MerchID)
);

-- Association Album/Artist
CREATE TABLE ArtistAlbum(
   ArtistID INT,
   AlbumID INT,
   PRIMARY KEY(ArtistID, AlbumID),
   FOREIGN KEY(ArtistID) REFERENCES Artist(ArtistID),
   FOREIGN KEY(AlbumID) REFERENCES Album(AlbumID)
);

-- Association Single/Artist
CREATE TABLE ArtistSingle(
   ArtistID INT,
   SingleID INT,
   PRIMARY KEY(ArtistID, SingleID),
   FOREIGN KEY(ArtistID) REFERENCES Artist(ArtistID),
   FOREIGN KEY(SingleID) REFERENCES Single(SingleID)
);

-- Association Band/Artist
CREATE TABLE Members(
   ArtistID INT,
   BandID INT,
   PRIMARY KEY(ArtistID, BandID),
   FOREIGN KEY(ArtistID) REFERENCES Artist(ArtistID),
   FOREIGN KEY(BandID) REFERENCES Band(BandID)
);

-- Association Album/Band
CREATE TABLE BandAlbum(
   AlbumID INT,
   BandID INT,
   PRIMARY KEY(AlbumID, BandID),
   FOREIGN KEY(AlbumID) REFERENCES Album(AlbumID),
   FOREIGN KEY(BandID) REFERENCES Band(BandID)
);

-- Association Single/Band
CREATE TABLE BandSingle(
   BandID INT,
   SingleID INT,
   PRIMARY KEY(BandID, SingleID),
   FOREIGN KEY(BandID) REFERENCES Band(BandID),
   FOREIGN KEY(SingleID) REFERENCES Single(SingleID)
);

-- Association Merch/Artist
CREATE TABLE ArtistMerch(
   ArtistID INT,
   MerchID INT,
   PRIMARY KEY(ArtistID, MerchID),
   FOREIGN KEY(ArtistID) REFERENCES Artist(ArtistID),
   FOREIGN KEY(MerchID) REFERENCES Merch(MerchID)
);

-- Association Merch/Band
CREATE TABLE BandMerch(
   BandID INT,
   MerchID INT,
   PRIMARY KEY(BandID, MerchID),
   FOREIGN KEY(BandID) REFERENCES Band(BandID),
   FOREIGN KEY(MerchID) REFERENCES Merch(MerchID)
);
