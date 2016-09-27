using System;

namespace PCategoria
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			Console.WriteLine ("Selecciona una opcion: ");
			Console.WriteLine ("0. Salir " + "\n" + "1. Nuevo " + "\n" + "2. Editar " + "\n" + "3. Eliminar " + "\n" + "4. Listar todos " + "\n");

			switch (Console.Read ()) 
			{
			case '0':
				Console.Write ("\nAdios");
				//Environment.Exit ();
				break;
			case '1':
				Console.Write ("\nNuevo");
				break;
			case '2':
				Console.Write ("\nEditar");
				break;
			case '3':
				Console.Write ("\nEliminar");
				break;
			case '4':
				Console.Write ("\nListar todos");
				break;
			}
		}
	}
}
