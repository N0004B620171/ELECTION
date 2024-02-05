using System.ComponentModel.DataAnnotations;

namespace ELECTION.Models
{
    public class Electeur
    {
        public int ElecteurID { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string? Adresse { get; set; }
        public string? NumeroIdentification { get; set; }

    }
}
