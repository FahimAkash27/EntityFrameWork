﻿// <auto-generated />
using System;
using EfCoreA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AEfCore.Migrations
{
    [DbContext(typeof(LibaryContext))]
    [Migration("20190920004955_createTable1")]
    partial class createTable1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfCoreA.BookInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Barcode");

                    b.Property<int>("Count");

                    b.Property<string>("Edition");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("BookInfos");
                });

            modelBuilder.Entity("EfCoreA.StudentBook", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("BookInfoId");

                    b.Property<DateTime>("IssueDate");

                    b.Property<DateTime>("ReturnDate");

                    b.Property<bool>("Returned");

                    b.HasKey("StudentId", "BookInfoId");

                    b.HasIndex("BookInfoId");

                    b.ToTable("StudentBooks");
                });

            modelBuilder.Entity("EfCoreA.StudentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("FineAmount");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("StudentInfos");
                });

            modelBuilder.Entity("EfCoreA.StudentBook", b =>
                {
                    b.HasOne("EfCoreA.BookInfo", "BookInfo")
                        .WithMany()
                        .HasForeignKey("BookInfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EfCoreA.StudentInfo", "StudentInfo")
                        .WithMany("StudentIssuedBooks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
