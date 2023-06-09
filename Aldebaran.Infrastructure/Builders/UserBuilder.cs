﻿using Aldebaran.Accounts.Models;
using Aldebaran.Accounts.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aldebaran.Infrastructure.Builders;

public class UserBuilder : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(b => b.Name)
            .HasMaxLength(100);

        builder.Property(b => b.Password)
            .HasConversion(
                password => password.ToString(),
                password => new Password(password!));

        builder.Property(b => b.Role)
            .HasConversion(
                role => (int)role, 
                role => (Roles)role);

        builder.Property(b => b.EmailAddress)
            .HasMaxLength(250);

        builder.Property(b => b.IsAuthenticated);
    }
}