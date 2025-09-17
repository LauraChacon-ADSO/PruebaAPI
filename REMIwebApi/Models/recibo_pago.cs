using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

[Table("recibo_pago")]
public partial class recibo_pago
{
    [Key]
    public int Id_recibo { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? nombreNegocio { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    public DateOnly? Fecha { get; set; }

    public double? Total { get; set; }

    public int Persona { get; set; }

    public int? Id_cliente { get; set; }

    [ForeignKey("Id_cliente")]
    [InverseProperty("recibo_pagos")]
    public virtual cliente? Id_clienteNavigation { get; set; }

    [ForeignKey("Persona")]
    [InverseProperty("recibo_pagos")]
    public virtual persona PersonaNavigation { get; set; } = null!;

    [InverseProperty("recibo_pago_Id_reciboNavigation")]
    public virtual ICollection<recibo_pago_has_metodo> recibo_pago_has_metodos { get; set; } = new List<recibo_pago_has_metodo>();

    [InverseProperty("reciboPagoNavigation")]
    public virtual ICollection<recibo_producto> recibo_productos { get; set; } = new List<recibo_producto>();
}
