using DevExpress.XtraSplashScreen;
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

            SplashScreenManager.ShowFluentSplashScreen(
                "English Words Learner", 
                "Learn words you want!", 
                null, 
                "Starting...", 
                85, 
                Color.FromArgb(21, 24, 28), 
                FluentLoadingIndicatorType.Dots, 
                null, 
                null, 
                null, 
                true, 
                true, 
                true, 
                SplashFormStartPosition.CenterScreen);

            if (!SQLs.WasLaunched())
                Application.Run(new SetUpForm());
            if (SQLs.WasLaunched())
                Application.Run(new MainForm());
        }
    }
} 