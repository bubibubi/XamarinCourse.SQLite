using System;
using Xamarin.Forms;
using Xamarin.SQLite.Model;
using Xamarin.SQLite.Repository;

namespace Xamarin.SQLite
{
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            MyListView.ItemTapped += MyListView_ItemTapped;
            InsertButton.Clicked += InsertButton_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MyListView.IsRefreshing = true;
            using (PersonRepository repository = new PersonRepository())
                MyListView.ItemsSource = repository.GetAll();
            MyListView.IsRefreshing = false;
        }

        private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((NavigationPage)App.Current.MainPage).PushAsync(new DetailPage((Person)e.Item));
        }

        private void InsertButton_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)App.Current.MainPage).PushAsync(new DetailPage());
        }


    }
}
