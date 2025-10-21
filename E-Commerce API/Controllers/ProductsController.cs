using AutoMapper;
using E_Commerce_API.DTO;
using E_Commerce_API.Models;
using E_Commerce_API.Profiles;
using E_Commerce_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
          private readonly IRepository<Product>  _repository;
        private readonly IMapper _mapper;


        public ProductsController(IRepository<Product> rep, IMapper m)
        {
            _repository = rep;
            _mapper = m;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products= await _repository.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateProductDto cpd)
        {
            var product=_mapper.Map<Product>(cpd);
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
            return Ok("Prouct added succesfuly");
        }
    }
}
