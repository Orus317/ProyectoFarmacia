using System.Text;
using ProyectoFarmacia;

// Creando lista de productos
CListaProductos Productos = new();

//Leyendo el archivo csv
using (StreamReader reader = new(@".\farmacia.csv", Encoding.GetEncoding("iso-8859-1")))
{
	reader.ReadLine();
	while (!reader.EndOfStream)
	{
		string? codigo, nombre, descripcion, proveedor;
		DateTime fechaFabricacion, fechaVencimiento;
		float precio;
		// Leyendo la linea
		string? line = reader.ReadLine();
		// Separando valores por ";"
		string[] values = line.Split(";");
		// Asignaciones
		codigo = values[0];
		nombre = values[1];
		descripcion = values[2];
		fechaFabricacion = DateTime.Parse(values[3]);
		fechaVencimiento = DateTime.Parse(values[4]);
		proveedor = values[5];
		precio = float.Parse(values[6]);
		Productos.Agregar(new CProducto(codigo, nombre, descripcion, fechaFabricacion, fechaVencimiento, proveedor, precio));
	}
}

Productos.Listar();
//object algo = Productos.Iesimo(1, true);
//CProducto s = (CProducto)((CNodoLista)algo).Element;
//s.Modificar();
//s.Mostrar();