
using AutoMapper;
using E_Commerce_API.DTO;
using E_Commerce_API.Models;
using E_Commerce_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Customer> _repository;
        public CustomersController(IMapper m, IRepository<Customer> r)
        {
            _mapper = m;    
            _repository = r;
        }
        [HttpGet]

        public async Task <IActionResult> GetAll()
        {
            var customers=await _repository.GetAllAsync();
            var dto= _mapper.Map< IEnumerable<CustomerDto> >(customers);
            return Ok(dto);
        }
        [HttpPost]
        public  async Task <IActionResult> Create(CustomerDto customer)
        {
            var mappercustomer=_mapper.Map< Customer>(customer);
            await _repository.AddAsync(mappercustomer);
            await _repository.SaveChangesAsync();
            return Ok("Custumer Add Successfully");
        }

    }
}
