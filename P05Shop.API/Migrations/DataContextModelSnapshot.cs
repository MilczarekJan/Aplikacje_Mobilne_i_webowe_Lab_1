﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P05Shop.API.Models;

#nullable disable

namespace P05Shop.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("P06Shop.Shared.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("P06Shop.Shared.Shop.Shoe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("ShoeSize")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Shoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            Name = "Ergonomic Steel Cheese",
                            ShoeSize = 0.79749055849271389
                        },
                        new
                        {
                            Id = 2,
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Name = "Refined Wooden Fish",
                            ShoeSize = 0.5060048510814108
                        },
                        new
                        {
                            Id = 3,
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            Name = "Intelligent Cotton Bike",
                            ShoeSize = 0.13483360229750796
                        },
                        new
                        {
                            Id = 4,
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Name = "Handmade Concrete Salad",
                            ShoeSize = 0.35886506380460459
                        },
                        new
                        {
                            Id = 5,
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            Name = "Ergonomic Granite Pants",
                            ShoeSize = 0.58047483189984916
                        },
                        new
                        {
                            Id = 6,
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            Name = "Generic Soft Fish",
                            ShoeSize = 0.24525723990297749
                        },
                        new
                        {
                            Id = 7,
                            Description = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            Name = "Handcrafted Concrete Hat",
                            ShoeSize = 0.25280545291155831
                        },
                        new
                        {
                            Id = 8,
                            Description = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            Name = "Licensed Steel Shoes",
                            ShoeSize = 0.48646042658316924
                        },
                        new
                        {
                            Id = 9,
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Name = "Handmade Cotton Ball",
                            ShoeSize = 0.635241387242098
                        },
                        new
                        {
                            Id = 10,
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            Name = "Incredible Cotton Pizza",
                            ShoeSize = 0.85220055787460902
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
