using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TAREAS_AGAMVC.Models;

public partial class Colaborador
{
    public int IdCol { get; set; }

    [Display(Name = "Nombre ")]
    public string NombreCol { get; set; } = null!;

    [Display(Name = "Apellido Paterno")]
    public string? APaternoCol { get; set; }

    [Display(Name = "Apellido Materno")]
    public string? AMaternoCol { get; set; }
        

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
