using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinLoginUI.Controls;
using XamarinLoginUI.iOS.Controls;

[assembly: ExportRenderer(typeof(GradientContentPage), typeof(GradientContentPageRenderer))]
namespace XamarinLoginUI.iOS.Controls
{
    public class GradientContentPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null) return;
            if (e.NewElement is GradientContentPage page)
            {
                var gradientLayer = new CAGradientLayer
                {
                    Frame = View.Bounds,
                    Colors = new CGColor[] { page.StartColor.ToCGColor(), page.EndColor.ToCGColor() }
                };
                View.Layer.InsertSublayer(gradientLayer, 0);
            }
        }
    }
}