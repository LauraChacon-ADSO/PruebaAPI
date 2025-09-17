using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

[Table("tipo_documento")]
public partial class tipo_documento
{
    [Key]
    [StringLength(5)]
    [Unicode(false)]
    public string Id_tdoc { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string Desc_tdoc { get; set; } = null!;

    public byte Estado { get; set; }

    [InverseProperty("tipoDocNavigation")]
    public virtual ICollection<persona> personas { get; set; } = new List<persona>();
}
