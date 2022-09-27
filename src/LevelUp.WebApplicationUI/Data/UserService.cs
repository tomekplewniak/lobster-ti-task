using System.Net.Http.Json;
using LevelUp.Domain.DtoModels.User;

namespace LevelUp.WebApplicationUI.Data;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsers()
    {
        var result =  await _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>("users");
        return result;
    }

    public async Task<UserDto> GetUserById(long id)
    {
        //var request = new HttpRequestMessage(HttpMethod.Get,
        //                $"user{id}");

        //var client = _httpClientFactory.CreateClient("feedbackApi");

        //var response = await client.SendAsync(request);

        //if (response.IsSuccessStatusCode)
        //{
        //    using var responseStream = await response.Content.ReadAsStreamAsync();
        //    {
        //        var options = new JsonSerializerOptions()
        //        {
        //            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //        };

        //        var user = await JsonSerializer.DeserializeAsync<UserDto>(responseStream, options);

        //        if (user is null)
        //        {
        //            throw new Exception("Problem with getting user by id.");
        //        }

        //        return user;
        //    }
        //}
        //else
        //{
        //    throw new Exception("Problem with getting user by id.");
        //}

        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserDto>> GetUserByNameSearch(string nameToSearch)
    {
        //var request = new HttpRequestMessage(HttpMethod.Post,
        //                $"users/search");

        //request.Content = JsonContent.Create(nameToSearch);

        //var client = _httpClientFactory.CreateClient("feedbackApi");

        //var response = await client.SendAsync(request);

        //if (response.IsSuccessStatusCode)
        //{
        //    using var responseStream = await response.Content.ReadAsStreamAsync();
        //    {
        //        var options = new JsonSerializerOptions()
        //        {
        //            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //        };

        //        var users = await JsonSerializer.DeserializeAsync<IEnumerable<UserDto>>(responseStream, options);

        //        if (users is null)
        //        {
        //            throw new Exception("Problem with searching of the ousers.}");
        //        }

        //        return users;
        //    }
        //}
        //else
        //{
        //    throw new Exception("Problem with searching of the of users.}");
        //}
        throw new NotImplementedException();
    }
}
