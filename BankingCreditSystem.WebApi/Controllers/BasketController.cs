using Microsoft.AspNetCore.Mvc;
using static BankingCreditSystem.WebApi.Controllers.BasketController;
using static BankingCreditSystem.WebApi.Controllers.ProductController;

namespace BankingCreditSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseController
    {
        [HttpPost]
        public async Task<Response<string>> AddBasketItem([FromBody] AddBasketItemRequest item)
        {
            var response = new Response<string>();


            //servise gidilecek. CQRS yapısını oluştur ve Entity yapısını oluştur.

            response.StatusCode = 200;
            response.IsSuccessful = true;
            response.MessageList = new List<string>() { "Ürün sepete eklendi." };

            return response;
            
        }

        [HttpGet]
        public async Task<Response<BasketListResponse>> List()
        {
            var response = new Response<BasketListResponse>();

            var product = new BasketProduct()
            {
                Id = 440, 
                Title = "Kurukahveci Mehmet Efendi Türk Kahvesi 500 g",
                Url = "kurukahveci-mehmet-efendi-turk-kahvesi-500-g-p-40",
                DiscountAmount = 24,
                DiscountRatio = 15,
                StockAmount = 150,
                ImageUrl = "https://images.ofix.com/product-image/s99714-focus-klozet-kapagi-ortusu-250-adet-orta.jpg",
                LastPrice = 532,
                LastPriceIncludedVAT = 537,
                SalePrice = 532,
                SaleVAT = 1,
                ProductCode = "S17069",
            };

            var basketItme = new BasketItem() { Product = product, Quantity = 2 };
             
            var basketListResponse = new BasketListResponse() { BasketItem = new List<BasketItem> { basketItme } };

            response.Data = basketListResponse;
            response.StatusCode = 200;
            response.IsSuccessful = true;


            return response;
        }

        public class BasketListResponse
        {
            public List<BasketItem> BasketItem { get; set; }
            public decimal TotalPrice { get => BasketItem.Sum(x => x.Product.LastPriceIncludedVAT * x.Quantity); }
        }

        public class BasketItem
        {
            public BasketProduct Product { get; set; }
            public int Quantity { get; set; }
        }

        public class BasketProduct
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Url { get; set; } //site urlde yazan kısım
            public decimal DiscountAmount { get; set; } //indirim tutarı
            public int DiscountRatio { get; set; } //indirim oranı
            public int StockAmount { get; set; } //stok Adedi
            public string ImageUrl { get; set; }
            public decimal LastPrice { get; set; } //son fiyat kdv eklenmemiş tutar.
            public decimal LastPriceIncludedVAT { get; set; } //son fiyat kdv eklenmiş tutarı. gerçek ürün fiyatıdır.
            public decimal SalePrice { get; set; } //satış fiyatı
            public int SaleVAT { get; set; }
            public string ProductCode { get; set; } //sku
        }

        public class AddBasketItemRequest
        {
            public string ProductId { get; set; }
            public int Quantity { get; set; }

        }

        public class Response<T>
        {
            public T Data { get; set; }
            public List<string> Errors { get; set; }
            public bool IsSuccessful { get; set; }
            public int StatusCode { get; set; }
            public List<string> MessageList { get; set; }
        }
    }
}
