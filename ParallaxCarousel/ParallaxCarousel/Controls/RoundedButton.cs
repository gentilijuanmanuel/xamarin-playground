using Xamarin.Forms;

namespace ParallaxCarousel.Controls
{
    public class RoundedButton : Button
    {
        private bool measured;
        private bool self;

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            if (!this.self)
                this.measured = true;
            return base.OnMeasure(widthConstraint, heightConstraint);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (this.measured)
            {
                this.measured = false;
                this.self = true;

                this.WidthRequest = width + this.Padding.Left + this.Padding.Right;
                this.HeightRequest = height + this.Padding.Top + this.Padding.Bottom;
            }
            else
                this.self = false;
        }
    }
}

