SELECT Id, Title, Genre, [Year], Rating
FROM Movies
ORDER BY Id;

DELETE FROM Movies
WHERE Id IN (1, 2, 3, 4);
