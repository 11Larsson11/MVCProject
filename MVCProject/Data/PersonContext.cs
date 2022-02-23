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
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<City>()
                .HasOne<Country>(city => city.Country)
                .WithMany(country => country.Cities)
                .HasForeignKey(city => city.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>()
                .HasOne<City>(person => person.City)
                .WithMany(city => city.Persons)
                .HasForeignKey(person => person.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>().HasData(new List<Person>
            {
                new Person
                    {Id = 1, Name = "Pölen", CityId = 11, PhoneNumber = "043016624" },
                new Person
                    {Id = 2, Name = "TeKå", CityId = 12, PhoneNumber = "0721453456" },
                new Person
                    {Id = 3, Name = "Koma", CityId = 11, PhoneNumber = "0771242424" },
                new Person
                    {Id = 4, Name = "Greven", CityId = 15, PhoneNumber = "031184698" },
                new Person
                    {Id = 5, Name = "Turbo", CityId = 13, PhoneNumber = "0443346723" },
                new Person
                    {Id = 6, Name = "Stekarn", CityId = 14, PhoneNumber = "0543768798" },
            });

            modelBuilder.Entity<City>().HasData(new List<City>
            {
                new City
                    {Id = 11, Name = "Rottne", CountryId = 101 },
                new City
                    {Id = 12, Name = "Borås", CountryId = 101 },
                new City
                    {Id = 13, Name = "Sverdlovsk", CountryId = 103 },
                new City
                    {Id = 14, Name = "Oslo", CountryId = 102 },
                new City
                    {Id = 15, Name = "Skövde", CountryId = 101 },

            });

            modelBuilder.Entity<Country>().HasData(new List<Country>
            {
                new Country
                    {Id = 101, Name = "Sweden" },
                new Country
                    {Id = 102, Name = "Norway" },
                new Country
                    {Id = 103, Name = "Russia" },


            });

        }     
    }
}
