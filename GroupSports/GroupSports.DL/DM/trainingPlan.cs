
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace GroupSports.DL.DM
{

using System;
    using System.Collections.Generic;
    
public partial class trainingPlan
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public trainingPlan()
    {

        this.mesocycle = new HashSet<mesocycle>();

    }


    public int id { get; set; }

    public string name { get; set; }

    public Nullable<System.DateTime> startDate { get; set; }

    public Nullable<System.DateTime> endDate { get; set; }

    public int coachId { get; set; }

    public int athleteId { get; set; }

    public bool available { get; set; }



    public virtual athelete athelete { get; set; }

    [Newtonsoft.Json.JsonIgnore] public virtual coach coach { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    [Newtonsoft.Json.JsonIgnore] public virtual ICollection<mesocycle> mesocycle { get; set; }

}

}
