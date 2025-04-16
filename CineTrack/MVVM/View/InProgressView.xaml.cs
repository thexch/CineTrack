using System.Windows.Controls;
using CineTrack.MVVM.ViewModel;

namespace CineTrack.MVVM.View
{
    public partial class InProgressView : UserControl
    {
        public InProgressView()
        {
            InitializeComponent();
            this.DataContext = new InProgressViewModel(); 
        }
    }
}
