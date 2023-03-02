﻿using EmsisoftTask.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmsisoftTask.Data.EntityFramework.Configurations
{
    public class HashConfiguration : IEntityTypeConfiguration<Hash>
    {
        public void Configure(EntityTypeBuilder<Hash> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Hashes");
        }
    }
}
