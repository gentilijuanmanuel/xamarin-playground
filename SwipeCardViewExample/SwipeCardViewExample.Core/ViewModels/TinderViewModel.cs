using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using SwipeCardViewExample.Core.Models;

namespace SwipeCardViewExample.Core.ViewModels
{
    public class TinderViewModel : MvxViewModel
    {
        //Private properties

        //Constructor
        public TinderViewModel()
        {
            this.InitializeProfiles();

            this.InitializeCommands();
        }

        //MvvmCross lifecycle
        public override Task Initialize()
        {
            //Mvxinteraction to the code behind
            //Threshold = (uint)(App.ScreenWidth / 3);

            return base.Initialize();
        }

        //Properties
        private ObservableCollection<Profile> _profiles = new ObservableCollection<Profile>();
        public ObservableCollection<Profile> Profiles
        {
            get => _profiles;
            set
            {
                _profiles = value;
                RaisePropertyChanged();
            }
        }

        private uint _threshold;
        public uint Threshold
        {
            get => _threshold;
            set
            {
                _threshold = value;
                RaisePropertyChanged();
            }
        }

        //Commands
        public ICommand SwipedCommand { get; private set; }

        public ICommand DraggingCommand { get; private set; }

        public ICommand ClearItemsCommand { get; private set; }

        public ICommand AddItemsCommand { get; private set; }

        //Private methods
        private void InitializeProfiles()
        {
            this.Profiles.Add(new Profile { ProfileId = 1, Name = "Laura", Age = 24, Gender = Gender.Female, Photo = "p705193.jpg" });
            this.Profiles.Add(new Profile { ProfileId = 2, Name = "Sophia", Age = 21, Gender = Gender.Female, Photo = "p597956.jpg" });
            this.Profiles.Add(new Profile { ProfileId = 3, Name = "Anne", Age = 19, Gender = Gender.Female, Photo = "p497489.jpg" });
            this.Profiles.Add(new Profile { ProfileId = 4, Name = "Yvonne ", Age = 27, Gender = Gender.Female, Photo = "p467499.jpg" });
            this.Profiles.Add(new Profile { ProfileId = 5, Name = "Abby", Age = 25, Gender = Gender.Female, Photo = "p589739.jpg" });
            this.Profiles.Add(new Profile { ProfileId = 6, Name = "Andressa", Age = 28, Gender = Gender.Female, Photo = "p453095.jpg" });
            this.Profiles.Add(new Profile { ProfileId = 7, Name = "June", Age = 29, Gender = Gender.Female, Photo = "p503001.jpg" });
            this.Profiles.Add(new Profile { ProfileId = 8, Name = "Kim", Age = 22, Gender = Gender.Female, Photo = "p627958.jpg" });
            this.Profiles.Add(new Profile { ProfileId = 9, Name = "Denesha", Age = 26, Gender = Gender.Female, Photo = "p474893.jpg" });
            this.Profiles.Add(new Profile { ProfileId = 10, Name = "Sasha", Age = 23, Gender = Gender.Female, Photo = "p458914.jpg" });

            this.Profiles.Add(new Profile { ProfileId = 11, Name = "Austin", Age = 28, Gender = Gender.Male, Photo = "p378674.jpg" });
            this.Profiles.Add(new Profile { ProfileId = 11, Name = "James", Age = 32, Gender = Gender.Male, Photo = "p398931.jpg" });
            this.Profiles.Add(new Profile { ProfileId = 11, Name = "Chris", Age = 27, Gender = Gender.Male, Photo = "p401107.jpg" });
            this.Profiles.Add(new Profile { ProfileId = 11, Name = "Alexander", Age = 30, Gender = Gender.Male, Photo = "p731150.jpg" });
            this.Profiles.Add(new Profile { ProfileId = 11, Name = "Steve", Age = 31, Gender = Gender.Male, Photo = "p327144.jpg" });
        }

        private void InitializeCommands()
        {
            this.SwipedCommand = new MvxCommand(this.Swipe);
            this.DraggingCommand = new MvxCommand(this.Drag);
            this.ClearItemsCommand = new MvxCommand(this.ClearItems);
            this.AddItemsCommand = new MvxCommand(this.AddItems);
        }

        private void Swipe()
        { 
        }

        private void Drag()
        {
            //MvxInteraction to the code behind
        }

        private void ClearItems()
        {
            this.Profiles.Clear();
        }

        private void AddItems()
        {
        }
    }
}
