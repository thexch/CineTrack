using CineTrack.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Linq;

namespace CineTrack.MVVM.ViewModel
{
    public class HomeViewModel : ObservableObject
    {
        private int _totalMoviesToWatch;
        public int TotalMoviesToWatch
        {
            get { return _totalMoviesToWatch; }
            set
            {
                _totalMoviesToWatch = value;
                OnPropertyChanged();
            }
        }

        private int _totalTvShowsToWatch;
        public int TotalTvShowsToWatch
        {
            get { return _totalTvShowsToWatch; }
            set
            {
                _totalTvShowsToWatch = value;
                OnPropertyChanged();
            }
        }

        private int _totalToWatch;
        public int TotalToWatch
        {
            get { return _totalToWatch; }
            set
            {
                _totalToWatch = value;
                OnPropertyChanged();
            }
        }

        private int _totalMoviesInProgress;
        public int TotalMoviesInProgress
        {
            get { return _totalMoviesInProgress; }
            set
            {
                _totalMoviesInProgress = value;
                OnPropertyChanged();
            }
        }

        private int _totalTvShowsInProgress;
        public int TotalTvShowsInProgress
        {
            get { return _totalTvShowsInProgress; }
            set
            {
                _totalTvShowsInProgress = value;
                OnPropertyChanged();
            }
        }

        private int _totalInProgress;
        public int TotalInProgress
        {
            get { return _totalInProgress; }
            set
            {
                _totalInProgress = value;
                OnPropertyChanged();
            }
        }

        private int _totalMoviesWatched;
        public int TotalMoviesWatched
        {
            get { return _totalMoviesWatched; }
            set
            {
                _totalMoviesWatched = value;
                OnPropertyChanged();
            }
        }

        private int _totalTvShowsWatched;
        public int TotalTvShowsWatched
        {
            get { return _totalTvShowsWatched; }
            set
            {
                _totalTvShowsWatched = value;
                OnPropertyChanged();
            }
        }

        private int _totalWatched;
        public int TotalWatched
        {
            get { return _totalWatched; }
            set
            {
                _totalWatched = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            // Initialiser les statistiques
            UpdateGlobalStatistics();
        }

        private void UpdateGlobalStatistics()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "status.json");
            Dictionary<string, Dictionary<string, string>> statusDictionary;

            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                statusDictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
            }
            else
            {
                return;
            }

            TotalMoviesToWatch = statusDictionary.Count(m => m.Value["status"] == "towatch" && m.Value["type"] == "Film");
            TotalTvShowsToWatch = statusDictionary.Count(m => m.Value["status"] == "towatch" && m.Value["type"] == "Série TV");
            TotalToWatch = TotalMoviesToWatch + TotalTvShowsToWatch;

            TotalMoviesInProgress = statusDictionary.Count(m => m.Value["status"] == "inprogress" && m.Value["type"] == "Film");
            TotalTvShowsInProgress = statusDictionary.Count(m => m.Value["status"] == "inprogress" && m.Value["type"] == "Série TV");
            TotalInProgress = TotalMoviesInProgress + TotalTvShowsInProgress;

            TotalMoviesWatched = statusDictionary.Count(m => m.Value["status"] == "watched" && m.Value["type"] == "Film");
            TotalTvShowsWatched = statusDictionary.Count(m => m.Value["status"] == "watched" && m.Value["type"] == "Série TV");
            TotalWatched = TotalMoviesWatched + TotalTvShowsWatched;
        }
    }
}
