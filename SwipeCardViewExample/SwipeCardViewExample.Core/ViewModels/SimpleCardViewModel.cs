using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace SwipeCardViewExample.Core.ViewModels
{
    public class SimpleCardViewModel : MvxViewModel
    {
        //Private properties

        //Constructor
        public SimpleCardViewModel()
        {
            this.InitializeCards();

            //TODO: implement with MVxInteraction
            //this.SwipedCommand = new MvxCommand<SwipedCardEventArgs>(this.Swipe);

            this.SwipedCommand = new MvxCommand(this.Swipe);

            this.ClearItemsCommand = new MvxCommand(this.ClearItems);
            this.AddItemsCommand = new MvxCommand(this.AddItems);
        }

        //MvvmCross lifecycle

        //Properties
        private ObservableCollection<string> cardItems;
        public ObservableCollection<string> CardItems
        {
            get => cardItems;
            set
            {
                cardItems = value;
                this.RaisePropertyChanged();
            }
        }

        private string message;
        public string Message
        {
            get => message;
            set
            {
                message = value;
                this.RaisePropertyChanged();
            }
        }

        //Commands
        public ICommand SwipedCommand { get; }

        public ICommand ClearItemsCommand { get; }

        public ICommand AddItemsCommand { get; }

        //Private methods
        private void InitializeCards()
        {
            this.CardItems = new ObservableCollection<string>();
            for (var i = 1; i <= 5; i++)
                this.CardItems.Add($"Card {i}");
        }

        private void ClearItems()
        {
            this.CardItems.Clear();
            this.Message = string.Empty;
        }

        private void AddItems()
        {
            for (var i = 1; i <= 5; i++)
            {
                this.CardItems.Add($"Card {i}");
            }
        }

        private void Swipe()
        {
             
        }
    }
}
