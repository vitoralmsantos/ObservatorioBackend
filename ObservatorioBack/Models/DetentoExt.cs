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
            }
            return detento;
        }

        /// <summary>
        /// Lista todos os detentos.
        /// </summary>
        /// <returns></returns>
        public static List<Detento> Listar()
        {
            List<Detento> detentos = null;

            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                detentos = context.Detentos.ToList();
            }
            return detentos;
        }

        /// <summary>
        /// Insere um novo detento.
        /// </summary>
        /// <param name="nome"></param>
        public static void Inserir(string nome)
        {
            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                Detento d = new Detento();
                d.Nome = nome;

                context.Detentos.Add(d);
                context.SaveChanges();
            }
        }

        public static void Atualizar(int id, string nome)
        {
            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                var detento_ = from Detento d in context.Detentos
                               where d.Id == id
                               select d;

                if (detento_.Count() > 0)
                {
                    detento_.First().Nome = nome;
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
                //Consulta processo do detento
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