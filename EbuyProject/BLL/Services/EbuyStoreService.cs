using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.HelpModel;
using SqlData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EbuyStoreService : IEbuyStoreService
    {
        private _1044_EEK1Context _context;
        public EbuyStoreService(_1044_EEK1Context context)
        {
            _context = context;
        }
        public Task<bool> Buy(Customer user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllProductsInData()
        {
            return  await _context.Products.Where(p => p.IsSold == false).ToListAsync();
        }
        public async Task<List<CountriesArea>> GetCountries()
        {
            return await _context.CountriesAreas.ToListAsync();
        }
        public async Task<List<CreditCardType>> GetCreditCardTypes()
        {
            return await _context.CreditCardTypes.ToListAsync();
        }
        public async Task<List<DeliveryMode>> GetDeliveryModes()
        {
            return await _context.DeliveryModes.ToListAsync();
        }
        public async Task<List<PurchasedProduct>> GetPurchasedProducts()
        {
            List<PurchasedProduct> pl = new List<PurchasedProduct>();
            try
            {
                pl = await _context.PurchasedProducts.ToListAsync();
            }
            catch (Exception e)
            {

                return pl;
            }
             
            return pl;
        }
        public async Task<List<PurchasedProduct>> GetPurchasedProductsOfCustomer(Customer user)
        {
            List<PurchasedProduct> v = await GetPurchasedProducts();
            List<PurchasedProduct> customerProducts = v.Where(x => x.CustomerId == user.CustomerId).ToList();
            return customerProducts;
        }
        public async Task<List<ShipmentArea>> GetShipmentAreas()
        {
            return await _context.ShipmentAreas.ToListAsync();
        }
        public async Task<List<ShipmentCompany>> GetShipmentCompany()
        {
            return await _context.ShipmentCompanies.ToListAsync();
        }
        public async Task<List<ShipmentOption>> GetShipmentOptions()
        {
            return await _context.ShipmentOptions.ToListAsync();
        }
        public async Task<List<State>> GetStates()
        {
            return await _context.States.ToListAsync();
        }
        public async Task<bool> RemoveProductsFromData(List<Product> productsToRemove , Customer customer , Transaction transaction /*, ShipmentAddress shipmentAddress*/)
        {
            try
            {
                double? transactionCost = 0;
                foreach (Product product in productsToRemove)
                {
                    PurchasedProduct purchasedProduct = new PurchasedProduct();

                    purchasedProduct.Product = product;
                    purchasedProduct.ProductId = product.Id;
                    purchasedProduct.PurchaseDate = DateTime.Now;
                    purchasedProduct.PriceAfterDiscount = product.PriceAfterDiscount;
                    purchasedProduct.Customer = customer;
                    purchasedProduct.CustomerId = customer.CustomerId;
                    purchasedProduct.BasicCost = product.Price;
                    purchasedProduct.Transaction = transaction;

                    await _context.PurchasedProducts.AddAsync(purchasedProduct);

                    transactionCost += product.PriceAfterDiscount;
                    //await _context.ShipmentAddresses.AddAsync(shipmentAddress);
                    product.IsSold = true;
                    _context.Products.Update(product);

                    Bogo removeBogo = await _context.Bogos.Where(b => b.ProductId == product.Id).FirstOrDefaultAsync();

                    _context.Bogos.Remove(removeBogo);
                    await _context.SaveChangesAsync();
                }

                await _context.Transactions.AddAsync(transaction);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                return false;
            }
           
            return true;
        } //TODO: complete
        //public async Task<List<Product>> Search(string byWhat , string? author , string? title , string? keyWords , string? category , DateTime? publishDate , double? price)
        //{
        //    string propertyToOrderByHim = byWhat.ToLower();
        //    List<Product> productList = await GetAllProductsInData();
        //    List <Product> result = new List<Product >();

        //    //if(String.IsNullOrEmpty(author) && String.IsNullOrEmpty(title) && String.IsNullOrEmpty(keyWords) && String.IsNullOrEmpty(category) && publishDate == null && price == null)
        //    //    result = productList;
        //    //if(!String.IsNullOrEmpty(author) && String.IsNullOrEmpty(title) && String.IsNullOrEmpty(keyWords) && String.IsNullOrEmpty(category) && publishDate == null && price == null)
        //    //    result = productList.Where(x => x.Author.AuthorName.ToLower() == author.ToLower()).ToList();
        //    //if (!String.IsNullOrEmpty(author) && !String.IsNullOrEmpty(title) && String.IsNullOrEmpty(keyWords) && String.IsNullOrEmpty(category) && publishDate == null && price == null)
        //    //    result = productList.Where(x => x.Author.AuthorName.ToLower() == author.ToLower() && x.Title.ToLower() == title.ToLower()).ToList();
        //    switch (propertyToOrderByHim)
        //    {
        //        case "":
        //            result = productList;
        //            break;
        //        case "author":
        //            result = productList.Where(x => x.Author.AuthorName.ToLower() == author.ToLower()).ToList();
        //            break;
        //        case "title":
        //            result =  productList.Where(x => x.Title.ToLower() == title.ToLower()).ToList();
        //            break;
        //        case "keywords":
        //            result =  productList.Where(x => x.Keywords.ToLower() == keyWords.ToLower()).ToList();
        //            break;
        //        case "category":
        //            result = productList.Where(x => x.Category.Description.ToLower() == category.ToLower()).ToList();
        //            break;
        //        case "publishdate":
        //            result =  productList.Where(x => x.Publishdate == publishDate).ToList();
        //            break;
        //        case "price":
        //            result = productList.Where(x => x.Price == price).ToList();
        //            break;
        //        default:
        //            break;
        //    }
        //    return result;

        //}

        public async Task<Cost_And_Duration> shipmentCalculate(double amountOfProducts ,ShipmentPrice shipmentPrice )
        {
            List< ShipmentPrice> shipmentPriceObject = await _context.ShipmentPrices.
                Where(sh => sh.ShipmentAreaId == shipmentPrice.ShipmentAreaId && sh.ShipmentOptionId == shipmentPrice.ShipmentOptionId).ToListAsync();
            double lowestCost = double.MaxValue;
            Cost_And_Duration cost_And_Duration = new Cost_And_Duration();
            foreach (var item in shipmentPriceObject)
            {
                double cost1 = item.BasicCharge + (amountOfProducts * item.ItemCharge);
                if (cost1 < lowestCost)
                {
                    lowestCost = cost1;
                    var a = item.ShipmentDuration;
                    cost_And_Duration.ShipmentDuration = a;
                }

            }
            cost_And_Duration.lowestCost = lowestCost;
            return cost_And_Duration;
        }
        public async Task<ShipmentPrice> GetShipmentPrice(ShipmentPriceModel shipmentPrice)
        {
            ShipmentPrice shipmentPriceObject = new ShipmentPrice();
            try
            {
                //shipmentPriceObject =  await _context.ShipmentPrices.
                //Include(x => x.ShipmentArea).Include(x => x.ShipmentOption).Include(x => x.ShipmentCompany).
                //Where(sh => sh.ShipmentAreaId == shipmentPrice.ShipmentAreaId && sh.ShipmentOptionId == shipmentPrice.ShipmentOptionId && sh.ShipmentCompanyId == shipmentPrice.ShipmentCompanyId).
                //FirstOrDefaultAsync();

                shipmentPriceObject = await _context.ShipmentPrices.
                Where(sh => sh.ShipmentAreaId == shipmentPrice.ShipmentAreaId && sh.ShipmentOptionId == shipmentPrice.ShipmentOptionId && sh.ShipmentCompanyId == shipmentPrice.ShipmentCompanyId).
                FirstOrDefaultAsync();
                return shipmentPriceObject;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return shipmentPriceObject;

        }

    }
}
