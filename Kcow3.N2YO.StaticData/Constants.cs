namespace Kcow3.N2YO.StaticData
{
    public static class Constants
    {
        public static string N2YOBaseEndpoint { get; } = "https://www.n2yo.com/rest/v1/";
        public static string TleEndpoint { get; } = "satellite/tle/";
        public static string SatellitePositionsEndpoint { get; } = "satellite/positions/";
        public static string VisualPassesEndpoint { get; } = "satellite/visualpasses/";

        /// <summary>
        /// Builds request to fetch TLE of given satellite
        /// </summary>
        /// <param name="id">NORAD id</param>
        /// <returns>TLE request string</returns>
        public static string BuildTleRequest(int id)
        {
            return $"{N2YOBaseEndpoint}{TleEndpoint}{id}";
        }

        /// <summary>
        /// Builds request to fetch Satellite positions of given satellite and parameters
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
                $"{N2YOBaseEndpoint}{SatellitePositionsEndpoint}{id}/" +
                $"{observer_lat.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture)}/" +
                $"{obeserver_lng.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture)}/" +
                $"{observer_alt.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture)}/{seconds}";
        }

        /// <summary>
        /// Builds request to fetch visual passes of given satellite and parameters
        /// </summary>
        /// <param name="id">NORAD id</param>
        /// <param name="observer_lat">Observer's latitude (decimal degrees format)</param>
        /// <param name="obeserver_lng">Observer's longitude (decimal degrees format)</param>
        /// <param name="observer_alt">Observer's altitude above sea level in meters</param>
        /// <param name="days">Number of days of prediction (max 10)</param>
        /// <param name="min_visibility">Minimum number of seconds the satellite should be considered optically visible during the pass to be returned as result</param>
        /// <returns></returns>
        public static string BuildVisualPassesRequest(int id, double observer_lat, double obeserver_lng, double observer_alt, int days, int min_visibility)
        {
            return $"{N2YOBaseEndpoint}{VisualPassesEndpoint}{id}/" +
                $"{observer_lat.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture)}/" +
                $"{obeserver_lng.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture)}/" +
                $"{observer_alt.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture)}/" +
                $"{days}/" +
                $"{min_visibility}";
        }

        /// <summary>
        /// Builds request to fetch radio passes of given satellite and parameters
        /// </summary>
        /// <param name="id">NORAD id</param>
        /// <param name="observer_lat">Observer's latitude (decimal degrees format)</param>
        /// <param name="obeserver_lng">Observer's longitude (decimal degrees format)</param>
        /// <param name="observer_alt">Observer's altitude above sea level in meters</param>
        /// <param name="days">Number of days of prediction (max 10)</param>
        /// <param name="min_elevation">The minimum elevation acceptable for the highest altitude point of the pass (degrees)</param>
        /// <returns></returns>
        public static string BuildRadioPassesRequest(int id, double observer_lat, double obeserver_lng, double observer_alt, int days, int min_elevation)
        {
            return $"{N2YOBaseEndpoint}{VisualPassesEndpoint}{id}/" +
                $"{observer_lat.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture)}/" +
                $"{obeserver_lng.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture)}/" +
                $"{observer_alt.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture)}/" +
                $"{days}/" +
                $"{min_elevation}";
        }
    }
}
