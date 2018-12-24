using System;
using System.Globalization;
using MLToolkit.Forms.SwipeCardView.Core;
using SwipeCardViewExample.Core.Parameters;
using Xamarin.Forms;

namespace SwipeCardViewExample.Forms.UI.Converters
{
    public class SwipedCardEventArgsToStringsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var swipedCardEventArgs = (SwipedCardEventArgs)value;

            var swipedDirection = new SwipedDirection(swipedCardEventArgs.Item.ToString(), swipedCardEventArgs.Direction.ToString());

            return swipedDirection;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
