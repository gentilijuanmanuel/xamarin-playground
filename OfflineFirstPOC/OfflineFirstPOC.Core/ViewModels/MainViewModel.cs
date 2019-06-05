using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using Realms;
using OfflineFirstPOC.Core.Models;
using Xamarin.Forms;

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
            this.InitializeData();
        }

        //Private methods
        private void InitializeData()
        {
            var config = RealmConfiguration.DefaultConfiguration;
            config.SchemaVersion = 1;

            _realm = Realm.GetInstance();

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
    }
}
