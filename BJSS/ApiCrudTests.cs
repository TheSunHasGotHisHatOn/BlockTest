using System.Net;
using System.Threading.Tasks;
using BJSS.Api;
using NUnit.Framework;

namespace BJSS
{
    // todo: check that nuget can be used by bjss peeps
    // todo: find better place (than bin) to stick geckodriver.exe
    [TestFixture]
    public class ApiCrudTests
    {
        //[TestCase(Firefox)]
        //[TestCase(IE)]


        [Test]
        public async Task GetApiTest()
        {
            // arrange
            // with reqres we don't need to create a user in order to get one, but with an app/website we
            // were testing we would need to do this.

            //  act
            var userResponse = await Reqres.GetUserAsync(2);

            // assert
            Assert.That(userResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code was wrong.  Expected OK but was {0}", userResponse.StatusCode);
        }

        [Test]
        public async Task CreateApiTest()
        {
            // arrange
            var user = new User
            {
                avatar = "myAvatar",
                first_name = "Lula",
                last_name = "Paloosa"
            };

            // act
            var createdUserResponse = await Reqres.CreateUserAsync(user);

            // assert
            Assert.That(createdUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code was wrong.  Expected OK but was {0}", createdUserResponse.StatusCode);
            Assert.That(createdUserResponse.User.first_name, Is.EqualTo(user.first_name), "createdUserResponse.first_name was wrong.");
            Assert.That(createdUserResponse.User.id, Is.Not.EqualTo(user.id), "createdUserResponse.id was not set.");

            // clean up
            await Reqres.DeleteUserAsync(createdUserResponse.User.id);
        }

        [Test]
        public async Task UpdateApiTest()
        {
            //arrange
            var user = new User
            {
                avatar = "myAvatar",
                first_name = "Lula",
                last_name = "Paloosa"
            };

            var createdUserResponse = await Reqres.CreateUserAsync(user);

            Assert.That(createdUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code was wrong.  Expected Created but was {0}", createdUserResponse.StatusCode);

            // act
            user.last_name = "Paloosa-Bricklebrack";
            var updatedUserResponse = await Reqres.UpdateUserAsync(createdUserResponse.User.id, user);

            // assert
            Assert.That(updatedUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code was wrong.  Expected OK but was {0}", updatedUserResponse.StatusCode);
            Assert.That(updatedUserResponse.User.last_name, Is.EqualTo(user.last_name), "last name was wrong");
            Assert.That(updatedUserResponse.User.first_name, Is.EqualTo(user.first_name), "first name was wrong");

            // clean up
           await Reqres.DeleteUserAsync(updatedUserResponse.User.id);
        }

        [Test]
        public async Task DeleteApiTest()
        {
            // arrange
            var user = new User
            {
                avatar = "myAvatar",
                first_name = "Lula",
                last_name = "Paloosa"
            };

            var createdUserResponse = await Reqres.CreateUserAsync(user);

            Assert.That(createdUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Status code was wrong.  Expected Created but was {0}", createdUserResponse.StatusCode);

            // act
            var deletedUserResponse = await Reqres.DeleteUserAsync(createdUserResponse.User.id);

            // assert
            Assert.That(deletedUserResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Status code was wrong.  Expected 404 Not Found but was {0}", deletedUserResponse.StatusCode);

            var userResponse = await Reqres.GetUserAsync(createdUserResponse.User.id);
            Assert.That(userResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Status code was wrong.  Expected 404 Not Found but was {0}", userResponse.StatusCode);
        }
    }
}
