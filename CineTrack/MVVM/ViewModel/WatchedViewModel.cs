using CineTrack.Core;
using CineTrack.MVVM.View;
using System.Collections.ObjectModel;
using System.Linq;

namespace CineTrack.MVVM.ViewModel
{
    public class WatchedViewModel : ObservableObject
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

        public WatchedViewModel()
        {
            MediaList = new ObservableCollection<SearchResult>();
        }

        private void UpdateStatistics()
        {
            MovieCount = MediaList.Count(m => m.MediaType == "Film");
            TvShowCount = MediaList.Count(m => m.MediaType == "Série TV");
            TotalCount = MediaList.Count;
        }
    }
}
