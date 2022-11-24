using O2Kml.Styles;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2Kml
{
    [XmlRoot("kml", Namespace = "http://www.opengis.net/kml/2.2")]
    public class Kml
    {
        public KmlDocument Document = new KmlDocument();

        [XmlAnyAttribute]
        public string[]? Attributes;

        [XmlAnyElement]
        public object[]? Elements;

        public virtual void FinalizeLoad ()
        {
            foreach(StyleMap sm in Document.StyleMaps)
            {
                sm.BuildDictionary(Document.Styles);
            }

            foreach(KmlPlacemark placemark in Document.Placemarks)
            {
                placemark.styleMap = Document.StyleMaps.First(x => x.id == placemark.styleUrl?.Replace("#", ""));
            }
        }

        public bool SaveToFile(string filename, bool overwrite = true)
        {
            return SaveToFile(this, filename, overwrite);
        }

        public static Kml? LoadFromFile (string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                XmlSerializer ser = new XmlSerializer(typeof(Kml));
                Kml loaded = ser.Deserialize(fs) as Kml ?? new();

                loaded.FinalizeLoad();

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
}
