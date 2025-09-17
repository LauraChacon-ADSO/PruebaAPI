using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

[Table("stock")]
public partial class stock
{
    [Key]
    public int Id_stock { get; set; }

    public int? stockMax { get; set; }

    public int? stockMin { get; set; }

    public int? cantidadActual { get; set; }

    public byte? estadoProducto { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string productoStock { get; set; } = null!;

    [InverseProperty("StockNavigation")]
    public virtual ICollection<movimientos_stock> movimientos_stocks { get; set; } = new List<movimientos_stock>();

    [ForeignKey("productoStock")]
    [InverseProperty("stocks")]
    public virtual producto productoStockNavigation { get; set; } = null!;
}
