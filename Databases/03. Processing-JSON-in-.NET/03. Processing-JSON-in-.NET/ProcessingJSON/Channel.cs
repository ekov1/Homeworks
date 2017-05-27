namespace ProcessingJSON
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    public class Channel
    {
        [XmlArray("Videos"), XmlArrayItem(typeof(Video), ElementName = "Video")]
        public List<Video> Videos { get; set; }
    }
}
