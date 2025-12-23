using System;
using System.Collections.Generic;

namespace Inventario.Models;

public partial class Usuariorol
{
    public int Idusuario { get; set; }

    public int Idrol { get; set; }

    public DateTime? Fechaasignacion { get; set; }

    public virtual Roles IdrolNavigation { get; set; } = null!;

    public virtual Usuarios IdusuarioNavigation { get; set; } = null!;
}
