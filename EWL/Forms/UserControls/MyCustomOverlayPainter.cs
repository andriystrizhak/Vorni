using DevExpress.Utils.Drawing;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eng_Flash_Cards_Learner.Forms.UserControls
{
    internal class MyCustomOverlayPainter : OverlayWindowPainterBase
    {
            static MyCustomOverlayPainter() { }
        protected override void Draw(OverlayWindowCustomDrawContext context)
        {
            context.Handled = true;
            context.DrawBackground();
        }
    }
}
