using Xamarin.Forms;

namespace SuperHero.ViewModels
{
    public class HerosDetailViewModel
    {
        private INavigation _navigation;
        public string SourceHTML { get; set; }
        public Command ClosePageToCommand { get; private set; }
        
        public HerosDetailViewModel(INavigation navigation, string sourceHTML)
        {
            _navigation = navigation;

            ClosePageToCommand = new Command(() => CloseToPage());
            SourceHTML = sourceHTML;
        }

        private void CloseToPage()
        {
            _navigation.PopModalAsync(true);
        }
    }
}
