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
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {

         Order order= await  _orderReadRepository.GetByIdAsync("02d4b7b3-d3e8-4dc5-af9a-1632e54e35a7");
            order.Address = "Giresun";
            await _orderWriteRepository.SaveAsync();


            //var customerId=Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Muhittin" });
            //await _orderWriteRepository.AddAsync(new() { Description = "deneme 1", Address = "İstanbul", CustomerId=customerId});
            //await _orderWriteRepository.AddAsync(new() { Description = "deneme 2", Address = "Ankara",CustomerId=customerId });
            //    await _orderWriteRepository.SaveAsync();


            //await _productWriteRepository.AddAsync(new() { Name="C Product",Price=1.50,Stock=10,CreatedDate=DateTime.UtcNow});
            // await _productWriteRepository.SaveAsync();   

            //  await  _productWriteRepository.AddRangeAsync(new()
            //   {
            //       new() {Id=Guid.NewGuid(),Name ="Product 1",Price=100,CreatedDate=DateTime.UtcNow,Stock=10 },
            //       new() {Id = Guid.NewGuid(), Name = "Product 2", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20 },
            //       new() {Id=Guid.NewGuid(),Name ="Product 3",Price=300,CreatedDate=DateTime.UtcNow,Stock=30 },
            //});
            //  var count=  await _productWriteRepository.SaveAsync();

            ///////////////////////////////////////////////////////////////

            //Product p =   await _productReadRepository.GetByIdAsync("0b2dc0ad-8855-49fe-89f0-a70a1f11e01d",false);
            //p.Name = "Mehmet";
            //await _productWriteRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
