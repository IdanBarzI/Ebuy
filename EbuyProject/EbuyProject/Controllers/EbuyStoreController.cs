using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.HelpModel;

namespace EbuyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EbuyStoreController : Controller
    {
        IEbuyStoreService _ebuyStore;
        private Cost_And_Duration cost_And_Duration;
        public EbuyStoreController(IEbuyStoreService ebuyStore, Cost_And_Duration cost_And_Duration)
        {
            _ebuyStore = ebuyStore;
            this.cost_And_Duration = cost_And_Duration;
        }

        [HttpGet("GetAllProductsInData")]
        public async Task<ActionResult<List<Product>>> GetAllProductsInData()
        {
            try
            {
                var products = await _ebuyStore.GetAllProductsInData();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(); 
            }
           
        }
        [HttpGet("GetCountries")]
        public async Task<ActionResult<List<CountriesArea>>> GetCountries()
        {
            try
            {
                var countries = await _ebuyStore.GetCountries();
                return Ok(countries);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }
        [HttpGet("GetCreditCardTypes")]
        public async Task<ActionResult<List<CreditCardType>>> GetCreditCardTypes()
        {
            try
            {
                var cct = await _ebuyStore.GetCreditCardTypes();
                return Ok(cct);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }
        [HttpGet("GetDeliveryModes")]
        public async Task<ActionResult<List<DeliveryMode>>> GetDeliveryModes()
        {
            try
            {
                var dm = await _ebuyStore.GetDeliveryModes();
                return Ok(dm);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetPurchasedProducts")]//need to check
        public async Task<ActionResult<List<PurchasedProduct>>> GetPurchasedProducts()
        {
            try
            {
                var pp = await _ebuyStore.GetPurchasedProducts();
                if(pp == null) return Ok("didnt found any ");
                return Ok(pp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetPurchasedProductsOfCustomer")]//need to check
        public async Task<ActionResult<List<PurchasedProduct>>> GetPurchasedProductsOfCustomer(ClubMember user)
        {
            try
            {
                var ppoc = await _ebuyStore.GetPurchasedProductsOfCustomer(user);
                return Ok(ppoc);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetShipmentAreas")]
        public async Task<ActionResult<List<ShipmentArea>>> GetShipmentAreas()
        {
            try
            {
                var ppoc = await _ebuyStore.GetShipmentAreas();
                return Ok(ppoc);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet("GetShipmentCompany")]
        public async Task<ActionResult<List<ShipmentCompany>>> GetShipmentCompany()
        {
            try
            {
                var ppoc = await _ebuyStore.GetShipmentCompany();
                return Ok(ppoc);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetShipmentOptions")]
        public async Task<ActionResult<List<ShipmentOption>>> GetShipmentOptions()
        {
            try
            {
                var ppoc = await _ebuyStore.GetShipmentOptions();
                return Ok(ppoc);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetStates")]
        public async Task<ActionResult<List<State>>> GetStates()
        {
            try
            {
                var ppoc = await _ebuyStore.GetStates();
                return Ok(ppoc);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("BuyOfClubMember")]//need to check
        public async Task<ActionResult<bool>> BuyOfClubMember(BuyModelClub buyModel)
        {
            try
            {
                if (buyModel != null)
                {
                    buyModel.Transaction.DeliveryDate = DateTime.Now.AddDays(cost_And_Duration.lowestCost);
                    var ppoc = await _ebuyStore.RemoveProductsFromData(buyModel.ProductsToRemove, buyModel.Customer, buyModel.Transaction/*, buyModel.ShipmentAddress*/);
                    return Ok(ppoc);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("BuyOfCasualCustomer")]//need to check
        public async Task<ActionResult<bool>> BuyOfCasualCustomer(BuyModelCasual buyModel)
        {
            try
            {
                if (buyModel != null)
                {
                    buyModel.Transaction.DeliveryDate = DateTime.Now.AddDays(cost_And_Duration.lowestCost);
                   var ppoc = await _ebuyStore.RemoveProductsFromData(buyModel.ProductsToRemove, buyModel.Customer, buyModel.Transaction/*, buyModel.ShipmentAddress*/);
                    return Ok(ppoc);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //[HttpPost("Search")]//need to check
        //public async Task<ActionResult<List<Product>>> Search(SearchModel searchModel)
        //{
        //    try
        //    {
        //        var ppoc = await _ebuyStore.Search(searchModel.ByWhat , searchModel.Author , searchModel.Title , searchModel.KeyWords , searchModel.Category , searchModel.PublishDate , searchModel.Price);
        //        return Ok(ppoc);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPost("shipmentCalculate")]
        public async Task<ActionResult<double>> shipmentCalculate(int amountOfProducts, ShipmentPrice shipmentPrice)
        {
            try
            {
                cost_And_Duration = await _ebuyStore.shipmentCalculate(amountOfProducts , shipmentPrice);
                return Ok(cost_And_Duration.lowestCost);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetShipmentPrice")]
        public async Task<ActionResult<ShipmentPrice>> GetShipmentPrice(ShipmentPriceModel shipmentPrice)
        {
            try
            {
                var ppoc = await _ebuyStore.GetShipmentPrice(shipmentPrice);
                if (ppoc == null) return Ok("shipment price not found");
                return Ok(ppoc);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


    }
}
