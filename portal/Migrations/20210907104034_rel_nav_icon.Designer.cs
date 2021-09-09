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
    [Migration("20210907104034_rel_nav_icon")]
    partial class rel_nav_icon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("portal.Models.IconNav", b =>
                {
                    b.Property<int>("id_IconNav")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("lang_Id")
                        .HasColumnType("int");

                    b.Property<string>("nameHint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameNav")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("urlNav")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_IconNav");

                    b.HasIndex("lang_Id");

                    b.ToTable("IconNav");
                });

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

            modelBuilder.Entity("portal.Models.IconNav", b =>
                {
                    b.HasOne("portal.Models.Language", "language")
                        .WithMany("IconNavs")
                        .HasForeignKey("lang_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("language");
                });

            modelBuilder.Entity("portal.Models.Language", b =>
                {
                    b.Navigation("IconNavs");
                });
#pragma warning restore 612, 618
        }
    }
}
