using Microsoft.EntityFrameworkCore;
using ScoreCombination.Core.Entities;
using System.Reflection;

namespace Confitec.Infrastructure.Context
{
    public class ScoreCombinationContext : DbContext
    {
        public ScoreCombinationContext(DbContextOptions<ScoreCombinationContext> options) : base(options)
        {
        }
        public DbSet<ScoreCombination.Core.Entities.ScoreCombinationEntity> ScoresCombinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
