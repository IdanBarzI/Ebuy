using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using SqlData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ClubMemberService : IClubMemberService
    {
        private _1044_EEK1Context _context;

        public ClubMemberService(_1044_EEK1Context context)
        {
            _context = context;
        }

        public async Task<List<ClubMember>> GetAllClubMembers()
        {
            List<Customer> customers = new List<Customer>();
            List<ClubMember> clubMembers = new List<ClubMember>();
            try
            {
                customers = await _context.Customers.ToListAsync();

                foreach (var item in customers)
                {
                    if (item.IsClubMember)
                        clubMembers.Add((ClubMember)item);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return clubMembers;
        }
        public async Task<ClubMember> RegisterClubMembers(ClubMember user)
        {
            try
            {
                List<ClubMember> clubMembers = await GetAllClubMembers();

                for (int i = 0; i < clubMembers.Count; i++)
                {
                    if (clubMembers[i].LoginName == user.LoginName || clubMembers[i].Password == user.Password) return null;
                }
                //user.RegistrationDate = DateTime.Now;

                //ClubMember user1 = new ClubMember() { LoginName = "vsvds22", Password = "dsfwq13q", Email = "fdg@gam.com", Addres = "setrgh" };
                await _context.Customers.AddAsync(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return user;
        }
        public async Task<ClubMember> LoginClubMembers(string userName, string password)
        {
            List<ClubMember> clubMembersList = await GetAllClubMembers();
            ClubMember user = new ClubMember();
            foreach (ClubMember clubMember in clubMembersList)
            {
                if (clubMember.LoginName == userName && clubMember.Password == password) return clubMember;
            }
            return null;
        }
        public async Task<ClubMember> GetOneClubMemberByName(string userName)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            List<ClubMember> clubMembersList = await GetAllClubMembers();
            ClubMember user = clubMembersList.Find(user => user.LoginName == userName);
            return user;
        }

        public async Task<List<Product>> GetBogoProducts(ClubMember user)// להזכיר לרשום את המחיר של זה כ0
        {
            try
            {
                List<Bogo> bogoList = await _context.Bogos.ToListAsync();
                List<Product> productsList = await _context.Products.Where(p => p.IsSold == false).ToListAsync();
                List<PurchasedProduct> purchasedProductsList = await _context.PurchasedProducts.ToListAsync();

                Random rd = new Random();
                List<Bogo> allProductsInLevel = new List<Bogo>();
                List<Product> productsToAddCart = new List<Product>();

                int bogoLevel = await CheckBogo(user);
                if (bogoLevel == 0) return productsToAddCart;


                allProductsInLevel = bogoList.FindAll(bogo => bogo.Bogolevel == bogoLevel);
                int rand_num = rd.Next(0, allProductsInLevel.Count);
                Bogo choosenBogoProduct = allProductsInLevel[rand_num];

                foreach (var item in productsList)
                {
                    if (choosenBogoProduct.ProductId == item.Id)
                    {
                        item.PriceAfterDiscount = 0;
                        productsToAddCart.Add(item);
                    }
                }

                return productsToAddCart;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
           
        }
        private async Task<int> CheckBogo(ClubMember user)
        {
            double? amount =await CalculateAmountOfPurchasedProducts(user);
            TimeSpan passDayTime = DateTime.Now - user.RegistrationDate;
            double totalDays = passDayTime.TotalDays;

            if (totalDays >= 365 && amount >= 1000 && amount < 1500 ) return 1;
            if (totalDays >= 365 && amount >= 1500 && amount < 2000 ) return 2;
            if (totalDays >= 365 && amount >= 2000 && amount < 5000 ) return 3;
            if (totalDays >= 365 && amount > 5000 ) return 4;
            return 0;
        }

        private async Task<double?> CalculateAmountOfPurchasedProducts(ClubMember user)
        {
            List<PurchasedProduct> purchasedProductsList =await _context.PurchasedProducts.ToListAsync();
            double? amount = 0;
            foreach (var item in purchasedProductsList)
            {
                if (item.CustomerId == user.CustomerId) amount += item.PriceAfterDiscount;
            }
            return amount;
        }

        private void GetRandomProducts(int bogoLevel, List<Bogo> bogoList)
        {
            List<Product> productsToAddCart = new List<Product>();
            List<Bogo> allProductsInLevel1 = new List<Bogo>();
            List<Bogo> allProductsInLevel2 = new List<Bogo>();
            List<Bogo> allProductsInLevel3 = new List<Bogo>();

            Random rd = new Random();

            allProductsInLevel1 = bogoList.FindAll(bogo => bogo.Bogolevel == 1);
            allProductsInLevel2 = bogoList.FindAll(bogo => bogo.Bogolevel == 2);
            allProductsInLevel3 = bogoList.FindAll(bogo => bogo.Bogolevel == 3);
            switch (bogoLevel)
            {
                case 1:
                    allProductsInLevel1 = bogoList.FindAll(bogo => bogo.Bogolevel == bogoLevel);
                    int rand_num = rd.Next(0, allProductsInLevel1.Count);//check the list and see if it start with zero or 1
                    Bogo choosenBogoProduct = bogoList[rand_num];
                    break;
                case 2:
                    foreach (var item in bogoList)
                    {
                        
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
