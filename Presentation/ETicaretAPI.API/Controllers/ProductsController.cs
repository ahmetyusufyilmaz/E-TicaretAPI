using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            //  await  _productWriteRepository.AddRangeAsync(new()
            //   {
            //       new() {Id=Guid.NewGuid(),Name ="Product 1",Price=100,CreatedDate=DateTime.UtcNow,Stock=10 },
            //       new() {Id = Guid.NewGuid(), Name = "Product 2", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20 },
            //       new() {Id=Guid.NewGuid(),Name ="Product 3",Price=300,CreatedDate=DateTime.UtcNow,Stock=30 },
            //});
            //  var count=  await _productWriteRepository.SaveAsync();


            Product p =   await _productReadRepository.GetByIdAsync("0b2dc0ad-8855-49fe-89f0-a70a1f11e01d",false);
            p.Name = "Mehmet";
            await _productWriteRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(string id)
        {
            Product product=await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
