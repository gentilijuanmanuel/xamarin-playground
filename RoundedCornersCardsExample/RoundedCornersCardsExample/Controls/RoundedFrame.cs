using Xamarin.Forms;

namespace RoundedCornersCardsExample.Controls
{
    public class RoundedFrame : Frame
    {
        public static readonly BindableProperty ShadowElevationProperty = BindableProperty.Create(
            nameof(ShadowElevation),
            typeof(float),
            typeof(RoundedFrame),
            40f
        );

        public float ShadowElevation
        {
            get => (float)GetValue(ShadowElevationProperty);
            set => SetValue(ShadowElevationProperty, value);
        }

        public static readonly BindableProperty ShadowTranslationZProperty = BindableProperty.Create(
            nameof(ShadowTranslationZ),
            typeof(float),
            typeof(RoundedFrame),
            0f
        );

        public float ShadowTranslationZ
        {
            get => (float)GetValue(ShadowTranslationZProperty);
            set => SetValue(ShadowTranslationZProperty, value);
        }

        public static readonly BindableProperty HasBackgroundGradientProperty = BindableProperty.Create(
            nameof(HasBackgroundGradient),
            typeof(bool),
            typeof(RoundedFrame),
            default(bool)
        );

        public bool HasBackgroundGradient
        {
            get => (bool)GetValue(HasBackgroundGradientProperty);
            set => SetValue(HasBackgroundGradientProperty, value);
        }

        public static readonly BindableProperty GradientStartColorProperty = BindableProperty.Create(
            nameof(GradientStartColor),
            typeof(Color),
            typeof(RoundedFrame),
            default(Color)
        );

        public Color GradientStartColor
        {
            get => (Color)GetValue(GradientStartColorProperty);
            set => SetValue(GradientStartColorProperty, value);
        }

        public static readonly BindableProperty GradientEndColorProperty = BindableProperty.Create(
            nameof(GradientEndColor),
            typeof(Color),
            typeof(RoundedFrame),
            default(Color)
        );

        public Color GradientEndColor
        {
            get => (Color)GetValue(GradientEndColorProperty);
            set => SetValue(GradientEndColorProperty, value);
        }
    }
}
