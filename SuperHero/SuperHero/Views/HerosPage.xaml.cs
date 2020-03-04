using SuperHero.Models;
using SuperHero.Services;
using SuperHero.ViewModels;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SuperHero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HerosPage : ContentPage
    {
        public HerosPage()
        {
            InitializeComponent();
            BindingContext = new HerosViewModel(ApiService.Instance);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string htmlDetail;
            (sender as ListView).SelectedItem = null;

            var hero = (e.Item as HerosModel);

            if (hero.Urls.Where(urls => urls.Type.Equals("wiki")).Count() > 0)
                htmlDetail = hero.Urls.Where(urls => urls.Type.Equals("wiki")).FirstOrDefault().Url;
            else
                htmlDetail = hero.Urls.Where(urls => urls.Type.Equals("detail")).FirstOrDefault().Url;

            if (!string.IsNullOrEmpty(htmlDetail))
                Navigation.PushModalAsync(new HeroDetailPage(htmlDetail));
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var busca = (sender as Entry).Text;
            listViewHeros.ItemsSource =
                (BindingContext as HerosViewModel).Heros.Where(hero => hero.Name.ToLower().Contains(busca.ToLower()));
        }
    }
}