
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
    
public partial class strengthTest
{

    public int id { get; set; }

    public double maxRepetitionWeightValue { get; set; }

    public int strengthTestTypeId { get; set; }

    public Nullable<int> sessionId { get; set; }

    public int coachId { get; set; }

    public int athleteId { get; set; }

    public System.DateTime date { get; set; }

    public bool available { get; set; }



    [Newtonsoft.Json.JsonIgnore] public virtual athelete athelete { get; set; }

    [Newtonsoft.Json.JsonIgnore] public virtual coach coach { get; set; }

    [Newtonsoft.Json.JsonIgnore] public virtual session session { get; set; }

    public virtual strengthTestType strengthTestType { get; set; }

}

}
