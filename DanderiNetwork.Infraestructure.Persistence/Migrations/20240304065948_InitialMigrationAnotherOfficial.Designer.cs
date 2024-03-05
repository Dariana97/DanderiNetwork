﻿// <auto-generated />
using System;
using DanderiNetwork.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DanderiNetwork.Infraestructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240304065948_InitialMigrationAnotherOfficial")]
    partial class InitialMigrationAnotherOfficial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DanderiNetwork.Core.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CommentID")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdReference")
                        .HasColumnType("int");

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CommentID");

                    b.HasIndex("PostID");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("DanderiNetwork.Core.Domain.Entities.Following", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("FollowingUserID")
                        .HasColumnType("int");

                    b.Property<int>("UserMainID")
                        .HasColumnType("int");

                    b.Property<string>("UsernameUserFollowed")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Following", (string)null);
                });

            modelBuilder.Entity("DanderiNetwork.Core.Domain.Entities.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Posts", (string)null);
                });

            modelBuilder.Entity("DanderiNetwork.Core.Domain.Entities.Comment", b =>
                {
                    b.HasOne("DanderiNetwork.Core.Domain.Entities.Comment", null)
                        .WithMany("Comments")
                        .HasForeignKey("CommentID");

                    b.HasOne("DanderiNetwork.Core.Domain.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("DanderiNetwork.Core.Domain.Entities.Comment", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("DanderiNetwork.Core.Domain.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
