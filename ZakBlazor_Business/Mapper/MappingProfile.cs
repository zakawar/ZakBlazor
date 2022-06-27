using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakBlazor_DataAccess;
using ZakBlazor_Models;

namespace ZakBlazor_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDTO,Category>().ReverseMap();

            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
