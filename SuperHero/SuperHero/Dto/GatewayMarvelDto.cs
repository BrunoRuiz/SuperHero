using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SuperHero.Dto
{
    public class GatewayMarvelDto
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("attributionText")]
        public string AttributionText { get; set; }

        [JsonProperty("attributionHTML")]
        public string AttributionHTML { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }
    }

    public class Data
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public IList<Result> Results { get; set; }
    }

    public class Result
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("comics")]
        public Common Comics { get; set; }

        [JsonProperty("series")]
        public Common Series { get; set; }

        [JsonProperty("stories")]
        public Storie Stories { get; set; }

        [JsonProperty("events")]
        public Common Events { get; set; }

        [JsonProperty("urls")]
        public IList<Urls> Urls { get; set; }
    }

    public class Urls
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Thumbnail
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

    }

    public class Common
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionURI { get; set; }

        [JsonProperty("items")]
        public IList<ItemBase> Items { get; set; }

        [JsonProperty("Returned")]
        public int Returned { get; set; }
    }

    public class Storie
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionURI { get; set; }

        [JsonProperty("items")]
        public IList<Item> Items { get; set; }

        [JsonProperty("Returned")]
        public int Returned { get; set; }

    }

    public class ItemBase
    {
        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Item : ItemBase
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

}