
using System.ComponentModel;
using ParallaxCarousel.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ScrollView), typeof(CarouselScrollViewRenderer))]
namespace ParallaxCarousel.iOS.Renderers
{
    public class CarouselScrollViewRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= this.OnElementPropertyChanged;

            e.NewElement.PropertyChanged += this.OnElementPropertyChanged;
        }

        private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.ShowsHorizontalScrollIndicator = false;
            this.ShowsVerticalScrollIndicator = false;
            this.Bounces = false;
        }
    }
}
