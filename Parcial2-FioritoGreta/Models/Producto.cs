
using Parcial2_FioritoGreta.Enums;

namespace Parcial2_FioritoGreta.Models
{
    public class Producto
    {
        public string Nombre { get; private set; }
        public Categorias Categoria { get; private set; }
        public double Precio { get; private set; }

        public Producto(string nombre, Categorias categoria, double precio)
        {
            Nombre = nombre;
            Categoria = categoria;
            Precio = precio;
        }
        public override string ToString()
        {
            return $"{Nombre} - {Categoria} - ${Precio}";
        }
    }
}
