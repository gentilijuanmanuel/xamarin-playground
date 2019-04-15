using BitcoinOnboardingApp.iOS.Renderers;
using BitcoinOnboardingApp.UI.Controls;
using CoreAnimation;
using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientStackLayout), typeof(GradientStackLayoutRenderer))]
namespace BitcoinOnboardingApp.iOS.Renderers
{
    public class GradientStackLayoutRenderer : VisualElementRenderer<StackLayout>
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            var stack = (GradientStackLayout)this.Element;
            CGColor startColor = stack.StartColor.ToCGColor();

            CGColor endColor = stack.EndColor.ToCGColor();

            var gradientLayer = new CAGradientLayer
            {
                Frame = rect,
                Colors = new CGColor[] { startColor, endColor }
            };

            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}
