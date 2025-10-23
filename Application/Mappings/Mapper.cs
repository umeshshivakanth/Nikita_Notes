using Application.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class Mapper : Profile
    {
        public Mapper()
        {

            CreateMap<Note, NoteDto>();

        
            CreateMap<NoteDto, Note>();
        }
    }
}
