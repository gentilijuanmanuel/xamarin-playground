using System.ComponentModel;
using Android.Graphics;
using Android.Util;
using Android.Views;
using ParallaxCarousel.Controls;
using ParallaxCarousel.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedContentView), typeof(RoundedContentViewRenderer))]
namespace ParallaxCarousel.Droid.Renderers
{
    public class RoundedContentViewRenderer : VisualElementRenderer<ContentView>
    {
        private float cornerRadius;
        private bool hasBackgroundGradient;
        private Xamarin.Forms.Color startColor;
        private Xamarin.Forms.Color endColor;

        public RoundedContentViewRenderer(Android.Content.Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
                return;

            var element = (RoundedContentView)this.Element;

            this.startColor = element.GradientStartColor;
            this.endColor = element.GradientEndColor;
            this.hasBackgroundGradient = element.HasBackgroundGradient;

            this.cornerRadius = TypedValue.ApplyDimension(ComplexUnitType.Dip, element.CornerRadius, Context.Resources.DisplayMetrics);
            this.OutlineProvider = new RoundedCornerOutlineProvider(this.cornerRadius);
            this.ClipToOutline = true;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var element = (RoundedContentView)this.Element;

            if (e.PropertyName == RoundedContentView.HasShadowProperty.PropertyName)
            {
                this.Elevation = element.HasShadow ? 40 : 0;
                this.TranslationZ = 0;
            }
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            var bounds = new RectF(0, 0, Width, Height);

            if (this.hasBackgroundGradient)
            {
                var fillPaint = new Paint(PaintFlags.AntiAlias);
                var shader = new LinearGradient(0, 0, 0, this.Height, this.startColor.ToAndroid(), this.endColor.ToAndroid(), Shader.TileMode.Clamp);
                fillPaint.SetShader(shader);
                canvas.DrawRect(bounds, fillPaint);
            }

            base.DispatchDraw(canvas);
        }
    }

    public class RoundedCornerOutlineProvider : ViewOutlineProvider
    {
        float roundCorner;

        public RoundedCornerOutlineProvider(float round)
        {
            this.roundCorner = round;
        }

        public override void GetOutline(Android.Views.View view, Outline outline)
        {
            outline.SetRoundRect(0, 0, view.Width, view.Height, roundCorner);
        }
    }
}

