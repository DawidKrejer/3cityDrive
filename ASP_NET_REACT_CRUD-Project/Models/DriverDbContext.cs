﻿using Microsoft.EntityFrameworkCore;

namespace ASP_NET_REACT_CRUD_Project.Models
{
    public class DriverDbContext : DbContext
    {
        public DriverDbContext(DbContextOptions<DriverDbContext> options) : base(options)
        {
        }

        public DbSet<Driver> Driver { get; set;}
        public DbSet<Race> Race { get; set; }

        public DbSet<UserModel> Uzytkownicy { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-G14VAC0; Initial Catalog=ecmo; User Id=sa; password=student; TrustServerCertificate= True");
        }
    }
}
