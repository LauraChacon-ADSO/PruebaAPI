using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

public partial class categoria
{
    [Key]
    [StringLength(5)]
    [Unicode(false)]
    public string Id_categoria { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string? nombreCat { get; set; }

    [InverseProperty("CategoriaNavigation")]
    public virtual ICollection<subcategoria> subcategoria { get; set; } = new List<subcategoria>();
}
