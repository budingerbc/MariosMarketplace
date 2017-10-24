using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MariosMarketplace.Models;

namespace MariosMarketplace.Migrations
{
    [DbContext(typeof(MariosMarketplaceContext))]
    [Migration("20171023152708_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3");

            modelBuilder.Entity("MariosMarketplace.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryOrigin")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MariosMarketplace.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<int>("ProductId");

                    b.Property<int>("Rating");

                    b.HasKey("ReviewId");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MariosMarketplace.Models.Review", b =>
                {
                    b.HasOne("MariosMarketplace.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
