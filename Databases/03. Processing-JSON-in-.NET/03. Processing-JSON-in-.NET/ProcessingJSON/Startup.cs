namespace ProcessingJSON
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Xml;
    using Newtonsoft.Json.Linq;
    using System.Xml.Serialization;
    using System.IO;

    public class Startup
    {
        private const string RSSFeedURL = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";

        private const string DownloadedFileName = "downloadedRSSFEeed";

        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            DownloadRSSFeed();

            var jsonContent = GetSerializedContent();
            GetVideoTitles(jsonContent);

            //SerializeToXML(jsonContent);
        }

        private static void SerializeToXML(string jsonContent)
        {
            var jsonObject = JObject.Parse(jsonContent);

            List<Video> videos = jsonObject["feed"]["entry"]
                .Select(x => JsonConvert.DeserializeObject<Video>(x.ToString()))
                .ToList();

            var channel = new Channel() { Videos = videos };
            var xmlSerializer = new XmlSerializer(typeof(Channel));

            using (FileStream streamWriter = new FileStream("../../serialized-info.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(streamWriter, channel);
            }
        }

        private static void GetVideoTitles(string jsonContent)
        {
            var jsonObject = JObject.Parse(jsonContent);

            var videoTitles = jsonObject.Descendants()
                .OfType<JProperty>()
                .Where(x => x.Name.ToLower() == "title")
                .Select(x => x.Value)
                .ToList();

            Console.WriteLine(string.Join("\n", videoTitles));
        }

        private static string GetSerializedContent()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(DownloadedFileName);

            var jsonContent = JsonConvert.SerializeXmlNode(xmlDocument, Newtonsoft.Json.Formatting.Indented);
            return jsonContent;
        }

        private static void DownloadRSSFeed()
        {
            var webClient = new WebClient();
            webClient.DownloadFile(RSSFeedURL, DownloadedFileName);
        }
    }
}
