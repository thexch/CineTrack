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
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand SearchViewCommand { get; set; }
        public RelayCommand TowatchViewCommand { get; set; }
        public RelayCommand WatchedViewCommand { get; set; }
        public RelayCommand InProgressViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public SearchViewModel SearchVM { get; set; }
        public TowatchViewModel TowatchVM { get; set; }
        public WatchedViewModel WatchedVM { get; set; }
        public InProgressViewModel InProgressVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            SearchVM = new SearchViewModel();
            TowatchVM = new TowatchViewModel();
            WatchedVM = new WatchedViewModel();
            InProgressVM = new InProgressViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVM; });
            SearchViewCommand = new RelayCommand(o => { CurrentView = SearchVM; });
            TowatchViewCommand = new RelayCommand(o => { CurrentView = TowatchVM; });
            WatchedViewCommand = new RelayCommand(o => { CurrentView = WatchedVM; });
            InProgressViewCommand = new RelayCommand(o => { CurrentView = InProgressVM; });

            // Charger et filtrer les médias au démarrage
            LoadAndFilterMedia();
        }

        private void LoadAndFilterMedia()
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

            var filteredMedia = new Dictionary<string, List<SearchResult>>
            {
                { "towatch", new List<SearchResult>() },
                { "inprogress", new List<SearchResult>() },
                { "watched", new List<SearchResult>() }
            };

            foreach (var entry in statusDictionary)
            {
                var status = entry.Value["status"];
                var type = entry.Value["type"];

                var searchResult = new SearchResult
                {
                    Title = entry.Key,
                    MediaType = type
                };

                if (filteredMedia.ContainsKey(status))
                {
                    filteredMedia[status].Add(searchResult);
                }
            }

            // Mettre à jour les ViewModels avec les données filtrées
            TowatchVM.MediaList = new ObservableCollection<SearchResult>(filteredMedia["towatch"]);
            InProgressVM.MediaList = new ObservableCollection<SearchResult>(filteredMedia["inprogress"]);
            WatchedVM.MediaList = new ObservableCollection<SearchResult>(filteredMedia["watched"]);
        }
    }
}
