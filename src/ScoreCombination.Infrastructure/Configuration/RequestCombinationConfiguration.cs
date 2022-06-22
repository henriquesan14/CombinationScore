using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScoreCombination.Core.Entities;

namespace Confitec.Infrastructure.Configurations
{
    public class RequestCombinationConfigurations
    {
        public void Configure(EntityTypeBuilder<RequestCombination> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder.Property(prop => prop.Request)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Request")
                .HasColumnType("text");
        }
    }
}