using System;
using System.Collections.Generic;

namespace Inventario.Models;

public partial class Rolpermiso
{
    public int? Idrol { get; set; }

    public int? Idpermiso { get; set; }

    public virtual Permisos? IdpermisoNavigation { get; set; }

    public virtual Roles? IdrolNavigation { get; set; }
}
