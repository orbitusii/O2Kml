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
        [XmlElement(ElementName = "coordinates")]
        public LatLon Coordinates { get; set; } = new LatLon();

        public override LatLon[] GetPoints()
        {
            return new LatLon[] { Coordinates };
        }
    }
}
