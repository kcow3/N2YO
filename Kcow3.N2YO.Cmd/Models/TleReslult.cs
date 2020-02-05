namespace Kcow3.N2YO.Cmd.Models
{
    public class TleResult
    {
        public string Tle { get; set; }
        public Info Info { get; set; }
    }

    public class Info
    {
        public int SatId { get; set; }
        public string SatName { get; set; }
        public int TransactionsCount { get; set; }
    }
}
