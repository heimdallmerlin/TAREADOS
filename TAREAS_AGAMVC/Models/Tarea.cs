using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TAREAS_AGAMVC.Models;

public partial class Tarea
{
    
    public int IdTar { get; set; }

    [Display(Name = "Tarea")]
    public string NombreTar { get; set; } = null!;

    [Display(Name = "Descripción")]
    public string? DescripcionTar { get; set; }

    [Display(Name = "Estatus")]
    public string EstatusTar { get; set; } = null!;

    public int IdCol { get; set; }
    public int IdCat { get; set; }

    [Display(Name = "Colaborador Asignado")]
    public virtual Categoria IdCatNavigation { get; set; } = null!;


    [Display(Name = "Categoria")]
    public virtual Colaborador IdColNavigation { get; set; } = null!;
}
