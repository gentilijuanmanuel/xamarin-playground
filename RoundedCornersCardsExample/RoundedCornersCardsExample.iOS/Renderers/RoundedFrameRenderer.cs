using System.ComponentModel;
using System.Drawing;
using CoreAnimation;
using CoreGraphics;
using RoundedCornersCardsExample.Controls;
using RoundedCornersCardsExample.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedFrame), typeof(RoundedFrameRenderer))]
namespace RoundedCornersCardsExample.iOS.Renderers
{
    public class RoundedFrameRenderer : VisualElementRenderer<Frame>
    {
        private RoundedFrame element;

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (element != null)
                return;

            element = (RoundedFrame)e.NewElement;

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
            float cornerRadius = ((RoundedFrame)this.Element).CornerRadius;

            if (cornerRadius == -1f)
                cornerRadius = 5f;

            this.Layer.CornerRadius = cornerRadius;

            if (((RoundedFrame)this.Element).HasShadow)
            {
                this.Layer.ShadowRadius = 10;
                Layer.ShadowColor = UIColor.Black.CGColor;
                Layer.ShadowOpacity = 0.4f;
                Layer.ShadowOffset = new SizeF();

                Layer.RasterizationScale = UIScreen.MainScreen.Scale;
                Layer.ShouldRasterize = true;
            }
        }

        private RoundedFrame FormsControl
        {
            get { return Element as RoundedFrame; }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Xamarin.Forms.Frame.CornerRadiusProperty.PropertyName)
                this.Layer.CornerRadius = (float)FormsControl.CornerRadius;

            if (e.PropertyName == Xamarin.Forms.Frame.HasShadowProperty.PropertyName)
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
