using EWL.EF_SQLite;
using System.Data.SQLite;
using NUnit.Framework;
using EWL;
using SQLitePCL;
using NUnit.Framework.Legacy;

namespace EWL_Tests
{
    /// <summary>
    /// Клас що містить тест-кейси
    /// </summary>
    public static class MyTestCases
    {
        /// <summary>
        /// Набір тест-кейсів з Категоріями
        /// </summary>
        /// <returns> IEnumerable категорій </returns>
        public static IEnumerable<TestCaseData> Categories_Cases()
        {
            yield return new TestCaseData("Category 1");
            yield return new TestCaseData("Category 2");
        }

        /// <summary>
        /// Набір тест-кейсів зі Словами
        /// </summary>
        /// <returns> IEnumerable слів </returns>
        public static IEnumerable<TestCaseData> Words_Cases()
        {
            yield return new TestCaseData("a", "ей");
            yield return new TestCaseData("b", "бі");
            yield return new TestCaseData("c", "сі");
        }
    }

    [TestFixture]
    public class SQLs_Test
    {
        //НЕ ЗАБУВАЙ КОМЕНТИТИ РЯДКИ З ЛОГІЮВАННЯМ В КОНТЕКСТІ МОДЕЛІ

        /// <summary>
        /// Connection String (contains path to .db file)
        /// </summary>
        readonly string conStr = "Data Source=D:\\SELF-DEV\\HARD-SKILLS\\DEVELOPMENT\\PRACTICE\\MyProjects\\EWL FC\\EWL_Tests\\Test_SQLs.db;";

        [OneTimeSetUp]
        public void Setup()
        {
            SQLService.CS = conStr;
            TearDown();
        }


        #region [ Words ]

        #region Words Adding

        [TestCaseSource(typeof(MyTestCases), "Words_Cases")]
        public void NewWord_Adding_Test(string engW, string uaW)
        {
            ClassicAssert.IsTrue(SQLService.TryAdd_Word_ToAllWords(engW, uaW),
                "Метод НЕ додав задане слово в Words");

            using VocabularyContext db = new(conStr);

            bool isAddedToWords = db.AllWords.Any(c => c.EngWord == engW && c.UaTranslation == uaW);
            ClassicAssert.IsTrue(isAddedToWords,
                "Задане слово НЕ було додане в БД");

            bool isWordAddedToWordCategories = db.WordCategories.Any(c => c.WordId == 3);
            ClassicAssert.IsTrue(isWordAddedToWordCategories,
                "Задане слово не було додане до категорії '1' в WordCategories");
        }

        [TestCaseSource(typeof(MyTestCases), "Words_Cases")]
        public void TwoIdenticalWords_Adding_Test(string engW, string uaW)
        {
            ClassicAssert.IsTrue(SQLService.TryAdd_Word_ToAllWords(engW, uaW),
                "Метод НЕ додав задане слово в Words");
            ClassicAssert.IsFalse(SQLService.TryAdd_Word_ToAllWords(engW, uaW),
                "Метод додав задане слово в Words [а не повинен був]");
        }

        #endregion

        #region Words Removing

        [TestCaseSource(typeof(MyTestCases), "Words_Cases")]
        public void LastWords_Removing_Test(string engW, string uaW)
        {
            var (anotherWId, anotherEngW, AnotherUaW) = (3, "candle", "свічка");
            SQLService.TryAdd_Word_ToAllWords(anotherEngW, AnotherUaW);   //Додавання першого слова
            SQLService.TryAdd_Word_ToAllWords(engW, uaW);                 //Додавання другого слова
            SQLService.Remove_LastWords_Permanently(1);                   //Видалення останнього слова

            using VocabularyContext db = new(conStr);

            //Перевірки
            bool isLastAddedWordRemovedFromWords = !db.AllWords.Any(c => c.EngWord == engW);
            ClassicAssert.IsTrue(isLastAddedWordRemovedFromWords, "Останнє слово НЕ було видалене");

            bool isAnotherWordNOTRemovedFromWords = db.AllWords.Any(c => c.EngWord == anotherEngW);
            ClassicAssert.IsTrue(isAnotherWordNOTRemovedFromWords, "Інше слово було видалене [а не повинне бути]");

            bool isLastAddedWordRemovedFromWordCategories = !db.WordCategories.Any(c => c.WordId == 4);
            ClassicAssert.IsTrue(isLastAddedWordRemovedFromWordCategories, "Останнє слово НЕ було видалене з WordCategories");

            bool isAnotherWordRemovedFromWordCategories = db.WordCategories.Any(c => c.WordId == anotherWId);
            ClassicAssert.IsTrue(isAnotherWordRemovedFromWordCategories, "Інше слово було видалене з WordCategories [а не повинне бути]");
        }

