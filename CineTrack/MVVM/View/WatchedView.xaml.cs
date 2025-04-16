using System.Windows.Controls;
using CineTrack.MVVM.ViewModel;

namespace CineTrack.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour WatchedView.xaml
    /// </summary>
    public partial class WatchedView : UserControl
    {
        public WatchedView()
        {
            InitializeComponent();
            this.DataContext = new WatchedViewModel();

        }
    }
}
