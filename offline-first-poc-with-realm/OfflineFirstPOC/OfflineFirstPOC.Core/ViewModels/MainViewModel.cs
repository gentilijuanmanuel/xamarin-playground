using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using Realms;
using OfflineFirstPOC.Core.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using Realms.Sync;
using System;

namespace OfflineFirstPOC.Core.ViewModels
{
    //https://fakerestapi.azurewebsites.net/swagger/ui/index#!/Books/Books_Get
    public class MainViewModel : INotifyPropertyChanged
    {
        //Members
        private Realm _realm;

        //Properties
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable Books { get; private set; }

        public ICommand AddBookCommand { get; private set; }
        public ICommand EditBookCommand { get; private set; }
        public ICommand DeleteBookCommand { get; private set; }
        public ICommand RefreshBooksCommand { get; private set; }

        //VW Lifecycle
        public MainViewModel()
        {
            this.InitializeCommands();
            this.InitializeData().IgnoreResult();
        }

        //Private methods
        private async Task InitializeData()
        {
            var config = RealmConfiguration.DefaultConfiguration;
            config.SchemaVersion = 1;

            _realm = await this.OpenRealm();

            this.Books = _realm.All<Book>();
        }

        private void InitializeCommands()
        {
            this.AddBookCommand = new Command<Book>(this.AddBook);
            this.EditBookCommand = new Command<Book>(this.EditBook);
            this.DeleteBookCommand = new Command<Book>(this.DeleteBook);
            this.RefreshBooksCommand = new Command(this.RefreshBooks);
        }

        private void AddBook(Book book)
        {
            _realm.Write(() =>
            {
                var newBook = _realm.Add(Book.Create());
                newBook.Title = book.Title;
                newBook.Description = book.Description;
                newBook.PageCount = book.PageCount;
            });
            this.RefreshBooks();
        }

        private void EditBook(Book book)
        {
            _realm.Write(() =>
            {
                var bookToUpdate = (Book)_realm.Find("Book", book.Id);
                bookToUpdate.Title = book.Title;
                bookToUpdate.Description = book.Description;
                bookToUpdate.PageCount = book.PageCount;
            });
            this.RefreshBooks();
        }

        private void DeleteBook(Book book)
        {
            _realm.Write(() => _realm.Remove(book));
            this.RefreshBooks();
        }

        private void RefreshBooks() => this.Books = _realm.All<Book>();

        private async Task<Realm> OpenRealm()
        {
            var user = User.Current;
            if (user != null)
            {
                var configuration = new FullSyncConfiguration(new Uri(Constants.RealmPath, UriKind.Relative), user);

                // User has already logged in, so we can just load the existing data in the Realm.
                return Realm.GetInstance(configuration);
            }

            // When that is called in the page constructor, we need to allow the UI operation
            // to complete before we can display a dialog prompt.
            await Task.Yield();

            //var response = await UserDialogs.Instance.PromptAsync(new PromptConfig
            //{
            //    Title = "Login",
            //    Message = "Please enter your nickname",
            //    OkText = "Login",
            //    IsCancellable = false,
            //});
            var credentials = Credentials.Nickname("JuanManuel", isAdmin: true);

            try
            {
                //UserDialogs.Instance.ShowLoading("Logging in...");

                user = await User.LoginAsync(credentials, new Uri(Constants.AuthUrl));

                //UserDialogs.Instance.ShowLoading("Loading data");

                var configuration = new FullSyncConfiguration(new Uri(Constants.RealmPath, UriKind.Relative), user);

                // First time the user logs in, let's use GetInstanceAsync so we fully download the Realm
                // before letting them interract with the UI.
                var realm = await Realm.GetInstanceAsync(configuration);

                //UserDialogs.Instance.HideLoading();

                return realm;
            }
            catch (Exception ex)
            {
                //await UserDialogs.Instance.AlertAsync(new AlertConfig
                //{
                //    Title = "An error has occurred",
                //    Message = $"An error occurred while trying to open the Realm: {ex.Message}"
                //});

                // Try again
                return await OpenRealm();
            }
        }
    }
}