        [TestCaseSource(typeof(MyTestCases), "Words_Cases")]
        public void Word_Removing_Test(string engW, string uaW)
        {
            var (anotherWId, anotherEngW, AnotherUaW) = (3, "candle", "свічка");
            SQLService.TryAdd_Word_ToAllWords(anotherEngW, AnotherUaW);   //Додавання першого слова
            SQLService.TryAdd_Word_ToAllWords(engW, uaW);                 //Додавання другого слова
            SQLService.Remove_Word_Permanently(4);                        //Видалення другого слова

            using VocabularyContext db = new(conStr);

            //Перевірки
            bool isLastAddedWordRemovedFromWords = !db.AllWords.Any(c => c.EngWord == engW);
            ClassicAssert.IsTrue(isLastAddedWordRemovedFromWords, "Друге слово НЕ було видалене");

            bool isAnotherWordNOTRemovedFromWords = db.AllWords.Any(c => c.EngWord == anotherEngW);
            ClassicAssert.IsTrue(isAnotherWordNOTRemovedFromWords, "Перше слово було видалене [а не повинне бути]");

            bool isLastAddedWordRemovedFromWordCategories = !db.WordCategories.Any(c => c.WordId == 4);
            ClassicAssert.IsTrue(isLastAddedWordRemovedFromWordCategories, "Друге слово НЕ було видалене з WordCategories");

            bool isAnotherWordRemovedFromWordCategories = db.WordCategories.Any(c => c.WordId == anotherWId);
            ClassicAssert.IsTrue(isAnotherWordRemovedFromWordCategories, "Перше слово було видалене з WordCategories [а не повинне бути]");
        }

        #endregion

        #region Changing word parametrs

        [TestCase(1, 4)]
        [TestCase(1, 0)]
        public void WordRating_Setting_Test(int wordId, int rating)
        {
            SQLService.Rate_Word(wordId, rating);        //Налаштування значення Rating в Word

            using VocabularyContext db = new(conStr);

            var actualRating = db.AllWords.First(w => w.WordId == wordId).Rating;
            ClassicAssert.AreEqual(rating, actualRating,
                "WordAddingMode НЕ встановлене із необхідним значенням");
        }

        [TestCase(0, 4)]
        [TestCase(1, -1)]
        public void WordRating_NOTSettingBelowOne_Test(int wordId, int rating)
        {
            //Налаштування значення Rating в Word
            ClassicAssert.Catch(typeof(ArgumentException), () => SQLService.Rate_Word(wordId, rating),
                "Тут повинне виникати виключення, а не виникає");
        }


        [TestCase(1)]
        [TestCase(2)]
        public void WordRepetition_Incrementation_Test(int wordId)
        {
            int repetition;
            using (VocabularyContext db = new(conStr))
            {
                repetition = db.AllWords.First(w => w.WordId == wordId).Repetition;
                SQLService.Increment_WordRepetition(wordId);        //Збільшення значення Repetition в Word
            }
            using (VocabularyContext db = new(conStr))
            {
                var actualRepetition = db.AllWords.First(w => w.WordId == wordId).Repetition;
                ClassicAssert.AreEqual(repetition + 1, actualRepetition,
                    "Repetition НЕ збільшилося із необхідним значенням");

                db.AllWords.First(w => w.WordId == wordId).Repetition = 0;
                db.SaveChanges();
            }
        }

        #endregion

        #endregion

        #region [ Categories ]

