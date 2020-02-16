using System;

namespace Kcow3.N2YO.TransData.Models
{
    // The N2YO Model definition
    // --------------------------------------------------------------------------------------------------------------------
    // Parameter            Type        Comments
    // --------------------------------------------------------------------------------------------------------------------
    // satid                integer     NORAD id used in input
    // satname              string      Satellite name
    // transactionscount    integer     Count of transactions performed with this API key in last 60 minutes
    // passescount          integer     Count of passes returned
    // startAz              float       Satellite azimuth for the start of this pass (relative to the observer, in degrees)
    // startAzCompass	    string	    Satellite azimuth for the start of this pass (relative to the observer). Possible values: N, NE, E, SE, S, SW, W, NW
    // startUTC             integer     Unix time for the start of this pass. You should convert this UTC value to observer's time zone
    // maxAz	            float	    Satellite azimuth for the max elevation of this pass (relative to the observer, in degrees)
    // maxAzCompass	        string	    Satellite azimuth for the max elevation of this pass (relative to the observer). Possible values: N, NE, E, SE, S, SW, W, NW
    // maxEl	            float	    Satellite max elevation for this pass (relative to the observer, in degrees)
    // maxUTC               integer     Unix time for the max elevation of this pass. You should convert this UTC value to observer's time zone
    // endAz	            float	    Satellite azimuth for the end of this pass (relative to the observer, in degrees)
    // endAzCompass	        string	    Satellite azimuth for the end of this pass (relative to the observer). Possible values: N, NE, E, SE, S, SW, W, NW
    // endUTC               integer     Unix time for the end of this pass. You should convert this UTC value to observer's time zone
    // --------------------------------------------------------------------------------------------------------------------
    public class RadioPass
    {
        public float StartAz { get; set; }
        public string StartAzCompass { get; set; }
        public int StartUTC { get; set; }
        public DateTime StartDate
        {
            get
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)
                    .AddSeconds(StartUTC).ToLocalTime();
            }
        }
        public float MaxAz { get; set; }
        public string MaxAzCompass { get; set; }
        public float MaxEl { get; set; }
        public int MaxUTC { get; set; }
        public float EndAz { get; set; }
        public string EndAzCompass { get; set; }
        public int EndUTC { get; set; }
        public DateTime EndDate
        {
            get
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)
                    .AddSeconds(EndUTC).ToLocalTime();
            }
        }
    }
}
