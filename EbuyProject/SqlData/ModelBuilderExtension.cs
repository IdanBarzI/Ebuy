using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlData
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClubMember>().HasData(
               new ClubMember { CustomerId = 1, LoginName = "roni", Addres = "neve shanan", Email = "roni@gmail.com", IsClubMember = true, Password = "loli64", RegistrationDate = new DateTime(2021, 08, 20) },
               new ClubMember { CustomerId = 2, LoginName = "nitzan", Addres = "yakov orlans", Email = "nitzan@gmail.com", IsClubMember = true, Password = "loli65", RegistrationDate = new DateTime(2020, 08, 20) },
               new ClubMember { CustomerId = 3, LoginName = "tomi", Addres = "neve shanan", Email = "roni@gmail.com", IsClubMember = true, Password = "loli66", RegistrationDate = new DateTime(2019, 08, 20) }
               );

            modelBuilder.Entity<ShipmentArea>().HasData(
               new ShipmentArea { Id = 1, Area = "Europe" },
               new ShipmentArea { Id = 2, Area = "America" },
               new ShipmentArea { Id = 3, Area = "Asia" }
               );

            modelBuilder.Entity<CountriesArea>().HasData(
              new CountriesArea { Id = 1, Country = "US", ShipmentAreaId = 2 },
              new CountriesArea { Id = 2, Country = "UK", ShipmentAreaId = 1 },
              new CountriesArea { Id = 3, Country = "France", ShipmentAreaId = 1 },
              new CountriesArea { Id = 4, Country = "Italy", ShipmentAreaId = 1 },
              new CountriesArea { Id = 5, Country = "Israel", ShipmentAreaId = 3 }
              );

            modelBuilder.Entity<State>().HasData(
             new State { Id = 1, Name = "Alabama" },
             new State { Id = 2, Name = "Alaska" },
             new State { Id = 3, Name = "Arizona" },
             new State { Id = 4, Name = "Arkansas" },
             new State { Id = 5, Name = "California" },
             new State { Id = 6, Name = "Colorado" },
             new State { Id = 7, Name = "Connecticut" },
             new State { Id = 8, Name = "Delaware" },
             new State { Id = 9, Name = "Florida" },
             new State { Id = 10, Name = "Georgia" },
             new State { Id = 11, Name = "Hawaii" },
             new State { Id = 12, Name = "Idaho" },
             new State { Id = 13, Name = "Illinois" },
             new State { Id = 14, Name = "Indiana" },
             new State { Id = 15, Name = "Iowa" },
             new State { Id = 16, Name = "Kansas" },
             new State { Id = 17, Name = "Kentucky" },
             new State { Id = 18, Name = "Louisiana" },
             new State { Id = 19, Name = "Maine" },
             new State { Id = 20, Name = "Maryland" },
             new State { Id = 21, Name = "Massachusetts" },
             new State { Id = 22, Name = "Michigan" },
             new State { Id = 23, Name = "Minnesota" },
             new State { Id = 24, Name = "Mississippi" },
             new State { Id = 25, Name = "Missouri" },
             new State { Id = 26, Name = "Montana" },
             new State { Id = 27, Name = "Nebraska" },
             new State { Id = 28, Name = "Nevada" },
             new State { Id = 29, Name = "New Hampshire" },
             new State { Id = 30, Name = "New Jersey" },
             new State { Id = 31, Name = "New Mexico" },
             new State { Id = 32, Name = "New York" },
             new State { Id = 33, Name = "North Carolina" },
             new State { Id = 34, Name = "North Dakota" },
             new State { Id = 35, Name = "Ohio" },
             new State { Id = 36, Name = "Oklahoma" },
             new State { Id = 37, Name = "Oregon" },
             new State { Id = 38, Name = "Pennsylvania" },
             new State { Id = 39, Name = "Rhode Island" },
             new State { Id = 40, Name = "South Carolina" },
             new State { Id = 41, Name = "South Dakota" },
             new State { Id = 42, Name = "Tennessee" },
             new State { Id = 43, Name = "Texas" },
             new State { Id = 44, Name = "Utah" },
             new State { Id = 45, Name = "Vermont" },
             new State { Id = 46, Name = "Virginia" },
             new State { Id = 47, Name = "Washington" },
             new State { Id = 48, Name = "West Virginia" },
             new State { Id = 49, Name = "Wisconsin" },
             new State { Id = 50, Name = "Wyoming" }
             );

            modelBuilder.Entity<ShipmentCompany>().HasData(
                new ShipmentCompany { Id = 1, CompanyName = "Amazone" },
                new ShipmentCompany { Id = 2, CompanyName = "Chita" },
                new ShipmentCompany { Id = 3, CompanyName = "Ron" }
                );

            modelBuilder.Entity<ShipmentOption>().HasData(
                new ShipmentOption { Id = 1, Description = "Email" },
                new ShipmentOption { Id = 2, Description = "delivery" }
                );

            modelBuilder.Entity<ShipmentPrice>().HasData(
                new ShipmentPrice { Id = 1, BasicCharge = 10, ItemCharge = 2, ShipmentCompanyId = 1, ShipmentDuration = 9, ShipmentOptionId = 1, ShipmentAreaId = 1 },
                new ShipmentPrice { Id = 2, BasicCharge = 15, ItemCharge = 1, ShipmentCompanyId = 1, ShipmentDuration = 14, ShipmentOptionId = 1, ShipmentAreaId = 2 },
                new ShipmentPrice { Id = 3, BasicCharge = 13, ItemCharge = 1, ShipmentCompanyId = 2, ShipmentDuration = 10, ShipmentOptionId = 1, ShipmentAreaId = 1 },
                new ShipmentPrice { Id = 4, BasicCharge = 14, ItemCharge = 0.7, ShipmentCompanyId = 2, ShipmentDuration = 5, ShipmentOptionId = 1, ShipmentAreaId = 2 },
                new ShipmentPrice { Id = 5, BasicCharge = 9, ItemCharge = 0.2, ShipmentCompanyId = 1, ShipmentDuration = 15, ShipmentOptionId = 2, ShipmentAreaId = 3 },
                new ShipmentPrice { Id = 6, BasicCharge = 5, ItemCharge = 0.6, ShipmentCompanyId = 1, ShipmentDuration = 21, ShipmentOptionId = 2, ShipmentAreaId = 1 },
                new ShipmentPrice { Id = 7, BasicCharge = 6.9, ItemCharge = 0.8, ShipmentCompanyId = 2, ShipmentDuration = 18, ShipmentOptionId = 2, ShipmentAreaId = 3 },
                new ShipmentPrice { Id = 8, BasicCharge = 7.99, ItemCharge = 1.2, ShipmentCompanyId = 2, ShipmentDuration = 19, ShipmentOptionId = 2, ShipmentAreaId = 2 },
                new ShipmentPrice { Id = 9, BasicCharge = 4, ItemCharge = 5.6, ShipmentCompanyId = 1, ShipmentDuration = 16, ShipmentOptionId = 2, ShipmentAreaId = 1 },
                new ShipmentPrice { Id = 10, BasicCharge = 2, ItemCharge = 0.4, ShipmentCompanyId = 1, ShipmentDuration = 13, ShipmentOptionId = 2, ShipmentAreaId = 3 },
                new ShipmentPrice { Id = 11, BasicCharge = 20.99, ItemCharge = 0.6, ShipmentCompanyId = 2, ShipmentDuration = 12, ShipmentOptionId = 1, ShipmentAreaId = 1 },
                new ShipmentPrice { Id = 12, BasicCharge = 19.99, ItemCharge = 0.2, ShipmentCompanyId = 2, ShipmentDuration = 11, ShipmentOptionId = 1, ShipmentAreaId = 2 }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Description = "Book" },
                new Category { Id = 2, Description = "Book" }
                );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, AuthorName = "J.K.ROWLING" },
                new Author { Id = 2, AuthorName = "Amit Segal" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, AuthorId = 1, Title = "Harry Potter1", Keywords = "The first book of Harry Potter series", Price = 50, Publishdate = new DateTime(1997, 06, 26) ,IsSold = true },
                new Product { Id = 2, CategoryId = 1, AuthorId = 1, Title = "Harry Potter2", Keywords = "The second book of Harry Potter series", Price = 50, Publishdate = new DateTime(1998, 06, 26) , IsSold = true },
                new Product { Id = 3, CategoryId = 1, AuthorId = 1, Title = "Harry Potter3", Keywords = "The third book of Harry Potter series", Price = 60, Publishdate = new DateTime(1999, 06, 26) },
                new Product { Id = 4, CategoryId = 2, AuthorId = 2, Title = "Stam", Keywords = "The first magazine", Price = 10, Publishdate = new DateTime(2008, 09, 29) },
                new Product { Id = 5, CategoryId = 2, AuthorId = 1, Title = "The Ickabog", Keywords = "good story", Price = 70, Publishdate = new DateTime(2020, 06, 26) },
                new Product { Id = 6, CategoryId = 1, AuthorId = 2, Title = "Borat", Keywords = "The last magazine", Price = 40, Publishdate = new DateTime(1998, 06, 26) },
                new Product { Id = 7, CategoryId = 1, AuthorId = 2, Title = "Borat", Keywords = "The last magazine", Price = 40, Publishdate = new DateTime(1998, 06, 26) }
                );

            modelBuilder.Entity<Bogo>().HasData(
                //new Bogo { Id = 1, Bogolevel = 1, ProductId = 1 },
                //new Bogo { Id = 2, Bogolevel = 2, ProductId = 2 },
                new Bogo { Id = 3, Bogolevel = 1, ProductId = 3 },
                new Bogo { Id = 4, Bogolevel = 2, ProductId = 4 }
                );

            modelBuilder.Entity<CreditCardType>().HasData(
                new CreditCardType { Id = 1, Name = "MasyerCardLocal", Prefix = "5100" },
                new CreditCardType { Id = 2, Name = "Visa", Prefix = "4580" },
                new CreditCardType { Id = 3, Name = "American Express", Prefix = "3755" }
                );

            modelBuilder.Entity<DeliveryMode>().HasData(
                new DeliveryMode { Id = 1, Description = "electronically" },
                new DeliveryMode { Id = 2, Description = "Hard copy" }
                );

            modelBuilder.Entity<ShipmentAddress>().HasData(
                new ShipmentAddress { Id = 1, Buyer = "roni", Country = 1, State = "North Carolina", City = "Jerusalem", Street = "af", HouseNumber = "14", ZipCode = "763245", Email = "roni@gmail.com" }
                );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { Id = 1, DeliveryModeId = 1, ShipmentAddressId = 1, ShipmentCompanyId = 1, ShipmentOptionId = 1, CctypeId = 1, Ccnumber = "5100456376489623", CcexpireDate = new DateTime(2028, 08, 01), ShipmentCost = 22.4, CcownerName = "roni" }
                );

            modelBuilder.Entity<PurchasedProduct>().HasData(
                new PurchasedProduct { Id = 1, CustomerId = 2, TransactionId = 1, ProductId = 1, PurchaseDate = DateTime.Now, BasicCost = 1500, PriceAfterDiscount = 1120 },
                new PurchasedProduct { Id = 2, CustomerId = 3, TransactionId = 1, ProductId = 2, PurchaseDate = DateTime.Now, BasicCost = 3000, PriceAfterDiscount = 2500 }
                );
        }
    }
}
