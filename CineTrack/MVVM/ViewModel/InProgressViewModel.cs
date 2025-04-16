using CineTrack.Core;
using CineTrack.MVVM.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace CineTrack.MVVM.ViewModel
{
    public class InProgressViewModel : ObservableObject
    {
        private ObservableCollection<SearchResult> _mediaList;

        public ObservableCollection<SearchResult> MediaList
        {
            get { return _mediaList; }
            set
            {
                _mediaList = value;
                OnPropertyChanged();
                UpdateStatistics();
            }
        }

        private int _movieCount;
        public int MovieCount
        {
            get { return _movieCount; }
            set
            {
                _movieCount = value;
                OnPropertyChanged();
            }
        }

        private int _tvShowCount;
        public int TvShowCount
        {
            get { return _tvShowCount; }
            set
            {
                _tvShowCount = value;
                OnPropertyChanged();
            }
        }

        private int _totalCount;
        public int TotalCount
        {
            get { return _totalCount; }
            set
            {
                _totalCount = value;
                OnPropertyChanged();
            }
        }

        public InProgressViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "status.json");

            if (!File.Exists(filePath))
            {
                MediaList = new ObservableCollection<SearchResult>();
                return;
            }

            var json = File.ReadAllText(filePath);
            var rawData = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);

            var list = rawData
                .Where(kvp => kvp.Value.ContainsKey("status") && kvp.Value["status"] == "inprogress")
                .Select(kvp => new SearchResult
                {
                    Id = int.Parse(kvp.Key),
                    Title = kvp.Value.ContainsKey("title") ? kvp.Value["title"] : "Titre inconnu",
                    ReleaseYear = kvp.Value.ContainsKey("releaseYear") ? kvp.Value["releaseYear"] : "N/A",
                    MediaType = kvp.Value.ContainsKey("type") ? kvp.Value["type"] : "Inconnu",
                    PosterPath = kvp.Value.ContainsKey("poster") ? kvp.Value["poster"] : "",
                    Overview = kvp.Value.ContainsKey("overview") ? kvp.Value["overview"] : "",
                    Rating = kvp.Value.ContainsKey("rating") ? kvp.Value["rating"] : "0",
                    MainActors = kvp.Value.ContainsKey("mainActors") ? kvp.Value["mainActors"] : "",
                    Status = kvp.Value["status"]
                })
                .ToList();

            MediaList = new ObservableCollection<SearchResult>(list);
            UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            MovieCount = MediaList.Count(m => m.MediaType == "Film");
            TvShowCount = MediaList.Count(m => m.MediaType == "Série TV");
            TotalCount = MediaList.Count;
        }
    }
}
