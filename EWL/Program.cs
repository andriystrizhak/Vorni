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

            if (!SQLService.WasLaunched())
                Application.Run(new SetUpForm());
            else if (SQLService.WasLaunched())
                Application.Run(new MainForm());
        }

        static void ShowFluentSplashScreen()
        {
            var img = new Bitmap(Resource1.Frame_4);

            SplashScreenManager.ShowImage(
                image: img, 
                useFadeIn: true, 
                useFadeOut: true, 
                startPos: SplashFormStartPosition.CenterScreen,
                location: new Point());

            ImageAnimator.Animate(SplashScreenManager.Default.Properties.ImageOptions.Image, OnFrameChanged);

            /*
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
            */
        }

        private static void OnFrameChanged(object sender, EventArgs e)
        {
            for (int i = 1; i <= 11; i++)
            {
                System.Threading.Thread.Sleep(20);
                if (SplashScreenManager.Default != null)
                {
                    SplashScreenManager.Default.Invalidate();
                }
            }
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
