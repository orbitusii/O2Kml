namespace O2Kml.Styles
{
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

        public LineStyle ()
        {
            color = "ffffffff";
            width = 1;
        }
    }
}