        #region Categories Adding

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void NewCategory_Adding_Test(string categoryName)
        {
            ClassicAssert.IsTrue(SQLService.Add_NewCategory(categoryName),
                "Додавання нової категорії НЕ вдале");

            using VocabularyContext db = new(conStr);

            bool isCategoryAdded = db.Categories.Any(c => c.Name == categoryName);
            ClassicAssert.IsTrue(isCategoryAdded,
                "Нова категорія не з'явилася в Categories");
        }

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void TwoIdenticalCategories_Adding_Test(string categoryName)
        {
            ClassicAssert.IsTrue(SQLService.Add_NewCategory(categoryName),
                "Додавання нової категорії НЕ вдале");
            ClassicAssert.IsFalse(SQLService.Add_NewCategory(categoryName),
                "Додавання нової категорії вдале [а не повинне бути]");
        }

        #endregion

        #region Categories Marking as Removed

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void Category_MarkingAsRemoved_Test(string categoryName)
        {
            int categoryID = 3;
            SQLService.Add_NewCategory(categoryName);          //Додавання нової категорії (3-тя)
            SQLService.Set_CurrentCategory(categoryID);        //Встановлення поточної категорії - '3'

            using VocabularyContext db = new(conStr);

            //Перевірки
            ClassicAssert.IsTrue(SQLService.TryMarkAsRemoved_Category(categoryID),
            "Задана категорія НЕ була (позначена як) видалена");

            var category = db.Categories.First(c => c.CategoryId == categoryID);
            bool categoryIsMarkedAsDeleted = category.Deleted;
            ClassicAssert.IsTrue(categoryIsMarkedAsDeleted,
                "Значення поля 'Deleted' заданої категорії НЕ змінилося на '1'");

            ClassicAssert.AreEqual(1, db.Settings.First().CurrentCategoryId,
                "CurrentCategoryID в Settings НЕ змінилося на дефолтне '1'");

            DateTime actualDateTime = category.DeletedAt;
            ClassicAssert.IsTrue(($"{actualDateTime:yyyy-MM-dd HH:mm}" == $"{DateTime.Now:yyyy-MM-dd HH:mm}"),
                "Дата не встановлена або встановлена НЕвірно");
        }

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void NonRemovableCategory_NOTMarkingAsRemoved_Test(string categoryName)
        {
            using VocabularyContext db = new(conStr);

            int categoryID = 3;
            //Додавання категорії, яку не можна видаляти
            db.Categories.Add(new Category { Name = categoryName, CanBeDeleted = false });
            db.SaveChanges();

            //Перевірки
            ClassicAssert.IsFalse(SQLService.TryMarkAsRemoved_Category(categoryID),
                "Дана категорія була (позначена як) видалена [а не повинна була]");

            bool categoryIsMarkedAsDeleted = db.Categories.First(c => c.CategoryId == categoryID).Deleted;
            ClassicAssert.IsFalse(categoryIsMarkedAsDeleted,
                "Значення поля 'Deleted' заданої категорії змінилося на '1' [а не повинно було]");
        }
        #endregion

        #region Categories Restoring from Deletion

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void Category_Restoring_FromDeletion_Test(string categoryName)
        {
            int categoryID = 3;
            SQLService.Add_NewCategory(categoryName);           //Додавання нової категорії (3-тя)
            SQLService.Set_CurrentCategory(categoryID);         //Встановлення поточної категорії - '3'
            SQLService.TryMarkAsRemoved_Category(categoryID);   //Позначення категорії як "Видалена"

            SQLService.Restore_Category_FromDeletion(categoryID);   //Відновлення категорії з "Кошика"

            using VocabularyContext db = new(conStr);

            bool categoryIsMarkedAsDeleted = db.Categories.First(c => c.CategoryId == categoryID).Deleted;
            ClassicAssert.IsFalse(categoryIsMarkedAsDeleted,
                "Значення поля 'Deleted' заданої категорії НЕ змінилося на '0'");

            ClassicAssert.AreEqual(1, SQLService.Get_CurrentCategory(),
                "CurrentCategoryID в Settings змінилося з дефолтного '1' на інше [а не повинне було]");
        }
        #endregion

        #region Categories Removing

