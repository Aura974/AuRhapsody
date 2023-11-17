SELECT 
    a.AlbumTitle,
    a.AlbumReleaseDate,
    a.AlbumPrice,
    a.AlbumQuantity,
    GROUP_CONCAT(DISTINCT ar.ArtistName ORDER BY ar.ArtistName ASC) AS Artists,
    GROUP_CONCAT(DISTINCT b.BandName ORDER BY b.BandName ASC) AS Bands
FROM Album a
LEFT JOIN artistalbum aa ON a.AlbumID = aa.AlbumID
LEFT JOIN Artist ar ON aa.ArtistID = ar.ArtistID
LEFT JOIN bandalbum ba ON a.AlbumID = ba.AlbumID
LEFT JOIN Band b ON ba.BandID = b.BandID
GROUP BY a.AlbumID;
