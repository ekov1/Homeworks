namespace ProcessingJSON
{
    using Newtonsoft.Json;
    using System;
    using System.Xml.Serialization;

    [Serializable]
    [XmlRoot("Channel")]
    public class Video
    {
        [JsonProperty("yt:videoId")]
        public string VideoId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public VideoInfo Info { get; set; }
    }
}