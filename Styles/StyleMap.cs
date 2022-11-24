using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2Kml.Styles
{
    public class StyleMap
    {
        [XmlAttribute]
        public string id = "Default StyleMap";

        [XmlElement("Pair")]
        public KmlPair[] Pairs { get; set; } = Array.Empty<KmlPair>();

        [XmlIgnore]
        public Dictionary<string, Style>? Styles;

        public Style this[string index]
        {
            get => Styles?[index.Replace("#", "")] ?? new();
        }

        public void BuildDictionary (Style[] styleArray)
        {
            Styles = new();
            foreach (var pair in Pairs)
            {
                Style? foundStyle = styleArray.First(x => x.id == pair.styleUrl.Replace("#", ""));

                if (foundStyle != null)
                {
                    Styles.Add(pair.key, foundStyle);
                }
            }
        }
    }

    public class KmlPair
    {
        public string key = "";
        public string styleUrl = "#";
    }
}
