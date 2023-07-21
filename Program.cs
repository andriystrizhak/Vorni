using Eng_Flash_Cards_Learner.Logic;

namespace Eng_Flash_Cards_Learner
{
    internal static class Program
    {
        public static LearningMode mode { get; set; } = LearningMode.DataBase;
        public static DB_SQLite db { get; set; } = new DB_SQLite();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            if (!db.WasLaunched())
                Application.Run(new SetUpForm());
            if (mode == LearningMode.DataBase)
                Application.Run(new MainBDForm());
        }
    }
}