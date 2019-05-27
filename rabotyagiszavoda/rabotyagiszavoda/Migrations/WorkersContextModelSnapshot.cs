﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using rabotyagiszavoda;

namespace rabotyagiszavoda.Migrations
{
    [DbContext(typeof(WorkersContext))]
    partial class WorkersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("rabotyagiszavoda.Model.Projects", b =>
                {
                    b.Property<int>("ProjId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("proj_id");

                    b.Property<int>("Cost")
                        .HasColumnName("cost");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasMaxLength(100);

                    b.Property<int?>("WorkerId")
                        .HasColumnName("worker_id");

                    b.HasKey("ProjId")
                        .HasName("projects_pkey");

                    b.HasIndex("WorkerId");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("rabotyagiszavoda.Model.Workers", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("worker_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.HasKey("WorkerId")
                        .HasName("workers_pkey");

                    b.ToTable("workers");
                });

            modelBuilder.Entity("rabotyagiszavoda.Model.Projects", b =>
                {
                    b.HasOne("rabotyagiszavoda.Model.Workers", "Worker")
                        .WithMany("Projects")
                        .HasForeignKey("WorkerId")
                        .HasConstraintName("workers_for_proj");
                });
#pragma warning restore 612, 618
        }
    }
}
