
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
    
public partial class anthropometricTest
{

    public int id { get; set; }

    public string size { get; set; }

    public double weight { get; set; }

    public double wingspan { get; set; }

    public double bodyFatPercentage { get; set; }

    public double leanBodyPercentage { get; set; }

    public int athleteId { get; set; }

    public int coachId { get; set; }

    public System.DateTime date { get; set; }

    public bool available { get; set; }



    [Newtonsoft.Json.JsonIgnore] public virtual athelete athelete { get; set; }

    [Newtonsoft.Json.JsonIgnore] public virtual coach coach { get; set; }

}

}
