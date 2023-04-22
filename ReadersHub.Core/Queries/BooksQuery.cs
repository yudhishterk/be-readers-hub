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

        public BookList GetBooks()
        {
            return _books.GetBooks();
        }

        public void AddBook(Book book)
        {
            _books.AddBook(book);
        }
    }
}
