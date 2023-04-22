using ReadersHub.Contracts.Books;
using ReadersHub.Data.Data;

namespace ReadersHub.Core.Queries
{
    public class BooksQuery
    {
        private BooksData _books;

        public BooksQuery(BooksData books)
        {
            _books = books;
        }

        public async Task<BookList> GetBooks()
        {
            return await _books.GetBooks();
        }

        public async Task AddBook(Book book)
        {
            await _books.AddBook(book);
        }

        public async Task DeleteBook(int id)
        {
            await _books.DeleteBook(id);
        }
    }
}
