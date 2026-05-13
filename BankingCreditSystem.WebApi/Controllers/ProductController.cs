using BankingCreditSystem.Application.Features.Category.Commands.Update;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Delete;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetList;
using BankingCreditSystem.Application.Features.Product.Commands.Create;
using BankingCreditSystem.Application.Features.Product.Commands.Delete;
using BankingCreditSystem.Application.Features.Product.Commands.Update;
using BankingCreditSystem.Application.Features.Product.Queries.GetById;
using BankingCreditSystem.Application.Features.Product.Queries.GetList;
using BankingCreditSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static BankingCreditSystem.WebApi.Controllers.ProductController;

namespace BankingCreditSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var result = await Mediator.Send(createProductCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListProductQuery getListProductQuery)
        {
            var result = await Mediator.Send(getListProductQuery);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetByIdProductQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            var result = await Mediator.Send(updateProductCommand);
            return Ok(result);
        }



        //Bir ürünün detay sayfasının getirilmesi. ofix.com response ve requestin aynısı yapıldı.
        [HttpGet("detail/{id}")]
        public async Task<Response<ProductDetailResponse>> Detail([FromRoute] int id)
        {
            //örnek request yapısı;

            //id si olanın resmini getir.
            var image = new Image { Id = 42, Path = "https://images.ofix.com/product-image/s17069-orta.jpg" , Alt= "Kurukahveci Mehmet Efendi Türk Kahvesi 500 g görseli" };

            //idli ürünün kategorilerni getir. (alt üst kategorileri.)
            var üstKategori = new Category()
            {
                CategoryId = 5,
                CategoryName = "Gıda",
                CategoryUrl = "gida"
            };
            var altKategori = new Category()
            {
                CategoryId = 2,
                CategoryName = "Kahveler",
                CategoryUrl = "kahveler"
            };
            var DigerAltKategori = new Category()
            {
                CategoryId = 1,
                CategoryName = "Türk Kahvesi",
                CategoryUrl = "turk-kahvesi"
            };
            var breadcrumb = new List<Category>();
            breadcrumb.Add(üstKategori);
            breadcrumb.Add(altKategori);
            breadcrumb.Add(DigerAltKategori);
            //idli ürünün markasını getir.


            var product = new ProductDetailResponse() { 
                Id = id,
                Title = "Kurukahveci Mehmet Efendi Türk Kahvesi 500 g",
                Url = "kurukahveci-mehmet-efendi-turk-kahvesi-500-g-p-40",
                Description = "<p><span style=\"font-size: 16pt;\"><strong>Kurukahveci Mehmet Efendi Türk Kahvesi 500 g</strong></span></p>\n<p><span style=\"font-size: 9pt;\">Kahvenin sosyalleştirici ve insanları birleştirici etkisi kahvehane kültürlerinin oluşmasına sebebiyet vermiştir.Bu hatrı sayılır birleştirici etkiyi gün içerisinde ofisinize rahatlıkla taşıyabilirsiniz. Enerjinizin düştüğünü hissettiğiniz anda içeceğiniz bir ''orta şekerli kahve'' veya öğle molalarınıza anlam katacak bir ''bol köpüklü kahve'' hem tadı hem kokusuyla size keyifli bir gün yaşatacaktır.</span><span style=\"font-size: 9pt;\">16. yüzyılda Yemen'den gelerek eşsiz kokusu ve lezzetiyle Osmanlı Sarayları ve padişahlarının vazgeçilmez lezzeti olan </span><strong style=\"font-size: 9pt;\">kahve;</strong><span style=\"font-size: 9pt;\"> </span><span style=\"font-size: 9pt;\">1871'de Kurukahveci Mehmet Efendi'nin ustalık, bilgi ve tecrübeleriyle daha da güçlenerek, formunu bozmadan günümüze kadar kalitesini korumuş ve Türk Kahvesi tarihi başlamıştır.</span><strong style=\"font-size: 9pt;\"> Kurukahveci Mehmet Efendi,</strong><span style=\"font-size: 9pt;\"> </span><span style=\"font-size: 9pt;\">kahve çekirdeklerini özenle işlemiş ve lezzetine doyum olmayacak şekilde fincanlarımıza taşıyarak kahve sanatının öncüsü olmuştur.</span></p>\n<p><span style=\"font-size: 9pt;\">Sağlık açısından faydalı olduğu bilinen ve uzmanlarca günde en az bir fincan tüketilmesi tavsiye edilen sade<strong> Türk Kahvesi</strong> yaklaşık 7 kaloridir. Orta şekerli olarak yaklaşık 27, şekerli olarak ise yaklaşık 45 kaloridir. İçerdiği bol miktarda kalsiyum ve demirin yanında; yağ, lif ve protein içermemesi sebebiyle, diyetler için herhangi bir engel teşkil etmemektedir. Türk Kahvesi kafein miktarı, 1 fincan iç</span><span style=\"font-size: 9pt;\">in 60 mg'dır. Bu miktar, diğer kahve türleri arasındaki en düşük kafein miktarlarındandır. </span><strong style=\"font-size: 9pt;\">Türk Kahvesi çeşitleri</strong><span style=\"font-size: 9pt;\">, sade, orta ya da şekerli olarak hazırlanabilir ve her damak zevkine hitap eder. Birbirinden şık tasarımlı Türk kahvesi fincanı ile birlikte; lokum ya da bir dilim çikolata ile yapacağınız bol köpüklü kahve sunumlarınız unutulmaz olacaktır. <br /><br /></span></p>\n<p><span style=\"font-size: 9pt;\"><img class=\"img img-responsive\" title=\" Kurukahveci Mehmet Efendi Logo\" style=\"width: 252px; height: 264px; display: block; margin-left: auto; margin-right: auto;\" src=\"https://images.ofix.com/description-image/kurukahveci-mehmet-efendi-logo-286x300.jpg?output=webp\" height=\"300\" width=\"286\" data-original-height=\"300\" data-original-width=\"286\" /></span></p>\n<p><span style=\"font-size: 9pt;\"><strong><br />Kurukahveci Mehmet Efendi Türk Kahvesi 500 g x 6 Adet</strong>, eşsiz kokusu ve tadı, dilediğiniz miktarda telvesi, üzerindeki köpüğü ve kendine özgü pişirilme şekli ile <strong>Ofix.com</strong>'da sizi bekliyor!  </span><span style=\"font-size: 9pt;\">Online alışveriş sitesi <strong>Ofix.com</strong> sitemizde, gıda ürünlerine uygun fiyat avantajlarıyla ulaşabilirsiniz. Sitemizde <strong>türk kahvesi fiyatları</strong> piyasa ortalamasına göre uygun düzeydedir. Kurumsal müşterilerimize sunduğumuz ekstra fiyat avantajlarından yararlanmak için <strong>Ofix.com</strong> sayfamızı ziyaret edebilirsiniz.</span></p>\n<p><span style=\"font-size: 9pt;\">Aradığınız en uygun <strong>türk kahvesi</strong> modellerini hemen ayağınıza getiren <strong>ofix.com</strong> sizlere her zaman en ucuz ve kaliteli <strong>türk kahvesi</strong> modellerini sunmaktadır. Farklı marka veya model <strong>türk kahvesi</strong> arıyorsanız, sitemizin <a title=\"Kahveler\" href=\"https://www.ofix.com/turk-kahvesi-c-503\"><strong>Gıda ve Mutfak Ürünleri - Kahveler</strong></a> kategorisinden beğendiğiniz ürünü seçip hemen sipariş verebilirsiniz. Tüm ihtiyaçlarınız tek adresi <strong>Ofix.com</strong> size her zaman güvenilir bir alışveriş imkanı sunmaktadır.</span></p>\n<p> </p>\n<h2><span style=\"font-size: 12pt;\"><strong>Kurukahveci Mehmet Efendi Türk Kahvesi Açıklaması:</strong></span></h2>\n<ul>\n<li>500 g</li>\n<li>Teneke kutu</li>\n<li>Yüksek kaliteli kahve çekirdeklerinden üretilmiştir</li>\n<li>Kalabalık iş yerleri için ideal</li>\n</ul>\n<p> </p>\n<h3><strong><span style=\"font-size: 11pt;\">Kurukahveci Mehmet Efendi Türk Kahvesi Nasıl Yapılır?</span></strong></h3>\n<ul>\n<li>İçme suyunu fincanla ölçerek cezveye koyunuz.</li>\n<li>Her fincan için 2 çay kaşığı kahve (6 g), arzu ederseniz şeker ilave ediniz.</li>\n<li>Kısık ateşte kahveyi iyice karıştırınız.</li>\n<li>Bir süre sonra kabaran köpüğü fincanlara pay ediniz.</li>\n<li>Kalan kahveyi bir taşım daha pişiriniz ve fincanlara boşaltınız.</li>\n</ul>\n<p> </p>\n<h3><strong><span style=\"font-size: 11pt;\">Türk Kahvesi Faydaları Nelerdir?</span></strong></h3>\n<p>Sağlık açısından faydaları herkesçe bilinen ve uzmanlarca günde en az bir fincan tüketilmesi tavsiye edilen sade Türk Kahvesi yaklaşık 7 kaloridir. Orta şekerli olarak yaklaşık 27, şekerli olarak ise yaklaşık 45 kaloridir. İçerdiği bol miktarda kalsiyum ve demirin yanında; yağ, lif ve protein içermemesi sebebiyle, diyetler için herhangi bir engel teşkil etmez. Türk Kahvesi kafein miktarı, 1 fincan için 60 mg'dır. Bu miktar, diğer kahve türleri arasındaki en düşük kafein miktarlarındandır. Türk Kahvesi çeşitleri, sade, orta ya da şekerli olarak hazırlanabilir ve her damak zevkine hitap etmektedir. Birbirinden şık tasarımlı Türk kahvesi fincanı ile birlikte; lokum ya da bir dilim çikolata ile yapacağınız bol köpüklü kahve sunumlarınız unutulmaz olacaktır. </p>\n<p>Yemeklerden sonra sindirimi kolaylaştırmaya yarayan ve yorgunluğa birebir olan Türk Kahvesi tüketimi, birçok kanser türüne yakalanma riskini %25 ila 50 arasında azaltıyor. Hafızayı güçlendirdiği ve dikkat artırdığı yapılan testler sonucu kanıtlanmıştır. Çok fazla tüketilmediği taktirde (günde 3 fincandan fazla tüketilmesi tavsiye edilmez.) sağlığa olumsuz herhangi bir etkisi yoktur.</p>\n<p> </p>\n<p><img class=\"img img-responsive\" title=\"Yerli Üretim Logo\" style=\"width: 150px; height: 58px;\" src=\"https://images.ofix.com/description-image/yerliretimlogo.png?output=webp\" height=\"387\" width=\"1000\" data-original-height=\"387\" data-original-width=\"1000\" /></p>",
                DiscountAmount = 24,
                DiscountRatio = 15,
                StockAmount = 150,
                ImageList = new List<Image> { image },
                BrandId = 472,
                BrandName = "Kurukahveci Mehmet Efendi",
                LastPrice = 532,
                LastPriceIncludedVAT = 537,
                SalePrice = 532,
                SaleVAT = 1,
                ProductCode = "S17069",
                Breadcrumb = breadcrumb
            };


            var response = new Response<ProductDetailResponse>();
            response.Data = product;
            response.StatusCode = 200;
            response.IsSuccessful = true;
            return response;
        }

        public class Response<T>
        {
            public T Data { get; set; }
            public List<string> Errors { get; set; }
            public bool IsSuccessful { get; set; }
            public int StatusCode { get; set; }
            public List<string> MessageList { get; set; }
        }

        public class ProductDetailResponse
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Url { get; set; } //site urlde yazan kısım
            public string Description { get; set; }
            public decimal DiscountAmount { get; set; } //indirim tutarı
            public int DiscountRatio { get; set; } //indirim oranı
            public int StockAmount { get; set; } //stok Adedi
            public List<Image> ImageList { get; set; }
            public int BrandId { get; set; }
            public string BrandName { get; set; }
            public decimal LastPrice { get; set; } //son fiyat kdv eklenmemiş tutar.
            public decimal LastPriceIncludedVAT { get; set; } //son fiyat kdv eklenmiş tutarı. gerçek ürün fiyatıdır.
            public decimal SalePrice { get; set; } //satış fiyatı
            public int SaleVAT { get; set; }
            public string ProductCode { get; set; } //sku
            public List<Category> Breadcrumb { get; set; }


        }

        public class Category
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string CategoryUrl { get; set; }
        }


        public class Image
        {
            public int Id { get; set; }
            public string Alt { get; set; }
            public string Path { get; set; }
        }
    }
}
