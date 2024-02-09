using System.ComponentModel.DataAnnotations;

namespace ELECTION.Models
{
    public class Vote
    {
        [Key]
        public int VoteID { get; set; }
        public int ElecteurID { get; set; }
        public int CandidatID { get; set; }
        public int BureauDeVoteID { get; set; }
        public DateTime DateVote { get; set; }
        // Autres propriétés pertinentes

        // Propriétés de navigation pour les relations avec électeur, candidat et bureau de vote
        public virtual required Electeur Electeur { get; set; }
        public virtual required Candidat Candidat { get; set; }
        public virtual required BureauDeVote BureauDeVote { get; set; }
    }
}
