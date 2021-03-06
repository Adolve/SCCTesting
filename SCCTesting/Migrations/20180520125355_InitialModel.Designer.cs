﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SCCTesting.Persistence;
using System;

namespace SCCTesting.Migrations
{
    [DbContext(typeof(SCCTestingDbContext))]
    [Migration("20180520125355_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SCCTesting.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("SCCTesting.Models.ProfessorTerm", b =>
                {
                    b.Property<int>("ProfessorId");

                    b.Property<int>("TermId");

                    b.HasKey("ProfessorId", "TermId");

                    b.HasIndex("TermId");

                    b.ToTable("ProfessorTerm");
                });

            modelBuilder.Entity("SCCTesting.Models.Term", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsCurrent");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Terms");
                });

            modelBuilder.Entity("SCCTesting.Models.ProfessorTerm", b =>
                {
                    b.HasOne("SCCTesting.Models.Professor", "Professor")
                        .WithMany("ProfessorTerms")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SCCTesting.Models.Term", "Term")
                        .WithMany("ProfessorTerms")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
