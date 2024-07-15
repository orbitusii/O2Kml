using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2Kml.Shapes
{
    [XmlType("Point")]
    public class KmlPoint : KmlShape
    {
        [XmlElement("coordinates")]
        public string InnerText
        {
            get => Coordinates.ToString();
            set
            {
                var match = LatLon.LatLonRegex.Match(value);
                if(match is not null)
                    Coordinates = LatLon.FromRegexMatch(match);
            }
        }

        [XmlIgnore]
        public LatLon Coordinates { get; set; } = new LatLon();

        public override LatLon[] GetPoints()
        {
            return new LatLon[] { Coordinates };
        }
    }
}
