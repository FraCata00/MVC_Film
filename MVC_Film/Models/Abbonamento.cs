//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Film.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Abbonamento
    {
        public int ID { get; set; }
        public int IdAccount { get; set; }
        public int IdMetodoPagamento { get; set; }
        public int GiorniAbbonamento { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual MetodoPagamento MetodoPagamento { get; set; }
    }
}