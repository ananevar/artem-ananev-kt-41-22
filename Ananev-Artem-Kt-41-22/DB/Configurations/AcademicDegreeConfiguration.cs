﻿using Ananev_Artem_Kt_41_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ananev_Artem_Kt_41_22.DB.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder.ToTable("AcademicDegrees");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Title).HasMaxLength(100).IsRequired();
        }

    }
}