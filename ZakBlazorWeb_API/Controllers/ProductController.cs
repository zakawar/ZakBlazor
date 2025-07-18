﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZakBlazor_Business.Repository.IRepository;
using ZakBlazor_Models;

namespace ZakBlazorWeb_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productRepository.GetAll());   
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int ? productId)
        {
            if (productId==null || productId == 0)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                }) ;
            }

            var product = _productRepository.Get(productId.Value);

            if (product == null)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }
            return Ok(product);
        }
    }

}
