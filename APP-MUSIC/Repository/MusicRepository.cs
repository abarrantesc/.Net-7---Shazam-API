using System;
using System.Dynamic;
using System.Text;
using System.Text.Json;
using API_MUSIC.Interface;
using APP_MUSIC.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace API_MUSIC.Repository
{
	public class MusicRepository : IMusic
	{

        public readonly string baseUrl = "https://shazam.p.rapidapi.com";



        private static IConfigurationSection GetSettingsRapidApi(string section)
        {

            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var appSetting = root.GetSection(section);


            return appSetting;
        }


        public async Task<ExpandoObject> GetSongsDetailsAsync(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            var appSetting = GetSettingsRapidApi("RapidAPI");
            var _KeyShazam = appSetting["X-RapidAPI-Key"];
            var _Hosthazam = appSetting["X-RapidAPI-Host"];

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/songs/get-details?key={Id}&locale=en-US"),
                Headers =
                 {   
                    { "X-RapidAPI-Key", $"{_KeyShazam}"},
                    { "X-RapidAPI-Host", $"{_Hosthazam}"},
                },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonConvert.DeserializeObject<SongsDetails>(body);
            var artistId = "";

            foreach (var item in data!.artists)
            {
                artistId = item.adamid;
            }

            mymodel.SongDetail = data;


            var dataTop = await GetTopSongArtistAsync(Convert.ToInt32(artistId));
            mymodel.SongsTop = dataTop;


            return mymodel! ;
        }   

        public async Task<SongModel> SearchSongAsync(string searchWords)
        {
            var appSetting = GetSettingsRapidApi("RapidAPI");
            var _KeyShazam = appSetting["X-RapidAPI-Key"];
            var _Hosthazam = appSetting["X-RapidAPI-Host"];

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {

                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/search?term={searchWords}&locale=en-US&offset=0&limit=100"),
                Headers =
                 {
                    { "X-RapidAPI-Key", $"{_KeyShazam}"},
                    { "X-RapidAPI-Host", $"{_Hosthazam}"},
                },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };


            var data = JsonConvert.DeserializeObject<SongModel>(body)!;

            return data!;
        }

        public async Task<TopSongs> GetTopSongArtistAsync(int Id)
        {
            Console.WriteLine($"{baseUrl}/artists/get-top-songs?id={Id}&l=en-US");

            var appSetting = GetSettingsRapidApi("RapidAPI");
            var _KeyShazam = appSetting["X-RapidAPI-Key"];
            var _Hosthazam = appSetting["X-RapidAPI-Host"];

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/artists/get-top-songs?id={Id}&l=en-US"),
                Headers =
                 {
                    { "X-RapidAPI-Key", $"{_KeyShazam}"},
                    { "X-RapidAPI-Host", $"{_Hosthazam}"},
                },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonConvert.DeserializeObject<TopSongs>(body);

            return data!;
        }


    }
}

