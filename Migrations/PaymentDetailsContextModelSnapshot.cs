﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentRegister_.net_core5_angular11.Models;

namespace PaymentRegister_.net_core5_angular11.Migrations
{
    [DbContext(typeof(PaymentDetailsContext))]
    partial class PaymentDetailsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaymentRegister_.net_core5_angular11.Models.PaymentDetails", b =>
                {
                    b.Property<int>("PaymentDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("CardOwnerName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ExpirationDate")
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("SecurityCode")
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("PaymentDetailsId");

                    b.ToTable("paymentDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
