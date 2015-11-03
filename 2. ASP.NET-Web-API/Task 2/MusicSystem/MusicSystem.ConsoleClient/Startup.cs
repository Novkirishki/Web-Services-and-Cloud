namespace MusicSystem.ConsoleClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;

    using Data;
    using Newtonsoft.Json.Linq;
    using System.Linq;

    public class Startup
    {
        private static readonly MusicSystemEntities Data = new MusicSystemEntities();

        internal static void Main()
        {
            var connection = new Uri("http://localhost:23463/");

            PrintXmlAlbums(connection, "api/Albums");
            PrintJsonSongs(connection, "api/Songs");
            PostSong(connection, "api/Songs");
            PutArtist(connection, "api/Artists/");
            DeleteArtist(connection, "api/Artists/", 2);

            Console.ReadLine();
        }

        private static async void PrintXmlAlbums(Uri connection, string requestPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var response = await httpClient.GetAsync(requestPath);
                Console.WriteLine(Environment.NewLine + "Albums: " + await response.Content.ReadAsStringAsync());
            }
        }

        private static async void PrintJsonSongs(Uri connection, string requestPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var response = await httpClient.GetAsync(requestPath);
                Console.WriteLine(Environment.NewLine + "Songs: " + await response.Content.ReadAsStringAsync());
            }
        }

        private static async void PostSong(Uri connection, string requestPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var json = JObject.Parse("{\"Title\": \"Some song 2\", \"Year\": 2014}");

                var response = await httpClient.PostAsync(
                    requestPath,
                    new StringContent(
                        json.ToString(),
                        Encoding.UTF8,
                        "application/json"));

                Console.WriteLine(Environment.NewLine + "Added Song: " + await response.Content.ReadAsStringAsync());
            }
        }

        private static async void PutArtist(Uri connection, string requestPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var json = JObject.Parse("{\"Name\": \"Krisko\", \"Age\": 29}");

                var response = await httpClient.PutAsync(
                    requestPath,
                    new StringContent(
                        json.ToString(),
                        Encoding.UTF8,
                        "application/json"));

                Console.WriteLine(Environment.NewLine + "Modified artist: " + await response.Content.ReadAsStringAsync());
            }
        }

        private static async void DeleteArtist(Uri connection, string requestPath, int id)
        {
            if (Data.Artists.Where(a => a.Id == id) == null)
            {
                Console.WriteLine("No such artist was found.");
                return;
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var response = await httpClient.DeleteAsync(requestPath + id);

                Console.WriteLine(Environment.NewLine + "Deleted artist: " + await response.Content.ReadAsStringAsync());
            }
        }
    }
}