using O2Kml.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UnitTests
{
    [TestClass]
    public class StyleTests
    {
        [TestMethod]
        public void TestStyle_Deserialize()
        {
            string StyleSample = 
@"<Style id=""sh_ylw-pushpin"">
    <IconStyle>
        <scale>1.3</scale>
        <Icon>
            <href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>
        </Icon>
        <hotSpot x=""20"" y=""2"" xunits=""pixels"" yunits=""pixels""/>
    </IconStyle>
    <LineStyle>
        <color>ff00aa00</color>
        <width>3</width>
    </LineStyle>
    <PolyStyle>
        <color>4000aa00</color>
    </PolyStyle>
</Style>";

            var styleStream = new StringReader(StyleSample);
            XmlSerializer ser = new XmlSerializer(typeof(Style));

            Style deserialized = ser.Deserialize(styleStream) as Style ?? new Style();

            Style ValidStyle = new Style
            {
                id = "sh_ylw-pushpin",

                IconStyle = new IconStyle
                {
                    scale = 1.3f,
                    Icon = new IconStyle.IconRef
                    {
                        link = "http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png",
                    },
                    hotSpot = new IconStyle.HotSpot
                    {
                        x = 20,
                        y = 2,
                        xunits = "pixels",
                        yunits = "pixels",
                    }
                },
                LineStyle = new LineStyle
                {
                    color = "ff00aa00",
                    width = 3,
                },
                PolyStyle = new PolyStyle
                {
                    color = "4000aa00",
                },
            };

            Assert.IsTrue(ValidStyle.Equals(deserialized), $"Expected {ValidStyle}\nActual {deserialized}");
        }

        [TestMethod]
        public void TestStyle_Serialize()
        {
            Style ExistingStyle = new()
            {
                id = "sh_ylw-pushpin",

                IconStyle = new IconStyle
                {
                    scale = 1.3f,
                    Icon = new IconStyle.IconRef
                    {
                        link = "http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png",
                    },
                    hotSpot = new IconStyle.HotSpot
                    {
                        x = 20,
                        y = 2,
                        xunits = "pixels",
                        yunits = "pixels",
                    }
                },
                LineStyle = new LineStyle
                {
                    color = "ff00aa00",
                    width = 3,
                },
                PolyStyle = new PolyStyle
                {
                    color = "4000aa00",
                },
            };

            XmlSerializer ser = new XmlSerializer( typeof( Style ) );
            string output;
            using (MemoryStream stream = new())
            {
                ser.Serialize(stream, ExistingStyle);

                output = Encoding.UTF8.GetString(stream.ToArray());
                output = output.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n", "");
                output = output.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" ", "");
            }

            string StyleSample =
@"<Style id=""sh_ylw-pushpin"">
    <IconStyle>
        <scale>1.3</scale>
        <Icon>
            <href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href>
        </Icon>
        <hotSpot x=""20"" y=""2"" xunits=""pixels"" yunits=""pixels"" />
    </IconStyle>
    <LineStyle>
        <color>ff00aa00</color>
        <width>3</width>
    </LineStyle>
    <PolyStyle>
        <color>4000aa00</color>
    </PolyStyle>
</Style>";

            Assert.AreEqual( StyleSample.Replace(" ", ""), output.Replace(" ", ""));
        }
    }
}
