using System.Xml.Serialization;

namespace O2Kml.Styles
{
    public class PolyStyle
    {
        [XmlElement]
        public string color { get; set; } = "84ffffff";

        public bool Equals (PolyStyle? obj)
        {
            return color == obj?.color;
        }

        public override string ToString()
        {
            return $"PolyStyle: {color}";
        }
    }
}
