using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObservatorioBack.Models
{
    public partial class Detento
    {
        /// <summary>
        /// Consulta um detento pelo seu Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Detento Consultar(int id)
        {
            Detento detento = null;

            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                var detento_ = from Detento d in context.Detentos
                               where d.Id == id
                               select d;

                if (detento_.Count() > 0)
                {
                    detento = detento_.First();
                }
                else throw new NegocioException(NegocioExcCode.DETENTOIDNAOENCONTRADO, id.ToString());
            }
            return detento;
        }

        /// <summary>
        /// Lista detentos com filtro de nome e genitora
        /// </summary>
        /// <returns></returns>
        public static List<Detento> Listar(string nome, string genitora)
        {
            List<Detento> detentos = new List<Detento>();

            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                var detentos_ = from Detento d in context.Detentos
                               where d.Nome.Contains(nome) && d.Genitora.Contains(genitora)
                               select d;

                detentos.AddRange(detentos_.ToList());
            }
            return detentos;
        }

        /// <summary>
        /// Insere um novo detento.
        /// </summary>
        /// <param name="nome"></param>
        public static void Inserir(string nome, string genitor, string genitora,
            string RG, string CPF, int qtdeFilhos, bool possuiMenor, string anotacoes)
        {
            if (genitora == null || genitora.Length == 0)
                throw new NegocioException(NegocioExcCode.DETENTOGENITORAOBRIGATORIA, "");

            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                Detento d = new Detento();
                d.Nome = nome;
                d.Genitor = genitor;
                d.Genitora = genitora;
                d.RG = RG;
                d.CPF = CPF;
                d.QtdeFilhos = qtdeFilhos;
                d.PossuiMenor = possuiMenor;
                d.Anotacoes = anotacoes;

                context.Detentos.Add(d);
                context.SaveChanges();
            }
        }

        public static void Atualizar(int id, string nome, string genitor, string genitora,
            string RG, string CPF, int qtdeFilhos, bool possuiMenor, string anotacoes)
        {
            if (genitora == null || genitora.Length == 0)
                throw new NegocioException(NegocioExcCode.DETENTOGENITORAOBRIGATORIA, "");

            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                var detento_ = from Detento d in context.Detentos
                               where d.Id == id
                               select d;

                if (detento_.Count() > 0)
                {
                    Detento d = detento_.First();
                    d.Nome = nome;
                    d.Genitor = genitor;
                    d.Genitora = genitora;
                    d.RG = RG;
                    d.CPF = CPF;
                    d.QtdeFilhos = qtdeFilhos;
                    d.PossuiMenor = possuiMenor;
                    d.Anotacoes = anotacoes;

                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Remover detento pelo id.
        /// </summary>
        /// <param name="id">Identificação no sistema</param>
        public static void Remover(int id)
        {
            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                //Consulta processos do detento
                var processo_ = from Processo p in context.Processos
                                where p.Detento.Id == id
                                select p;

                if (processo_.Count() > 0)
                {
                    string processosId = "";
                    foreach (Processo p in processo_)
                    {
                        processosId += " " + p.Id;
                    }
                    throw new NegocioException(NegocioExcCode.DETENTOPOSSUIPROCESSO,
                        "[" + processosId + "]");
                }

                var detento_ = from Detento d in context.Detentos
                               where d.Id == id
                               select d;

                if (detento_.Count() > 0)
                {
                    context.Detentos.Remove(detento_.First());
                    context.SaveChanges();
                }
                else throw new NegocioException(NegocioExcCode.DETENTOIDNAOENCONTRADO, id.ToString());
            }
        }


        public static void InserirProcesso(int idDetento, string numero, DateTime dataInicio, 
            string anotacoes, int idJuizo)
        {
            if (numero == null || numero.Length == 0)
                throw new NegocioException(NegocioExcCode.PROCESSONUMOBRIGATORIO, "");

            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                var detento_ = from Detento d in context.Detentos
                               where d.Id == idDetento
                               select d;

                if (detento_.Count() == 0)
                    throw new NegocioException(NegocioExcCode.DETENTOIDNAOENCONTRADO, idDetento.ToString());

                var juizo_ = from Juizo j in context.Juizos
                               where j.Id == idJuizo
                               select j;

                if (juizo_.Count() == 0)
                    throw new NegocioException(NegocioExcCode.JUIZONAOENCONTRADO, idJuizo.ToString());

                Processo p = new Processo();
                p.Numero = numero;
                p.DataInicio = dataInicio;
                p.Detento = detento_.First();
                p.Juizo = juizo_.First();
                p.Anotacoes = anotacoes;

                context.Processos.Add(p);
                context.SaveChanges();
            }
        }

        public static void AtualizarProcesso(int idProcesso, string numero, DateTime dataInicio,
            string anotacoes, int idJuizo)
        {
            if (numero == null || numero.Length == 0)
                throw new NegocioException(NegocioExcCode.PROCESSONUMOBRIGATORIO, "");

            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                var processo_ = from Processo p in context.Processos
                               where p.Id == idProcesso
                               select p;

                if (processo_.Count() == 0)
                    throw new NegocioException(NegocioExcCode.PROCESSONAOENCONTRADO, idProcesso.ToString());

                var juizo_ = from Juizo j in context.Juizos
                             where j.Id == idJuizo
                             select j;

                if (juizo_.Count() == 0)
                    throw new NegocioException(NegocioExcCode.JUIZONAOENCONTRADO, idJuizo.ToString());

                Processo p = processo_.First();
                p.Numero = numero;
                p.DataInicio = dataInicio;
                p.Juizo = juizo_.First();
                p.Anotacoes = anotacoes;

                context.SaveChanges();
            }
        }

        public static void RemoverProcesso(int idProcesso)
        {
            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                var processo_ = from Processo p in context.Processos
                                where p.Id == idProcesso
                                select p;

                if (processo_.Count() == 0)
                    throw new NegocioException(NegocioExcCode.PROCESSONAOENCONTRADO, idProcesso.ToString());

                var acomp_ = from Acompanhamento a in context.Acompanhamentos
                             where a.Processo.Id == idProcesso
                             select a;

                if (acomp_.Count() > 0)
                    throw new NegocioException(NegocioExcCode.PROCESSOPOSSUIACOMP, processo_.First().Numero);

                context.Processos.Remove(processo_.First());
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Retorna a lista de processos de um detento.
        /// </summary>
        /// <param name="idDetento"></param>
        /// <returns></returns>
        public List<Processo> ListarProcessosPorDetento(int idDetento)
        {
            List<Processo> processos = new List<Processo>();

            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                var processo_ = from Processo p in context.Processos
                                where p.Detento.Id == idDetento
                                select p;

                processos.AddRange(processo_);
            }

            return processos;
        }
    }
}