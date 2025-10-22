using Application.DTO;
using AutoMapper;
using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class Mapper :Profile
    {
        public Mapper()
        {
            CreateMap<Note, NoteDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<NoteDto, Note>();

        }


    }
}
