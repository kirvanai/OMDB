using RestSharp;

namespace OMDB.Models
{
    public class MovieDAL
    {   
        public static Movie GetMovie(string title)
        {
            string url = $@"https://www.omdbapi.com/?t={title}&apikey=ea12151f";
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest();
            Movie m = client.Get<Movie>(request);

            return m;
        }

    }
}
