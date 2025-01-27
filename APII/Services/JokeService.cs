using APII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APII.Services
{
    public class JokeService
    {
        public async Task<string> GetJokeAsync()
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

}
