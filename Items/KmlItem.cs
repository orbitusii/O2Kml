using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2Kml
{
    public abstract class KmlItem
    {
        [XmlElement("name")]
        public string Name { get; set; } = string.Empty;
    }

    public enum ItemType
    {
        Placemark,
        Folder,
    }
}
