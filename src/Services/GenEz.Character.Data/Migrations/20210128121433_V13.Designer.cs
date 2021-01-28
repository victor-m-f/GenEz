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
    [Migration("20210128121433_V13")]
    partial class V13
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CharacteristicCharacteristic", b =>
                {
                    b.Property<Guid>("CharacteristicsOpposedFromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CharacteristicsOpposedToId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CharacteristicsOpposedFromId", "CharacteristicsOpposedToId");

                    b.HasIndex("CharacteristicsOpposedToId");

                    b.ToTable("tb_opposed_characteristic");
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.Characteristic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsPositive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NeutralName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("NeutralName")
                        .IsUnique();

                    b.ToTable("tb_characteristic");
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.Education", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("MinimumAge")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("YearsToComplete")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_education");

                    b.HasData(
                        new
                        {
                            Id = new Guid("418a24c4-5e3a-41be-aec7-5f534ca09587"),
                            MinimumAge = (byte)0,
                            Name = "less than primary school",
                            YearsToComplete = (byte)0
                        },
                        new
                        {
                            Id = new Guid("cc1bffd3-8272-48ae-85f0-f1b7abeffe06"),
                            MinimumAge = (byte)6,
                            Name = "primary school",
                            YearsToComplete = (byte)5
                        },
                        new
                        {
                            Id = new Guid("a24f28be-5288-438b-8710-5cdc180426a6"),
                            MinimumAge = (byte)15,
                            Name = "high school",
                            YearsToComplete = (byte)4
                        },
                        new
                        {
                            Id = new Guid("04856059-d913-4615-b469-1f2ed2cf47f7"),
                            MinimumAge = (byte)17,
                            Name = "some college",
                            YearsToComplete = (byte)3
                        },
                        new
                        {
                            Id = new Guid("0bb2708d-d637-42ef-a728-93b6eb9f4f32"),
                            MinimumAge = (byte)17,
                            Name = "bachelor's degree",
                            Title = "Bachelor",
                            YearsToComplete = (byte)5
                        },
                        new
                        {
                            Id = new Guid("606ba2fc-e154-438f-a9de-7c2ad447886e"),
                            MinimumAge = (byte)22,
                            Name = "masters",
                            Title = "Master",
                            YearsToComplete = (byte)2
                        },
                        new
                        {
                            Id = new Guid("814ef9bc-0e26-4154-9bd5-28476b909945"),
                            Abbreviation = "Dr.",
                            MinimumAge = (byte)22,
                            Name = "doctorate",
                            Title = "Doctor",
                            YearsToComplete = (byte)2
                        });
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.Ethnicity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_ethnicity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("418a24c4-5e3a-41be-aec7-5f534ca09587"),
                            Name = "caucasian"
                        },
                        new
                        {
                            Id = new Guid("cc1bffd3-8272-48ae-85f0-f1b7abeffe06"),
                            Name = "mixed"
                        },
                        new
                        {
                            Id = new Guid("a24f28be-5288-438b-8710-5cdc180426a6"),
                            Name = "latin"
                        },
                        new
                        {
                            Id = new Guid("04856059-d913-4615-b469-1f2ed2cf47f7"),
                            Name = "african"
                        },
                        new
                        {
                            Id = new Guid("0bb2708d-d637-42ef-a728-93b6eb9f4f32"),
                            Name = "middle eastern"
                        },
                        new
                        {
                            Id = new Guid("606ba2fc-e154-438f-a9de-7c2ad447886e"),
                            Name = "amerindian"
                        },
                        new
                        {
                            Id = new Guid("1cb3cdce-5aa9-49ab-b18d-4e9f225ccbbe"),
                            Name = "asian"
                        },
                        new
                        {
                            Id = new Guid("a489ab07-7264-4c7d-881a-31504fc3a372"),
                            Name = "south asian"
                        });
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.NameOrigin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("NeutralName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_name_origin");

                    b.HasData(
                        new
                        {
                            Id = new Guid("be0c73e9-2710-4676-9478-ee36a9e6f96e"),
                            Name = "African",
                            NeutralName = "AFRICAN"
                        },
                        new
                        {
                            Id = new Guid("f7a540bd-ddc7-421d-a879-0e7974a5633b"),
                            Name = "Arabic",
                            NeutralName = "ARABIC"
                        },
                        new
                        {
                            Id = new Guid("81f4bb6e-3c6d-4ee4-a7c6-4f18be3dd478"),
                            Name = "Celtic",
                            NeutralName = "CELTIC"
                        },
                        new
                        {
                            Id = new Guid("e376ea1a-0f28-4f67-809a-a78bcc0a7183"),
                            Name = "Chinese",
                            NeutralName = "CHINESE"
                        },
                        new
                        {
                            Id = new Guid("838c1be0-06b0-48ac-9268-c69072280f90"),
                            Name = "French",
                            NeutralName = "FRENCH"
                        },
                        new
                        {
                            Id = new Guid("208ed58e-d875-473a-a67e-3dc3e034c783"),
                            Name = "Gaelic",
                            NeutralName = "GAELIC"
                        },
                        new
                        {
                            Id = new Guid("eb47fd93-662f-45a8-b6f4-fe63400d0c3d"),
                            Name = "German",
                            NeutralName = "GERMAN"
                        },
                        new
                        {
                            Id = new Guid("0c101315-5611-4967-acb0-27e124d5de1c"),
                            Name = "Greek",
                            NeutralName = "GREEK"
                        },
                        new
                        {
                            Id = new Guid("6408b9ea-d64f-4f22-9045-133788ecb4b6"),
                            Name = "Hawaiian",
                            NeutralName = "HAWAIIAN"
                        },
                        new
                        {
                            Id = new Guid("24ecc259-89e2-4b20-b1f5-7890a5e4e820"),
                            Name = "Hebrew",
                            NeutralName = "HEBREW"
                        },
                        new
                        {
                            Id = new Guid("ee7088e9-706b-49c6-8468-ed57ddfaed12"),
                            Name = "Hindu",
                            NeutralName = "HINDU"
                        },
                        new
                        {
                            Id = new Guid("4455ea44-e256-4f38-b120-5da91007aef6"),
                            Name = "Italian",
                            NeutralName = "ITALIAN"
                        },
                        new
                        {
                            Id = new Guid("bc3d3311-4353-4fe7-85f8-e9816ca2e80a"),
                            Name = "Japanese",
                            NeutralName = "JAPANESE"
                        },
                        new
                        {
                            Id = new Guid("fcb12666-b2f2-4a00-a9e8-0b48e46653cd"),
                            Name = "Latin",
                            NeutralName = "LATIN"
                        },
                        new
                        {
                            Id = new Guid("9da6842e-8f89-4a04-a187-973bef4f0d45"),
                            Name = "Portuguese",
                            NeutralName = "PORTUGUESE"
                        },
                        new
                        {
                            Id = new Guid("609c53b7-968c-46b0-b231-01e0ddc6a351"),
                            Name = "Russian",
                            NeutralName = "RUSSIAN"
                        });
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.Nickname", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_nickname");
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

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("tb_person_name");
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.Religion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adjective")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("IsFictional")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("NeutralText")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_religion");

                    b.HasData(
                        new
                        {
                            Id = new Guid("418a24c4-5e3a-41be-aec7-5f534ca09587"),
                            Adjective = "christian",
                            IsFictional = false,
                            Name = "Christianity",
                            NeutralText = "CHRISTIANITY"
                        },
                        new
                        {
                            Id = new Guid("cc1bffd3-8272-48ae-85f0-f1b7abeffe06"),
                            Adjective = "muslim",
                            IsFictional = false,
                            Name = "Islam",
                            NeutralText = "ISLAM"
                        },
                        new
                        {
                            Id = new Guid("a24f28be-5288-438b-8710-5cdc180426a6"),
                            Adjective = "agnostic",
                            IsFictional = false,
                            Name = "Agnosticism",
                            NeutralText = "AGNOSTICISM"
                        },
                        new
                        {
                            Id = new Guid("04856059-d913-4615-b469-1f2ed2cf47f7"),
                            Adjective = "atheist",
                            IsFictional = false,
                            Name = "Atheism",
                            NeutralText = "ATHEISM"
                        },
                        new
                        {
                            Id = new Guid("0bb2708d-d637-42ef-a728-93b6eb9f4f32"),
                            Adjective = "hindu",
                            IsFictional = false,
                            Name = "Hinduism",
                            NeutralText = "HINDUISM"
                        },
                        new
                        {
                            Id = new Guid("606ba2fc-e154-438f-a9de-7c2ad447886e"),
                            Adjective = "buddhist",
                            IsFictional = false,
                            Name = "Buddhism",
                            NeutralText = "BUDDHISM"
                        },
                        new
                        {
                            Id = new Guid("1cb3cdce-5aa9-49ab-b18d-4e9f225ccbbe"),
                            Adjective = "taoist",
                            IsFictional = false,
                            Name = "Taoism",
                            NeutralText = "TAOISM"
                        },
                        new
                        {
                            Id = new Guid("a489ab07-7264-4c7d-881a-31504fc3a372"),
                            Adjective = "sikh",
                            IsFictional = false,
                            Name = "Sikhism",
                            NeutralText = "SIKHISM"
                        },
                        new
                        {
                            Id = new Guid("be87573a-91f0-4228-bf66-4bc4382467b7"),
                            Adjective = "spiritist",
                            IsFictional = false,
                            Name = "Spiritism",
                            NeutralText = "SPIRITISM"
                        },
                        new
                        {
                            Id = new Guid("5ddb4cc2-bea2-4766-a870-9abb852574dd"),
                            Adjective = "jew",
                            IsFictional = false,
                            Name = "Judaism",
                            NeutralText = "JUDAISM"
                        });
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.SexualOrientation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<bool?>("PreferFemale")
                        .HasColumnType("bit");

                    b.Property<bool?>("PreferOppositeSex")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_sexual_orientation");

                    b.HasData(
                        new
                        {
                            Id = new Guid("418a24c4-5e3a-41be-aec7-5f534ca09587"),
                            Name = "androsexual",
                            PreferFemale = false
                        },
                        new
                        {
                            Id = new Guid("cc1bffd3-8272-48ae-85f0-f1b7abeffe06"),
                            Name = "gynesexual",
                            PreferFemale = true
                        },
                        new
                        {
                            Id = new Guid("a24f28be-5288-438b-8710-5cdc180426a6"),
                            Name = "asexual"
                        },
                        new
                        {
                            Id = new Guid("04856059-d913-4615-b469-1f2ed2cf47f7"),
                            Name = "autosexual"
                        },
                        new
                        {
                            Id = new Guid("0bb2708d-d637-42ef-a728-93b6eb9f4f32"),
                            Name = "bicurious"
                        },
                        new
                        {
                            Id = new Guid("606ba2fc-e154-438f-a9de-7c2ad447886e"),
                            Name = "bisexual"
                        },
                        new
                        {
                            Id = new Guid("1cb3cdce-5aa9-49ab-b18d-4e9f225ccbbe"),
                            Name = "gay",
                            PreferOppositeSex = false
                        },
                        new
                        {
                            Id = new Guid("a489ab07-7264-4c7d-881a-31504fc3a372"),
                            Name = "straight",
                            PreferOppositeSex = true
                        },
                        new
                        {
                            Id = new Guid("d7a9cab4-703d-47f7-92b3-87b3281c2ed0"),
                            Name = "pansexual"
                        });
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.SocialClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_social_class");

                    b.HasData(
                        new
                        {
                            Id = new Guid("be0c73e9-2710-4676-9478-ee36a9e6f96e"),
                            Name = "working"
                        },
                        new
                        {
                            Id = new Guid("f7a540bd-ddc7-421d-a879-0e7974a5633b"),
                            Name = "middle"
                        },
                        new
                        {
                            Id = new Guid("81f4bb6e-3c6d-4ee4-a7c6-4f18be3dd478"),
                            Name = "upper"
                        });
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.Spelling", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NeutralText")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<Guid?>("PersonNameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("PersonNameId");

                    b.HasIndex("Text")
                        .IsUnique();

                    b.ToTable("tb_spelling");
                });

            modelBuilder.Entity("NameOriginPersonName", b =>
                {
                    b.Property<Guid>("NameOriginsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonNamesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NameOriginsId", "PersonNamesId");

                    b.HasIndex("PersonNamesId");

                    b.ToTable("tb_person_name_origin");
                });

            modelBuilder.Entity("NicknamePersonName", b =>
                {
                    b.Property<Guid>("NicknamesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonNamesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NicknamesId", "PersonNamesId");

                    b.HasIndex("PersonNamesId");

                    b.ToTable("tb_person_name_nickname");
                });

            modelBuilder.Entity("PersonNamePersonName", b =>
                {
                    b.Property<Guid>("RelatedPersonNamesFromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RelatedPersonNamesToId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RelatedPersonNamesFromId", "RelatedPersonNamesToId");

                    b.HasIndex("RelatedPersonNamesToId");

                    b.ToTable("tb_related_person_name");
                });

            modelBuilder.Entity("CharacteristicCharacteristic", b =>
                {
                    b.HasOne("GenEz.Character.Domain.Entities.Characteristic", null)
                        .WithMany()
                        .HasForeignKey("CharacteristicsOpposedFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GenEz.Character.Domain.Entities.Characteristic", null)
                        .WithMany()
                        .HasForeignKey("CharacteristicsOpposedToId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.Spelling", b =>
                {
                    b.HasOne("GenEz.Character.Domain.Entities.PersonName", "PersonName")
                        .WithMany("Spellings")
                        .HasForeignKey("PersonNameId");

                    b.Navigation("PersonName");
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

            modelBuilder.Entity("NicknamePersonName", b =>
                {
                    b.HasOne("GenEz.Character.Domain.Entities.Nickname", null)
                        .WithMany()
                        .HasForeignKey("NicknamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GenEz.Character.Domain.Entities.PersonName", null)
                        .WithMany()
                        .HasForeignKey("PersonNamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonNamePersonName", b =>
                {
                    b.HasOne("GenEz.Character.Domain.Entities.PersonName", null)
                        .WithMany()
                        .HasForeignKey("RelatedPersonNamesFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GenEz.Character.Domain.Entities.PersonName", null)
                        .WithMany()
                        .HasForeignKey("RelatedPersonNamesToId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenEz.Character.Domain.Entities.PersonName", b =>
                {
                    b.Navigation("Spellings");
                });
#pragma warning restore 612, 618
        }
    }
}
