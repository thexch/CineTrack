using System.Windows.Controls;
using CineTrack.MVVM.ViewModel;

namespace CineTrack.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour TowatchView.xaml
    /// </summary>
    public partial class TowatchView : UserControl
    {
        public TowatchView()
        {
            InitializeComponent();
            this.DataContext = new TowatchViewModel(); 
        }
    }
}