        public void Category_MarkAsRemoved(int categoryID, string categoryName)
        {
            SQLService.Add_NewCategory(categoryName);           //Додавання нової категорії (3-тя)
            SQLService.TryAdd_Word_ToCategory(1, categoryID);   //Додавання першого слова до нової категорії
            SQLService.TryAdd_Word_ToCategory(2, categoryID);   //Додавання другого слова до нової категорії
            SQLService.TryMarkAsRemoved_Category(categoryID);   //Позначення категорії як "видалена"
        }

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void RecentlyMarkedCategories_Removing_Test(string categoryName)
        {
            int categoryID = 3;
            Category_MarkAsRemoved(categoryID, categoryName);
            SQLService.FindAndRemove_LongMarkedCategories(3);

            using VocabularyContext db = new();

            //Перевірки
            bool isRecentlyMarkedCategoryWordsDeleted = !db.WordCategories.Any(c => c.CategoryId == categoryID);
            ClassicAssert.IsFalse(isRecentlyMarkedCategoryWordsDeleted, 
                "Слова даної категорії видалені з WordCategory [а НЕ повинні бути]");

            bool isRecentlyMarkedCategoryDeleted = !db.Categories.Any(c => c.CategoryId == categoryID);
            ClassicAssert.IsFalse(isRecentlyMarkedCategoryDeleted, 
                "Дана категорія видалена з Categories [а НЕ повинна бути]");
        }

        [TestCaseSource(typeof(MyTestCases), "Categories_Cases")]
        public void LongMarkedCategories_Removing_Test(string categoryName)
        {
            int categoryID = 3;
            Category_MarkAsRemoved(categoryID, categoryName);

            using VocabularyContext db = new();

            //Зміна дати (позначення як) видалення даної категорії
            db.Categories.First(c => c.CategoryId == categoryID).DeletedAt = 
                new DateTime(year: 2023, month: 01, day: 01, kind: DateTimeKind.Utc, hour: 12, minute: 0, second: 0);
            db.SaveChanges();
            SQLService.FindAndRemove_LongMarkedCategories(3);

            //Перевірка
            bool isLongMarkedCategoryWordsDeleted = !db.WordCategories.Any(c => c.CategoryId == categoryID);
            ClassicAssert.IsTrue(isLongMarkedCategoryWordsDeleted,
                "Слова даної категорії НЕ видалені з WordCategory");

            bool isLongMarkedCategoryDeleted = !db.Categories.Any(c => c.CategoryId == categoryID);
            ClassicAssert.IsTrue(isLongMarkedCategoryDeleted,
                "Дана категорія НЕ видалена з Categories");
        }
        #endregion

        #endregion

        #region [ WordCategories ]

        #region Adding words to category

        [TestCase(1)]
        [TestCase(2)]
        public void Word_Adding_ToCategory_Test(int wordID)
        {
            int anotherCategoryID = 2;

            using VocabularyContext db = new();

            //Перевірки
            ClassicAssert.IsTrue(SQLService.TryAdd_Word_ToCategory(wordID, anotherCategoryID), 
                "Метод НЕ додав слово до категорії '2'");

            bool isAddedToCategory2 = db.WordCategories.Any(wc => wc.WordId == wordID &&  wc.CategoryId == anotherCategoryID);
            ClassicAssert.IsTrue(isAddedToCategory2, "Слово НЕ з'явилося в категорії '2'");
        }

        [TestCase(2, 2)]
        public void TwoIdenticalWords_Adding_ToCategory_Test(int anotherWordID, int anotherCategoryID)
        {
            ClassicAssert.IsTrue(SQLService.TryAdd_Word_ToCategory(anotherWordID, anotherCategoryID), 
                "Метод НЕ додав слово до категорії '2'");
            ClassicAssert.IsFalse(SQLService.TryAdd_Word_ToCategory(anotherWordID, anotherCategoryID), 
                "Метод додав ІДЕНТИЧНЕ слово до категорії '2' [а не повинен]");
        }

