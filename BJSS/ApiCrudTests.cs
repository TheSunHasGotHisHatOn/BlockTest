using System.Net;
using System.Threading.Tasks;
using BJSS.Api;
using NUnit.Framework;

namespace BJSS
{
    // todo: find better place (than bin) to stick geckodriver.exe

    /// <summary>
    /// CRUD tests have been put in more traditional Arrange-Act-Assert framework because they're
    /// much easier tests and testing them in this way is a lot easier and more maintainable. 
    ///  The whole BDD framework adds a lot of overhead which for simple tests is overkill.
    /// </summary>
    [TestFixture]
    public class ApiCrudTests
    {
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public async Task GetApiTest()
        {
            // arrange
            // with reqres we don't need to create a user in order to get one, but with an app/website we
            // were testing we would need to do this.

            //  act
            var userResponse = await Reqres.GetUserAsync(2);

            // assert
            Assert.That(userResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code was wrong.  Expected OK but was {0}", userResponse.StatusCode);
            Assert.That(userResponse.User.FirstName, Is.Not.Null, "FirstName was null");
            Assert.That(userResponse.User.FirstName, Is.Not.Empty, "UserName was empty");
            Assert.That(userResponse.User.Id, Is.GreaterThan(0), "Id was not set");
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public async Task CreateApiTest()
        {
            // arrange
            var user = new ReqresUserBuilder().HasNonEnglishUnicodeCharacter().Build();

            UserResponse createdUserResponse = null;

            try
            {
                // act
                createdUserResponse = await Reqres.CreateUserAsync(user);

                // assert
                Assert.That(createdUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code was wrong.  Expected OK but was {0}", createdUserResponse.StatusCode);
                Assert.That(createdUserResponse.User.FirstName, Is.EqualTo(user.FirstName), "createdUserResponse.first_name was wrong.");
                Assert.That(createdUserResponse.User.Id, Is.Not.EqualTo(user.Id), "createdUserResponse.id was not set.");
            }
            finally 
            {
                // clean up
                if (createdUserResponse != null)
                    await Reqres.DeleteUserAsync(createdUserResponse.User.Id);
            }
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public async Task UpdateApiTest()
        {
            //arrange
            var user = new ReqresUserBuilder().HasNonEnglishUnicodeCharacter().Build();

            UserResponse createdUserResponse = null;

            try
            {
                createdUserResponse = await Reqres.CreateUserAsync(user);
                Assert.That(createdUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code was wrong.  Expected Created but was {0}", createdUserResponse.StatusCode);

            // act
            user.LastName = user.LastName + "123";
            var updatedUserResponse = await Reqres.UpdateUserAsync(createdUserResponse.User.Id, user);

            // assert
            Assert.That(updatedUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code was wrong.  Expected OK but was {0}", updatedUserResponse.StatusCode);
            Assert.That(updatedUserResponse.User.LastName, Is.EqualTo(user.LastName), "last name was wrong");
            Assert.That(updatedUserResponse.User.FirstName, Is.EqualTo(user.FirstName), "first name was wrong");


            }
           finally
            {
                // clean up
                if (createdUserResponse != null)
                await Reqres.DeleteUserAsync(createdUserResponse.User.Id);
            }
            
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public async Task DeleteApiTest()
        {
            // arrange
            var user = new ReqresUserBuilder().HasNonEnglishUnicodeCharacter().Build();

            var createdUserResponse = await Reqres.CreateUserAsync(user);

            Assert.That(createdUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code was wrong.  Expected Created but was {0}", createdUserResponse.StatusCode);

            // act
            var deletedUserResponse = await Reqres.DeleteUserAsync(createdUserResponse.User.Id);

            // assert
            Assert.That(deletedUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Status code was wrong.  Expected 404 Not Found but was {0}", deletedUserResponse.StatusCode);

            var userResponse = await Reqres.GetUserAsync(createdUserResponse.User.Id);
            Assert.That(userResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Status code was wrong.  Expected 404 Not Found but was {0}", userResponse.StatusCode);
        }
    }
}
