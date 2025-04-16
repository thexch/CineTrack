using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TMDbLib.Client;

namespace CineTrack.MVVM.View
{
    public partial class SearchView : UserControl
    {
        private readonly TMDbClient _client;

        public SearchView()
        {
            InitializeComponent();

            // Lire la clé API depuis le fichier de configuration
            string json = File.ReadAllText("appsettings.json");
            JObject config = JObject.Parse(json);
            string apiKey = config["TMDbApiKey"].ToString();

            // Initialiser le client TMDb avec la clé API
            _client = new TMDbClient(apiKey)
            {
                DefaultLanguage = "fr-FR"
            };

            SearchBox.Text = "Rechercher un film ou une série...";
            SearchBox.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "Rechercher un film ou une série...")
            {
                SearchBox.Text = string.Empty;
                SearchBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                SearchBox.Text = "Rechercher un film ou une série...";
                SearchBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchBox.Text;

            if (string.IsNullOrWhiteSpace(query) || query == "Rechercher un film ou une série...")
            {
                MessageBox.Show("Veuillez entrer un terme de recherche.");
                return;
            }

            var results = await SearchMoviesAndTvShows(query);
            ResultsList.ItemsSource = results;
        }

        private async Task<ObservableCollection<SearchResult>> SearchMoviesAndTvShows(string query)
        {
            var results = new ObservableCollection<SearchResult>();
            string loweredQuery = query.ToLower();

            // Rechercher des films
            var movieResults = await _client.SearchMovieAsync(query, language: "fr-FR");
            var sortedMovies = movieResults.Results
                .OrderByDescending(m => m.Title?.ToLower().StartsWith(loweredQuery) == true)
                .ThenByDescending(m => m.VoteCount)
                .ThenByDescending(m => m.Popularity)
                .ToList();

            foreach (var movie in sortedMovies)
            {
                var movieCredits = await _client.GetMovieCreditsAsync(movie.Id);
                results.Add(new SearchResult
                {
                    Id = movie.Id, 
                    Title = movie.Title,
                    ReleaseYear = movie.ReleaseDate?.Year.ToString() ?? "N/A",
                    MediaType = "Film",
                    PosterPath = $"https://image.tmdb.org/t/p/w500{movie.PosterPath}",
                    Overview = movie.Overview,
                    Rating = movie.VoteAverage.ToString(),
                    MainActors = string.Join(", ", movieCredits.Cast.Take(3).Select(c => c.Name))
                });
            }

            // Rechercher des séries TV
            var tvResults = await _client.SearchTvShowAsync(query, language: "fr-FR");
            var sortedTvShows = tvResults.Results
                .OrderByDescending(tv => tv.Name?.ToLower().StartsWith(loweredQuery) == true)
                .ThenByDescending(tv => tv.VoteCount)
                .ThenByDescending(tv => tv.Popularity)
                .ToList();

            foreach (var tvShow in sortedTvShows)
            {
                var tvCredits = await _client.GetTvShowCreditsAsync(tvShow.Id, "fr-FR");
                results.Add(new SearchResult
                {
                    Id = tvShow.Id, 
                    Title = tvShow.Name,
                    ReleaseYear = tvShow.FirstAirDate?.Year.ToString() ?? "N/A",
                    MediaType = "Série TV",
                    PosterPath = $"https://image.tmdb.org/t/p/w500{tvShow.PosterPath}",
                    Overview = tvShow.Overview,
                    Rating = tvShow.VoteAverage.ToString(),
                    MainActors = string.Join(", ", tvCredits.Cast.Take(3).Select(c => c.Name))
                });

            }

            return results;
        }

        private void ResultsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ResultsList.SelectedItem is SearchResult selectedResult)
            {
                var detailsWindow = new DetailsWindow(selectedResult);
                detailsWindow.ShowDialog();
            }
        }
    }

    public class SearchResult
    {
        public int Id { get; set; } // Ajout de l'ID
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public string MediaType { get; set; }
        public string PosterPath { get; set; }
        public string Overview { get; set; }
        public string Rating { get; set; }
        public string MainActors { get; set; }
        public string Status { get; set; } 
    }
}
