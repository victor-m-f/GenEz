﻿// <auto-generated />
using System;
using GenEz.Character.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GenEz.Character.Data.Migrations
{
    [DbContext(typeof(CharacterDbContext))]
    [Migration("20210125173454_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("GenEz.Character.Domain.Entities.NameOrigin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("tb_name_origin");
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.PersonName", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsFemale")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFirstName")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMale")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSurname")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("NeutralName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nickname")
                        .HasColumnType("varchar(30)");

                    b.Property<Guid?>("PersonNameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("PersonNameId");

                    b.ToTable("tb_person_name");
                });

            modelBuilder.Entity("NameOriginPersonName", b =>
                {
                    b.Property<Guid>("NameOriginsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonNamesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NameOriginsId", "PersonNamesId");

                    b.HasIndex("PersonNamesId");

                    b.ToTable("NameOriginPersonName");
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.PersonName", b =>
                {
                    b.HasOne("GenEz.Character.Domain.Entities.PersonName", null)
                        .WithMany("RelatedPersonNames")
                        .HasForeignKey("PersonNameId");
                });

            modelBuilder.Entity("NameOriginPersonName", b =>
                {
                    b.HasOne("GenEz.Character.Domain.Entities.NameOrigin", null)
                        .WithMany()
                        .HasForeignKey("NameOriginsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GenEz.Character.Domain.Entities.PersonName", null)
                        .WithMany()
                        .HasForeignKey("PersonNamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.PersonName", b =>
                {
                    b.Navigation("RelatedPersonNames");
                });
#pragma warning restore 612, 618
        }
    }
}
