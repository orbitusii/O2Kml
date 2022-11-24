using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KML.Shapes
{
    [XmlType("Polgyon")]
    public class Polygon: KmlShape
    {
        [XmlArray]
        [XmlArrayItem("LinearRing", typeof(LineString))]
        public LineString[]? outerBoundaryIs;

        [XmlArray]
        [XmlArrayItem("LinearRing", typeof(LineString))]
        public LineString[]? innerBoundaryIs;

        public override LatLon[] GetPoints()
        {
            return outerBoundaryIs?[0].Coordinates.ToArray() ?? Array.Empty<LatLon>();
        }
    }
}