        /// <summary>
        /// Перевіряє чи виникне виключення якщо додати до категорії слово з неправильним номером wordID чи categoryID
        /// </summary>
        /// <param name="invalidNumber">неправильний номер для wordID чи categoryID</param>
        [TestCase(0)]
        [TestCase(-2)]
        public void InvalidNumber_Word_Adding_ToCategory_Test(int invalidNumber)
        {
            int validWordID = 2;
            int validCategoryID = 2;

            TestDelegate AddValidWordIDToInvalidCategoryID = () => SQLService.TryAdd_Word_ToCategory(validWordID, invalidNumber);
            ClassicAssert.Catch(typeof(ArgumentException), AddValidWordIDToInvalidCategoryID,
                "Тут повинне виникати виключення, а не виникає");

            TestDelegate AddInvalidWordIDToValidCategoryID = () => SQLService.TryAdd_Word_ToCategory(invalidNumber, validCategoryID);
            ClassicAssert.Catch(typeof(ArgumentException), AddInvalidWordIDToValidCategoryID,
                "Тут повинне виникати виключення, а не виникає");

            TestDelegate AddInvalidWordIDToInvalidCategoryID = () => SQLService.TryAdd_Word_ToCategory(invalidNumber, invalidNumber);
            ClassicAssert.Catch(typeof(ArgumentException), AddInvalidWordIDToInvalidCategoryID,
                "Тут повинне виникати виключення, а не виникає");
        }

        #endregion

        #region Removing words from category

