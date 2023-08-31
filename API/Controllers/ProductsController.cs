using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> productRepository;
        private readonly IGenericRepository<ProductType> productTypeRepository;
        private readonly IGenericRepository<ProductBrand> productBrandRepository;
        private readonly IGenericRepository<ProductRating> productRatingRepository;
        private readonly IMapper mapper;
        public ProductsController(IGenericRepository<Product> _productRepository, IGenericRepository<ProductBrand> _productBrandRepository, IGenericRepository<ProductType> _productTypeRepository, IGenericRepository<ProductRating> _productRatingRepository, IMapper _mapper)
        {
            productBrandRepository = _productBrandRepository;
            productTypeRepository = _productTypeRepository;
            productRepository = _productRepository;
            productRatingRepository = _productRatingRepository;
            mapper = _mapper;

        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

            var countSpec = new ProductsWithFiltersForCountSpecification(productParams);

            var totalItems = await productRepository.CountAsync(countSpec);

            var products = await productRepository.ListAsync(spec);

            var data = mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await productRepository.GetEntityWithSpec(spec);

            if (product == null) return NotFound(new ApiResponse(404));

            return mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrandsAsync()
        {
            return Ok(await productTypeRepository.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypesAsync()
        {
            return Ok(await productBrandRepository.ListAllAsync());
        }

        [HttpGet("ratings")]
        public async Task<ActionResult<IReadOnlyList<ProductRating>>> GetProductRatingsAsync()
        {
            return Ok(await productRatingRepository.ListAllAsync());
        }
    }
}