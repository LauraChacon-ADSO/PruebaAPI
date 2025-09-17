using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

[Table("cliente")]
public partial class cliente
{
    [Key]
    public int Id_cliente { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string nombre { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string Apellido { get; set; } = null!;

    [StringLength(45)]
    [Unicode(false)]
    public string correo { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string Telefono { get; set; } = null!;

    [InverseProperty("Id_clienteNavigation")]
    public virtual ICollection<recibo_pago> recibo_pagos { get; set; } = new List<recibo_pago>();
}
