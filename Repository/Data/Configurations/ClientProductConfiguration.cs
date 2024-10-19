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
    internal class ClientProductConfiguration : IEntityTypeConfiguration<ClientProduct>
    {
        public void Configure(EntityTypeBuilder<ClientProduct> builder)
        {
            builder.HasKey(cp => new { cp.ClientId, cp.ProductId });

            builder.Property(x => x.StartDate)
                .IsRequired();

            builder.Property(x => x.License)
                .IsRequired()
                .HasMaxLength(255);


            // This to ensure the Many-to-Many Relationship 
            // as this class has one-to-many with the client and product
            builder.HasOne(cp => cp.Client)
                .WithMany(c => c.ClientProducts)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Restrict); // this will prevent the deletion if there is related record
            
            builder.HasOne(cp => cp.Product)
                .WithMany(p => p.ClientProducts)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // this will prevent the deletion if there is related record
        }
    }
}
