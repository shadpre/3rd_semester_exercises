using Dapper;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace gettingstarted.week34.prg_1_Dapper.Exercises;

public class GetAllBooksByIdOrderAndPaginateExercise
{
    public IEnumerable<Book> GetAllBooksOrderByAndPaginate(string orderBy, int pageSize, int startAt)
    {
        var sql = $@"
select
    book_id as {nameof(Book.BookId)}, 
    title as {nameof(Book.Title)}, 
    publisher as {nameof(Book.Publisher)}, 
    cover_img_url as {nameof(Book.CoverImgUrl)} 
from library.books
order by {orderBy} ASC
offset @startAt
limit @pageSize;
";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.Query<Book>(sql, new { pageSize, startAt });
        }
    }

    [Test]
    public void TestGetAllBooksOrderByAndPaginate()
    {
        Helper.TriggerRebuild();
        var insertBookSql =
            "INSERT INTO library.books (book_id, title, publisher, cover_img_url) VALUES (@bookId, @title, @publisher, @coverImgUrl);";
        var books = new List<Book>();
        using (var conn = Helper.DataSource.OpenConnection())
        {
            for (var i = 1; i < 10; i++)
            {
                var book = Helper.MakeRandomBookWithId(i);
                books.Add(book);
                conn.Execute(insertBookSql, book);
            }
        }

        var booksByTitle = books.OrderBy(b => b.Title).ToList();
        var expectedTitle = new List<Book>() { booksByTitle[2], booksByTitle[3] };
        var actualTitle = GetAllBooksOrderByAndPaginate("books.title", 2, 2);


        var booksByPublisher = books.OrderBy(b => b.Publisher).ToList();
        var expectedPublisher = new List<Book>() { booksByPublisher[2], booksByPublisher[3] };
        var actualPublisher = GetAllBooksOrderByAndPaginate("books.publisher", 2, 2);


        using (new AssertionScope())
        {
            actualTitle.Should().BeEquivalentTo(expectedTitle);
            actualPublisher.Should().BeEquivalentTo(expectedPublisher);
        }
    }
}