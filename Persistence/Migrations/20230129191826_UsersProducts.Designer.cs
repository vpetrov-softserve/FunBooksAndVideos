﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230129191826_UsersProducts")]
    partial class UsersProducts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.ProductDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("SKU")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.UsersContentProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContentProductId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsShipped")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContentProductId");

                    b.ToTable("UsersContentProducts");
                });

            modelBuilder.Entity("Domain.UsersMemberships", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MembershipId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MembershipId");

                    b.ToTable("UsersMemberships");
                });

            modelBuilder.Entity("Domain.ContentProduct", b =>
                {
                    b.HasBaseType("Domain.ProductDetails");

                    b.Property<bool>("IsShipped")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductType")
                        .HasColumnType("INTEGER");

                    b.ToTable("Domain.ContentProduct", (string)null);
                });

            modelBuilder.Entity("Domain.Membership", b =>
                {
                    b.HasBaseType("Domain.ProductDetails");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MembershipType")
                        .HasColumnType("INTEGER");

                    b.ToTable("Domain.Membership", (string)null);
                });

            modelBuilder.Entity("Domain.ProductDetails", b =>
                {
                    b.HasOne("Domain.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Domain.UsersContentProducts", b =>
                {
                    b.HasOne("Domain.ContentProduct", "ContentProduct")
                        .WithMany()
                        .HasForeignKey("ContentProductId");

                    b.Navigation("ContentProduct");
                });

            modelBuilder.Entity("Domain.UsersMemberships", b =>
                {
                    b.HasOne("Domain.Membership", "Membership")
                        .WithMany()
                        .HasForeignKey("MembershipId");

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("Domain.ContentProduct", b =>
                {
                    b.HasOne("Domain.ProductDetails", null)
                        .WithOne()
                        .HasForeignKey("Domain.ContentProduct", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Membership", b =>
                {
                    b.HasOne("Domain.ProductDetails", null)
                        .WithOne()
                        .HasForeignKey("Domain.Membership", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}