namespace ReadersHub.Contracts.Books
{
    public class BookList
    {
        public IEnumerable<Book> Books { get; set; }

        public BookList(IEnumerable<Book> books)
        {
            Books = books;
        }
    }
}
