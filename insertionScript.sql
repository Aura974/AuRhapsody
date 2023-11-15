-- Insert data for artists
INSERT INTO Artist (ArtistName, DateOfBirth, ArtistBiography, ArtistWebsite, ArtistImage, ArtistActive)
VALUES 
('Beyoncé', '1981-09-04', 'American singer, songwriter, and actress.', 'https://www.beyonce.com/', 'beyonce.jpg', true),
('Lady Gaga', '1986-03-28', 'American singer, songwriter, and actress.', 'https://www.ladygaga.com/', 'ladygaga.jpg', true),
('Adele', '1988-05-05', 'British singer and songwriter.', 'https://www.adele.com/', 'adele.jpg', true),
('Céline Dion', '1968-03-30', 'Canadian singer.', 'https://www.celinedion.com/', 'celinedion.jpg', true);

-- Insert data for bands
INSERT INTO Band (BandName, DateOfCreation, BandBiography, BandWebsite, BandImage, BandActive)
VALUES 
('Destiny''s Child', '1990-01-01', 'American girl group.', 'https://destinyschild.com/', 'destinyschild.jpg', true),
('Spice Girls', '1994-01-01', 'British girl group.', 'https://www.thespicegirls.com/', 'spicegirls.jpg', true),
('Queen', '1970-01-01', 'British rock band.', 'https://www.queenonline.com/', 'queen.jpg', true);

-- Insert data for albums
INSERT INTO Album (AlbumTitle, AlbumPrice, AlbumQuantity, AlbumImage, AlbumReleaseDate)
VALUES 
('Bee and Lady', 19.99, 100, 'album1.jpg', '2009-04-14'),
('Adele & DC3', 24.99, 150, 'album2.jpg', '2026-12-25'),
('Spicy Queen', 29.99, 200, 'album3.jpg', '1995-06-27');

-- Insert data for singles
INSERT INTO Single (SingleTitle, SinglePrice, SingleQuantity, SingleImage)
VALUES 
('Survivor', 2.99, 50, 'single1.jpg'),
('Wannabe', 3.99, 75, 'single2.jpg'),
('All By Myself', 4.99, 100, 'single3.jpg');

-- Insert data for merch
INSERT INTO Merch (MerchType, MerchName, MerchDate, MerchPrice, MerchQuantity, MerchImage)
VALUES 
('Poster', 'Live in Las Vegas', '2008-01-01', 49.99, 30, 'poster1.jpg'),
('DVD', 'Live in Atlanta', '2006-03-28', 24.99, 20, 'dvd1.jpg'),
('Clothing', 'Lady Gaga T-shirt', '2022-03-01', 19.99, 25, 'clothing1.jpg'),
('Clothing', 'Adele Hoodie', '2023-04-01', 29.99, 15, 'clothing2.jpg'),
('Miscellaneous', 'Bohemian Rhapsody Mug', '2018-05-01', 7.99, 40, 'misc1.jpg');

-- Insert data for associations
-- Artist-Album associations
INSERT INTO ArtistAlbum (ArtistID, AlbumID)
VALUES 
(1, 1), -- Beyoncé with "Bee and Lady"
(2, 1), -- Lady Gaga with "Bee and Lady"
(3, 2); -- Adele with "Adele & DC3"

-- Band-Album associations
INSERT INTO BandAlbum (BandID, AlbumID)
VALUES 
(1, 2), -- Destiny's Child with "Adele & DC3"
(3, 3), -- Queen with "Spicy Queen"
(2, 3); -- Spice Girls with "Spicy Queen"

-- Artist-Single associations
INSERT INTO ArtistSingle (ArtistID, SingleID)
VALUES 
(4, 3); -- Céline Dion with "All By Myself"

-- Band-Single associations
INSERT INTO BandSingle (BandID, SingleID)
VALUES 
(1, 1), -- Destiny's Child with "Survivor"
(2, 2); -- Spice Girls with "Wannabe"

-- Artist-Merch associations
INSERT INTO ArtistMerch (ArtistID, MerchID)
VALUES 
(4, 1), -- Céline Dion with "Live in Las Vegas"
(2, 3), -- Lady Gaga with "Lady Gaga T-shirt"
(3, 4); -- Adele with "Adele Hoodie"

-- Band-Merch associations
INSERT INTO BandMerch (BandID, MerchID)
VALUES 
(1, 2), -- Destiny's Child with "Live in Atlanta"
(3, 5); -- Queen with "Bohemian Rhapsody Mug"
