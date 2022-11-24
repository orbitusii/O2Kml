using System.Xml.Serialization;

namespace O2Kml.Styles
{
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
}
