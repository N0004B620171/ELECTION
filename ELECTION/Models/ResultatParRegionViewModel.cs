namespace ELECTION.Models
{
    internal class ResultatParRegionViewModel
    {
        public int RegionID { get; set; }
        public string? RegionNom { get; set; }
        public string? CandidatNom { get; set; }
        public int NombreDeVotes { get; set; }
    }
}