using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RoundedCornersCardsExample.ViewModels.Items;

namespace RoundedCornersCardsExample.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            this.Cards = new List<Card>
            {
                new Card { Title = "Card 1" },
                new Card { Title = "Card 2" },
                new Card { Title = "Card 3" },
                new Card { Title = "Card 4" },
                new Card { Title = "Card 5" },
                new Card { Title = "Card 6" }
            };
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
