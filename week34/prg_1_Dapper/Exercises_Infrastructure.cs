using Bogus;
using Dapper;
using FluentAssertions;
using gettingstarted.week34.prg_1_Dapper;
using NUnit.Framework;

/// <summary>
/// Description: Please read beforehand.
/// I supplied a database schema as a SQL script
/// + some classes which correspond with query models.
/// Each test rebuilds and seeds the database, so you just have
/// to think about implementing repository methods.
///
/// Remember to add environment variable to the test running config
/// </summary>
public class InfrastructureExercises
{
    //The data source can be accessed: Helper.Datasource (public + static)

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

    [Test]
    public void GetAllBooksTest()
    {
        //ARRANGE
        Helper.TriggerRebuild();
        var expected = new List<Book>();
        for (var i = 1; i < 10; i++)
        {
            var book = new Faker<Book>()
                .RuleFor(b => b.BookId, i)
                .RuleFor(b => b.Publisher, p => p.Company.CompanyName())
                .RuleFor(b => b.Title, t => t.Lorem.Sentence())
                .RuleFor(b => b.CoverImgUrl, "https://picsum.photos/200/300")
                .Generate();
            expected.Add(book);
            var sql = $@" 
            insert into library.books (title, publisher, cover_img_url) VALUES (@title, @publisher, @coverImgUrl);
            ";
            using (var conn = Helper.DataSource.OpenConnection())
            {
                conn.Execute(sql, book);
            }
        }

        //ACT
        var actual = GetAllBooks();

        // Assert
        actual.Should().BeEquivalentTo(expected, Helper.MyBecause(actual, expected));
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


    [Test]
    public void InsertAndReturnBookTest()
    {
        Helper.TriggerRebuild();
        var book = new Faker<Book>()
            .RuleFor(b => b.BookId, 1)
            .RuleFor(b => b.Publisher, p => p.Company.CompanyName())
            .RuleFor(b => b.Title, t => t.Lorem.Sentence())
            .RuleFor(b => b.CoverImgUrl, "https://picsum.photos/200/300")
            .Generate();
        //ACT
        var actual = InsertAndReturnBook(book.Title, book.Publisher, book.CoverImgUrl);

        //ASSERT
        actual.Should().BeEquivalentTo(book, Helper.MyBecause(actual, book));
    }
    
    //Update book
    
    //Delete book
    
    //Join book with author names
    
    //Select all books on reading list for user with ID 1
    
    //Get top 5 books by most added to reading list
    
    //
}

public class Book
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public string? Publisher { get; set; }
    public string? CoverImgUrl { get; set; }
}