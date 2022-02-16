using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.DataModels
{
    public class PersonContext: DbContext
    {
        public PersonContext(){}

        public PersonContext(DbContextOptions<PersonContext> options) : base(options){}

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new List<Person>
            {
                new Person
                    {Id = 1, Name = "Pölen", City = "Rottne", PhoneNumber = "043016624" },
                new Person
                    {Id = 2, Name = "TeKå", City = "Borås", PhoneNumber = "0721453456" },
                new Person
                    {Id = 3, Name = "Koma", City = "Rotterdam", PhoneNumber = "0771242424" },
                new Person
                    {Id = 4, Name = "Greven", City = "Helsinki", PhoneNumber = "031184698" },
                new Person
                    {Id = 5, Name = "Turbo", City = "Sverdlovsk", PhoneNumber = "0443346723" },
                new Person
                    {Id = 6, Name = "Stekarn", City = "Skövde", PhoneNumber = "0543768798" },
            });
        }     
    }
}
