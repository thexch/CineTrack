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
    public class TowatchViewModel : ObservableObject
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

        public TowatchViewModel()
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
                .Where(kvp => kvp.Value.ContainsKey("status") && kvp.Value["status"] == "towatch")
                .Select(kvp => new SearchResult
                {
                    Id = int.Parse(kvp.Key),
                    Title = kvp.Value["title"],
                    ReleaseYear = kvp.Value["releaseYear"],
                    MediaType = kvp.Value["type"],
                    PosterPath = kvp.Value["poster"],
                    Overview = kvp.Value["overview"],
                    Rating = kvp.Value["rating"],
                    MainActors = kvp.Value["mainActors"],
                    Status = kvp.Value["status"]
                });

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
