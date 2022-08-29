using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prefix = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Addres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsClubMember = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryModes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryModes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    ClubMemberDiscount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ShipmentAreas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentAreas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentCompanies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentCompanies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentOptions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentOptions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VAT",
                columns: table => new
                {
                    Vat = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    AuthorID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Publishdate = table.Column<DateTime>(type: "date", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Authors",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Products_Categories",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CasualCustomer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FirstPurchasing = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasualCustomer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CasualCustomer_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "ClubMember",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubMember", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_ClubMember_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "CountriesAreas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ShipmentAreaID = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesAreas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CountriesAreas_ShipmentAreas",
                        column: x => x.ShipmentAreaID,
                        principalTable: "ShipmentAreas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ShipmentPrices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ShipmentAreaID = table.Column<int>(type: "int", nullable: false),
                    ShipmentOptionID = table.Column<int>(type: "int", nullable: false),
                    ShipmentCompanyID = table.Column<int>(type: "int", nullable: false),
                    BasicCharge = table.Column<double>(type: "float", nullable: false),
                    ItemCharge = table.Column<double>(type: "float", nullable: false),
                    ShipmentDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentPrices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShipmentPrices_ShipmentAreas",
                        column: x => x.ShipmentAreaID,
                        principalTable: "ShipmentAreas",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ShipmentPrices_ShipmentCompanies",
                        column: x => x.ShipmentCompanyID,
                        principalTable: "ShipmentCompanies",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ShipmentPrices_ShipmentOptions",
                        column: x => x.ShipmentOptionID,
                        principalTable: "ShipmentOptions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BOGO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOGOlevel = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOGO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BOGO_Products",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ShipmentAddresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buyer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PBO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentAddresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShipmentAddresses_CountriesAreas",
                        column: x => x.Country,
                        principalTable: "CountriesAreas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryModeID = table.Column<int>(type: "int", nullable: false),
                    ShipmentAddressID = table.Column<int>(type: "int", nullable: false),
                    ShipmentCompanyID = table.Column<int>(type: "int", nullable: false),
                    ShipmentOptionID = table.Column<int>(type: "int", nullable: false),
                    CCTypeID = table.Column<int>(type: "int", nullable: false),
                    CCNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CCExpireDate = table.Column<DateTime>(type: "date", nullable: false),
                    ShipmentCost = table.Column<double>(type: "float", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "date", nullable: false),
                    CCOwnerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transactions_CreditCardTypes",
                        column: x => x.CCTypeID,
                        principalTable: "CreditCardTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Transactions_DeliveryMode",
                        column: x => x.DeliveryModeID,
                        principalTable: "DeliveryModes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Transactions_ShipmentAddresses",
                        column: x => x.ShipmentAddressID,
                        principalTable: "ShipmentAddresses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Transactions_ShipmentOptions",
                        column: x => x.ShipmentOptionID,
                        principalTable: "ShipmentOptions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PurchasedProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TransactionID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    BasicCost = table.Column<double>(type: "float", nullable: false),
                    VAT = table.Column<double>(type: "float", nullable: false),
                    PriceAfterDiscount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_purchasedProducts_Customers",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_purchasedProducts_Products",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_purchasedProducts_Transactions",
                        column: x => x.TransactionID,
                        principalTable: "Transactions",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "AuthorName" },
                values: new object[,]
                {
                    { 1, "J.K.ROWLING" },
                    { 2, "Amit Segal" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Description" },
                values: new object[,]
                {
                    { 1, "Book" },
                    { 2, "Book" }
                });

            migrationBuilder.InsertData(
                table: "CreditCardTypes",
                columns: new[] { "ID", "Name", "Prefix" },
                values: new object[,]
                {
                    { 1, "MasyerCardLocal", "5100" },
                    { 2, "Visa", "4580" },
                    { 3, "American Express", "3755" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Addres", "Email", "IsClubMember", "LoginName" },
                values: new object[,]
                {
                    { 1, "neve shanan", "roni@gmail.com", true, "roni" },
                    { 2, "yakov orlans", "nitzan@gmail.com", true, "nitzan" },
                    { 3, "neve shanan", "roni@gmail.com", true, "tomi" }
                });

            migrationBuilder.InsertData(
                table: "DeliveryModes",
                columns: new[] { "ID", "Description" },
                values: new object[,]
                {
                    { 1, "electronically" },
                    { 2, "Hard copy" }
                });

            migrationBuilder.InsertData(
                table: "ShipmentAreas",
                columns: new[] { "ID", "Area" },
                values: new object[,]
                {
                    { 1, "Europe" },
                    { 2, "America" },
                    { 3, "Asia" }
                });

            migrationBuilder.InsertData(
                table: "ShipmentCompanies",
                columns: new[] { "ID", "CompanyName" },
                values: new object[,]
                {
                    { 1, "Amazone" },
                    { 2, "Chita" },
                    { 3, "Ron" }
                });

            migrationBuilder.InsertData(
                table: "ShipmentOptions",
                columns: new[] { "ID", "Description" },
                values: new object[,]
                {
                    { 1, "Email" },
                    { 2, "delivery" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alabama" },
                    { 2, "Alaska" },
                    { 3, "Arizona" },
                    { 4, "Arkansas" },
                    { 5, "California" },
                    { 6, "Colorado" },
                    { 7, "Connecticut" },
                    { 8, "Delaware" },
                    { 9, "Florida" },
                    { 10, "Georgia" },
                    { 11, "Hawaii" },
                    { 12, "Idaho" },
                    { 13, "Illinois" },
                    { 14, "Indiana" },
                    { 15, "Iowa" },
                    { 16, "Kansas" },
                    { 17, "Kentucky" },
                    { 18, "Louisiana" },
                    { 19, "Maine" },
                    { 20, "Maryland" },
                    { 21, "Massachusetts" },
                    { 22, "Michigan" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 23, "Minnesota" },
                    { 24, "Mississippi" },
                    { 25, "Missouri" },
                    { 26, "Montana" },
                    { 27, "Nebraska" },
                    { 28, "Nevada" },
                    { 29, "New Hampshire" },
                    { 30, "New Jersey" },
                    { 31, "New Mexico" },
                    { 32, "New York" },
                    { 33, "North Carolina" },
                    { 34, "North Dakota" },
                    { 35, "Ohio" },
                    { 36, "Oklahoma" },
                    { 37, "Oregon" },
                    { 38, "Pennsylvania" },
                    { 39, "Rhode Island" },
                    { 40, "South Carolina" },
                    { 41, "South Dakota" },
                    { 42, "Tennessee" },
                    { 43, "Texas" },
                    { 44, "Utah" },
                    { 45, "Vermont" },
                    { 46, "Virginia" },
                    { 47, "Washington" },
                    { 48, "West Virginia" },
                    { 49, "Wisconsin" },
                    { 50, "Wyoming" }
                });

            migrationBuilder.InsertData(
                table: "ClubMember",
                columns: new[] { "CustomerId", "Password", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "loli64", new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "loli65", new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "loli66", new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CountriesAreas",
                columns: new[] { "ID", "Country", "ShipmentAreaID" },
                values: new object[,]
                {
                    { 1, "US", 2 },
                    { 2, "UK", 1 },
                    { 3, "France", 1 },
                    { 4, "Italy", 1 },
                    { 5, "Israel", 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "AuthorID", "CategoryID", "IsSold", "Keywords", "Price", "Publishdate", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, true, "The first book of Harry Potter series", 50.0, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter1" },
                    { 2, 1, 1, true, "The second book of Harry Potter series", 50.0, new DateTime(1998, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter2" },
                    { 3, 1, 1, false, "The third book of Harry Potter series", 60.0, new DateTime(1999, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter3" },
                    { 4, 2, 2, false, "The first magazine", 10.0, new DateTime(2008, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stam" },
                    { 5, 1, 2, false, "good story", 70.0, new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Ickabog" },
                    { 6, 2, 1, false, "The last magazine", 40.0, new DateTime(1998, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borat" },
                    { 7, 2, 1, false, "The last magazine", 40.0, new DateTime(1998, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borat" }
                });

            migrationBuilder.InsertData(
                table: "ShipmentPrices",
                columns: new[] { "ID", "BasicCharge", "ItemCharge", "ShipmentAreaID", "ShipmentCompanyID", "ShipmentDuration", "ShipmentOptionID" },
                values: new object[,]
                {
                    { 1, 10.0, 2.0, 1, 1, 9, 1 },
                    { 2, 15.0, 1.0, 2, 1, 14, 1 },
                    { 3, 13.0, 1.0, 1, 2, 10, 1 },
                    { 4, 14.0, 0.69999999999999996, 2, 2, 5, 1 },
                    { 5, 9.0, 0.20000000000000001, 3, 1, 15, 2 },
                    { 6, 5.0, 0.59999999999999998, 1, 1, 21, 2 },
                    { 7, 6.9000000000000004, 0.80000000000000004, 3, 2, 18, 2 },
                    { 8, 7.9900000000000002, 1.2, 2, 2, 19, 2 },
                    { 9, 4.0, 5.5999999999999996, 1, 1, 16, 2 },
                    { 10, 2.0, 0.40000000000000002, 3, 1, 13, 2 },
                    { 11, 20.989999999999998, 0.59999999999999998, 1, 2, 12, 1 },
                    { 12, 19.989999999999998, 0.20000000000000001, 2, 2, 11, 1 }
                });

            migrationBuilder.InsertData(
                table: "BOGO",
                columns: new[] { "ID", "BOGOlevel", "ProductID" },
                values: new object[] { 3, 1, 3 });

            migrationBuilder.InsertData(
                table: "BOGO",
                columns: new[] { "ID", "BOGOlevel", "ProductID" },
                values: new object[] { 4, 2, 4 });

            migrationBuilder.InsertData(
                table: "ShipmentAddresses",
                columns: new[] { "ID", "Buyer", "City", "Country", "Email", "HouseNumber", "PBO", "State", "Street", "ZipCode" },
                values: new object[] { 1, "roni", "Jerusalem", 1, "roni@gmail.com", "14", null, "North Carolina", "af", "763245" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "ID", "CCExpireDate", "CCNumber", "CCOwnerName", "CCTypeID", "DeliveryDate", "DeliveryModeID", "ShipmentAddressID", "ShipmentCompanyID", "ShipmentCost", "ShipmentOptionID" },
                values: new object[] { 1, new DateTime(2028, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5100456376489623", "roni", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 22.399999999999999, 1 });

            migrationBuilder.InsertData(
                table: "PurchasedProducts",
                columns: new[] { "ID", "BasicCost", "CustomerId", "PriceAfterDiscount", "ProductID", "PurchaseDate", "TransactionID", "VAT" },
                values: new object[] { 1, 1500.0, 2, 1120.0, 1, new DateTime(2022, 8, 25, 9, 26, 14, 394, DateTimeKind.Local).AddTicks(4879), 1, 0.0 });

            migrationBuilder.InsertData(
                table: "PurchasedProducts",
                columns: new[] { "ID", "BasicCost", "CustomerId", "PriceAfterDiscount", "ProductID", "PurchaseDate", "TransactionID", "VAT" },
                values: new object[] { 2, 3000.0, 3, 2500.0, 2, new DateTime(2022, 8, 25, 9, 26, 14, 394, DateTimeKind.Local).AddTicks(4916), 1, 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_BOGO_ProductID",
                table: "BOGO",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CountriesAreas_ShipmentAreaID",
                table: "CountriesAreas",
                column: "ShipmentAreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AuthorID",
                table: "Products",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedProducts_CustomerId",
                table: "PurchasedProducts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedProducts_ProductID",
                table: "PurchasedProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedProducts_TransactionID",
                table: "PurchasedProducts",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentAddresses_Country",
                table: "ShipmentAddresses",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentPrices_ShipmentAreaID",
                table: "ShipmentPrices",
                column: "ShipmentAreaID");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentPrices_ShipmentCompanyID",
                table: "ShipmentPrices",
                column: "ShipmentCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentPrices_ShipmentOptionID",
                table: "ShipmentPrices",
                column: "ShipmentOptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CCTypeID",
                table: "Transactions",
                column: "CCTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DeliveryModeID",
                table: "Transactions",
                column: "DeliveryModeID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ShipmentAddressID",
                table: "Transactions",
                column: "ShipmentAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ShipmentOptionID",
                table: "Transactions",
                column: "ShipmentOptionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOGO");

            migrationBuilder.DropTable(
                name: "CasualCustomer");

            migrationBuilder.DropTable(
                name: "ClubMember");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "PurchasedProducts");

            migrationBuilder.DropTable(
                name: "ShipmentPrices");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "VAT");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "ShipmentCompanies");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CreditCardTypes");

            migrationBuilder.DropTable(
                name: "DeliveryModes");

            migrationBuilder.DropTable(
                name: "ShipmentAddresses");

            migrationBuilder.DropTable(
                name: "ShipmentOptions");

            migrationBuilder.DropTable(
                name: "CountriesAreas");

            migrationBuilder.DropTable(
                name: "ShipmentAreas");
        }
    }
}
