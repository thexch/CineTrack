using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TMDbLib.Client;

namespace CineTrack.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour SearchView.xaml
    /// </summary>
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
                DefaultLanguage = "fr-FR" // Définit la langue en français
            };
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtenir le texte de recherche
            string query = SearchBox.Text;

            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Veuillez entrer un terme de recherche.");
                return;
            }

            // Effectuer la recherche
            var results = await SearchMoviesAndTvShows(query);

            // Afficher les résultats dans la ListBox
            ResultsList.ItemsSource = results;
        }


        private async Task<ObservableCollection<SearchResult>> SearchMoviesAndTvShows(string query)
        {
            var results = new ObservableCollection<SearchResult>();

            // Rechercher des films
            var movieResults = await _client.SearchMovieAsync(query, language: "fr-FR");
            foreach (var movie in movieResults.Results)
            {
                var movieCredits = await _client.GetMovieCreditsAsync(movie.Id);
                results.Add(new SearchResult
                {
                    Title = movie.Title,
                    ReleaseYear = movie.ReleaseDate.HasValue ? movie.ReleaseDate.Value.Year.ToString() : "N/A",
                    MediaType = "Film",
                    PosterPath = $"https://image.tmdb.org/t/p/w500{movie.PosterPath}",
                    Overview = movie.Overview,
                    Rating = movie.VoteAverage.ToString(),
                    MainActors = string.Join(", ", movieCredits.Cast.Take(3).Select(c => c.Name)) // Acteurs principaux
                });
            }

            // Rechercher des séries TV
            var tvResults = await _client.SearchTvShowAsync(query, language: "fr-FR");
            foreach (var tvShow in tvResults.Results)
            {
                var tvCredits = await _client.GetTvShowCreditsAsync(tvShow.Id, "fr-FR");
                results.Add(new SearchResult
                {
                    Title = tvShow.Name,
                    ReleaseYear = tvShow.FirstAirDate.HasValue ? tvShow.FirstAirDate.Value.Year.ToString() : "N/A",
                    MediaType = "Série TV",
                    PosterPath = $"https://image.tmdb.org/t/p/w500{tvShow.PosterPath}",
                    Overview = tvShow.Overview,
                    Rating = tvShow.VoteAverage.ToString(),
                    MainActors = string.Join(", ", tvCredits.Cast.Take(3).Select(c => c.Name)) // Acteurs principaux
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
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public string MediaType { get; set; }
        public string PosterPath { get; set; }
        public string Overview { get; set; }
        public string Rating { get; set; }
        public string MainActors { get; set; }
    }
}
