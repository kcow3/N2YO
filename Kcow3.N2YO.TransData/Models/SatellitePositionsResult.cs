namespace Kcow3.N2YO.TransData.Models
{
    public class SatellitePositionsResult
    {
        // The N2YO Model definition
        // --------------------------------------------------------------------------------------------------------------------
        // Parameter            Type        Comments
        // --------------------------------------------------------------------------------------------------------------------
        // satid	            integer	    NORAD id used in input
        // satname	            string	    Satellite name
        // transactionscount	integer	    Count of transactions performed with this API key in last 60 minutes
        // satlatitude	        float	    Satellite footprint latitude (decimal degrees format)
        // satlongitude	        float	    Satellite footprint longitude (decimal degrees format)
        // azimuth	            float	    Satellite azimuth with respect to observer's location (degrees)
        // elevation	        float	    Satellite elevation with respect to observer's location (degrees)
        // ra	                float	    Satellite right ascension (degrees)
        // dec	                float	    Satellite declination (degrees)
        // timestamp	        integer	    Unix time for this position (seconds). You should convert this UTC value to observer's time zone
        // --------------------------------------------------------------------------------------------------------------------
        public Info Info { get; set; }
        public Position[] Positions { get; set; }
    }
    public class Position
    {
        public float SatLatitude { get; set; }
        public float SatLongitude { get; set; }
        public float Azimuth { get; set; }
        public float Elevation { get; set; }
        public float Ra { get; set; }
        public float Dec { get; set; }
        public int Timestamp { get; set; }
    }

}
