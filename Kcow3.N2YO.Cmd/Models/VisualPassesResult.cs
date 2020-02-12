namespace Kcow3.N2YO.Cmd.Models
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
    // startEl	            float	    Satellite elevation for the start of this pass (relative to the observer, in degrees)
    // startUTC             integer     Unix time for the start of this pass. You should convert this UTC value to observer's time zone
    // maxAz	            float	    Satellite azimuth for the max elevation of this pass (relative to the observer, in degrees)
    // maxAzCompass	        string	    Satellite azimuth for the max elevation of this pass (relative to the observer). Possible values: N, NE, E, SE, S, SW, W, NW
    // maxEl	            float	    Satellite max elevation for this pass (relative to the observer, in degrees)
    // maxUTC               integer     Unix time for the max elevation of this pass. You should convert this UTC value to observer's time zone
    // endAz	            float	    Satellite azimuth for the end of this pass (relative to the observer, in degrees)
    // endAzCompass	        string	    Satellite azimuth for the end of this pass (relative to the observer). Possible values: N, NE, E, SE, S, SW, W, NW
    // endEl	            float	    Satellite elevation for the end of this pass (relative to the observer, in degrees)
    // endUTC               integer     Unix time for the end of this pass. You should convert this UTC value to observer's time zone
    // mag	                float	    Max visual magnitude of the pass, same scale as star brightness. If magnitude cannot be determined, the value is 100000
    // duration             integer     Total visible duration of this pass (in seconds)
    // --------------------------------------------------------------------------------------------------------------------
    public class VisualPassesResult
    {
        public PassesInfo Info { get; set; }
        public VisualPass[] Passes { get; set; }
    }
}
