using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

public partial class proveedore
{
    [Key]
    public int Id_Proveedor { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? nombreProveedor { get; set; }

    [StringLength(45)]
    [Unicode(false)]
    public string? direccionProveedor { get; set; }

    public int? telefonoProveedor { get; set; }

    [StringLength(45)]
    [Unicode(false)]
    public string? correoProveedor { get; set; }

    [InverseProperty("ProveedorNavigation")]
    public virtual ICollection<producto> productos { get; set; } = new List<producto>();
}
