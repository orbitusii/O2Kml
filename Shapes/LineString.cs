using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace O2Kml.Shapes
{
    [XmlType("LineString")]
    public class LineString: KmlShape
    {
        [XmlIgnore]
        public List<LatLon> Coordinates;

        [XmlElement("coordinates")]
        public string InnerText
        {
            get => string.Join(' ', Coordinates.Select(x => x.ToString()));
            set
            {
                var matches = LatLon.LatLonRegex.Matches(value);
                Coordinates = new List<LatLon>(matches.Select(x => LatLon.FromRegexMatch(x)));
            }
        }

        [XmlAnyElement]
        public object[] Elements;

        public override LatLon[] GetPoints()
        {
            return Coordinates.ToArray();
        }
    }
}
