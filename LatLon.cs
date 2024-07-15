using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace O2Kml
{
    public class LatLon
    {
        public static readonly Regex LatLonRegex = new Regex(@"(?<lon>[-]?\d+[.]?\d*),(?<lat>[-]?\d+[.]?\d*)([,](?<alt>[-]?\d+[.]?\d*))?", RegexOptions.IgnoreCase);

        public double Lat = 0;
        public double Lon = 0;
        public double Alt = 0;

        public override string ToString()
        {
            return $"{Lat},{Lon},{Alt}";
        }

        public static LatLon FromRegexMatch (Match match)
        {
            var groups = match.Groups;
            double lon = double.Parse(groups["lon"].Value);
            double lat = double.Parse(groups["lat"].Value);
            double alt = double.TryParse(groups["alt"].Value, out double _a) ? _a : 0;

            return new LatLon { Lat = lat, Lon = lon, Alt = alt };
        }

        public override bool Equals(object? obj)
        {
            if(obj is LatLon second)
            {
                return this.GetHashCode() == second.GetHashCode();
            }

            return base.Equals(obj);
        }

        public override int GetHashCode() => Lat.GetHashCode() + Lon.GetHashCode() + Alt.GetHashCode();
        
    }
}
