//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiSpark.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class clubs
    {
        public int id { get; set; }
        public string nom { get; set; }
        public Nullable<int> idcontact { get; set; }
        public string logo { get; set; }
        public Nullable<int> idsport { get; set; }
        public System.DateTime DateCreation { get; set; }
        public System.DateTime DateModification { get; set; }
    }
}