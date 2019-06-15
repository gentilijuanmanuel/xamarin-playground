using System.ComponentModel;
using System.Drawing;
using CoreAnimation;
using CoreGraphics;
using ParallaxCarousel.Controls;
using ParallaxCarousel.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedContentView), typeof(RoundedContentViewRenderer))]
namespace ParallaxCarousel.iOS.Renderers
{
    public class RoundedContentViewRenderer : VisualElementRenderer<ContentView>
    {
        private RoundedContentView element;

        protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
        {
            base.OnElementChanged(e);

            if (element != null)
                return;

            element = (RoundedContentView)e.NewElement;

            this.SetupCorners();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            float cornerRadius = element.CornerRadius;

            if (cornerRadius == -1f)
                cornerRadius = 5f;

            if (element != null && element.HasBackgroundGradient)
            {
                var gradientLayer = new CAGradientLayer
                {
                    CornerRadius = cornerRadius,
                    Frame = this.NativeView.Bounds,
                    Colors = new CGColor[]
                    {
                        element.GradientStartColor.ToCGColor(),
                        element.GradientEndColor.ToCGColor()
                    }
                };

                this.NativeView.Layer.InsertSublayer(gradientLayer, 0);
            }
        }

        private void SetupCorners()
        {
            float cornerRadius = ((RoundedContentView)this.Element).CornerRadius;

            if (cornerRadius == -1f)
                cornerRadius = 5f;

            this.Layer.CornerRadius = cornerRadius;

            if (((RoundedContentView)this.Element).HasShadow)
            {
                this.Layer.ShadowRadius = 10;
                Layer.ShadowColor = UIColor.Black.CGColor;
                Layer.ShadowOpacity = 0.4f;
                Layer.ShadowOffset = new SizeF();

                Layer.RasterizationScale = UIScreen.MainScreen.Scale;
                Layer.ShouldRasterize = true;
            }
        }

        private RoundedContentView FormsControl
        {
            get { return Element as RoundedContentView; }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedContentView.CornerRadiusProperty.PropertyName)
                this.Layer.CornerRadius = (float)FormsControl.CornerRadius;

            if (e.PropertyName == RoundedContentView.HasShadowProperty.PropertyName)
            {
                if (FormsControl.HasShadow)
                {
                    this.Layer.ShadowRadius = 10;
                    this.Layer.ShadowColor = UIColor.Black.CGColor;
                    this.Layer.ShadowOpacity = 0.4f;
                    this.Layer.ShadowOffset = new SizeF();

                    this.Layer.RasterizationScale = UIScreen.MainScreen.Scale;
                    this.Layer.ShouldRasterize = true;
                }
                else
                {
                    this.Layer.ShadowRadius = 0;
                    this.Layer.ShadowOpacity = 0;
                }
            }
        }
    }
}
