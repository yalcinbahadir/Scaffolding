﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ScaffoldExampleConsole
{
    public partial class SamuraisContext : DbContext
    {
        public SamuraisContext()
        {
        }

        public SamuraisContext(DbContextOptions<SamuraisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Samurai> Samurais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PF1GGK43\\SQLEXPRESS02;Initial Catalog=Samurais;MultipleActiveResultSets=true; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasIndex(e => e.SamuraiId, "IX_Quotes_SamuraiId");

                entity.HasOne(d => d.Samurai)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.SamuraiId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
