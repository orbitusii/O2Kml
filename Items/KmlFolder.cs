using O2Kml.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2Kml
{
    public class KmlFolder : KmlItem
    {
        [XmlElement]
        public string Description { get; set; } = string.Empty;

        [XmlChoiceIdentifier("ItemType")]
        [XmlElement("Placemark", typeof(KmlPlacemark))]
        [XmlElement("Folder", typeof(KmlFolder))]
        public KmlItem[] Items { get; set; } = Array.Empty<KmlItem>();
    }
}
