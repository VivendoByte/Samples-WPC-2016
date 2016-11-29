using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC_2016.Samples.Sample13
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Speaker> Speakers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=WPC2016.db");
        }
    }


    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Technologies { get; set; }
        public string Province { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DateTimeOffset BindingDate
        {
            get
            {
                return new DateTimeOffset(this.BirthDate);
            }
            set
            {
                this.BirthDate = value.Date;
            }
        }
    }
}