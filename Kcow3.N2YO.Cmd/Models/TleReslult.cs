namespace Kcow3.N2YO.Cmd.Models
{
    // The N2YO Model definition
    // --------------------------------------------------------------------------------------------------------------------
    // Parameter             Type        Comments
    // --------------------------------------------------------------------------------------------------------------------
    // satid                 integer     NORAD id used in input
    // satname               string      Satellite name
    // transactionscount     integer     Count of transactions performed with this API key in last 60 minutes
    // tle                   string      TLE on single line string. Split the line in two by \r\n to get original two lines
    // --------------------------------------------------------------------------------------------------------------------
    public class TleResult
    {
        public string Tle { get; set; }
        public Info Info { get; set; }
    }
}