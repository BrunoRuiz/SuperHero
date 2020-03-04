using Newtonsoft.Json;
using SuperHero.Interfaces;
using SuperHero.Models;
using SuperHero.Services;
using SuperHero.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SuperHero.ViewModels
{
    public class HerosViewModel : BaseViewModel, IAsyncInitialization
    {
        private const int PageSize = 4;
        private readonly IApi _api;
        private IList<int> qtdePage;

        public Task Initialization { get; }

        private IList<HerosModel> _heros;
        public IList<HerosModel> Heros
        {
            get => _heros;
            set => RaiseIfPropertyChanged(ref _heros, value);
        }

        public Command NextPageToCommand { get; private set; }

        public Command PreviousPageToCommand { get; private set; }

        public HerosViewModel(IApi api)
        {
            _api = api;

            NextPageToCommand = new Command<ListView>((listView) => NextPageCommand(listView));
            PreviousPageToCommand = new Command<ListView>((listView) => PreviousPageCommand(listView));

            Initialization = InitializationAsync();
        }

        private async Task InitializationAsync()
        {
            await LoadHerosAsync();
        }

        private void InitializaSkeleton()
        {
            Heros = new List<HerosModel>()
                {
                    new HerosModel()
                    {
                        ID = 1,
                        Name = "Loading SKeleton 1",
                        IsBusy = true
                    },
                    new HerosModel()
                    {
                        ID = 2,
                        Name = "Loading SKeleton 2",
                        IsBusy = true
                    },
                    new HerosModel()
                    {
                        ID = 3,
                        Name = "Loading SKeleton 3",
                        IsBusy = true
                    },
                    new HerosModel()
                    {
                        ID = 4,
                        Name = "Loading SKeleton 4",
                        IsBusy = true
                    }
                };
        }

        private async Task LoadHerosAsync()
        {
            IsBusy = true;
            try
            {
                InitializaSkeleton();

                var restApiParams = new RestApiParams();
                var heros = await _api.GetHeros(restApiParams);

                var dtoToModel = JsonConvert.SerializeObject(heros.Data.Results);
                var listHeros = JsonConvert.DeserializeObject<IList<HerosModel>>(dtoToModel);

                //TODO - Bruno Ruiz - Simulando uma resposta demorada da API
                await Task.Delay(3200);

                qtdePage = new List<int>(PaginationService.GetPagination(listHeros, PageSize));
                Heros = new List<HerosModel>(PaginationService.GetPages(1));

            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void NextPageCommand(ListView listView)
        {
            int page = Heros.FirstOrDefault().Page;
            page++;

            if (qtdePage.Contains(page))
                Heros = PaginationService.GetPages(page);
        }

        private void PreviousPageCommand(ListView listView)
        {
            int page = Heros.FirstOrDefault().Page;
            page--;

            if (qtdePage.Contains(page))
                Heros = PaginationService.GetPages(page);
        }
    }

}
