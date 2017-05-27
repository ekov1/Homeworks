namespace XMLProcessing
{
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using Utils;

    // NOTE TO SELF: Tasks 9, 15 not finished
    public class Startup
    {
        private const string CataloguePath = "../../../catalogue.xml";

        private static IReader reader = new ConsoleReader();

        private static IWriter writer = new ConsoleWriter();

        public static void Main()
        {
            // Task 2
            //PrintUniqueArtists();

            // Task 4
            //DeleteExpensiveAlbums();

            // Task 5
            //ExtractSongTitles();

            // Task 6
            //ExtractSongTitlesLinq();

            // Task 7
            //ParseTXTtoXML();

            // Task 8
            //XmlReaderAndWriterParsing();

            // Task 11 
            //ExtractPriceFrom5YearsAlbums();
            //ExtractPriceFrom5YearsAlbumsLinq();
        }

        private static void PrintUniqueArtists()
        {
            XmlDocument document = new XmlDocument();

            document.Load(CataloguePath);

            XmlElement rootNode = document.DocumentElement;
            Hashtable uniqueArtists = new Hashtable();

            // XPATH SOLUTION
            //var xPath = "/catalogue/album/artist";
            //XmlNodeList artists = document.SelectNodes(xPath);

            //foreach (XmlElement artist in artists)
            //{
            //    var albumArtist = artist.InnerText;
            foreach (XmlElement node in rootNode.ChildNodes)
            {
                var albumArtist = node["artist"].InnerText;

                if (!uniqueArtists.ContainsKey(albumArtist))
                {
                    uniqueArtists.Add(albumArtist, 1);
                }
                else
                {
                    uniqueArtists[albumArtist] = (int)uniqueArtists[albumArtist] + 1;
                }
            }

            foreach (var artist in uniqueArtists.Keys)
            {
                var albumCount = (int)uniqueArtists[artist] > 1 ? "albums" : "album";

                writer.WriteLine($"{artist} has {uniqueArtists[artist]} {albumCount}!");
            }
        }

        private static void DeleteExpensiveAlbums()
        {
            XmlDocument document = new XmlDocument();
            document.Load(CataloguePath);

            XmlElement rootNode = document.DocumentElement;

            foreach (XmlElement node in rootNode.ChildNodes)
            {
                var price = decimal.Parse(node["price"].InnerText);

                if (price > 20)
                {
                    rootNode.RemoveChild(node);
                }
            }

            document.Save("../../../newCatalogue.xml");
        }

        private static void ExtractSongTitles()
        {
            var songTitles = new List<string>();

            using (XmlReader reader = XmlReader.Create(CataloguePath))
            {
                while (reader.Read())
                {
                    if (reader.Name == "title")
                    {
                        var value = reader.ReadInnerXml();

                        songTitles.Add(value);
                    }
                }
            }

            writer.WriteLine(string.Join(",", songTitles));
        }

        private static void ExtractSongTitlesLinq()
        {
            XDocument document = XDocument.Load(CataloguePath);

            var songTitles =
                document.Descendants()
                .Where(node => node.Name == "title")
                .Select(element => element.Value)
                .ToList();

            writer.WriteLine(string.Join(",", songTitles));
        }

        private static void ParseTXTtoXML()
        {
            var personInfo = new List<string>();

            using (StreamReader reader = new StreamReader("../../../person-data.txt"))
            {
                var lineInfo = string.Empty;

                do
                {
                    lineInfo = reader.ReadLine();
                    personInfo.Add(lineInfo);

                } while (lineInfo != null);
            }

            XElement xStructure = new XElement("people",
                new XElement("person",
                    new XElement("name", personInfo[0]),
                    new XElement("adress", personInfo[1]),
                    new XElement("phoneNumber", personInfo[2])
                    )
                );

            xStructure.Save("../../../parsedPersonInfo.xml");
        }

        private static void XmlReaderAndWriterParsing()
        {
            var dict = new Dictionary<string, string>();

            using (XmlReader reader = XmlReader.Create(CataloguePath))
            {
                var albumName = string.Empty;

                while (reader.Read())
                {
                    if (reader.Name == "name")
                    {
                        albumName = reader.ReadInnerXml();
                        dict.Add(albumName, "");
                    }
                    else if (reader.Name == "producer")
                    {
                        dict[albumName] = reader.ReadInnerXml();
                    }
                }
            }

            using (XmlWriter writer = XmlWriter.Create("../../../album.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                foreach (var key in dict.Keys)
                {

                    writer.WriteStartElement("album");

                    writer.WriteElementString("title", key);
                    writer.WriteElementString("producer", dict[key]);

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

        }

        private static void ExtractPriceFrom5YearsAlbums()
        {
            XmlDocument document = new XmlDocument();
            document.Load(CataloguePath);

            XmlElement rootElement = document.DocumentElement;

            var xPath = "/catalogue/album";
            var albums = rootElement.SelectNodes(xPath);

            var albumPrices = new List<string>();

            foreach (XmlElement album in albums)
            {
                var albumYear = album["year"].InnerText;

                if (int.Parse(albumYear) <= DateTime.Now.Year - 5)
                {
                    albumPrices.Add(album["price"].InnerText);
                }
            }

            writer.WriteLine(string.Join(",", albumPrices));
        }

        private static void ExtractPriceFrom5YearsAlbumsLinq()
        {
            XDocument document = XDocument.Load(CataloguePath);

            var albumPrices =
                document.Descendants()
                .Where(x => (x.Name == "year") && (int.Parse(x.Value) <= DateTime.Now.Year - 5))
                .Select(x => x.Parent)
                .Descendants()
                .Where(x => x.Name == "price")
                .Select(x => x.Value)
                .ToList();

            writer.WriteLine(string.Join(",", albumPrices));
        }
    }
}
