using ShoppingCart.Services;
using System.Web.Http;

namespace ShoppingCart.WebApi.Controllers
{
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_categoryService.GetCategories());
        }

        // GET: api/Categories/2
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var product = _categoryService.GetCategory(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
