using Models;
using Models.HelpModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEbuyStoreService
    {
        //Task<CartProducts> AddBogoProductTocart(ClubMember user);
        //Task<CartProducts> AddProductToCart(Product user);
        //Task<CartProducts> RemoveProductFromCart(Product user);
        //Task<CartProducts> GetProductsInCart(Product user);
        //Task<double> GetAmauntOfProductIncart(CartProducts product);
        Task<bool> Buy(Customer user); 
        Task<List<Product>> GetAllProductsInData();
        //Task<List<Product>> Search(string byWhat, string? author, string? title, string? keyWords, string? category, DateTime? publishDate, double? price);// include chec
        Task<List<PurchasedProduct>> GetPurchasedProducts();
        Task<List<PurchasedProduct>> GetPurchasedProductsOfCustomer(Customer user);

        Task<List<CountriesArea>> GetCountries();
        Task<List<DeliveryMode>> GetDeliveryModes();
        Task<List<State>> GetStates();
        
        Task<List<ShipmentOption>> GetShipmentOptions();
        Task<List<ShipmentCompany>> GetShipmentCompany();
        Task<List<ShipmentArea>> GetShipmentAreas();
        Task<List<CreditCardType>> GetCreditCardTypes();
        Task<Cost_And_Duration> shipmentCalculate(double amountOfProducts ,ShipmentPrice shipmentPrice );

        Task<bool> RemoveProductsFromData(List<Product> productsToRemove, Customer customer, Transaction transaction/*, ShipmentAddress shipmentAddress*/);
        Task<ShipmentPrice> GetShipmentPrice(ShipmentPriceModel shipmentPrice);
    }
}
