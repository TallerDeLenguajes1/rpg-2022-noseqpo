using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGJuego
{
    public static class SISO
    {
        // Además el programa tendra que tener una opción para que en vez de generar automáticamente los jugadores, se los cargue via el archivo json de jugadores.
        public static List<Personaje> crearPersonajes(int cantidad)
        {
            List<Personaje> lista = new List<Personaje>();
            string path = @"C:\Users\Acer Aspire 5\Codigos\TallerDeLenguajesI\rpg-2022-noseqpo\RPGJuego\RPGJuego\";


            if (!File.Exists(path + @"/index.json"))
            {
                File.Create(path + @"/index.json").Close();
            }
            path += @"/index.json";

            for(int i = 0; i < cantidad; i++)
    {
                Personaje personaje = new Personaje(i);
                for (int j = 0; j < i + 1; j++)
                {
                    // para que se encuentre personajes cada vez mas potentes
                    personaje.PowerUp();
                }

                lista.Add(personaje);
            }


            return lista;
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
        }
    }
}
