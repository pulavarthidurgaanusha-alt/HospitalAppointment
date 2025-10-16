  SELECT 
        d.Name AS DoctorName,
        d.Specialization,
        AVG(r.Value) AS AverageRating
    FROM 
        dbo.Doctors d
    INNER JOIN 
        dbo.Rating r ON d.user_id = r.DoctorId
    WHERE 
        d.Specialization = 'cardiologist'
    GROUP BY 
        d.Name, d.Specialization
    ORDER BY 
        AverageRating DESC