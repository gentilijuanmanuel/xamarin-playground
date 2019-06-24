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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
