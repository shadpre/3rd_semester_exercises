using Dapper;
using FluentAssertions;
using NUnit.Framework;

namespace gettingstarted.week34.prg_1_Dapper.Exercises;

[TestFixture]
public class GetAllBooksExercise
{
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
            using (var conn = Helper.DataSource.OpenConnection())
            {
                conn.Execute(sql, book);
            }
        }

        //ACT
        var actual = GetAllBooksSolution();

        // Assert
        actual.Should().BeEquivalentTo(expected, Helper.MyBecause(actual, expected));
    }

    public IEnumerable<Book> GetAllBooksSolution()
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
}