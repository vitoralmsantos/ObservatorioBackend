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
        DETENTOIDNAOENCONTRADO = 2001,
        DETENTOGENITORAOBRIGATORIA = 2002,
        DETENTOPOSSUIPROCESSO = 2003,
        PROCESSONUMOBRIGATORIO = 3001,
        PROCESSONAOENCONTRADO = 3002,
        PROCESSOPOSSUIACOMP = 3003,
        PROCESSODATAOBRIGATORIA = 3004,
        JUIZONAOENCONTRADO = 4001
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
                    case NegocioExcCode.DETENTOIDNAOENCONTRADO:
                        return "Detento não encontrado: " + Detalhe;
                    case NegocioExcCode.DETENTOGENITORAOBRIGATORIA:
                        return "O nome da genitora é obrigatório";
                    case NegocioExcCode.DETENTOPOSSUIPROCESSO:
                        return "Detento não pode ser excluído pois possui processos: " + Detalhe;
                    case NegocioExcCode.PROCESSONUMOBRIGATORIO:
                        return "O número do processo é obrigatório";
                    case NegocioExcCode.PROCESSONAOENCONTRADO:
                        return "Processo não encontrado: " + Detalhe;
                    case NegocioExcCode.PROCESSOPOSSUIACOMP:
                        return "Processo possui acompanhamentos cadastrados: " + Detalhe;
                    case NegocioExcCode.PROCESSODATAOBRIGATORIA:
                        return "A data do processo é obrigatória";
                    case NegocioExcCode.JUIZONAOENCONTRADO:
                        return "Juizo não encontrado: " + Detalhe;
                    default: return "Erro desconhecido";
                }
            }
        }
    }
}