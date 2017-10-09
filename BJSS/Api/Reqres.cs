using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BJSS.Api
{
    public class Reqres
    {
        private const string GET_USER_PATH_TEMPLATE = "users/{0}";

        // for some reason the create method used doesn't have the api from the base url
        private const string CREATE_USER_PATH_TEMPLATE = "/api/users";

        private const string UPDATE_USER_PATH_TEMPLATE = "/api/users/{0}";

        private const string DELETE_USER_PATH_TEMPLATE = "/users/{0}";

        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://reqres.in/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
            
        }

        public static async Task<GetUserResponse> GetUserAsync(int id)
        {
            var client = GetClient();
            var path = string.Format(GET_USER_PATH_TEMPLATE, id);

            HttpResponseMessage response = await client.GetAsync(path);

            GetUserResponse userResponse;

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                userResponse = JsonConvert.DeserializeObject<GetUserResponse>(json);
            }
            else
            {
                userResponse = new GetUserResponse();
            }

            userResponse.StatusCode = response.StatusCode;

            return userResponse;
        }

        public static async Task<UserResponse> CreateUserAsync(User user)
        {
            var client = GetClient();

            var response = await client.PostAsync(CREATE_USER_PATH_TEMPLATE, user.AsStringContent());
            User createdUser = null;

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                createdUser = JsonConvert.DeserializeObject<User>(json);
            }

            return new UserResponse
            {
                User = createdUser,
                StatusCode = response.StatusCode
            };
        }

        public static async Task<UserResponse> UpdateUserAsync(int id, User user)
        {
            var client = GetClient();
            var path = string.Format(UPDATE_USER_PATH_TEMPLATE, id);
            var response = await client.PutAsync(path, user.AsStringContent());

            User updatedUser = null;

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                updatedUser = JsonConvert.DeserializeObject<User>(json);
            }

            return new UserResponse
            {
                User = user,
                StatusCode = response.StatusCode
            };
        }

        public static async Task<UserResponse> DeleteUserAsync(int id)
        {
            var client = GetClient();
            var path = string.Format(DELETE_USER_PATH_TEMPLATE, id);
            var response = await client.DeleteAsync(path);

            return new UserResponse
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
