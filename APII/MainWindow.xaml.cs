using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using APII.Model;
using APII.Services;

namespace APII
{
    public partial class MainWindow : Window
    {

        JokeService jokeService;
        public MainWindow()
        {
            InitializeComponent();
            jokeService = new JokeService();
        }

        public async void btnGenerateJoke_Click(object sender, RoutedEventArgs e)
        {
            lblJoke.Text = "Chargement de la blague...";
            // Récupérer la catégorie sélectionnée dans la ComboBox
            string selectedCategory = ((ComboBoxItem)cbJokeCategory.SelectedItem).Content.ToString();
            string joke = await jokeService.GetJokeAsync(selectedCategory);
            lblJoke.Text = joke;
        }
       
    }

}