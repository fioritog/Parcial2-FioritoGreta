1) No, si no es necesario almacenar el historial de alquiler, no debería ser necesario  tampoco guardarlos en un archivo.
   Si, en una "Lista<Equipo> Equipos" podemos gestionar los productos de la tienda.

2)  Si, dentro del archivo se podrán ver las múltiples actividades disponibles y sus detalles sin ninguna necesidad de ingresarlas cada vez que se ingresa al sistema.
    Si, es posible usar un "Dictionary<int, Actividad>" en el cual el índice indica el código de la actividad. Como no se requieren reservas no sería necesario considerar a aquellas actividades que se pueden llegar a repetir dentro del día.


3) Si, deberíamos almacenar las reservar en un "Dictionary<int,Reserva>" donde el índice del diccionario se referiría al código único de cada reserva. Este código nos puede ser utilizado como parámetro en caso de tener que cancelar, modificar (clase, vuelo, cant de asientos) una reserva.



5) Si, en caso que en algún momento se necesite agregar otro tipo de vehículo, por ejemplo cuatriciclo, será más práctico.
   No, el enunciado dice que no es necesario llevar registro histórico de aquellos vehículos que salen.
