
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
    
public partial class atheleteByTeam
{

    public int id { get; set; }

    public int atheleteId { get; set; }

    public int teamId { get; set; }

    public bool available { get; set; }



    [Newtonsoft.Json.JsonIgnore] public virtual athelete athelete { get; set; }

    [Newtonsoft.Json.JsonIgnore] public virtual team team { get; set; }

}

}
