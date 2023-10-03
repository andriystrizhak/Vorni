using EWL.EF_SQLite;
using EWL .NOT_Forms;
using SQLitePCL;

namespace EWL
{
    internal static class Program
    {
        public static LearningMode Mode { get; set; } = LearningMode.DataBase;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            SQLs.CS = "Data Source=.\\Vocabulary.db;";

            if (!SQLs.WasLaunched())
                Application.Run(new SetUpForm());
            if (Mode == LearningMode.DataBase)
                Application.Run(new MainForm());
        }
    }
} 