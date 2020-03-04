using Refit;
using SuperHero.Dto;
using SuperHero.Interfaces;
using System.Threading.Tasks;

namespace SuperHero.Services
{
    public class ApiService : IApi
    {
        private static string BaseUrl => "http://gateway.marvel.com/v1/public";
        private GatewayMarvelDto _allHeros;
        private static ApiService _instance;
        private readonly IApi _api;

        public static ApiService Instance = _instance ?? (_instance = new ApiService());

        private ApiService()
        {
            _api = RestService.For<IApi>(BaseUrl);
        }

        public async Task<GatewayMarvelDto> GetHeros(RestApiParams restApiParams)
        {
            _allHeros = await _api.GetHeros(restApiParams);
            return _allHeros;
        }
    }
}
