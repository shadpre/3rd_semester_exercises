
using Dapper;
using FluentAssertions;
using gettingstarted.week34.prg_1_Dapper;
using NUnit.Framework;

public class DeleteBookByIdExercise
{
    public bool DeleteBookById(int bookId)
    {
        throw new NotImplementedException();
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


}
