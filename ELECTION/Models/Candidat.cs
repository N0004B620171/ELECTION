using System.ComponentModel.DataAnnotations;

namespace ELECTION.Models
{
    public class Candidat
    {
        public int CandidatID { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string? PartiPolitique { get; set; }
        public string? Photo { get; set; }
    }
}
