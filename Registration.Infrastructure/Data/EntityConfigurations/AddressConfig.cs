using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Core.Entities;

namespace Registration.Infrastructure.Data.EntityConfigurations
{
    public class AddressConfig :IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            //Id
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");
            //CityName
            builder.Property(d => d.CityName)
                .IsRequired();
            //CountryName
            builder.Property(d => d.CountryName)
                .IsRequired();
            //Location
            builder.Property(d => d.Location)
                .IsRequired();
            builder.Property(d => d.IsDefault)
                .HasDefaultValue(false);
            //Customer : Address
            builder.HasOne(d => d.Customer)
                .WithMany(d => d.Addresses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
