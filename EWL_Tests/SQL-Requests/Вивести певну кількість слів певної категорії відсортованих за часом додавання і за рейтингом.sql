SELECT AllWords.WordID, AllWords.EngWord, AllWords.UaTranslation, AllWords.Rating, AllWords.Repetition, WordCategories.AddedAt
FROM AllWords
JOIN WordCategories
ON AllWords.WordID = WordCategories.WordID
WHERE WordCategories.CategoryID = 1
ORDER BY AllWords.Rating, WordCategories.AddedAt
LIMIT 2