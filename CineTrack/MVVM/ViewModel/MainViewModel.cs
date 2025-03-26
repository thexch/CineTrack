using CineTrack.Core;
using CineTrack.MVVM.View;

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
        }
    }  
}