        [TestCase(1)]
        [TestCase(2)]
        public void LastAddedWord_Removing_FromWordCategories_Test(int count)
        {
            int categoryID = 2;
            for (int i = 1; i <= count; i++)
                SQLService.TryAdd_Word_ToCategory(i, categoryID);    //Додавання слова(-ів) до іншої категорії
            SQLService.Remove_LastWords_FromCategory(count);         //Видалення останнього(-іх) доданого до іншої категорії слова з WordCategories

            using VocabularyContext db = new();

            int WordsCount = 2;
            for (int i = 1; i <= WordsCount; i++)
            {
                if (i <= count)
                {
                    bool isLastAddedWordRemovedFromWords = !db.WordCategories.Any(wc => wc.WordId == i && wc.CategoryId == 2);
                    ClassicAssert.IsTrue(isLastAddedWordRemovedFromWords, "Останні додані слова НЕ були видалені");
                }
                else
                {
                    bool isAnotherWordNOTRemovedFromWords = db.WordCategories.Any(wc => wc.WordId == i && wc.CategoryId == 1);
                    ClassicAssert.IsTrue(isAnotherWordNOTRemovedFromWords, "Інші слова були видалені [а не повинні бути]");
                }
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Word_Removing_FromWordCategories_Test(int wordID)
        {
            int categoryID = 2;                                    //Номер неосновної категорії
            SQLService.TryAdd_Word_ToCategory(wordID, categoryID);       //Додавання слова(-ів) до іншої категорії

            ClassicAssert.Catch<ArgumentException>(() => SQLService.Remove_Word_FromCategory(wordID, 1), 
                "Тут повинне виникати виключення, а не виникає");  //Спроба видалення слова з основної категорії

            using VocabularyContext db = new();

            SQLService.Remove_Word_FromCategory(wordID, categoryID);     //Видалення слова з неосновної категорії
            bool isWordRemovedFromAnotherCategory = !db.WordCategories.Any(wc => wc.WordId == wordID && wc.CategoryId == 2);
            ClassicAssert.IsTrue(isWordRemovedFromAnotherCategory, "Слово НЕ було видалене з НЕосновної категорії");
        }

        #endregion

        #region Getting Words from Category

        /// <summary>
        /// Додавання слів до БД (й половини з них до побічної категорії '2')
        /// </summary>
        /// <param name="wordCount">Кількість слів</param>
        void Words_Adding_ToDB(int wordCount)
        {
            int anotherCategoryID = 2;
            int alreadyAddedWordsCount = 2;

            for (int i = 0; i < wordCount; i++)
                SQLService.TryAdd_Word_ToAllWords($"{i + 1}", "i + 1");
            for (int i = 0; i < wordCount + alreadyAddedWordsCount; i++)
                if (i % 2 == 0)
                    SQLService.TryAdd_Word_ToCategory(i + 1, anotherCategoryID);
        }

        [TestCase(4)]
        [TestCase(6)]
        public void Words_Getting_FromMainCategory_Test(int addedWordCount)
        {
            int getWordsCount = 4;
            int categoryID = 1;
            Words_Adding_ToDB(addedWordCount);

            var allWFromCategory = SQLService.Get_Words_FromCategory(categoryID);
            ClassicAssert.AreEqual(addedWordCount + 2, allWFromCategory.Count, 
                $"Отриманих слів має бути {addedWordCount + 2} а не {allWFromCategory.Count}");

            var countWFromCategory = SQLService.Get_Words_FromCategory(categoryID, getWordsCount);
            ClassicAssert.AreEqual(getWordsCount, countWFromCategory.Count, 
                $"Отриманих слів має бути {getWordsCount} а не {allWFromCategory.Count}");
        }

        [TestCase(4)]
        [TestCase(6)]
        public void Words_Getting_FromAnotherCategory_Test(int addedWordCount)
        {
            int getWordsCount = 2;
            int categoryID = 2;
            Words_Adding_ToDB(addedWordCount);

            var allWFromCategory = SQLService.Get_Words_FromCategory(categoryID);
            //int addedWordCount
            ClassicAssert.AreEqual((int)Math.Round(((double)addedWordCount + 2)/2, MidpointRounding.AwayFromZero), allWFromCategory.Count,
                $"Отриманих слів має бути {addedWordCount + 2} а не {allWFromCategory.Count}");

            var countWFromCategory = SQLService.Get_Words_FromCategory(categoryID, getWordsCount);
            ClassicAssert.AreEqual(getWordsCount, countWFromCategory.Count,
                $"Отриманих слів має бути {addedWordCount + 2} а не {allWFromCategory.Count}");   
        }

        [TestCase(4)]
        [TestCase(6)]
        public void Words_NOTGetting_FromAnotherCategory_Test(int addedWordCount)
        {
            Words_Adding_ToDB(addedWordCount);
            int nonexistentWordCount = -2;
            TestDelegate GetWordsFromNonexistentCategory = () => SQLService.Get_Words_FromCategory(2, nonexistentWordCount);

            ClassicAssert.Catch(typeof(ArgumentException), GetWordsFromNonexistentCategory, 
                "Тут повинне виникати виключення, а не виникає");
        }

        #endregion

        #endregion

        #region [ Settings ]

        #region Setting Current category

        [TestCase(2)]
        [TestCase(1)]
        public void CurrentCategory_SettingAndGetting_Test(int categoryID)
        {
            SQLService.Set_CurrentCategory(categoryID);        //Налаштування значення CurrentCategoryID в Settings

            using VocabularyContext db = new(conStr);

            //Перевірки
            var actualCurrentCategoryID = db.Settings.First(s => s.SettingsId == 1).CurrentCategoryId;
            ClassicAssert.AreEqual(categoryID, actualCurrentCategoryID,
                "CurrentCategoryID НЕ встановлене із необхідним значенням");

            int gettedCurrentCategoryID = SQLService.Get_CurrentCategory();   //Отримання значення CurrentCategoryID в Settings
            int expectedCurrentCategoryID = actualCurrentCategoryID;    //зміна призначення змінної
            ClassicAssert.AreEqual(expectedCurrentCategoryID, gettedCurrentCategoryID,
                "Отримане значення CurrentCategoryID - НЕ вірне");
        }

        [Test]
        public void AllCategories_Getting_Test()
        {
            var categories = SQLService.Get_Categories();
            ClassicAssert.AreEqual("AllWords", categories[0].Name,
                "Отриманий список інформації про категорії - НЕ вірний");
        }
        #endregion

        #region Setting Number of Words to Learn

        [TestCase(1)]
        [TestCase(99)]
        public void NumberOfWordsToLearn_SettingAndGetting_Test(int count)
        {
            SQLService.Set_NumberOfWordsToLearn(count);        //Налаштування значення WordCountToLearn в Settings

            using VocabularyContext db = new(conStr);

            //Перевірки
            var actualNumberOfWordsToLearn = db.Settings.First().WordCountToLearn;
            ClassicAssert.AreEqual(count, actualNumberOfWordsToLearn,
                "WordCountToLearn НЕ встановлене із необхідним значенням");

            int gettedNumberOfWordsToLearn = SQLService.Get_NumberOfWordsToLearn();   //Отримання значення WordCountToLearn в Settings
            int expectedNumberOfWordsToLearn = actualNumberOfWordsToLearn;     //зміна призначення змінної
            ClassicAssert.AreEqual(expectedNumberOfWordsToLearn, gettedNumberOfWordsToLearn,
                "Отримане значення WordCountToLearn - НЕ вірне");
        }

        [TestCase(0)]
        [TestCase(-12)]
        public void NumberOfWordsToLearn_NOTSettingBelowOne_Test(int count)
        {
            //Налаштування значення CurrentCategoryID в Settings
            TestDelegate SetNumberOfWordsForFalseNumber = () => SQLService.Set_NumberOfWordsToLearn(count);
            ClassicAssert.Catch(typeof(ArgumentException), SetNumberOfWordsForFalseNumber,
                "Тут повинне виникати виключення, а не виникає");

            int gettedNumberOfWordsToLearn = SQLService.Get_NumberOfWordsToLearn();   //Отримання значення WordCountToLearn в Settings
            ClassicAssert.AreNotEqual(count, gettedNumberOfWordsToLearn,
                "Отримане значення WordCountToLearn - НЕ повинне було змінюватися");
        }

        #endregion

        #region Setting Was Launched

        [TestCase(true)]
        [TestCase(false)]
        public void WasLaunched_SettingAndGetting_Test(bool wasLaunched)
        {
            SQLService.Set_WasLaunched(wasLaunched);        //Налаштування значення WasLaunched в Settings

            using VocabularyContext db = new(conStr);

            //Перевірки
            var actualWasLaunched = db.Settings.First().WasLaunched;
            ClassicAssert.AreEqual(wasLaunched, actualWasLaunched,
                "WasLaunched НЕ встановлене із необхідним значенням");

            var gettedWasLaunched = SQLService.WasLaunched();     //Отримання значення WasLaunched в Settings
            var expectedWasLaunched = actualWasLaunched;    //зміна призначення змінної
            ClassicAssert.AreEqual(expectedWasLaunched, gettedWasLaunched,
                "Отримане значення WasLaunched - НЕ вірне");
        }

        #endregion

        #region Setting Number of Words to Learn

        [TestCase(1)]
        [TestCase(99)]
        public void WordAddingMode_SettingAndGetting_Test(int count)
        {
            SQLService.Set_WordAddingMode(count);        //Налаштування значення WordAddingMode в Settings

            using VocabularyContext db = new(conStr);

            //Перевірки
            var actualWordAddingMode = db.Settings.First().WordAddingMode;
            ClassicAssert.AreEqual(count, actualWordAddingMode,
                "WordAddingMode НЕ встановлене із необхідним значенням");

            var gettedWordAddingMode = SQLService.Get_WordAddingMode();   //Отримання значення WordAddingMode в Settings
            var expectedWordAddingMode = actualWordAddingMode;     //зміна призначення змінної
            ClassicAssert.AreEqual(expectedWordAddingMode, gettedWordAddingMode,
                "Отримане значення WordAddingMode - НЕ вірне");
        }

        [TestCase(-1)]
        [TestCase(-12)]
        public void WordAddingMode_NOTSettingBelowOne_Test(int count)
        {
            //Налаштування значення WordAddingMode в Settings
            TestDelegate SetNonexistentWordAddingMode = () => SQLService.Set_WordAddingMode(count);
            ClassicAssert.Catch(typeof(ArgumentException), SetNonexistentWordAddingMode,
                "Тут повинне виникати виключення, а не виникає");

            int gettedWordAddingMode = SQLService.Get_WordAddingMode();   //Отримання значення WordAddingMode в Settings
            ClassicAssert.AreNotEqual(count, gettedWordAddingMode,
                "Отримане значення WordCountToLearn - НЕ повинне було змінюватися");
        }

        #endregion

        #endregion

        //TODO - Додавати ТЕСТИ ...


        [TearDown]
        public void TearDown()
        {
            using VocabularyContext db = new();
            db.WordCategories.RemoveRange(db.WordCategories.Skip(2));
            db.AllWords.RemoveRange(db.AllWords.Skip(2));
            db.Categories.RemoveRange(db.Categories.Skip(2));
            db.Settings.First().WordCountToLearn = 5;
            db.SaveChanges();
        }
    }
}