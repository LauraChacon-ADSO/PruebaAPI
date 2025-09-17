using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

[Table("movimientos_stock")]
public partial class movimientos_stock
{
    [Key]
    public int Id_movimiento { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Tipo { get; set; }

    public int? Cantidad { get; set; }

    public DateOnly? Fecha { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Observaciones { get; set; }

    public int Stock { get; set; }

    [ForeignKey("Stock")]
    [InverseProperty("movimientos_stocks")]
    public virtual stock StockNavigation { get; set; } = null!;
}
