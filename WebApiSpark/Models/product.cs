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
    
    public partial class product
    {
        public int id_produit { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public Nullable<float> prix { get; set; }
        public Nullable<float> fraislivraison { get; set; }
        public string photo1 { get; set; }
        public string photo2 { get; set; }
        public string photo3 { get; set; }
        public Nullable<int> quantitedisponible { get; set; }
        public int idsport { get; set; }
        public System.DateTime DateCreation { get; set; }
        public System.DateTime DateModification { get; set; }
    }
}
