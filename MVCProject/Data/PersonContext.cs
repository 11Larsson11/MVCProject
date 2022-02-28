using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using System;
using System.Collections.Generic;

namespace MVCProject.DataModels
{
    public class PersonContext: IdentityDbContext<ApplicationUser>
    {
        public PersonContext(){}
        public PersonContext(DbContextOptions<PersonContext> options) : base(options){}
        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<PersonLanguage> PersonLanguage { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<PersonLanguage>()
                .HasKey(personLanguage => new { personLanguage.PersonId, personLanguage.LanguageId });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Person>(personLanguage => personLanguage.Person)
                .WithMany(person => person.PersonLanguage)
                .HasForeignKey(personLanguage => personLanguage.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Language>(personLanguage => personLanguage.Language)
                .WithMany(language => language.PersonLanguages)
                .HasForeignKey(personLanguage => personLanguage.LanguageId)
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

            modelBuilder.Entity<Language>().HasData(new List<Language>
            {
                new Language
                    {Id = 1001, Name = "Swedish" },
                new Language
                    {Id = 1002, Name = "Norwegian" },
                new Language
                    {Id = 1003, Name = "Russian" },


            });

            modelBuilder.Entity<PersonLanguage>().HasData(new List<PersonLanguage>
            {
                new PersonLanguage
                    {PersonId = 1, LanguageId = 1001 },
                new PersonLanguage
                    {PersonId = 2, LanguageId = 1001 },
                new PersonLanguage
                    {PersonId = 3, LanguageId = 1001 },
                new PersonLanguage
                    {PersonId = 4, LanguageId = 1001 },
                new PersonLanguage
                    {PersonId = 5, LanguageId = 1003 },
                new PersonLanguage
                    {PersonId = 6, LanguageId = 1002 },

            });

            string roleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"
            });

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                PasswordHash = hasher.HashPassword(null, "password"),
                FirstName = "Bruno",
                LastName = "Spekel",
                BirthDate = "2001-02-18"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });
        }     
    }
}
