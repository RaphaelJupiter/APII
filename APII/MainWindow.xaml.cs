using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace APII
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnGenerateJoke_Click(object sender, RoutedEventArgs e)
        {
            lblJoke.Text = "Chargement de la blague...";
            string joke = await GetJokeAsync();
            lblJoke.Text = joke;
        }

        private async Task<string> GetJokeAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Appel à l'API pour obtenir la blague
                    HttpResponseMessage response = await client.GetAsync("https://v2.jokeapi.dev/joke/Any");
                    response.EnsureSuccessStatusCode();  // Vérifie que la réponse est correcte

                    // Lecture du contenu de la réponse sous forme de chaîne JSON
                    string jsonString = await response.Content.ReadAsStringAsync();

                    // Désérialisation du JSON dans un objet Root
                    var jokeResponse = JsonSerializer.Deserialize<Root>(jsonString);

                    // Si la réponse contient une blague de type "twopart", on retourne la blague complète
                    if (jokeResponse.type == "twopart")
                    {
                        return $"{jokeResponse.setup}\n\n{jokeResponse.delivery}";
                    }
                    else
                    {
                        return jokeResponse.setup;  // Blague courte
                    }
                }
                catch (Exception ex)
                {
                    // En cas d'erreur, on renvoie le message d'erreur
                    return $"Erreur : {ex.Message}";
                }
            }
        }
    }

    // Classe représentant les différents "drapeaux" de sécurité
    public class Flags
    {
        public bool nsfw { get; set; }
        public bool religious { get; set; }
        public bool political { get; set; }
        public bool racist { get; set; }
        public bool sexist { get; set; }
        public bool @explicit { get; set; }
    }

    // Classe représentant la réponse complète de l'API (Root)
    public class Root
    {
        public bool error { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string setup { get; set; }
        public string delivery { get; set; }
        public Flags flags { get; set; }
        public bool safe { get; set; }
        public int id { get; set; }
        public string lang { get; set; }
    }
}