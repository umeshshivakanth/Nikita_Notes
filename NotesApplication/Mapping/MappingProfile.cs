using AutoMapper;
using NotesApplication.Models;
using NotesApplication.ViewModel;

namespace NotesApplication.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<Note, NoteViewModel>();

            CreateMap<NoteViewModel, Note>();
        }
    }
    }
