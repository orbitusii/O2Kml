using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using KML.Shapes;
using O2Kml.Styles;

namespace KML
{
    [XmlRoot("kml", Namespace = "http://www.opengis.net/kml/2.2")]
    public class Kml
    {
        public KmlDocument Document = new KmlDocument();

        [XmlAnyAttribute]
        public string[]? Attributes;

        [XmlAnyElement]
        public object[]? Elements;

        public static Kml? LoadFromFile (string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                XmlSerializer ser = new XmlSerializer(typeof(Kml));
                Kml loaded = ser.Deserialize(fs) as Kml ?? new();

                loaded.Document.StyleMap.BuildDictionary(loaded.Document.Styles);

                return loaded;
            }
        }

        public static bool TryLoadFromFile (string filename, out Kml? loaded)
        {
            try
            {
                loaded = LoadFromFile(filename);
                return true;
            }
            catch
            {
                loaded = null;
                return false;
            }
        }

        public bool SaveToFile(string filename, bool overwrite = true)
        {
            return SaveToFile(this, filename, overwrite);
        }

        public static bool SaveToFile (Kml kml, string filename, bool overwrite = true)
        {
            if(File.Exists(filename) && !overwrite)
            {
                return false;
            }
            else if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }

            using (FileStream fs = new FileStream(filename, FileMode.Truncate))
            {
                XmlSerializer ser = new XmlSerializer(typeof(Kml));
                ser.Serialize(fs, kml);
                return true;
            }
        }
    }

    public class KmlDocument
    {
        [XmlElement]
        public string name = "";

        public StyleMap StyleMap = new();

        [XmlElement("Style")]
        public Style[] Styles = Array.Empty<Style>();

        [XmlElement("Placemark")]
        public KmlPlacemark[] Placemarks = new KmlPlacemark[0];
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
        public object? Shape;
    }
}
