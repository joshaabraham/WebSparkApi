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
    
    public partial class commande
    {
        public int id_commande { get; set; }
        public string guid { get; set; }
        public int id_client { get; set; }
        public int id_fournisseur { get; set; }
        public System.DateTime dateminlivraison { get; set; }
        public System.DateTime datemaxlivraison { get; set; }
        public float montanttotal { get; set; }
        public int id_listproduitsachete { get; set; }
        public System.DateTime DateCreation { get; set; }
        public System.DateTime Datemodification { get; set; }
    }
}
