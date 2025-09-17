using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

public partial class recibo_producto
{
    [Key]
    public int Id { get; set; }

    public int? Cantidad { get; set; }

    public double? valorUnitario { get; set; }

    public double? Subtotal { get; set; }

    public int reciboPago { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Producto { get; set; } = null!;

    [ForeignKey("Producto")]
    [InverseProperty("recibo_productos")]
    public virtual producto ProductoNavigation { get; set; } = null!;

    [ForeignKey("reciboPago")]
    [InverseProperty("recibo_productos")]
    public virtual recibo_pago reciboPagoNavigation { get; set; } = null!;
}
