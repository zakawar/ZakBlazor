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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public CategoryDTO Create(CategoryDTO objDTO)
        {

            var obj = _mapper.Map<CategoryDTO, Category>(objDTO);
            obj.CreatedTime = DateTime.Now;
            var addedobj = _db.Categories.Add(obj);
            _db.SaveChanges();

            return _mapper.Map<Category, CategoryDTO>(addedobj.Entity);
        }

        public int Delete(int id)
        {
            var deletedObj = _db.Categories.FirstOrDefault(u => u.Id == id);

            if (deletedObj != null)
            {
                _db.Categories.Remove(deletedObj);
                return _db.SaveChanges();

            }
            return 0;
        }

        public CategoryDTO Get(int id)
        {
            var Getobj = _db.Categories.FirstOrDefault(u => u.Id == id);

            if (Getobj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(Getobj);
            }

            return new CategoryDTO();

        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public CategoryDTO Update(CategoryDTO objDTO)
        {
            var updatedObj = _db.Categories.FirstOrDefault(u => u.Id == objDTO.Id);
            if (updatedObj != null)
            {
                updatedObj.Name = objDTO.Name;
                _db.Categories.Update(updatedObj);
                _db.SaveChanges();
                return _mapper.Map<Category, CategoryDTO>(updatedObj);
            }
            return objDTO;
        }
    }
}
