using DevExpress.XtraSplashScreen;
using Eng_Flash_Cards_Learner.NOT_Forms.GPT;
using Eng_Flash_Cards_Learner.NOT_Forms;
using Eng_Flash_Cards_Learner;
using EWL.EF_SQLite;
using EWL .NOT_Forms;
using SQLitePCL;
using System.Drawing.Drawing2D;
using Eng_Flash_Cards_Learner.NOT_Forms.LearningItems;
using DevExpress.Utils.Svg;
using System.Windows.Forms;
using System.Reflection;
using Eng_Flash_Cards_Learner.Forms.UserControls;

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
            SQLService.CS = "Data Source=.\\Vocabulary.db;";

            ShowFluentSplashScreen();

            //if (!SQLService.WasLaunched())
            //    Application.Run(new SetUpForm());
            //else if (SQLService.WasLaunched())
                Application.Run(new MainForm());
        }

        static void ShowFluentSplashScreen()
        {
            SplashScreenManager.ShowForm(typeof(CustomSplashScreen));
        }
    }
}
