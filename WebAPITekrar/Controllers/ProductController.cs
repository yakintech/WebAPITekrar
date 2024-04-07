using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITekrar.Models.DTO.Product;
using WebAPITekrar.Models.ORM;

namespace WebAPITekrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ECommerceContext db;

        public ProductController(ECommerceContext _db)
        {
            db = _db;
        }


        [HttpGet]
        public IActionResult GetProducts()
        {
           List<GetAllProductsResponseDto> responseModel = db.Products.Where(q => q.IsDeleted == false).Select(q => new GetAllProductsResponseDto()
           {
                ID = q.ID,
                Name = q.Name,
                Description = q.Description,
                UnitPrice = q.UnitPrice,
                Stock = q.Stock
            }).ToList();

            return Ok(responseModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductByID(int id)
        {
            Product product = db.Products.FirstOrDefault(q => q.ID == id && q.IsDeleted == false);

            if (product != null)
            {
                GetProductByIdResponseDto responseModel = new GetProductByIdResponseDto();
                responseModel.ID = product.ID;
                responseModel.Name = product.Name;
                responseModel.Description = product.Description;
                responseModel.UnitPrice = product.UnitPrice;
                responseModel.Stock = product.Stock;

               

                return Ok(responseModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Product product = db.Products.FirstOrDefault(q => q.ID == id);

            if (product != null)
            {
                product.IsDeleted = true;
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult CreateProduct(CreateProductRequestDto requestModel)
        {
            Product product = new Product();
            product.Name = requestModel.Name;
            product.Description = requestModel.Description;
            product.UnitPrice = requestModel.UnitPrice;
            product.Stock = requestModel.Stock;

            db.Products.Add(product);
            db.SaveChanges();

            return Ok();

            //CreateProductResponseDto responseModel = new CreateProductResponseDto();
            //responseModel.ID = product.ID;
            //responseModel.Name = product.Name;
            //responseModel.Description = product.Description;
            //responseModel.UnitPrice = product.UnitPrice;
            //responseModel.Stock = product.Stock;
            //responseModel.AddDate = product.AddDate;

            //return StatusCode(StatusCodes.Status201Created, responseModel);
        }

    }
}


