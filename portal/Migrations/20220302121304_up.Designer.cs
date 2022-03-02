﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using portal.Data;

namespace portal.Migrations
{
    [DbContext(typeof(PortalContext))]
    [Migration("20220302121304_up")]
    partial class up
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("portal.Models.Language", b =>
                {
                    b.Property<int>("Lang_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Lang_key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lang_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Lang_Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("portal.Models.TextResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("textResources");
                });

            modelBuilder.Entity("portal.Models.TextResource", b =>
                {
                    b.HasOne("portal.Models.Language", "language")
                        .WithMany("textResources")
                        .HasForeignKey("LanguageId");

                    b.Navigation("language");
                });

            modelBuilder.Entity("portal.Models.Language", b =>
                {
                    b.Navigation("textResources");
                });
#pragma warning restore 612, 618
        }
    }
}
