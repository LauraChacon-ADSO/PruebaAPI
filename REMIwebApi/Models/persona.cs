using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

[Table("persona")]
public partial class persona
{
    [Key]
    public int Id_Persona { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? primerNombre { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? segundoNombre { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? primerApellido { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? segundoApellido { get; set; }

    [StringLength(45)]
    [Unicode(false)]
    public string? Correo { get; set; }

    public long? TelefonoCel { get; set; }

    [MaxLength(130)]
    public byte[]? Contrasena { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string tipoDoc { get; set; } = null!;

    [InverseProperty("recibo_pago_PersonaNavigation")]
    public virtual ICollection<recibo_pago_has_metodo> recibo_pago_has_metodos { get; set; } = new List<recibo_pago_has_metodo>();

    [InverseProperty("PersonaNavigation")]
    public virtual ICollection<recibo_pago> recibo_pagos { get; set; } = new List<recibo_pago>();

    [ForeignKey("tipoDoc")]
    [InverseProperty("personas")]
    public virtual tipo_documento tipoDocNavigation { get; set; } = null!;

    [ForeignKey("persona_Id_Persona")]
    [InverseProperty("persona_Id_Personas")]
    public virtual ICollection<role> roles_Id_Rols { get; set; } = new List<role>();
}
