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
    public class CategoriesController : ControllerBase
    {
        private  readonly IMapper _mapper;
        private readonly IRepository<Category> _repository;
    
        public CategoriesController(IMapper mapper, IRepository<Category> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task <IActionResult>GetAll()
        {
            var categories= await _repository.GetAllAsync();
            var c=_mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(c);
        }
        [HttpPost]
        public async Task <IActionResult> Create(CategoryDto category)
        {
            var categorymapped= _mapper.Map<Category>(category);
            await _repository.AddAsync(categorymapped);
            await _repository.SaveChangesAsync();
            return Ok("Category Added Successfuly");
        }
    }
}
