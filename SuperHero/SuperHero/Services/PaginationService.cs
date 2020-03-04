using SuperHero.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuperHero.Services
{
    public static class PaginationService
    {
        private static IEnumerable<IGrouping<int, HerosModel>> _herosGrouping { get; set; }

        public static IList<int> GetPagination(IList<HerosModel> heros, int pageSize)
        {
            _herosGrouping = heros.Select((e, i) => new HerosModel
            {
                Comics = e.Comics,
                Description = e.Description,
                Events = e.Events,
                ID = e.ID,
                IsBusy = e.IsBusy,
                Modified = e.Modified,
                Name = e.Name,
                ResourceURI = e.ResourceURI,
                Series = e.Series,
                Stories = e.Stories,
                Thumbnail = e.Thumbnail,
                Urls = e.Urls,
                Page = (i / pageSize) + 1

            }).GroupBy(e => e.Page);

            return _herosGrouping.Select(x => x.Key).ToList(); ;
        }

        public static IList<HerosModel> GetPages(int pageNumber)
        {
            return _herosGrouping.FirstOrDefault(x => x.Key == pageNumber).ToList();
        }
    }
}
