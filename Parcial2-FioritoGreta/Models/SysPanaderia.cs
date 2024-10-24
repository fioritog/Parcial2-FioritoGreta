
using Parcial2_FioritoGreta.Enums;

namespace Parcial2_FioritoGreta.Models
{
    abstract class SysPanaderia
    {

        static public List<Producto> Catalogo = new();
        static string ArchivoCatalogo = "Catalogo.txt";

        static public void AgregarProducto(Producto producto)
        {
            Catalogo.Add(producto);
            GuardarProducto(producto);
        }
        static public void MostrarCatalogo()
        {
            if (Catalogo.Count == 0)
            {
                Console.WriteLine($"No hay productos en el catálogo.");
            }
            else
            {
                foreach (var p in Catalogo)
                {
                    Console.WriteLine(p);
                }
            }
        }
        static public void EliminarProducto(string nombre)
        {
            var prod = Catalogo.Find(p => p.Nombre == nombre);
            if (prod == null)
            {
                Console.WriteLine($"Producto no encontrado. ");
            }
            else
            {
                Catalogo.Remove(prod);
                GuardarDatos();
                Console.WriteLine($"Producto: {nombre} removido del catalogo");
            }
        }

        static public void ActualizarProducto(string nombre)
        {
            var prod = Catalogo.Find(p => p.Nombre == nombre);
            if (prod == null)
            {
                Console.WriteLine($"\nProducto no encontrado. ");
            }
            else
            {
                Console.WriteLine("Seleccione la categoría del producto: ");
                foreach (var cat in Enum.GetValues(typeof(Categorias)))
                {
                    Console.WriteLine($"{(int)cat + 1}. {cat}");
                }
                int seleccion = int.Parse(Console.ReadLine());
                Categorias categoriaSeleccionada = (Categorias)seleccion;
                Console.Write($"Ingrese el nuevo precio del producto: $");
                var precio = double.Parse(Console.ReadLine());
                Catalogo.Remove(prod);
                Producto nuevoProducto = new Producto(nombre, categoriaSeleccionada, precio);
                Catalogo.Add(nuevoProducto);
                Console.WriteLine($"\nProdcuto: {nombre} actualizado!");
                GuardarDatos();
            }

        }
        static public void CalcularTotal() 
        {
            double total = 0;
            if (File.Exists(ArchivoCatalogo))
            {
                foreach (var prod in Catalogo)
                {
                    total = total + prod.Precio;
                }
                Console.WriteLine($"El total acumulado del inventario es: ${total}");
            }
            else 
            {
                Console.WriteLine($"No hay productos en el inventario");
            }

        }
        static public void GuardarProducto(Producto producto)
        {
            using StreamWriter writer = new(ArchivoCatalogo, true);
            writer.WriteLine(producto);
        }
        static public void GuardarDatos()
        {
            using StreamWriter writer = new(ArchivoCatalogo);
            foreach (var p in Catalogo)
            {
                writer.WriteLine(p);
            }
        }
        static public void CargarDatos()
        {
            if (File.Exists(ArchivoCatalogo))
            {
                foreach (var linea in File.ReadAllLines(ArchivoCatalogo))
                {
                    string[] d = linea.Split(" - ");
                    Producto pr = null;

                    string nombre = d[0];
                    Categorias categoria = (Categorias)Enum.Parse(typeof(Categorias), d[1]);
                    double precio = double.Parse(d[2]);

                    pr = new Producto(nombre, categoria, precio);
                    Catalogo.Add(pr);
                    pr = null;
                }

            }
        }
    }
}
