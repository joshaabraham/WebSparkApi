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
    
    public partial class calendrierdisponibilite
    {
        public int idcalendrier { get; set; }
        public int iduser { get; set; }
        public short lundimatin { get; set; }
        public short lundiapmidi { get; set; }
        public short lundisoir { get; set; }
        public short mardimatin { get; set; }
        public short mardiapmidi { get; set; }
        public short mardisoir { get; set; }
        public short mercredimatin { get; set; }
        public short mercrediapmidi { get; set; }
        public short mercredisoir { get; set; }
        public short jeudimatin { get; set; }
        public short jeudiapmidi { get; set; }
        public short jeudisoir { get; set; }
        public short vendredimatin { get; set; }
        public short vendrediapmidi { get; set; }
        public short vendredisoir { get; set; }
        public short weekendmatin { get; set; }
        public short weekendapmidi { get; set; }
        public short weekendsoir { get; set; }
        public System.DateTime DateModification { get; set; }
    }
}
