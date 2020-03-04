using Refit;
using SuperHero.Dto;
using SuperHero.Services;
using System.Threading.Tasks;

namespace SuperHero.Interfaces
{
    public interface IApi
    {
        [Get("/characters")]
        Task<GatewayMarvelDto> GetHeros(RestApiParams restApiParams);
    }
}
