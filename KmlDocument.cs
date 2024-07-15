using System;
using System.Linq;
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

        [XmlChoiceIdentifier("ItemType")]
        [XmlElement("Placemark", typeof(KmlPlacemark))]
        [XmlElement("Folder", typeof(KmlFolder))]
        public KmlItem[] Items = Array.Empty<KmlItem>();

        [XmlIgnore]
        public KmlPlacemark[] Placemarks => Items.Where(x => x is KmlPlacemark).Select(x => (KmlPlacemark)x).ToArray();
        [XmlIgnore]
        public KmlFolder[] Folders => Items.Where(x => x is KmlFolder).Select(x => (KmlFolder)x).ToArray();
    }
}
