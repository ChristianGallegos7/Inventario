using System;
using System.Collections.Generic;

namespace Inventario.Models;

public partial class Roles
{
    public int Idrol { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }

    public virtual ICollection<Usuariorol> Usuariorol { get; set; } = new List<Usuariorol>();
}
