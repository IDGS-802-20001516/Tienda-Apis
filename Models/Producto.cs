using System;
using System.Collections.Generic;

namespace Producto.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int? IdCategoria { get; set; }

    public string? Color { get; set; }

    public string? Nombre { get; set; }

    public string? Modelo { get; set; }

    public string? Almacenamiento { get; set; }

    public string? Procesador { get; set; }

    public string? Ram { get; set; }

    public string? Imagen { get; set; }

    public double? Precio { get; set; }
    
}
