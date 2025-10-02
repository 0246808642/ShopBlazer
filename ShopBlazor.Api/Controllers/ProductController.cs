using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBlazor.Api.Repository;
using ShopBlazor.Models.DTOs;

namespace ShopBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper= mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var produtos = await _repository.GetItens();
                if(produtos is null)
                {
                    return NotFound();
                }
                var dto = _mapper.Map<IEnumerable<ProductDto>>(produtos);
                return Ok(dto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error ao tentar acessar o banco de dados");
            }
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ProductDto>> GetItem(long id)
        {
            try
            {
                var produto = await _repository.GetItem(id);
                if(produto is null)
                {
                    return NotFound($"Produto com id={id} não encontrado");
                }
                var dto = _mapper.Map<ProductDto>(produto);
                return Ok(dto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error ao tentar acessar o banco de dados");
            }
        }

        [HttpGet("Categorias/{id:long}")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories(long id)
        {
            try
            {
               var cat = await _repository.GetItensByCategory(id);
                if (cat is null)
                {
                    NotFound($"Categoria com id={id} não encontrada");
                }
                var dto = _mapper.Map<IEnumerable<ProductDto>>(cat);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error ao tentar acessar o banco de dados");
            }
        }
    }
}
