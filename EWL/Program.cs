using EWL.EF_SQLite;
using EWL .NOT_Forms;
using SQLitePCL;

namespace EWL
{
    internal static class Program
    {
        public static LearningMode Mode { get; set; } = LearningMode.DataBase;
        public static DB_SQLite DB { get; set; } = new("Data Source=.\\Vocabulary.db;Version=3;");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            if (!DB.WasLaunched())
                Application.Run(new SetUpForm());
            if (Mode == LearningMode.DataBase)
                Application.Run(new MainForm());
        }
    }
} 