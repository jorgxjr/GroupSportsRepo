
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
    
public partial class competitionSprintsTest
{

    public int id { get; set; }

    public double meters { get; set; }

    public int athleteId { get; set; }

    public int competitionByCoachId { get; set; }

    public System.DateTime date { get; set; }

    public bool validity { get; set; }

    public int hours { get; set; }

    public int minutes { get; set; }

    public int seconds { get; set; }

    public int milliseconds { get; set; }

    public bool available { get; set; }



    [Newtonsoft.Json.JsonIgnore] public virtual athelete athelete { get; set; }

    [Newtonsoft.Json.JsonIgnore] public virtual competitionByCoach competitionByCoach { get; set; }

}

}
