﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BJSS.TestObjects;
using Newtonsoft.Json;

namespace BJSS.Api
{
    public class Reqres
    {
        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://reqres.in/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static async Task<ReqresResponse> GetUserAsync(int id)
        {
            var client = GetClient();
            var path = string.Format(AppSettings.GetUserPathTemplate, id);

            HttpResponseMessage response = await client.GetAsync(path);
            var json = await response.Content.ReadAsStringAsync();
            ReqresResponse userResponse;

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    userResponse = JsonConvert.DeserializeObject<ReqresResponse>(json);
                }
                catch (Exception)
                {
                    userResponse = new ReqresResponse();
                }
            }
            else
            {
                userResponse = new ReqresResponse();
            }
            
            userResponse.RawResponse = json;
            userResponse.StatusCode = response.StatusCode;

            return userResponse;
        }

        public static async Task<ReqresResponse> CreateUserAsync(User user)
        {
            var client = GetClient();

            var response = await client.PostAsync(AppSettings.CreateUserPathTemplate, user.AsStringContent());
            var json = await response.Content.ReadAsStringAsync();
            User createdUser = null;

            if (response.IsSuccessStatusCode)
            {
                createdUser = JsonConvert.DeserializeObject<User>(json);
            }

            return new ReqresResponse
            {
                User = createdUser,
                StatusCode = response.StatusCode,
                RawResponse = json
            };
        }

        public static async Task<ReqresResponse> UpdateUserAsync(int id, User user)
        {
            var client = GetClient();
            var path = string.Format(AppSettings.UpdateUserPathTemplate, id);
            var response = await client.PutAsync(path, user.AsStringContent());
            var json = await response.Content.ReadAsStringAsync();

            User updatedUser = null;

            if (response.IsSuccessStatusCode)
            {
                updatedUser = JsonConvert.DeserializeObject<User>(json);
            }

            return new ReqresResponse
            {
                User = updatedUser,
                StatusCode = response.StatusCode,
                RawResponse = json
            };
        }

        public static async Task<ReqresResponse> DeleteUserAsync(int id)
        {
            var client = GetClient();
            var path = string.Format(AppSettings.DeleteUserPathTemplate, id);
            var response = await client.DeleteAsync(path);

            return new ReqresResponse
            {
                StatusCode = response.StatusCode,
                RawResponse = await response.Content.ReadAsStringAsync()
            };
        }
    }
}
