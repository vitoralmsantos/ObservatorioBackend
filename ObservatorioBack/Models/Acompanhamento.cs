//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ObservatorioBack.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Acompanhamento
    {
        public int Id { get; set; }
        public System.DateTime DataInicio { get; set; }
        public System.DateTime DataFim { get; set; }
        public string Comentario { get; set; }
    
        public virtual Processo Processo { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Acompanhamento AcompanhamentoDestino { get; set; }
        public virtual Acompanhamento AcompanhamentoOrigem { get; set; }
    }
}
