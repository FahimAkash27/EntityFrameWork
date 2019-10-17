using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EfCoreA
{
    class LibaryContext : DbContext
    {
        private string connectionString;

        public LibaryContext()
        {
            connectionString = "Server = DESKTOP-G4I44H7; Database = EfCoreA; User Id = akash; Password = 1234;";
        }

        public LibaryContext(string connectionString)
        {
            this.connectionString = connectionString;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }






        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<StudentBook>()
                .HasKey(sb => new { sb.StudentId, sb.BookInfoId, sb.Id});



            builder.Entity<StudentBook>()
                .HasOne(sb => sb.StudentInfo)
                .WithMany(s => s.StudentIssuedBooks)
                .HasForeignKey(sb => sb.StudentId);


            base.OnModelCreating(builder);
        }

        public DbSet<StudentInfo> StudentInfos { get; set; }

        public DbSet<BookInfo> BookInfos { get; set; }

        public DbSet<StudentBook> StudentBooks { get; set; }
    }
}
