using Application.DTO;
using AutoMapper;
using BasicNotesApp.Web.ViewModel;

namespace Web.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            // ViewModel -> DTO (for Create/Edit)
            CreateMap<NoteViewModel, NoteDto>();

            // DTO -> ViewModel (for display in Index/Edit)
            CreateMap<NoteDto, NoteViewModel>()
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.CategoryName));
        }
    }
}
