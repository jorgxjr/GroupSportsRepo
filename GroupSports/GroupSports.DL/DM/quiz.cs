
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
    
public partial class quiz
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public quiz()
    {

        this.athleteQuiz = new HashSet<athleteQuiz>();

        this.quizQuestion = new HashSet<quizQuestion>();

    }


    public int id { get; set; }

    public int coachId { get; set; }

    public string quizTitle { get; set; }

    public System.DateTime date { get; set; }

    public bool available { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    [Newtonsoft.Json.JsonIgnore] public virtual ICollection<athleteQuiz> athleteQuiz { get; set; }

    [Newtonsoft.Json.JsonIgnore] public virtual coach coach { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    [Newtonsoft.Json.JsonIgnore] public virtual ICollection<quizQuestion> quizQuestion { get; set; }

}

}
