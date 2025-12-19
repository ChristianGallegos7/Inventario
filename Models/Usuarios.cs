using System;
using System.Collections.Generic;

namespace Inventario.Models;

public partial class Usuarios
{
    public int Idusuario { get; set; }

    public string Identificacion { get; set; } = null!;

    public string Primernombre { get; set; } = null!;

    public string? Segundonombre { get; set; }

    public string Primerapellido { get; set; } = null!;

    public string? Segundoapellido { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string Nombreusuario { get; set; } = null!;

    public string Clavehash { get; set; } = null!;

    public bool Activo { get; set; }

    public int Intentosfallidos { get; set; }

    public DateTime Fechacreacion { get; set; }

    public DateTime Fechaactualizacion { get; set; }

    public DateTime? Bloqueadohasta { get; set; }

    public virtual ICollection<Usuariorol> Usuariorol { get; set; } = new List<Usuariorol>();
}
