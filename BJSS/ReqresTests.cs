using System;
using System.Net;
using System.Threading.Tasks;
using BJSS.ReqresApi;
using NUnit.Framework;

namespace BJSS
{
    /// <summary>
    /// CRUD tests have been put in more traditional Arrange-Act-Assert framework because they're
    /// much easier tests and testing them in this way is a lot easier and more maintainable.
    /// The whole BDD framework adds a lot of overhead which for simple tests is overkill.
    /// If these were to be related to the website and were needed in the website tests (for example, logging
    /// on to the website using the api) then the objects could be incorporated into the bdd tests.
    /// </summary>
    [TestFixture]
    public class ReqresTests
    {
        [Test]
        public async Task GetUserTest()
        {
            ReqresResponse userResponse = null;
            try
            {
                // arrange
                // with reqres we don't need to create a user in order to get one, but with an app/website we
                // were testing we would need to do this.
                var reqres = new ReqresPage();

                //  act
                userResponse = await reqres.GetUserAsync(2);

                // assert
                Assert.That(userResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code was wrong.  Expected OK but was {0}", userResponse.StatusCode);
                Assert.That(userResponse.User.FirstName, Is.Not.Null, "FirstName was null");
                Assert.That(userResponse.User.FirstName, Is.Not.Empty, "UserName was empty");
                Assert.That(userResponse.User.Id, Is.GreaterThan(0), "Id was not set");
            }
            catch (Exception)
            {
                userResponse?.LogTrace();
                throw;
            }
        }

        [Test]
        public async Task CreateUserTest()
        {
            // arrange
            var user = new UserBuilder().HasNonEnglishUnicodeCharacter().Build();
            var reqres = new ReqresPage();
            ReqresResponse createdUserResponse = null;

            try
            {
                // act
                createdUserResponse = await reqres.CreateUserAsync(user);

                // assert
                Assert.That(createdUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created),
                    "Status code was wrong.  Expected OK but was {0}", createdUserResponse.StatusCode);
                Assert.That(createdUserResponse.User.FirstName, Is.EqualTo(user.FirstName),
                    "createdUserResponse.first_name was wrong.");
                Assert.That(createdUserResponse.User.Id, Is.Not.EqualTo(user.Id), "createdUserResponse.id was not set.");
            }
            catch (Exception)
            {
                createdUserResponse?.LogTrace();
                throw;
            }
            finally 
            {
                // clean up
                if (createdUserResponse != null)
                    await reqres.DeleteUserAsync(createdUserResponse.User.Id);
            }
        }

        [Test]
        public async Task UpdateUserTest()
        {
            //arrange
            var user = new UserBuilder().HasNonEnglishUnicodeCharacter().Build();
            var reqres = new ReqresPage();
            ReqresResponse createdUserResponse = null;
            ReqresResponse updatedUserResponse = null;

            try
            {
                createdUserResponse = await reqres.CreateUserAsync(user);
                Assert.That(createdUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code was wrong.  Expected Created but was {0}", createdUserResponse.StatusCode);

                // act
                user.LastName = user.LastName + "123";
                updatedUserResponse = await reqres.UpdateUserAsync(createdUserResponse.User.Id, user);

                // assert
                Assert.That(updatedUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code was wrong.  Expected OK but was {0}", updatedUserResponse.StatusCode);
                Assert.That(updatedUserResponse.User.LastName, Is.EqualTo(user.LastName), "last name was wrong");
                Assert.That(updatedUserResponse.User.FirstName, Is.EqualTo(user.FirstName), "first name was wrong");
            }
            catch (Exception)
            {
                createdUserResponse?.LogTrace();
                updatedUserResponse?.LogTrace();
                throw;
            }
            finally
            {
                // clean up
                if (createdUserResponse != null)
                await reqres.DeleteUserAsync(createdUserResponse.User.Id);
            }
        }

        [Test]
        public async Task DeleteUserTest()
        {
            // arrange
            var user = new UserBuilder().HasNonEnglishUnicodeCharacter().Build();
            var reqres = new ReqresPage();
            ReqresResponse createdUserResponse = null;
            ReqresResponse deletedUserResponse = null;
            ReqresResponse userResponse = null;

            try
            {
                createdUserResponse = await reqres.CreateUserAsync(user);

                Assert.That(createdUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code was wrong.  Expected Created but was {0}", createdUserResponse.StatusCode);

                // act
                deletedUserResponse = await reqres.DeleteUserAsync(createdUserResponse.User.Id);

                // assert
                Assert.That(deletedUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Status code was wrong.  Expected 404 Not Found but was {0}", deletedUserResponse.StatusCode);

                userResponse = await reqres.GetUserAsync(createdUserResponse.User.Id);
                Assert.That(userResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Status code was wrong.  Expected 404 Not Found but was {0}", userResponse.StatusCode);
            }
            catch (Exception)
            {
                createdUserResponse?.LogTrace();
                deletedUserResponse?.LogTrace();
                userResponse?.LogTrace();
                throw;
            }
        }

        [Test]
        public async Task FailingGetUserTest()
        {
            ReqresResponse userResponse = null;
            try
            {
                // arrange
                // with reqres we don't need to create a user in order to get one, but with an app/website we
                // were testing we would need to do this.
                var reqres = new ReqresPage();

                //  act
                userResponse = await reqres.GetUserAsync(2);

                // assert
                Assert.That(userResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code was wrong.  Expected OK but was {0}", userResponse.StatusCode);
                Assert.That(userResponse.User.FirstName, Is.Not.Null, "FirstName was null");
                Assert.That(userResponse.User.FirstName, Is.Not.Empty, "UserName was empty");
                Assert.That(userResponse.User.Id, Is.GreaterThan(0), "Id was not set");
                Assert.Fail();
            }
            catch (Exception)
            {
                userResponse?.LogTrace();
                throw;
            }
        }
    }
}
