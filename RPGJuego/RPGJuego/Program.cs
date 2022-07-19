using RPGJuego;
{
    // mover todo a Sistema
    Sistema newGame = new Sistema();

    List<Personaje> lista = newGame.crearPersonajes(5);

    Console.WriteLine("Pre\n");
    foreach (Personaje item in lista)
    {
        Console.WriteLine(item.ToString());
    }

    
    newGame.Start(lista);


    Console.WriteLine("\n\nPost\n");
    foreach (Personaje item in lista)
    {
        Console.WriteLine(item.ToString());
    }

    string[] winner = { "cd", "bds" , "c"}; // linea por indice 

    //SISO.addToCSV(winner);
}