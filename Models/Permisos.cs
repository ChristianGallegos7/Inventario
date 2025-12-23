using System;
using System.Collections.Generic;

namespace Inventario.Models;

public partial class Permisos
{
    public int Idpermiso { get; set; }

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? Fechacreacion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }
}
