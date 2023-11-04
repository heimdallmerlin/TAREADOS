using System;
using System.Collections.Generic;

namespace TAREAS_AGAMVC.Models;

public partial class Categoria
{
    public int IdCat { get; set; }

    public string NombreCat { get; set; } = null!;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
