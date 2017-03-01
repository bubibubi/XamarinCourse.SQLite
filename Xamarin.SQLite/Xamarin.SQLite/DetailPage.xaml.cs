using System;
using Xamarin.Forms;
using Xamarin.SQLite.Model;
using Xamarin.SQLite.Repository;

namespace Xamarin.SQLite
{
    public partial class DetailPage : ContentPage
    {
        private readonly Person _person;

        public DetailPage()
        {
            InitializeComponent();

            DeleteButton.Clicked += DeleteButton_Clicked;
            OkButton.Clicked += OkButton_Clicked;

            DeleteButton.IsVisible = false;
            _person = null;
        }

        public DetailPage(Person person) : this()
        {
            Id.Text = person.Id.ToString();
            Name.Text = person.Name;
            Age.Text = person.Age == null ? null : person.Age.ToString();

            DeleteButton.IsVisible = true;
            _person = person;
        }

        private void OkButton_Clicked(object sender, EventArgs e)
        {
            if (_person == null)
            {
                Person person = new Person();
                person.Name = Name.Text;
                person.Age = string.IsNullOrWhiteSpace(Age.Text) ? null : (int?)Convert.ToInt32(Age.Text);

                using (PersonRepository repository = new PersonRepository())
                    repository.Insert(person);
            }
            else
            {
                _person.Name = Name.Text;
                _person.Age = string.IsNullOrWhiteSpace(Age.Text) ? null : (int?)Convert.ToInt32(Age.Text);

                using (PersonRepository repository = new PersonRepository())
                    repository.Update(_person);
            }

            ((NavigationPage)App.Current.MainPage).PopAsync();

        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert(
                "Conferma eliminazione",
                "Conferma l'eliminazione dell'entità",
                "Sì",
                "No"))
            {
                using (PersonRepository repository = new PersonRepository())
                    repository.Delete(_person.Id);
                ((NavigationPage)App.Current.MainPage).PopAsync();
            }
        }


    }
}
