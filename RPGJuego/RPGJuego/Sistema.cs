using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGJuego
{
    public class Sistema
    {
        private static int maxDamage = 500; // * 100
        private List<string> archivos = new List<string>(); // no needed

        public List<Personaje> crearPersonajes(int cantidad)
        {
            List<Personaje> lista = new List<Personaje>();
            string path = @"C:\Users\Acer Aspire 5\Codigos\TallerDeLenguajesI\rpg-2022-noseqpo\RPGJuego\RPGJuego\";

            if (!File.Exists(path + @"/index.json"))
            {
                File.Create(path + @"/index.json").Close();
            }
            path += @"/index.json";

            for (int i = 0; i < cantidad; i++)
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
        public void Start(List<Personaje> lista)
        {
            int cnt = 0;
            while (Vivos(lista)>1)
            {
                Console.WriteLine("Seleccion de peleadores N: {0}\n", cnt);
                cnt++;
                
                Personaje uno = nthVivo(lista,1);
                Personaje dos = nthVivo(lista,2);

                Pelea(uno, dos);

            }
        }

        private Personaje nthVivo(List<Personaje> lista, int n)
        {
            Personaje? tmp = null;
            // lo ideal seria que nunca llegue a retornar null
            int cnt = 0;
            
            Console.WriteLine("eleccion de {0}", n);
            foreach (Personaje item in lista)
            {
                if (Vivo_(item))
                {
                    cnt++;
                }
                if (cnt==n)
                {
                    return item;
                }
            }
            
            return tmp;
        }

        
        private void Pelea(Personaje uno, Personaje dos)
        {
            // se pegan entre si hasta que uno muera
            while (Vivo_(uno) && Vivo_(dos))
            {
                Console.WriteLine("\nPELEA entre {0} y {1}!", uno.Id, dos.Id);
                Atacar(uno, dos);
                Atacar(dos, uno);
            }
            // eliminar perdedor
            uno.PowerUp();
            dos.PowerUp();
        }

        private void Atacar(Personaje atacante, Personaje defensor)
        {
            int damm = (int)Danio(atacante, defensor );
            Console.WriteLine("{0} inflige {1} de daño a {2}", atacante.Id, damm, defensor.Id);
            defensor.Vida -= damm;
        }

        public int Vivos(List<Personaje> lista)
        {
            int tmp = 0;
            foreach (Personaje personaje in lista)
            {
                if (Vivo_(personaje))
                {
                    tmp++;
                }
            }
            return tmp;
        }

        private bool Vivo_(Personaje test)
        {
            if (test != null)
            {
                return test.Vida > 0;
            }
            else return false;
        }

        public void toList(string linea) // no needed
        {

        }

        private double PoderDisparo( Personaje atacante)
        {
            double pd = atacante.Destreza * atacante.Fuerza * atacante.Nivel;
            return pd;
        }

        private int EfectividadDisparo()
        {
            Random r = new Random();
            return 1 + r.Next(100);
        }

        private double VAtaque(Personaje atacante)
        {
            return PoderDisparo(atacante) * EfectividadDisparo() / 100;
        }

        private double PoderDefensa(Personaje defensor)
        {
            return defensor.Armadura * defensor.Velocidad;
        }

        private double Danio(Personaje atacante, Personaje defensor)
        {
            double damage = (VAtaque(atacante) * EfectividadDisparo() - PoderDefensa(defensor))/maxDamage;
            if (damage < 0)
            {
                Console.WriteLine("NO ENTIENDO"); // ni quiero entender
                damage *= -1;
            }
            while (damage>100)
            {
                Console.WriteLine("MUY FUERTE!");
                damage *= 0.50;
            }
            Console.WriteLine("ATAQUE FINAL: " + damage);
            return damage;
        }

        


    }

    

}
