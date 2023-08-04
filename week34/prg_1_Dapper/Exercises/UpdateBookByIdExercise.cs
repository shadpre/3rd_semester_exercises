using Dapper;
using FluentAssertions;
using gettingstarted.week34.prg_1_Dapper;
using NUnit.Framework;

public class UpdateBookByIdExercise
{
    
    public Book UpdateBookById(int bookIdToUpdate, string newTitle, string newPublisher, string newCoverImgUrl)
    {
        throw new NotImplementedException();
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
}