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
    
    public partial class messages
    {
        public int id_message { get; set; }
        public string textmessage { get; set; }
        public int id_user { get; set; }
        public int id_conversation { get; set; }
        public System.DateTime DateCreation { get; set; }
        public System.DateTime DateModification { get; set; }
    }
}