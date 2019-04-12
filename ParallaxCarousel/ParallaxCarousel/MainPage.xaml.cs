using System.Collections.Generic;
using System.Linq;
using CarouselView.FormsPlugin.Abstractions;
using ParallaxCarousel.ViewModels;
using Xamarin.Forms;

namespace ParallaxCarousel
{
    public partial class MainPage : ContentPage
    {
        private int _currentIndex;
        private List<Color> _backgroundColors = new List<Color>();

        public CarouselWrapper Wrapper { get; set; }

        public MainPage()
        {
            InitializeComponent();

            this.Wrapper = new CarouselWrapper
            {
                Items = new List<CarouselItem>
                {
                    new CarouselItem
                    {
                        Position = 0,
                        Type = "JUICY AND ORANGE",
                        ImageSrc = "oranges.png",
                        Name = "ORANGE AWESOMENESS",
                        Price = 120,
                        Title = "ORANGE AWESOMENESS",
                        BackgroundColor = Color.FromHex("#9866d5"),
                        StartColor = Color.FromHex("#f3463f"),
                        EndColor=Color.FromHex("#fece49")
                    },
                    new CarouselItem
                    {
                        Position = 0,
                        Type = "NOT A TYPICAL FRUIT",
                        ImageSrc = "tomato.png",
                        Name = "TERRIBLE TOMATO",
                        Price = 129,
                        Title = "TERRIBLE TOMATO",
                        BackgroundColor = Color.FromHex("#fab62a"),
                        StartColor = Color.FromHex("#42a7ff"),
                        EndColor=Color.FromHex("#fab62a")
                    },
                    new CarouselItem
                    {
                        Position=0,
                        Type="SWEET AND GREEN",
                        ImageSrc="pear.png",
                        Name = "PEAR PARTY",
                        Price = 140,
                        Title = "PEAR PARTY",
                        BackgroundColor = Color.FromHex("#425cfc"),
                        StartColor = Color.FromHex("#33ccf3"),
                        EndColor=Color.FromHex("#ccee44")
                    }
                }
            };

            this.BindingContext = this.Wrapper;

            for (int i = 0; i < this.Wrapper.Items.Count; i++)
            {
                var current = this.Wrapper.Items[i];

                var next = this.Wrapper.Items.Count > i + 1 ? this.Wrapper.Items[i + 1] : null;


                if (next != null)
                    this._backgroundColors.AddRange(SetGradients(current.BackgroundColor, next.BackgroundColor, 100));
                else
                    this._backgroundColors.Add(current.BackgroundColor);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.page.BackgroundColor = this._backgroundColors.First();
        }

        public void Handle_PositionSelected(object sender, PositionSelectedEventArgs e)
        {
            this._currentIndex = e.NewValue;
            this.Wrapper.SlidePosition = 0;
        }

        public void Handle_Scrolled(object sender, CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs e)
        {
            int position = 0;

            if (e.Direction == ScrollDirection.Right)
                position = (int)((this._currentIndex * 100) + e.NewValue);
            else if (e.Direction == ScrollDirection.Left)
                position = (int)((this._currentIndex * 100) - e.NewValue);

            if (position > this._backgroundColors.Count - 1)
                this.page.BackgroundColor = this._backgroundColors.Last();
            else if (position < 0)
                this.page.BackgroundColor = this._backgroundColors.First();
            else
                this.page.BackgroundColor = this._backgroundColors[position];

            this.Wrapper.SlidePosition = e.NewValue;

            if (e.Direction == ScrollDirection.Right)
            {
                this.Wrapper.Items[this._currentIndex].Position = - this.Wrapper.SlidePosition;

                if (this._currentIndex < this.Wrapper.Items.Count - 1)
                {
                    this.Wrapper.Items[this._currentIndex + 1].Position = 100 - this.Wrapper.SlidePosition;
                }
            }
            else if (e.Direction == ScrollDirection.Left)
            {
                this.Wrapper.Items[_currentIndex].Position = this.Wrapper.SlidePosition;

                if (this._currentIndex > 0)
                {
                    this.Wrapper.Items[_currentIndex - 1].Position = -100 + this.Wrapper.SlidePosition;
                }
            }
        }

        public static IEnumerable<Color> SetGradients(Color start, Color end, int steps)
        {
            var colorList = new List<Color>();

            double aStep = ((end.A * 255) - (start.A * 255)) / steps;
            double rStep = ((end.R * 255) - (start.R * 255)) / steps;
            double gStep = ((end.G * 255) - (start.G * 255)) / steps;
            double bStep = ((end.B * 255) - (start.B * 255)) / steps;

            for (int i = 0; i < 100; i++)
            {
                var a = (start.A * 255) + (int)(aStep * i);
                var r = (start.R * 255) + (int)(rStep * i);
                var g = (start.G * 255) + (int)(gStep * i);
                var b = (start.B * 255) + (int)(bStep * i);

                colorList.Add(Color.FromRgba(r / 255, g / 255, b / 255, a / 255));
            }

            return colorList;
        }
    }
}
