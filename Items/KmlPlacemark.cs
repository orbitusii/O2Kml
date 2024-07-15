using System.Xml.Serialization;
using O2Kml.Shapes;
using O2Kml.Styles;

namespace O2Kml
{
    public class KmlPlacemark: KmlItem
    {
        [XmlElement]
        public string? styleUrl = "#";

        [XmlIgnore]
        public StyleMap? styleMap;

        [XmlIgnore]
        public ShapeType ShapeType;

        [XmlChoiceIdentifier("ShapeType")]
        [XmlElement("Polygon", typeof(Polygon))]
        [XmlElement("LinearRing", typeof(LineString))]
        [XmlElement("LineString", typeof(LineString))]
        [XmlElement("Point", typeof(KmlPoint))]
        public object? Shape;
    }
}
