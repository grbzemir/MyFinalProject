using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase

    {
        // IdataResult bize bir işlem sonucu ve bir mesaj döndürür kısacası tüm datayı!

        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public List<Product> Get()
        {
          

            // Dependency chain -- bağımlılık zinciri Product service product managera bagımlı halde
            
            var result = _productService.GetAll();
            return result.Data;


        }


    }
}
