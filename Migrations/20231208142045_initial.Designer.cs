﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Slutuppgift___Bibliotek.Data;

#nullable disable

namespace Slutuppgift___Bibliotek.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231208142045_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Slutuppgift___Bibliotek.Models.Auther", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Authers");
                });

            modelBuilder.Entity("Slutuppgift___Bibliotek.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutherId")
                        .HasColumnType("int");

                    b.Property<bool>("Availble")
                        .HasColumnType("bit");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<Guid>("ISBN")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LoanCardID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LoanTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AutherId");

                    b.HasIndex("LoanCardID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Slutuppgift___Bibliotek.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("loanCardID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("loanCardID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Slutuppgift___Bibliotek.Models.LoanCard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("PinCode")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("LoanCards");
                });

            modelBuilder.Entity("Slutuppgift___Bibliotek.Models.Book", b =>
                {
                    b.HasOne("Slutuppgift___Bibliotek.Models.Auther", null)
                        .WithMany("books")
                        .HasForeignKey("AutherId");

                    b.HasOne("Slutuppgift___Bibliotek.Models.LoanCard", "LoanCards")
                        .WithMany("Books")
                        .HasForeignKey("LoanCardID");

                    b.Navigation("LoanCards");
                });

            modelBuilder.Entity("Slutuppgift___Bibliotek.Models.Customer", b =>
                {
                    b.HasOne("Slutuppgift___Bibliotek.Models.LoanCard", "loanCard")
                        .WithMany()
                        .HasForeignKey("loanCardID");

                    b.Navigation("loanCard");
                });

            modelBuilder.Entity("Slutuppgift___Bibliotek.Models.Auther", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("Slutuppgift___Bibliotek.Models.LoanCard", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}