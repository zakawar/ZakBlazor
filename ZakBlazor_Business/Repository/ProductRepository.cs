using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakBlazor_Business.Repository.IRepository;
using ZakBlazor_DataAccess;
using ZakBlazor_DataAccess.Data;
using ZakBlazor_Models;

namespace ZakBlazor_Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO objDTO)
        {
            var obj = _mapper.Map<ProductDTO, Product>(objDTO);
            
            var addedobj = _db.Products.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDTO>(addedobj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var deletedObj = await _db.Products.FirstOrDefaultAsync(u => u.Id == id);

            if (deletedObj != null)
            {
                _db.Products.Remove(deletedObj);
                return await _db.SaveChangesAsync();

            }
            return 0;
        }

        public async Task<ProductDTO> Get(int id)
        {
            var Getobj = await _db.Products.Include(u=>u.Category).FirstOrDefaultAsync(u => u.Id == id);

            if (Getobj != null)
            {
                return _mapper.Map<Product, ProductDTO>(Getobj);
            }

            return new ProductDTO();

        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.Products.Include(u => u.Category));
        }
        
        public async Task<ProductDTO> Update(ProductDTO objDTO)
        {
            var updatedObj = await _db.Products.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if (updatedObj != null)
            {
                updatedObj.Name = objDTO.Name;
                updatedObj.Description = objDTO.Description;
                updatedObj.ImageUrl = objDTO.ImageUrl;
                updatedObj.CategoryId= objDTO.CategoryId;
                updatedObj.Color = objDTO.Color;
                updatedObj.ShopFavorites = objDTO.ShopFavorites;
                updatedObj.CustomerFavorites = objDTO.CustomerFavorites;
                _db.Products.Update(updatedObj);
                await _db.SaveChangesAsync();
                return _mapper.Map<Product, ProductDTO>(updatedObj);
            }
            return objDTO;
        }
    }
}

