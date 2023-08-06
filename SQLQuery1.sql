SELECT
	ProductName,
	Category,
	Price
FROM 
	Product
WHERE 
	Category IN ('Summer roll','Sago')
	AND Price <10
ORDER BY 
	Category ASC;


