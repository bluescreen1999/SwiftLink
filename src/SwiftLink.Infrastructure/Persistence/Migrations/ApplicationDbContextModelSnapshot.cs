﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwiftLink.Infrastructure.Persistence.Context;

#nullable disable

namespace SwiftLink.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Base")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SwiftLink.Domain.Entities.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<string>("OriginalUrl")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1500)");

                    b.Property<string>("Password")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ShortCode")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)");

                    b.Property<int>("SubscriberId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Base_Link");

                    b.HasIndex("ShortCode")
                        .IsUnique();

                    b.HasIndex("SubscriberId");

                    b.ToTable("Link", "Base", t =>
                        {
                            t.HasComment("Stores Original links and generated shortCode.");
                        });
                });

            modelBuilder.Entity("SwiftLink.Domain.Entities.LinkVisit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ClientMetaData")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("LinkId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Base_LinkVisit");

                    b.HasIndex("LinkId");

                    b.ToTable("LinkVisit", "Base", t =>
                        {
                            t.HasComment("analytics, providing insights into the number of users who clicked on a shortened link.");
                        });
                });

            modelBuilder.Entity("SwiftLink.Domain.Entities.Subscriber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Token")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_Base_Subscriber");

                    b.ToTable("Subscriber", "Base", t =>
                        {
                            t.HasComment("Only these subscribers are allowed to insert a URL to obtain a shorter one.");
                        });
                });

            modelBuilder.Entity("SwiftLink.Domain.Entities.Link", b =>
                {
                    b.HasOne("SwiftLink.Domain.Entities.Subscriber", "Subscriber")
                        .WithMany()
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Subscriber");
                });

            modelBuilder.Entity("SwiftLink.Domain.Entities.LinkVisit", b =>
                {
                    b.HasOne("SwiftLink.Domain.Entities.Link", "Link")
                        .WithMany("LinkVisits")
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Link");
                });

            modelBuilder.Entity("SwiftLink.Domain.Entities.Link", b =>
                {
                    b.Navigation("LinkVisits");
                });
#pragma warning restore 612, 618
        }
    }
}
