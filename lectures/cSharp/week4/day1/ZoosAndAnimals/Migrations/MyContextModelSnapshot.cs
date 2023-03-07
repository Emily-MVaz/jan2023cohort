﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZoosAndAnimals.Models;

#nullable disable

namespace ZoosAndAnimals.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ZoosAndAnimals.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Diet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Habitat")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("AnimalId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("ZoosAndAnimals.Models.Assign", b =>
                {
                    b.Property<int>("AssignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ZooId")
                        .HasColumnType("int");

                    b.HasKey("AssignId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("ZooId");

                    b.ToTable("Assign");
                });

            modelBuilder.Entity("ZoosAndAnimals.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ZoosAndAnimals.Models.Zoo", b =>
                {
                    b.Property<int>("ZooId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ZooId");

                    b.HasIndex("UserId");

                    b.ToTable("Zoos");
                });

            modelBuilder.Entity("ZoosAndAnimals.Models.Assign", b =>
                {
                    b.HasOne("ZoosAndAnimals.Models.Animal", "TheAnimal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZoosAndAnimals.Models.Zoo", "TheZoo")
                        .WithMany("AllAnimals")
                        .HasForeignKey("ZooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TheAnimal");

                    b.Navigation("TheZoo");
                });

            modelBuilder.Entity("ZoosAndAnimals.Models.Zoo", b =>
                {
                    b.HasOne("ZoosAndAnimals.Models.User", "Owner")
                        .WithMany("OwnerZoo")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ZoosAndAnimals.Models.User", b =>
                {
                    b.Navigation("OwnerZoo");
                });

            modelBuilder.Entity("ZoosAndAnimals.Models.Zoo", b =>
                {
                    b.Navigation("AllAnimals");
                });
#pragma warning restore 612, 618
        }
    }
}
