using DevExpress.XtraSplashScreen;
using Eng_Flash_Cards_Learner.NOT_Forms.GPT;
using Eng_Flash_Cards_Learner.NOT_Forms;
using EWL.EF_SQLite;
using EWL .NOT_Forms;
using SQLitePCL;
using System.Drawing.Drawing2D;
using Eng_Flash_Cards_Learner.NOT_Forms.LearningItems;

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

            ShowFluentSplashScreen();

            if (!SQLs.WasLaunched())
                Application.Run(new SetUpForm());
            if (SQLs.WasLaunched())
                Application.Run(new MainForm());
        }

        static void ShowFluentSplashScreen()
        {
            var ssOptions = new FluentSplashScreenOptions();
            //ssOptions.LogoImageOptions.Image = null;
            ssOptions.Title = "English Words Learner";
            ssOptions.Subtitle = "Learn words you want!";
            ssOptions.RightFooter = "Starting...";
            ssOptions.LeftFooter = "@andriy_strizhak";
            ssOptions.LoadingIndicatorType = FluentLoadingIndicatorType.Dots;
            ssOptions.Opacity = 100;

            SplashScreenManager.ShowFluentSplashScreen
                (ssOptions, customDrawEventHandler: FluentSplashScreenDraw, useFadeIn: true, useFadeOut: true);

            /*
            SplashScreenManager.ShowFluentSplashScreen(
                "English Words Learner",
                "Learn words you want!",
                "@andriy_strizhak",
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
            */
        }

        static void FluentSplashScreenDraw(object sender, FluentSplashScreenCustomDrawEventArgs e)
        {
            var linGrBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(e.Bounds.Height + 1200, e.Bounds.Width),
                Color.FromArgb(100, 24, 27, 32),
                Color.FromArgb(100, 170, 101, 254));
            e.Cache.FillRectangle(linGrBrush, e.Bounds);
        }
    }
}
