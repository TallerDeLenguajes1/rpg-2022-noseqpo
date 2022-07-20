using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace RPGJuego
{
    public static class SISO
    {
        // Además el programa tendra que tener una opción para que en vez de generar automáticamente los jugadores, se los cargue via el archivo json de jugadores.
        public static void guardarJson(List<Personaje> guardar)
        {
            // este metodo sobre escribe
            string path = @"C:\Users\Acer Aspire 5\Codigos\TallerDeLenguajesI\rpg-2022-noseqpo\RPGJuego\RPGJuego\index.json";
            string toJson = JsonSerializer.Serialize(guardar);
            File.WriteAllText(path, toJson);
            Console.WriteLine("***** Personajes Guardados!\n\n");
        }

        public static List<Personaje> cargarJson()
        {
            string path = @"C:\Users\Acer Aspire 5\Codigos\TallerDeLenguajesI\rpg-2022-noseqpo\RPGJuego\RPGJuego\index.json";
            List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(File.ReadAllText(path));

            Console.WriteLine("***** Personajes Cargados!\n\n");
            return personajes;
        }

        public static void addToCSV(string[] ganador)
        {
            // crear un iterable local menete
            // Elegir mas datos para guardar
            // Además agregue una opción en el menú principal para que permita listar por pantalla el contenido de dicho archivo.

            string path = @"C:\Users\Acer Aspire 5\Codigos\TallerDeLenguajesI\rpg-2022-noseqpo\RPGJuego\RPGJuego\";
            if (Directory.Exists(path))
            {               
                File.AppendAllLines(path+"ganadores.csv", ganador);
            }
            else
            {
                Console.WriteLine("No existe");
            }
            Console.WriteLine("***** Registro de ganadores guardado!\n\n");
        }
    }
}
