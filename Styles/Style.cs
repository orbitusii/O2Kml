using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace O2Kml.Styles
{
    [XmlType("Style")]
    public class Style
    {
        [XmlAttribute]
        public string id { get; set; } = "default style";

        [XmlElement]
        public IconStyle IconStyle { get; set; } = new();
        [XmlElement]
        public LineStyle LineStyle { get; set; } = new();
        [XmlElement]
        public PolyStyle PolyStyle { get; set; } = new();

        public bool Equals(Style? obj)
        {
            return id == obj?.id
                && (IconStyle.Equals(obj.IconStyle))
                && (LineStyle.Equals(obj.LineStyle))
                && (PolyStyle.Equals(obj.PolyStyle));
        }

        public override string ToString()
        {
            return $"KML Style: {id}\n\t{IconStyle}\n\t{LineStyle}\n\t{PolyStyle}";
        }
    }
}
