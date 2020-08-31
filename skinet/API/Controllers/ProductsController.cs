using Core.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Specifications;
using AutoMapper;
using API.Dtos;
using API.Errors;
using System.Net;
using Microsoft.AspNetCore.Http;
using API.Helpers;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productSpec)
        {
            var countSpec = new ProductWithFilterForCountSpecifications(productSpec);
            var spec = new ProductsWithTypesAndBrandsSpecification(productSpec);

            var totalItems = await _productRepository.CountAsync(countSpec);

            var product = await _productRepository.ListAsync(spec);
            var mappedDto = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(product);

            if (mappedDto != null)
                return Ok(new Pagination<ProductToReturnDto>(productSpec.PageSize, productSpec.PageIndex, totalItems, mappedDto));
            else
                return NotFound(new ApiResponse((int)HttpStatusCode.BadRequest));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _productRepository.GetEntityWithSpec(spec);

            var mappedDto = _mapper.Map<ProductToReturnDto>(product);

            if (mappedDto != null)
                return Ok(mappedDto);
            else
                return NotFound(new ApiResponse((int)HttpStatusCode.BadRequest));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrand = await _productBrandRepository.GetListAllAsync();
            if (productBrand != null)
                return Ok(productBrand);
            else
                return NotFound(new ApiResponse((int)HttpStatusCode.BadRequest));
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var productType = await _productTypeRepository.GetListAllAsync();
            if (productType != null)
                return Ok(productType);
            else
                return NotFound(new ApiResponse((int)HttpStatusCode.BadRequest));
        }
    }
}