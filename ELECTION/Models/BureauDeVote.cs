using System.ComponentModel.DataAnnotations;

namespace ELECTION.Models
{
    public class BureauDeVote
    {
        [Key]
        public int BureauID { get; set; }
        public string? Emplacement { get; set; }
        public string? Responsable { get; set; }
        public int RegionID { get; set; }
        // Autres propriétés pertinentes

        // Propriété de navigation pour la relation avec la région
        public virtual Region? Region { get; set; }

    }
}

