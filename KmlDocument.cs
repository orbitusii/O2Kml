using System;
using System.Xml.Serialization;
using O2Kml.Styles;

namespace O2Kml
{
    public class KmlDocument
    {
        [XmlElement]
        public string name = "";

        [XmlElement("StyleMap")]
        public StyleMap[] StyleMaps = Array.Empty<StyleMap>();

        [XmlElement("Style")]
        public Style[] Styles = Array.Empty<Style>();

        [XmlElement("Placemark")]
        public KmlPlacemark[] Placemarks = new KmlPlacemark[0];
    }
}
