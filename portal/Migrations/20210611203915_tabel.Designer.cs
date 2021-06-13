﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using portal.Data;

namespace portal.Migrations
{
    [DbContext(typeof(PortalContext))]
    [Migration("20210611203915_tabel")]
    partial class tabel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
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
#pragma warning restore 612, 618
        }
    }
}
