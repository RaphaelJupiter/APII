using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
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
            string joke = await jokeService.GetJokeAsync();
            lblJoke.Text = joke;
        }
       
    }

}