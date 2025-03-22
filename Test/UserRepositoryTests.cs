using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DZ_4;


[TestFixture]
public class UserRepositoryTests
{
    private AppDbContext? context1;
    private UserRepository? repository1;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        context1 = new AppDbContext(options);
        repository1 = new UserRepository(context1); 
    }

    [Test]
    public void GetAllUsers_ShouldReturnUsers()
    {
        var user1 = new User { Username = "Alice", Password = "1234" };
        var user2 = new User { Username = "Bob", Password = "qwerty" };
        context1?.Users.AddRange(user1, user2);
        context1?.SaveChanges();

        var result = repository1?.GetAllUsers();

        Assert.That(result?.Count, Is.EqualTo(2));
        Assert.That(result?.Any(u => u.Username == "Alice"), Is.True);
        Assert.That(result?.Any(u => u.Username == "Bob"), Is.True);
    }

    [TearDown]
    public void TearDown()
    {
        context1?.Database.EnsureDeleted();
    }
}
