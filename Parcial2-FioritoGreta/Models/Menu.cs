

using Parcial2_FioritoGreta.Enums;

namespace Parcial2_FioritoGreta.Models
{
    abstract class Menu
    {
        private static List<Action> Acciones = new()
        {
            AgregarProducto,
            EliminarProducto,
            ActualizarProducto,
            MostrarCatalogo,
            CalcularTotalMercaderia
        };
        public static void MostrarMenu()
        {
            SysPanaderia.CargarDatos();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n --- Menú de misiones ---\n" +
                    "1. Agregar producto al inventario.\n" +
                    "2. Eliminar producto del catálogo.\n" +
                    "3. Actualizar categoria o precio de un producto\n" +
                    "4. Mostrar todos los productos.\n" +
                    "5. Calcular precio total de la mercancía.\n" +
                    "6. Guardar y Salir\n");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                if (int.TryParse(opcion, out int indice) && indice >= 1 && indice <= Acciones.Count + 1)
                {
                    if (indice == Acciones.Count + 1)
                    {
                        salir = true;
                    }
                    else
                    {
                        Acciones[indice - 1].Invoke();
                    }
                }
                else
                {
                    Console.WriteLine($"\nOpción no válida.");
                }
            }
        }

        static void AgregarProducto()
        {
            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Seleccione la categoría del producto: ");
            foreach (var cat in Enum.GetValues(typeof(Categorias)))
            {
                Console.WriteLine($"{(int)cat + 1}. {cat}");
            }
            int seleccion = int.Parse(Console.ReadLine());
            Categorias categoriaSeleccionada = (Categorias)seleccion;
            Console.Write("Ingrese el precio del producto: $");
            var precio = double.Parse(Console.ReadLine());

            Producto nuevoProducto = new Producto(nombre, categoriaSeleccionada, precio);

            SysPanaderia.AgregarProducto(nuevoProducto);
        }
        static void MostrarCatalogo() => SysPanaderia.MostrarCatalogo();

        static void ActualizarProducto()
        {
            Console.Write($"Ingrese el nombre del producto a modificar: ");
            string nombre = Console.ReadLine();

            SysPanaderia.ActualizarProducto(nombre);
        }
        static void EliminarProducto()
        {
            Console.Write($"Ingrese el nombre del producto a eliminar: ");
            string nombre = Console.ReadLine();

            SysPanaderia.EliminarProducto(nombre);
        }

        static void CalcularTotalMercaderia() => SysPanaderia.CalcularTotal();
    }

}

