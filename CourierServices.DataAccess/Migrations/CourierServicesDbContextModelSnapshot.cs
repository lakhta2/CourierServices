﻿// <auto-generated />
using System;
using CourierServices.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourierServices.DataAccess.Migrations
{
    [DbContext(typeof(CourierServicesDbContext))]
    partial class CourierServicesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourierServices.DataAccess.Entities.FinalOrders", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("FinalOrders");
                });

            modelBuilder.Entity("CourierServices.DataAccess.Entities.Logs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Query")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("CourierServices.DataAccess.Entities.OrderEntities", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CourierServices.DataAccess.Entities.FinalOrders", b =>
                {
                    b.OwnsOne("CourierServices.DataAccess.ValueObjects.DeliveryTimeValueObject", "DeliveryTime", b1 =>
                        {
                            b1.Property<Guid>("FinalOrdersId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("DeliveryTimeValue")
                                .HasColumnType("datetime2");

                            b1.HasKey("FinalOrdersId");

                            b1.ToTable("FinalOrders");

                            b1.WithOwner()
                                .HasForeignKey("FinalOrdersId");
                        });

                    b.OwnsOne("CourierServices.DataAccess.ValueObjects.DistrictValueObject", "District", b1 =>
                        {
                            b1.Property<Guid>("FinalOrdersId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DistrictId")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("NormalizedName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("FinalOrdersId");

                            b1.ToTable("FinalOrders");

                            b1.WithOwner()
                                .HasForeignKey("FinalOrdersId");
                        });

                    b.OwnsOne("CourierServices.DataAccess.ValueObjects.WeightValueObject", "Weight", b1 =>
                        {
                            b1.Property<Guid>("FinalOrdersId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("WeightValue")
                                .HasColumnType("float");

                            b1.HasKey("FinalOrdersId");

                            b1.ToTable("FinalOrders");

                            b1.WithOwner()
                                .HasForeignKey("FinalOrdersId");
                        });

                    b.Navigation("DeliveryTime")
                        .IsRequired();

                    b.Navigation("District")
                        .IsRequired();

                    b.Navigation("Weight")
                        .IsRequired();
                });

            modelBuilder.Entity("CourierServices.DataAccess.Entities.OrderEntities", b =>
                {
                    b.OwnsOne("CourierServices.DataAccess.ValueObjects.DeliveryTimeValueObject", "DeliveryTime", b1 =>
                        {
                            b1.Property<Guid>("OrderEntitiesId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("DeliveryTimeValue")
                                .HasColumnType("datetime2");

                            b1.HasKey("OrderEntitiesId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderEntitiesId");
                        });

                    b.OwnsOne("CourierServices.DataAccess.ValueObjects.DistrictValueObject", "District", b1 =>
                        {
                            b1.Property<Guid>("OrderEntitiesId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DistrictId")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("NormalizedName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderEntitiesId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderEntitiesId");
                        });

                    b.OwnsOne("CourierServices.DataAccess.ValueObjects.WeightValueObject", "Weight", b1 =>
                        {
                            b1.Property<Guid>("OrderEntitiesId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("WeightValue")
                                .HasColumnType("float");

                            b1.HasKey("OrderEntitiesId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderEntitiesId");
                        });

                    b.Navigation("DeliveryTime")
                        .IsRequired();

                    b.Navigation("District")
                        .IsRequired();

                    b.Navigation("Weight")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
