using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObservatorioBack.Models
{
    public enum NegocioExcCode
    {
        ERRODESCONHECIDO = 1,
        AUTENTICACAO = 1001,
        DETENTOPOSSUIPROCESSO = 2001

        
    }

    public class NegocioException : Exception
    {
        private string Detalhe { get; }
        public NegocioExcCode Codigo { get; }

        public NegocioException(NegocioExcCode codigo, string detalhe)
            : base(detalhe)
        {
            this.Codigo = codigo;
            this.Detalhe = detalhe;
        }

        public override string Message
        {
            get
            {
                switch (Codigo)
                {
                    case NegocioExcCode.ERRODESCONHECIDO:
                        return "Erro desconhecido: " + Detalhe;
                    case NegocioExcCode.AUTENTICACAO:
                        return "Não foi possível realizar sua autenticação: " + Detalhe;
                    case NegocioExcCode.DETENTOPOSSUIPROCESSO:
                        return "Detento não pode ser excluído pois possui processos: " + Detalhe;
                    default: return "Erro desconhecido";
                }
            }
        }
    }
}