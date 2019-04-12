using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ParallaxCarousel.ViewModels
{
    public class CarouselWrapper : INotifyPropertyChanged
    {
        public List<CarouselItem> Items { get; set; } = new List<CarouselItem>();

        private double _slidePosition;

        public double SlidePosition
        {
            get => _slidePosition;
            set
            {
                if(_slidePosition != value)
                {
                    _slidePosition = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
