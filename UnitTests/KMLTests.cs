
using O2Kml.Shapes;
using O2Kml.Styles;

namespace UnitTests
{
    [TestClass]
    public class KMLTests
    {
        public readonly Kml TestKml = new()
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
                            id = "normal style",
                        }
                    },
                Items = new KmlItem[]
                    {
                        new KmlPlacemark
                        {
                            Name = "test placemark",
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
                        },
                        new KmlPlacemark
                        {
                            Name = "point",
                            styleUrl = "#msn test",
                            Shape = new KmlPoint
                            {
                                InnerText = "45.00000000000000,45,100",
                            }
                        },
                        new KmlFolder
                        {
                            Name = "Folder",
                            Description = "something",
                            Items = Array.Empty<KmlItem>(),
                        }
                    }
            }
        };

        [TestMethod]
        public void TestMethod1()
        {
            // TODO: Add some more reasonable tests here
            Assert.IsTrue(true);
            Assert.IsFalse(false);
        }

        [TestMethod]
        public void TestLoadFinalizing()
        {
            TestKml.FinalizeLoad();

            Assert.IsTrue(TestKml.Document.Items.Count() == 3);

            Assert.IsNotNull(TestKml.Document.StyleMaps[0].Styles, $"Style map failed to have its dictionary built");
            Assert.IsNotNull(((KmlPlacemark)TestKml.Document.Items[0]).styleMap, $"Placemark failed to find a StyleMap object");
        }

        [TestMethod]
        public void TestKmlPlacemarks ()
        {
            Assert.IsTrue(TestKml.Document.Placemarks.Count() == 2);

            Assert.IsInstanceOfType(((KmlPlacemark)TestKml.Document.Items[1]).Shape, typeof(KmlPoint));
            Assert.IsTrue((((KmlPlacemark)TestKml.Document.Items[1]).Shape as KmlPoint).Coordinates.Equals(new LatLon { Lat = 45, Lon = 45, Alt = 100 }));
        }

        [TestMethod]
        public void TestKmlFolders ()
        {
            Assert.IsTrue(TestKml.Document.Folders.Count() == 1);
            Assert.IsTrue(TestKml.Document.Folders.First().Name == "Folder");
            Assert.IsTrue(TestKml.Document.Folders.First().Description == "something");
            Assert.IsTrue(TestKml.Document.Folders.First().Items.Count() == 0);
        }
    }
}