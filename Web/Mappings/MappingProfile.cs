using Application.DTO;
using AutoMapper;
using BasicNotesApp.Web.ViewModel;

namespace Web.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
        
            CreateMap<NoteViewModel, NoteDto>();

          
            CreateMap<NoteDto, NoteViewModel>();
        }
    }
}
