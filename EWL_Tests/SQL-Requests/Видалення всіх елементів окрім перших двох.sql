DELETE FROM Categories 
WHERE CategoryID NOT IN ( 
	SELECT CategoryID 
	FROM Categories 
	ORDER BY CategoryID 
	LIMIT 2
);