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
        public string id { get; set; } = "new style";

        [XmlElement]
        public IconStyle? IconStyle { get; set; }
        [XmlElement]
        public LineStyle? LineStyle { get; set; }
        [XmlElement]
        public PolyStyle? PolyStyle { get; set; }

        public bool Equals(Style? obj)
        {
            return id == obj?.id
                && (IconStyle?.Equals(obj.IconStyle) ?? obj.IconStyle is null)
                && (LineStyle?.Equals(obj.LineStyle) ?? obj.LineStyle is null)
                && (PolyStyle?.Equals(obj.PolyStyle) ?? obj.PolyStyle is null);
        }

        public override string ToString()
        {
            return $"KML Style: {id}\n\t{IconStyle}\n\t{LineStyle}\n\t{PolyStyle}";
        }
    }

    public class IconStyle
    {
        public float scale { get; set; }
        public IconRef Icon { get; set; } = new IconRef();
        public HotSpot? hotSpot { get; set; }

        public class IconRef
        {
            [XmlElement("href")]
            public string? link { get; set; } = "";
        }

        public class HotSpot
        {
            [XmlAttribute]
            public float x { get; set; }
            [XmlAttribute]
            public float y { get; set; }
            [XmlAttribute]
            public string xunits { get; set; } = "pixels";
            [XmlAttribute]
            public string yunits { get; set; } = "pixels";

            public bool Equals (HotSpot? obj)
            {
                return x == obj?.x
                    && y == obj?.y
                    && xunits == obj?.xunits
                    && yunits == obj?.yunits;
            }
        }

        public bool Equals (IconStyle? obj)
        {
            return scale == obj?.scale
                && Icon.link == obj.Icon.link
                && (hotSpot?.Equals(obj.hotSpot) ?? obj.hotSpot is null);
        }

        public override string ToString()
        {
            return $"IconStyle: {scale} {Icon.link} {hotSpot?.x}{hotSpot?.xunits},{hotSpot?.y}{hotSpot?.yunits}";
        }
    }

    public class LineStyle : PolyStyle
    {
        public float width { get; set; } = 1;

        public bool Equals (LineStyle? obj)
        {
            return color == obj?.color
                && width == obj?.width;
        }

        public override string ToString()
        {
            return $"LineStyle: {color} @{width}px";
        }
    }

    public class PolyStyle
    {
        [XmlElement]
        public string color { get; set; } = "ffffffff";

        public bool Equals (PolyStyle? obj)
        {
            return color == obj?.color;
        }

        public override string ToString()
        {
            return $"PolyStyle: {color}";
        }
    }
}
