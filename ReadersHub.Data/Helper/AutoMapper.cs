using AutoMapper;
using ReadersHub.Data.Models;
using ReadersHub.Contracts.Books;

namespace ReadersHub.Data.Helper
{
    public class AutoMapper
    {
        private static AutoMapper? _instance;

        private Mapper _mapper;

        private AutoMapper()
        {
            _mapper = new Mapper(GetConfiguration());
        }

        private MapperConfiguration GetConfiguration()
        {
            var configure = new MapperConfigurationExpression();

            CreateMap(configure);

            return new MapperConfiguration(configure);
        }

        public static Mapper Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new AutoMapper();
                }

                return _instance._mapper;
            }
        }

        private void CreateMap(MapperConfigurationExpression configure)
        {
            configure.CreateMap<BookDto, Book>();
            configure.CreateMap<Book, BookDto>();
        }
    }
}
