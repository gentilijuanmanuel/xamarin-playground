using System;
using OfflineFirstPOC.Core.Models;
using OfflineFirstPOC.Core.ViewModels;
using Xamarin.Forms;

namespace OfflineFirstPOC.Core.Views
{
    public class AddEditBookPage : ContentPage
    {
        readonly Book existingBook;
        readonly EntryCell titleCell, descriptionCell, pageCountCell;

        public AddEditBookPage(MainViewModel viewModel, Book existingBook = null)
        {
            this.BindingContext = viewModel;

            this.existingBook = existingBook;

            var tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot(existingBook != null ? "Edit Book" : "New Book") {
                    new TableSection("Details") {
                        (titleCell = new EntryCell {
                            Label = "Title",
                            Placeholder = "Add title...",
                            Text = existingBook?.Title,
                        }),
                        (descriptionCell = new EntryCell {
                            Label = "Description",
                            Placeholder = "Add description...",
                            Text = existingBook?.Description,
                        }),
                        (pageCountCell = new EntryCell { 
                            Label = "Page count",
                            Placeholder = "Add page count...",
                            Text = existingBook?.PageCount.ToString()
                        })
                    },
                }
            };

            Button button = new Button
            {
                BackgroundColor = existingBook != null ? Color.Gray : Color.Green,
                TextColor = Color.White,
                Text = existingBook != null ? "Finished" : "Add Book",
                CornerRadius = 0,
            };
            button.Clicked += OnDismiss;

            Content = new StackLayout
            {
                Spacing = 0,
                Children = { tableView, button },
            };
        }

        async void OnDismiss(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.IsEnabled = false;
            this.IsBusy = true;
            try
            {
                var title = titleCell.Text;
                var description = descriptionCell.Text;
                var pageCount = Convert.ToInt32(pageCountCell.Text);

                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || pageCount == 0)
                {
                    this.IsBusy = false;
                    await this.DisplayAlert("Missing Information",
                        "You must enter values for the Title and Description.",
                        "OK");
                }
                else
                {
                    var viewModel = (MainViewModel)this.BindingContext;
                    if (existingBook != null)
                    {
                        var updatedBook = new Book { Id = existingBook.Id, Title = title, Description = description, PageCount = pageCount };
                        viewModel.EditBookCommand.Execute(updatedBook);
                    }
                    else
                        viewModel.AddBookCommand.Execute(new Book { Title = title, Description = description, PageCount = pageCount });

                    await Navigation.PopModalAsync();
                }
            }
            finally
            {
                this.IsBusy = false;
                button.IsEnabled = true;
            }
        }
    }
}

