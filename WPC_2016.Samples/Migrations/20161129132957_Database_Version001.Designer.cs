using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WPC_2016.Samples.Sample13;

namespace WPC_2016.Samples.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20161129132957_Database_Version001")]
    partial class Database_Version001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("WPC_2016.Samples.Sample13.Speaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Name");

                    b.Property<string>("Province");

                    b.Property<string>("Surname");

                    b.Property<string>("Technologies");

                    b.HasKey("Id");

                    b.ToTable("Speakers");
                });
        }
    }
}
