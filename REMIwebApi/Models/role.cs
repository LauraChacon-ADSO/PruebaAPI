using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace REMIwebApi.Models;

public partial class role
{
    [Key]
    public int Id_Rol { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Desc_rol { get; set; } = null!;

    [ForeignKey("roles_Id_Rol")]
    [InverseProperty("roles_Id_Rols")]
    public virtual ICollection<persona> persona_Id_Personas { get; set; } = new List<persona>();
}
