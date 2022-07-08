using AutoMapper;
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
    public class ProductPriceRepository : IProductPriceRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductPriceRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductPriceDTO> Create(ProductPriceDTO objDTO)
        {

            var obj = _mapper.Map<ProductPriceDTO, ProductPrice>(objDTO);
           
            var addedobj = _db.ProductPrices.Add(obj);
            _db.SaveChanges();

            return _mapper.Map<ProductPrice, ProductPriceDTO>(addedobj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var deletedObj = _db.ProductPrices.FirstOrDefault(u => u.Id == id);

            if (deletedObj != null)
            {
                _db.ProductPrices.Remove(deletedObj);
                return _db.SaveChanges();

            }
            return 0;
        }

        public async Task<ProductPriceDTO> Get(int id)
        {
            var Getobj = _db.ProductPrices.FirstOrDefault(u => u.Id == id);

            if (Getobj != null)
            {
                return _mapper.Map<ProductPrice, ProductPriceDTO>(Getobj);
            }

            return new ProductPriceDTO();

        }

        public async Task<IEnumerable<ProductPriceDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDTO>>(_db.ProductPrices);
        }

        public async Task<ProductPriceDTO> Update(ProductPriceDTO objDTO)
        {
            var updatedObj = _db.ProductPrices.FirstOrDefault(u => u.Id == objDTO.Id);
            if (updatedObj != null)
            {                
                updatedObj.Size = objDTO.Size;
                updatedObj.Price = objDTO.Price;
                updatedObj.ProductId = objDTO.ProductId;
                _db.ProductPrices.Update(updatedObj);
                _db.SaveChanges();
                return _mapper.Map<ProductPrice, ProductPriceDTO>(updatedObj);
            }
            return objDTO;
        }
    }
}
