using AutoMapper;
using libraryManagement.Models;
using libraryManagement.Models.DTO;

namespace libraryManagement.Models.DTO.Mapper
{
    public class AllMappersProfile:Profile
    {
        public AllMappersProfile()
        {
            CreateMap<TblBook,BooksDTO>();
            CreateMap<BooksDTO,TblBook>();
        }
    }
}