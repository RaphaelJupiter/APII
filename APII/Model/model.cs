using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APII.Services;



namespace APII.Model
{
    internal class model
    {
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
