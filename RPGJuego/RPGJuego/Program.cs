using RPGJuego;
{
    // mover todo a Sistema

    List<Personaje> lista = new List<Personaje>();

    for (int i = 0; i < 4; i++)
    {
        Personaje personaje = new Personaje(i);
        for (int j = 0; j < i+1; j++)
        {
            // para que se encuentre personajes cada vez mas potentes
            personaje.PowerUp();
        }
        
        lista.Add(personaje);
    }

    Console.WriteLine("Pre\n");
    foreach (Personaje item in lista)
    {
        Console.WriteLine(item.ToString());
    }

    Sistema newGame = new Sistema();
    newGame.Start(lista);


    Console.WriteLine("\n\nPost\n");
    foreach (Personaje item in lista)
    {
        Console.WriteLine(item.ToString());
    }
}