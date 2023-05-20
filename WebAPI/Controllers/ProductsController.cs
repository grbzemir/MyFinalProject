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


        [HttpGet("GetAll")]
        public IActionResult Get()
        {
          

            // Dependency chain -- bağımlılık zinciri Product service product managera bagımlı halde
            
            var result = _productService.GetAll();

            if(result.Success) 
            
            {
                return Ok(result); // 200 sunucuyla alakalı her şey yolunda demekdir
            }
            return BadRequest(result); // 400 sunucuyla alakalı bir hata demekdir


        } 
          [HttpGet("Getbyid")]
        public IActionResult Get(int id)

        {

            var result = _productService.GetById(id);


            if(result.Success)

            {

                return Ok(result);

            }

            return BadRequest(result);


        }

        [HttpPost("add")]

        //IActionResult http durumlarında kullanılır
        public IActionResult Add(Product product)

        {

            var result = _productService.Add(product);

            if(result.Success)

            {
                    return Ok(result);
            }

            return BadRequest(result);
        }

 


    }
}
