using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

public partial class subcategoria
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string Id_subcategoria { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string? nombreSub { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string Categoria { get; set; } = null!;

    [ForeignKey("Categoria")]
    [InverseProperty("subcategoria")]
    public virtual categoria CategoriaNavigation { get; set; } = null!;

    [InverseProperty("SubcategoriaNavigation")]
    public virtual ICollection<producto> productos { get; set; } = new List<producto>();
}
