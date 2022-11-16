using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using KML.Shapes;

namespace KML
{
    [XmlRoot("kml", Namespace = "http://www.opengis.net/kml/2.2")]
    public class Kml
    {
        public KmlDocument Document;

        [XmlAnyAttribute]
        public string[] Attributes;

        [XmlAnyElement]
        public object[] Elements;
    }

    public class KmlDocument
    {
        [XmlElement]
        public string name;

        [XmlElement("Placemark")]
        public KmlPlacemark[] Placemarks;
    }

    public class KmlPlacemark
    {
        [XmlElement]
        public string? name;

        [XmlElement]
        public string? styleUrl;

        [XmlIgnore]
        public ShapeType ShapeType;

        [XmlChoiceIdentifier("ShapeType")]
        [XmlElement("Polygon", typeof(Polygon))]
        [XmlElement("LinearRing", typeof(LineString))]
        [XmlElement("LineString", typeof(LineString))]
        public object Shape;
    }
}
