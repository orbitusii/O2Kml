using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2Kml.Shapes
{
    public abstract class KmlShape
    {
        public bool? tessellate;
        public bool? extrude;

        public abstract LatLon[] GetPoints();
    }

    public enum ShapeType
    {
        Polygon,
        LinearRing,
        LineString,
    }
}
