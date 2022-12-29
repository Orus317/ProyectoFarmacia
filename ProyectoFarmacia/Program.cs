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

// Lector del archivo csv para generar la lista de clientes 
using (StreamReader reader = new(@".\clientes.csv", Encoding.GetEncoding("iso-8859-1")))
{
	// Omitir la primera línea
	reader.ReadLine();
	// Leer todas las líneas del archivo 
	while (!reader.EndOfStream)
	{
		string codigo, nombre, apellido, direccion;
		// Leyendo la linea
		string? line = reader.ReadLine();
		// Separando valores por ";"
		string[] values = line.Split(";");
		// Asignaciones
		codigo = values[0];
		nombre = values[1];
		apellido = values[2];
		direccion = values[3];
		//Agregar el producto a la lista de productos
        Clientes.Agregar(new CCliente(codigo, nombre, apellido, direccion));
	}
}

// Lista de Ventas

Ventas.Agregar(new CVentas("91035","95961212","101000801","12/05/2022",11));
Ventas.Agregar(new CVentas("92036","36192134","101001101","12/04/2022",2));
Ventas.Agregar(new CVentas("93036","85586251","101001601","11/04/2022",7));
Ventas.Agregar(new CVentas("94036","85143178","101001801","10/04/2022",11));
Ventas.Agregar(new CVentas("95036","45686143","101002001","11/03/2022",9));
Ventas.Agregar(new CVentas("96036","82784817","101002101","11/03/2022",14));
Ventas.Agregar(new CVentas("97036","01278535","101002301","12/04/2022",15));
Ventas.Agregar(new CVentas("98036","34480959","101002401","12/05/2022",8));
Ventas.Agregar(new CVentas("99036","05196068","101002601","10/05/2022",13));
Ventas.Agregar(new CVentas("81736","97218107","101003001","12/05/2022",15));

while (true)
{
	CMenu.MostrarMenu(Clientes, Productos, Ventas);
}

