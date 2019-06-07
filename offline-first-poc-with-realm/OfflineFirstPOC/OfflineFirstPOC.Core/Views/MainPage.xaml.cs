using System;
using System.ComponentModel;
using OfflineFirstPOC.Core.Models;
using OfflineFirstPOC.Core.ViewModels;
using Xamarin.Forms;

namespace OfflineFirstPOC.Core.Views
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();

            this.BindingContext = viewModel;
        }

        async void OnAddNewBook(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddEditBookPage((MainViewModel)this.BindingContext));
        }

        async void OnEditBook(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(
                new AddEditBookPage((MainViewModel)this.BindingContext, (Book)e.Item));
        }

        public void OnDeleteBook(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var book = item.CommandParameter as Book;

            var viewModel = (MainViewModel)this.BindingContext;

            viewModel.DeleteBookCommand.Execute(book);
        }
    }
}
