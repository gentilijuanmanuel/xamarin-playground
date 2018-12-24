using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using SwipeCardViewExample.Core.Parameters;

namespace SwipeCardViewExample.Core.ViewModels
{
    public class SimpleCardViewModel : MvxViewModel
    {
        //Private properties

        //Constructor
        public SimpleCardViewModel()
        {
            this.InitializeCards();

            this.SwipedCommand = new MvxCommand<SwipedDirection>(this.Swipe);

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
        public MvxCommand<SwipedDirection> SwipedCommand { get; }

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
                this.CardItems.Add($"Card {i}");
        }

        private void Swipe(SwipedDirection swipedDirection)
        {
             this.Message = $"{swipedDirection.Item} swiped {swipedDirection.Direction}";
        }
    }
}
