using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Core.Entities;

namespace Registration.Infrastructure.Data.EntityConfigurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //Id
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");
            //FirstName
            builder.Property(d => d.FirstName)
                .HasMaxLength(50);
            builder.Property(d => d.FirstName)
                .IsRequired();
            //LastName
            builder.Property(d => d.LastName)
                .HasMaxLength(50);
            //Email
            builder.Property(d => d.Email)
                .IsRequired();
            builder.HasIndex(d => d.Email)
                .IsUnique();
            //password
            builder.Property(d => d.Password)
                .IsRequired();
            //IsActive
            builder.Property(d => d.IsActive)
                .HasDefaultValue(true);
 
        }
    }
}
