using DevExpress.DashboardExport.Map;
using DevExpress.Utils.Text;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eng_Flash_Cards_Learner.Forms.UserControls
{
    internal class SplashImagePainter : ICustomImagePainter
    {
        static SplashImagePainter()
        {
            Painter = new SplashImagePainter();
        }
        protected SplashImagePainter() { }
        public static SplashImagePainter Painter { get; private set; }

        ViewInfo info = null;
        public ViewInfo ViewInfo
        {
            get
            {
                if (this.info == null) this.info = new ViewInfo();
                return this.info;
            }
        }

        #region Drawing
        public void Draw(GraphicsCache cache, Rectangle bounds)
        {
            PointF pt = ViewInfo.CalcProgressLabelPoint(cache, bounds);
            //cache.Graphics.DrawString(ViewInfo.Text, ViewInfo.ProgressLabelFont, ViewInfo.Brush, pt);
        }

        void ICustomImagePainter.Draw(DevExpress.Utils.Drawing.GraphicsCache cache, Rectangle bounds)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    class ViewInfo
    {
        public ViewInfo()
        {
            Counter = 1;
            Stage = string.Empty;
        }

        public int Counter { get; set; }
        public string Stage { get; set; }

        public PointF CalcProgressLabelPoint(GraphicsCache cache, Rectangle bounds)
        {

            const int yOffset = 40;
            //Size size = TextUtils.GetStringSize(cache.Graphics, Text, ProgressLabelFont);
            Size size = new Size(0, 0); //REMOVE
            return new Point(bounds.Width / 2 - size.Width / 2, yOffset);
        }
        Font progressFont = null;
        public Font ProgressLabelFont
        {
            get
            {
                if (this.progressFont == null) this.progressFont = new Font("Consolas", 10);
                return this.progressFont;
            }
        }
        Brush brush = null;
        public Brush Brush
        {
            get
            {
                if (this.brush == null) this.brush = new SolidBrush(Color.Black);
                return this.brush;
            }
        }
        public string Text { get { return string.Format("{0} - ({1}%)", Stage, Counter.ToString("D2")); } }
    }
}
