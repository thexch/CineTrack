using CineTrack.MVVM.View;
using System.Windows;
using System.Windows.Input;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CineTrack
{
    public partial class DetailsWindow : Window
    {
        public DetailsWindow(SearchResult searchResult)
        {
            InitializeComponent();
            DataContext = searchResult;
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
        public void UpdateJsonStatus(string title, string status, string mediaType)
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "status.json");
            Dictionary<string, Dictionary<string, string>> statusDictionary;

            try
            {
                if (File.Exists(jsonFilePath))
                {
                    string json = File.ReadAllText(jsonFilePath);
                    statusDictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
                }
                else
                {
                    statusDictionary = new Dictionary<string, Dictionary<string, string>>();
                }

                // Mettre à jour le statut et le type de média
                statusDictionary[title] = new Dictionary<string, string>
        {
            { "status", status },
            { "type", mediaType }
        };

                string updatedJson = JsonConvert.SerializeObject(statusDictionary, Formatting.Indented);
                File.WriteAllText(jsonFilePath, updatedJson);
                Console.WriteLine($"Statut mis à jour dans {jsonFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la mise à jour du statut : {ex.Message}");
            }
        }

        private void MarkAsTowatch_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus("towatch");
        }

        private void MarkAsInProgress_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus("inprogress");
        }

        private void MarkAsWatched_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus("watched");
        }

        private void UpdateStatus(string status)
        {
            var searchResult = DataContext as SearchResult;
            if (searchResult != null)
            {
                // Mettre à jour le fichier JSON avec le nouveau statut et le type de média
                UpdateJsonStatus(searchResult.Title, status, searchResult.MediaType);
            }
        }


    }
}
