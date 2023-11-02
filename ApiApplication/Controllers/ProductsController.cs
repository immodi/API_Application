using ApiApplication.APIs.DTOs;
using ApiApplication.APIs.Errors;
using ApiApplication.APIs.Helpers;
using ApiApplication.Core.Models;
using ApiApplication.Core.Repositories;
using ApiApplication.Core.Specifications;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.APIs.Controllers
{
    public class ProductsController : ApiBaseController
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IGenericRepository<ProductBrand> _brandRepository;
        private readonly IGenericRepository<ProductType> _typeRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> repository,
                                  IGenericRepository<ProductBrand> brandRepository,
                                  IGenericRepository<ProductType> typeRepository,
                                  IMapper mapper)
        {
            _repository = repository;
            _brandRepository = brandRepository;
            _typeRepository = typeRepository;
            _mapper = mapper;
        }


        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productSpec)
        {
            var spec = new ProductSpecifications(productSpec);
            var products = await _repository.GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            var countSpec = new ProductWithFilterForCountSpecification(productSpec);
            var count = await _repository.GetCountWithSpecAsync(countSpec);
            return Ok(new Pagination<ProductToReturnDto>(productSpec.PageIndex, productSpec.PageSize, count, data));
        }

        [ProducesResponseType(typeof(ProductToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductSpecifications(id);
            var product = await _repository.GetIdWithSpecAsync(spec);
            if (product is null) return NotFound(new ErrorResponse(404));
            var mappedProducts = _mapper.Map<Product,ProductToReturnDto>(product);
            return Ok(mappedProducts);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllBrands()
        {
            var brands = await _brandRepository.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetAllTypes()
        {
            var types = await _typeRepository.GetAllAsync();
            return Ok(types);
        }
    }
}
 