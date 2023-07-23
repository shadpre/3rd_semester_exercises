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
/// When you have your method implementation, run the test
/// (either click the green start button next to the tests at the bottom of the file)
/// or use the dotnet test command.
///
/// Remember to add environment variable to the test running config
/// Settings -> Build, execution, deployment
/// -> Unit testing -> Test runner,
/// scroll down to environment variables, add pgconn with you connection string value.
/// </summary>
public class InfrastructureExercises : IInfrastructureExercises
{
    //The data source can be accessed: Helper.Datasource (public + static)
    //Postgres running from docker compose file (if you have docker installed), you can use Helper.PostgresDockerDataSource

    public IEnumerable<Book> GetAllBooks()
    {
        throw new NotImplementedException();
    }
    [Test]
    public void GetAllBooksTest()
    {
        //ARRANGE
        Helper.TriggerRebuild();
        var expected = new List<Book>();
        for (var i = 1; i < 10; i++)
        {
            var book = Helper.MakeRandomBookWithId(i);
            expected.Add(book);
            //Note if you're reading this: There is a more performant way of making "bulk" inserts rather than loops,
            //but since this is simply 10 inserts, it's "good enough"
            var sql = $@" 
            insert into library.books (title, publisher, cover_img_url) VALUES (@title, @publisher, @coverImgUrl);
            ";
            using (var conn = Helper.PostgresDockerDataSource.OpenConnection())
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
        throw new NotImplementedException();
    }

    public Book UpdateBookById(int bookIdToUpdate, string newTitle, string newPublisher, string newCoverImgUrl)
    {
        throw new NotImplementedException();
    }

    public bool DeleteBookById(int bookId)
    {
        throw new NotImplementedException();
    }

    //This one is harder, so only proceed if you're ready for a more challenging exercise
    public IEnumerable<BookWithAuthors> GetBooksWithAuthors()
    {
        throw new NotImplementedException();
    }
    
    //Tomas, if you're reading this, I just want to know your opinion on the first 4 exercises.
    //If this "implement the method so the test passes" format feels nice, I'll make a bunch more
    //This could be exericses like the following:
    //Select all books on reading list for user with ID X
    //Get top 5 books by most added to reading list
    //etc.





    [Test]
    public void InsertAndReturnBookTest()
    {
        Helper.TriggerRebuild();
        var book = Helper.MakeRandomBookWithId(1);
        //ACT
        var actual = InsertAndReturnBook(book.Title, book.Publisher, book.CoverImgUrl);

        //ASSERT
        actual.Should().BeEquivalentTo(book, Helper.MyBecause(actual, book));
    }


    [Test]
    public void TestUpdateBookById()
    {
        //ARRANGE
        Helper.TriggerRebuild();
        var book = Helper.MakeRandomBookWithId(1);
        var sql =
            "insert into library.books (title, publisher, cover_img_url) VALUES (@title, @publisher, @coverImgUrl);";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            conn.Execute(sql, book);
        }

        book.Title = "NEW TITLE";
        var expected = book;

        //ACT
        var actual = UpdateBookById(book.BookId, "NEW TITLE", book.Publisher, book.CoverImgUrl);

        //ASSERT
        actual.Should().BeEquivalentTo(expected, Helper.MyBecause(actual, book));
    }

    [Test]
    public void TestDeleteBookByIdReturnFalseIfNoBookWasDeleted()
    {
        //Act
        var actual = DeleteBookById(12345);

        //Assert
        actual.Should().Be(false);
    }

    [Test]
    public void TestDeleteBookById()
    {
        //ARRANGE
        Helper.TriggerRebuild();
        var book = Helper.MakeRandomBookWithId(1);
        var sql =
            "insert into library.books (title, publisher, cover_img_url) VALUES (@title, @publisher, @coverImgUrl);";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            conn.Execute(sql, book);
        }

        //Act
        var actual = DeleteBookById(book.BookId);

        //Assert
        using (var conn = Helper.DataSource.OpenConnection())
        {
            var doesNotExist = conn.ExecuteScalar<int>("SELECT COUNT(*) FROM library.books WHERE book_id = @bookId;",
                new { bookId = book.BookId }) == 0;
            (doesNotExist && actual).Should().Be(true);
        }
    }
    

    [Test]
    public void TestGetBooksWithAuthors()
    {
        //ARRANGE
        Helper.TriggerRebuild();
        var book = Helper.MakeRandomBookWithId(1);
        var author = Helper.MakeRandomAuthorWithId(1);
        var author2 = Helper.MakeRandomAuthorWithId(2);

        var bookInsertSql =
            "insert into library.books (book_id, title, publisher, cover_img_url) VALUES (@bookId, @title, @publisher, @coverImgUrl); ";
        var authorInsertSql =
            "insert into library.authors (author_id, name, birthday, nationality) VALUES (@authorId, @name, date('2020-10-10'), @nationality); ";

        var insertions = new List<Tuple<string, object>>()
        {
            new(bookInsertSql, book), 
            new(authorInsertSql,author),
            new(authorInsertSql, author2)
        };

        foreach (var tuple in insertions)
        {
            using (var conn = Helper.DataSource.OpenConnection())
            {
                conn.Execute(tuple.Item1, tuple.Item2);
            }
        }
        
        //Insert junctions
        using (var conn = Helper.DataSource.OpenConnection())
        {
            conn.Execute(
                "INSERT INTO library.author_wrote_book_items VALUES (1,1); INSERT INTO library.author_wrote_book_items VALUES (1,2);");
        }

        var expected = new List<BookWithAuthors>()
        {
            new()
            {
                Title = book.Title,
                BookId = book.BookId,
                Authors = new[] { author.Name, author2.Name }
            }
        };
        
        
        //ACT
        var actual = GetBooksWithAuthors();

        //ASSERT
        actual.Should().BeEquivalentTo(expected, Helper.MyBecause(actual, expected));

    }

}

public interface IInfrastructureExercises
{
    /// <summary>
    /// The test seeds some objects of generic type Book (see classes in the bottom of file).
    /// Return these using the datasource from the Helper class.
    /// </summary>
    /// <returns></returns>
    IEnumerable<Book> GetAllBooks();
    /// <summary>
    /// Insert and return the inserted book with the listed properties.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="publisher"></param>
    /// <param name="coverImgUrl"></param>
    /// <returns></returns>
    Book InsertAndReturnBook(string title, string publisher, string coverImgUrl);
    
    /// <summary>
    /// The test seeds a book with the given ID, now you must update a property
    /// </summary>
    /// <param name="bookIdToUpdate"></param>
    /// <param name="newTitle"></param>
    /// <param name="newPublisher"></param>
    /// <param name="newCoverImgUrl"></param>
    /// <returns></returns>
    Book UpdateBookById(int bookIdToUpdate, string newTitle, string newPublisher, string newCoverImgUrl);
    
    /// <summary>
    /// Delete a book by ID and return true if deleted
    /// </summary>
    /// <param name="bookId"></param>
    /// <returns></returns>
    bool DeleteBookById(int bookId);
    
    /// <summary>
    /// This one is hard:
    /// you must make a 3 table join in order to find a list of books with author names who wrote it
    /// </summary>
    /// <returns></returns>
    IEnumerable<BookWithAuthors> GetBooksWithAuthors();
}

public class Book
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public string? Publisher { get; set; }
    public string? CoverImgUrl { get; set; }
}

public class BookWithAuthors
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public IEnumerable<string> Authors { get; set; }
}


public class Author
{
    public string Name { get; set; }
    public string Nationality { get; set; }
    public int AuthorId { get; set; }
    public DateTime Bithday { get; set; }
}