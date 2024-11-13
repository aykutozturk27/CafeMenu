﻿// <auto-generated />
using System;
using CafeMenu.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CafeMenu.DataAccess.Migrations
{
    [DbContext(typeof(CafeMenuContext))]
    partial class CafeMenuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CafeMenu.Entities.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CategoryName");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("ParentCategoryId");

                    b.HasKey("CategoryId");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("Category", "dbo");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("OperationClaim", "dbo");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImagePath");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ProductName");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("Product", "dbo");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.ProductProperty", b =>
                {
                    b.Property<int>("ProductPropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductPropertyId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("ProductPropertyId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PropertyId");

                    b.ToTable("ProductProperty", "dbo");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyId"));

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Key");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Value");

                    b.HasKey("PropertyId");

                    b.ToTable("Property", "dbo");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(500)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(500)")
                        .HasColumnName("PasswordSalt");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Surname");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Username");

                    b.HasKey("UserId");

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOperationClaims", "dbo");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.Category", b =>
                {
                    b.HasOne("CafeMenu.Entities.Concrete.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("CreatorUserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.Product", b =>
                {
                    b.HasOne("CafeMenu.Entities.Concrete.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CafeMenu.Entities.Concrete.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("CreatorUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.ProductProperty", b =>
                {
                    b.HasOne("CafeMenu.Entities.Concrete.Product", "Product")
                        .WithMany("ProductProperties")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CafeMenu.Entities.Concrete.Property", "Property")
                        .WithMany("ProductProperties")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.HasOne("CafeMenu.Entities.Concrete.OperationClaim", "OperationClaim")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CafeMenu.Entities.Concrete.User", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.OperationClaim", b =>
                {
                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.Product", b =>
                {
                    b.Navigation("ProductProperties");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.Property", b =>
                {
                    b.Navigation("ProductProperties");
                });

            modelBuilder.Entity("CafeMenu.Entities.Concrete.User", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Products");

                    b.Navigation("UserOperationClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
