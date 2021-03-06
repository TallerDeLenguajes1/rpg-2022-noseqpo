using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;

namespace RPGJuego
{
    public class Personaje
    {
        private int id;
        private string name;
        private int vida;
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;

        public Personaje(int id)
        {
            this.nivel = 1;
            this.vida = 100;
            this.id = id;
            this.name = crearNombre();
            // poner nombre desde api? 
        }

        private string crearNombre()
        {
            var url = $"https://random-names-api.herokuapp.com/random";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            string nombre = "";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            ListNames nombres = JsonSerializer.Deserialize<ListNames>(responseBody);
                            foreach (Name tmp in nombres.nombres)
                            {
                                nombre = tmp.name;
                            }
                            return nombre;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
                return "";
            }
        }

        public int Id { get { return this.id; } }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }

        public int Vida { get => vida; set => vida = value; }

        public void PowerUp()
        {
            Console.WriteLine("{0} HA SUBIDO DE NIVEL", this.id);
            Random rand = new Random();
            int consti = 50;
            this.armadura += this.nivel * rand.Next(consti);
            this.fuerza += this.nivel * rand.Next(consti);
            this.destreza += this.nivel * rand.Next(consti);
            this.velocidad += this.nivel * rand.Next(consti);
            this.nivel++;
        }

        public override string ToString()
        {
            string nameS = "Personaje "+ this.name + "\n";
            string vidaS = "La vida actual del personaje es: " + this.vida + "\n";
            string nivelS = "El nivel actual del personaje es: " + this.nivel + "\n";
            string velocidadS = "La velocidad actual del personaje es: " + this.velocidad + "\n";
            string armaduraS = "La armadura actual del personaje es: " + this.armadura + "\n";
            string destrezaS = "La armadura actual del personaje es: " + this.destreza + "\n";
            string fuerzaS = "La fuerza actual del personaje es: " + this.fuerza + "\n";

            return nameS + vidaS + nivelS + velocidadS + armaduraS + destrezaS + fuerzaS;
        }

    }
}
