using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ELECTION.Models;

namespace ELECTION.Data
{
    public class ELECTIONContext : DbContext
    {
        public ELECTIONContext (DbContextOptions<ELECTIONContext> options)
            : base(options)
        {
        }

        public DbSet<ELECTION.Models.Candidat> Candidat { get; set; } = default!;
        public DbSet<ELECTION.Models.Electeur> Electeur { get; set; } = default!;
        public DbSet<ELECTION.Models.Region> Region { get; set; } = default!;
        public DbSet<ELECTION.Models.BureauDeVote> BureauDeVote { get; set; } = default!;
        public DbSet<ELECTION.Models.Vote> Vote { get; set; } = default!;
    }
}
