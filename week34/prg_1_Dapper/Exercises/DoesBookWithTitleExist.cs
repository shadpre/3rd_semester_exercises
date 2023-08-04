using Bogus;
using Dapper;
using FluentAssertions;
using FluentAssertions.Execution;
using gettingstarted.week34.prg_1_Dapper;
using NUnit.Framework;

public class DoesBookWithTileExistExercise
{
    public bool DoesBookWithTitleExist(string title)
    {
        var sql = @$"
SELECT COUNT(*) FROM library.books WHERE title = @title;
";
        using (var conn = Helper.DataSource.OpenConnection())
        {
            return conn.ExecuteScalar<int>(sql, new
            {
                title
            }) == 1;
        }
    }


    [Test]
    public void DoesBookWithTitleExistTest()
    {
        Helper.TriggerRebuild();
        var book = Helper.MakeRandomBookWithId(1);
        var actualEmpty = DoesBookWithTitleExist(book.Title);
        var insertionSql =
            "INSERT INTO library.books (title, publisher, cover_img_url) VALUES (@title, @publisher, @coverImgUrl);";
        using (var conn = Helper.DataSource.OpenConnection())
        {
             conn.Execute(insertionSql, book);
        }

        var actualExisting = DoesBookWithTitleExist(book.Title);
        using (new AssertionScope())
        {
            actualEmpty.Should().BeFalse();
            actualExisting.Should().BeTrue();
        }
    }
}