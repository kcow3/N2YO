namespace Kcow3.N2YO.StaticData
{
    public static class Constants
    {
        public static string N2YOBaseUrl { get; } = "https://www.n2yo.com/rest/v1/";
        public static string TleEndpoint { get; } = "satellite/tle/";
        public static string SatellitePositions { get; } = "satellite/positions/";

        /// <summary>
        /// Builds request to fetch TLE of given satellite
        /// </summary>
        /// <param name="id">NORAD id</param>
        /// <returns>TLE request string</returns>
        public static string BuildTleRequest(int id)
        {
            return $"{N2YOBaseUrl}{TleEndpoint}{id}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">NORAD id</param>
        /// <param name="observer_lat">Observer's latitude (decimal degrees format)</param>
        /// <param name="obeserver_lng">Observer's longitude (decimal degrees format)</param>
        /// <param name="observer_alt">	Observer's altitude above sea level in meters</param>
        /// <param name="seconds">	Number of future positions to return. Each second is a position. Limit 300 seconds</param>
        /// <returns></returns>
        public static string BuildSatellitePositionsRequest(int id, double observer_lat, double obeserver_lng, double observer_alt, int seconds)
        {
            return 
                $"{N2YOBaseUrl}{SatellitePositions}{id}/" +
                $"{observer_lat.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture)}/" +
                $"{obeserver_lng.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture)}/" +
                $"{observer_alt.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture)}/{seconds}";
        }
    }
}
