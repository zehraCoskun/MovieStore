using AutoMapper;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Operations.ActorOperations.Commands.CreateActor;
using MovieStoreWebApi.Operations.ActorOperations.Queries;
using MovieStoreWebApi.Operations.DirectorOperations.Commands.CreateDirector;
using MovieStoreWebApi.Operations.DirectorOperations.Queries;
using MovieStoreWebApi.Operations.GenreOperations.Commands;
using MovieStoreWebApi.Operations.GenreOperations.Queries;
using MovieStoreWebApi.Operations.Queries;

namespace MovieStoreWebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //movie controller 
            CreateMap<int,Actor>().ForMember(dest => dest.ID , opt=> opt.MapFrom(x=> x));
            CreateMap<int,Movie>().ForMember(dest => dest.ID , opt=> opt.MapFrom(x=> x));
            CreateMap<Movie, GetMovieByIdModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.GenreName.GenreName))
                                                 .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(x => x.Firstname + " " + x.Surname).ToList()))
                                                 .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.DirectorName.Firstname + " " + src.DirectorName.Surname));
            CreateMap<Movie, MoviesViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.GenreName.GenreName))
                                               .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(x => x.Firstname + " " + x.Surname)))
                                               .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.DirectorName.Firstname + " " + src.DirectorName.Surname));
            //CreateMap<CreateMovieModel, Movie>().ForMember(dest=> dest.Actors, opt=>opt.MapFrom(src=> src.Actors.Select(x=> x.Firstname+" "+x.Surname).ToList()));

            //actor controller
            CreateMap<Actor, ActorsViewModel>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies.Select(x=> x.MovieTitle)));
            CreateMap<Actor, GetActorByIdModel>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies.Select(x=> x.MovieTitle)));
            CreateMap<CreateActorModel, Actor>().ForMember(dest=>dest.Movies,opt=> opt.MapFrom(src=>src.Movies));

            //genre controller
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GetGenreByIdModel>();
            CreateMap<CreateGenreModel, Genre>();

            //director controller
            CreateMap<Director, DirectorsViewModel>();
            CreateMap<Director, GetDirectorByIdModel>();
            CreateMap<DirectorCreateModel, Director>();

            
           
            

        }
    }
}