using ReadersHub.Contracts.Books;
using AutoMapper;
using ReadersHub.Data.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<BookList> GetBooks()
        {
            var booksDto = await _context.Books.ToArrayAsync();
            var books = Array.ConvertAll(booksDto, dto => _mapper.Map<Book>(dto));
            return new BookList(books);
        }

        public async Task AddBook(Book book)
        {
            var bookDto = _mapper.Map<BookDto>(book);

            await _context.Books.AddAsync(bookDto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            _context.Remove(new BookDto { Id = id });
            await _context.SaveChangesAsync();
        }
    }
}
