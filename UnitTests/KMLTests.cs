
using O2Kml.Shapes;
using O2Kml.Styles;

namespace UnitTests
{
    [TestClass]
    public class KMLTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // TODO: Add some more reasonable tests here
            Assert.IsTrue(true);
            Assert.IsFalse(false);
        }

        [TestMethod]
        public void TestLoadFinalizing ()
        {
            Kml kml = new()
            {
                Document = new()
                {
                    name = "test",
                    StyleMaps = new StyleMap[]
                    {
                        new()
                        {
                            id = "msn test",
                            Pairs = new KmlPair[]
                            {
                                new()
                                {
                                    key = "normal",
                                    styleUrl = "normal style"
                                }
                            }
                        }
                    },
                    Styles = new Style[]
                    {
                        new()
                        {
                            id= "normal style",
                        }
                    },
                    Placemarks = new KmlPlacemark[]
                    {
                        new()
                        {
                            name = "test placemark",
                            styleUrl = "#msn test",
                            Shape = new LineString
                            {
                                Coordinates = new List<LatLon>
                                {
                                    new() {Lat = 0, Lon = 0, Alt= 0},
                                    new() {Lat = 1, Lon = 0, Alt= 0},
                                    new() {Lat = 1, Lon = 1,}
                                }
                            }
                        }
                    }
                }
            };

            kml.FinalizeLoad();

            Assert.IsNotNull(kml.Document.StyleMaps[0].Styles, $"Style map failed to have its dictionary built");
            Assert.IsNotNull(kml.Document.Placemarks[0].styleMap, $"Placemark failed to find a StyleMap object");
        }
    }
}