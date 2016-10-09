using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EgojitCms;

namespace Web.Migrations
{
    [DbContext(typeof(EgojitCmsDbContext))]
    partial class EgojitCmsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("EgojitCms.web.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateAt");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("Pwd")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("EgojitCms.web.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateAt");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("Tel")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("Tel1")
                        .HasAnnotation("MaxLength", 15);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EgojitCms.web.Models.Account", b =>
                {
                    b.HasOne("EgojitCms.web.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
