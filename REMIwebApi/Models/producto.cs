using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

public partial class producto
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string cod_Producto { get; set; } = null!;

    [StringLength(45)]
    [Unicode(false)]
    public string? Referencia { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? marcaProducto { get; set; }

    public double? precioDocena { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Subcategoria { get; set; } = null!;

    public int Proveedor { get; set; }

    [ForeignKey("Proveedor")]
    [InverseProperty("productos")]
    public virtual proveedore ProveedorNavigation { get; set; } = null!;

    [ForeignKey("Subcategoria")]
    [InverseProperty("productos")]
    public virtual subcategoria SubcategoriaNavigation { get; set; } = null!;

    [InverseProperty("ProductoNavigation")]
    public virtual ICollection<recibo_producto> recibo_productos { get; set; } = new List<recibo_producto>();

    [InverseProperty("productoStockNavigation")]
    public virtual ICollection<stock> stocks { get; set; } = new List<stock>();
}
