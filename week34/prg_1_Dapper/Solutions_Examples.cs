using Dapper;

namespace gettingstarted.week34.prg_1_Dapper;

public class Solutions_Examples : IInfrastructureExercises
{

    public IEnumerable<Book> GetAllBooks()
    {
        var sql = @$"
    SELECT 
    book_id as {nameof(Book.BookId)}, 
    title as {nameof(Book.Title)}, 
    publisher as {nameof(Book.Publisher)}, 
    cover_img_url as {nameof(Book.CoverImgUrl)} 
    FROM library.books;";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Query<Book>(sql);
        }
    }
    
    public Book InsertAndReturnBook(string title, string publisher, string coverImgUrl)
    {
        var sql =
            $@"INSERT INTO library.books (title, publisher, cover_img_url) VALUES (@title, @publisher, @coverImgUrl) 
                                                            RETURNING     book_id as {nameof(Book.BookId)}, 
    title as {nameof(Book.Title)}, 
    publisher as {nameof(Book.Publisher)}, 
    cover_img_url as {nameof(Book.CoverImgUrl)};";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Book>(sql, new { title, publisher, coverImgUrl });
        }
    }

    public Book UpdateBookById(int bookIdToUpdate, string newTitle, string newPublisher, string newCoverImgUrl)
    {
        var sql = @$"
UPDATE library.books SET title = @newTitle, publisher = @newPublisher, cover_img_url = @newCoverImgUrl WHERE book_id = @bookIdToUpdate
RETURNING 
    book_id as {nameof(Book.BookId)}, 
    title as {nameof(Book.Title)}, 
    publisher as {nameof(Book.Publisher)}, 
    cover_img_url as {nameof(Book.CoverImgUrl)};
";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.QueryFirst<Book>(sql, new { bookIdToUpdate, newTitle, newPublisher, newCoverImgUrl });
        }
    }
    public bool DeleteBookById(int bookId)
    {
        var sql = $@"
DELETE FROM library.books WHERE book_id = @bookId;
";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Execute(sql, new { bookId }) == 1;
        }
    }

    public IEnumerable<BookWithAuthors> GetBooksWithAuthors()
    {
        var sql = $@"
SELECT books.book_id as {nameof(BookWithAuthors.BookId)}, 
       title as {nameof(BookWithAuthors.Title)}, 
       array_agg(library.authors.name) as {nameof(BookWithAuthors.Authors)}
FROM library.books 
    JOIN library.author_wrote_book_items as junction on books.book_id = junction.book_id
    JOIN library.authors on junction.author_id = authors.author_id
GROUP BY books.book_id, books.title;";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Query<BookWithAuthors>(sql);
        }
    }

}