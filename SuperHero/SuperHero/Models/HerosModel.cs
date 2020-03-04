using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SuperHero.Models
{
    public class HerosModel
    {        
        [JsonIgnore]
        public int Page { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public string ResourceURI { get; set; }
        public Common Comics { get; set; }
        public Common Series { get; set; }
        public Storie Stories { get; set; }
        public Common Events { get; set; }
        public IList<Urls> Urls { get; set; }
        public bool IsBusy { get; set; }
    }
   
    public class Urls
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }

    public class Thumbnail
    {
        public string Path { get; set; }
        public string Extension { get; set; }
        public string PathImageSource => string.Concat(Path, ".", Extension);
    }

    public class Common
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public IList<ItemBase> Items { get; set; }
        public int Returned { get; set; }
    }

    public class Storie
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public IList<Item> Items { get; set; }
        public int Returned { get; set; }

    }

    public class ItemBase
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }

    public class Item : ItemBase
    {
        public string Type { get; set; }
    }
}