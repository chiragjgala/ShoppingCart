using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCart.Entities;
using ShoppingCart.Services;

namespace ShoppingCart.WebApi.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("~/api/Categories/{categoryId:int}/Products")]
        [HttpGet]
        public IHttpActionResult Get(int categoryId)
        {
            return Ok(_productService.GetProducts(categoryId));
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        //[Route("{id:int?}")] optional param
        //[Route("{id:int=4}")] default param value
        [Route("{id:int}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Product product)
        {
            if (product == null) throw new ArgumentNullException("product");

            var savedProduct = _productService.SaveProduct(product);

            var response = Request.CreateResponse(HttpStatusCode.Created, savedProduct);

            var uri = Url.Link("DefaultApi", new { id = product.Id, controller = "Products" });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Put(int id, [FromBody]Product product)
        {
            if (product == null) throw new ArgumentNullException("product");

            _productService.UpdateProduct(id, product);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public void Delete(int id)
        {
            var product = _productService.GetProduct(id);

            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _productService.Delete(id);
        }
    }
}
