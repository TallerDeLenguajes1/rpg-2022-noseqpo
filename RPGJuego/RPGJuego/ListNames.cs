using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RPGJuego
{
    public class ListNames
    {
        [JsonPropertyName("Nombres")]
        public List<Name> nombres { get; set; }
    }
}
