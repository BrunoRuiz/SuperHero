using SuperHero.Views;
using Xamarin.Forms;

namespace SuperHero
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new HerosPage();
        }
    }
}
