using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(9);

            builder.HasIndex(x => x.Code)
                .IsUnique();

            builder.Property(x => x.Class)
                .IsRequired();
                

            // This to ensure the Many-to-Many Relationship 
            builder.HasMany(c => c.ClientProducts)
                .WithOne(c => c.Client)
                .HasForeignKey(c => c.ClientId);

        }
    }
}
