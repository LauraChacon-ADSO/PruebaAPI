using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

[Table("metodo_de_pago")]
public partial class metodo_de_pago
{
    [Key]
    [StringLength(5)]
    [Unicode(false)]
    public string Id_metodo { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Desc_metodo { get; set; }

    [InverseProperty("metodo_de_pago_Id_metodoNavigation")]
    public virtual ICollection<recibo_pago_has_metodo> recibo_pago_has_metodos { get; set; } = new List<recibo_pago_has_metodo>();
}
