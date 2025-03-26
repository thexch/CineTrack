using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CineTrack
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadStatusFromJson();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void LoadStatusFromJson()
        {
            string jsonFilePath = "status.json";
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                var statusDictionary = JsonConvert.DeserializeObject<Dictionary<string, MovieInfo>>(json);

            }
        }
        public class MovieInfo
        {
            public string Status { get; set; }
            public string Type { get; set; }
        }

    }
}
