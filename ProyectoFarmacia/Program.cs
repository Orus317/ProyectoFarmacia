using System.Text;
using ProyectoFarmacia;

// Creando lista de productos
CListaProductos Productos = new();
CListaClientes Clientes = new();
CListaVentas Ventas = new();
// Lector del archivo csv para generar la lista CLisaProductos
using (StreamReader reader = new(@".\farmacia.csv", Encoding.GetEncoding("iso-8859-1")))
{
	// Omitir la primera línea
	reader.ReadLine();
	// Leer todas las líneas del archivo 
	while (!reader.EndOfStream)
	{
		string codigo, nombre, descripcion, proveedor;
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
		//Agregar el producto a la lista de productos
		Productos.Agregar(new CProducto(codigo, nombre, descripcion, fechaFabricacion, fechaVencimiento, proveedor, precio));
	}
}

while (true)
{
	CMenu.MostrarMenu(Clientes, Productos, Ventas);
}
