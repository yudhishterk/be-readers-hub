using ReadersHub.Contracts.Books;
using AutoMapper;
using ReadersHub.Data.Models;

namespace ReadersHub.Data.Data
{
    public class BooksData
    {
        private readonly ReadersHubContext _context;
        private readonly Mapper _mapper;

        public BooksData(ReadersHubContext context)
        {
            _context = context;
            _mapper = Helper.AutoMapper.Instance;
        }

        public BookList GetBooks()
        {
            var books = _context.Books.AsParallel().Select(book => _mapper.Map<Book>(book));

            return new BookList(books);
        }

        public void AddBook(Book book)
        {
            var bookDto = _mapper.Map<BookDto>(book);
            _context.Books.Add(bookDto);
            _context.SaveChanges();
        }
    }
}
