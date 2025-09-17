using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

[PrimaryKey("recibo_pago_Id_recibo", "recibo_pago_Persona", "metodo_de_pago_Id_metodo")]
[Table("recibo_pago_has_metodo")]
public partial class recibo_pago_has_metodo
{
    [Key]
    public int recibo_pago_Id_recibo { get; set; }

    [Key]
    public int recibo_pago_Persona { get; set; }

    [Key]
    [StringLength(5)]
    [Unicode(false)]
    public string metodo_de_pago_Id_metodo { get; set; } = null!;

    [ForeignKey("metodo_de_pago_Id_metodo")]
    [InverseProperty("recibo_pago_has_metodos")]
    public virtual metodo_de_pago metodo_de_pago_Id_metodoNavigation { get; set; } = null!;

    [ForeignKey("recibo_pago_Id_recibo")]
    [InverseProperty("recibo_pago_has_metodos")]
    public virtual recibo_pago recibo_pago_Id_reciboNavigation { get; set; } = null!;

    [ForeignKey("recibo_pago_Persona")]
    [InverseProperty("recibo_pago_has_metodos")]
    public virtual persona recibo_pago_PersonaNavigation { get; set; } = null!;
}
