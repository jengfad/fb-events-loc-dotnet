using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace FEL.Core
{
    public static class Helpers
    {
        public static double HaversineDistance(double lat1, double lon1, double lat2, double lon2) {
            var R = 6372.8; // In kilometers
            var dLat = toRadians(lat2 - lat1);
            var dLon = toRadians(lon2 - lon1);
            lat1 = toRadians(lat1);
            lat2 = toRadians(lat2);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Asin(Math.Sqrt(a));
            return R * 2 * Math.Asin(Math.Sqrt(a));
        }

        private static double toRadians(double angle) {
            return Math.PI * angle / 180.0;
        }

        public static void WriteToFile(this string Str)
        {
            string Filename = "generatedUrl.txt";
            File.WriteAllText(Filename, Str);
            return;
        }

    }
}