
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
    
public partial class competitionThrowsTest
{

    public int id { get; set; }

    public int competitionThrowsTestTypeId { get; set; }

    public double resutMeters { get; set; }

    public double weight { get; set; }

    public int athleteId { get; set; }

    public int competitionByCoachId { get; set; }

    public System.DateTime date { get; set; }

    public bool validity { get; set; }

    public bool available { get; set; }



    [Newtonsoft.Json.JsonIgnore] public virtual athelete athelete { get; set; }

    [Newtonsoft.Json.JsonIgnore] public virtual competitionByCoach competitionByCoach { get; set; }

    [Newtonsoft.Json.JsonIgnore] public virtual competitionThrowsTestType competitionThrowsTestType { get; set; }

}

}
