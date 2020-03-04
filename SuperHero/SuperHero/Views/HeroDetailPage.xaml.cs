using SuperHero.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SuperHero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeroDetailPage : ContentPage
    {
        public HeroDetailPage(string sourceHTML)
        {
            InitializeComponent();
            BindingContext = new HerosDetailViewModel(Navigation, sourceHTML);
        }
    }
}