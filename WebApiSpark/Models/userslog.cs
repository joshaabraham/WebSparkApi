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
    
    public partial class userslog
    {
        public int id { get; set; }
        public string photo { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string sex { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string adresse { get; set; }
        public string lattitude { get; set; }
        public string longitude { get; set; }
        public Nullable<int> idpersonne { get; set; }
        public Nullable<int> idcontact { get; set; }
        public System.DateTime DateCreation { get; set; }
        public System.DateTime DateModification { get; set; }
        public string age { get; set; }
    }
}
