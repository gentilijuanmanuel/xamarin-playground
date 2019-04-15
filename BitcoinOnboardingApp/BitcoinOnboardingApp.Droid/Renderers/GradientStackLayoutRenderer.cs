using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.V4.View;
using BitcoinOnboardingApp.Droid.Renderers;
using BitcoinOnboardingApp.UI.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientStackLayout), typeof(GradientStackLayoutRenderer))]
namespace BitcoinOnboardingApp.Droid.Renderers
{
    public class GradientStackLayoutRenderer : VisualElementRenderer<StackLayout>
    {
        public GradientStackLayoutRenderer(Context context)
            : base(context)
        {
        }

        private Color StartColor { get; set; }
        private Color EndColor { get; set; }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            try
            {
                var stack = e.NewElement as GradientStackLayout;
                this.StartColor = stack.StartColor;
                this.EndColor = stack.EndColor;

                var gradient = new GradientDrawable(
                    GradientDrawable.Orientation.TopBottom,
                    new[] { this.StartColor.ToAndroid().ToArgb(), this.EndColor.ToAndroid().ToArgb() }
                );

                ViewCompat.SetBackground(this, gradient);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
            }
        }
    }
}
