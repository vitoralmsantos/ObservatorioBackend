using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObservatorioBack.Models
{
    public partial class Processo
    {
        public static Processo Consultar(int id)
        {
            Processo processo = null;

            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                var processo_ = from Processo p in context.Processos
                                where p.Id == id
                                select p;

                if (processo_.Count() > 0)
                {
                    processo = processo_.First();
                }
            }
            return processo;
        }

        public static List<Processo> Listar()
        {
            List<Processo> processo = null;

            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                processos = context.Processos.ToList();
            }
            return processos;
        }

        public static void Inserir(int numero, DateTime date)
        {
            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                Processo p = new Processo();
                p.Numero = numero;
                p.DataInicio = date;

                context.Processos.Add(p);
                context.SaveChanges();
            }
        }

        public static void Atualizar(int id, int numero, DateTime date)
        {
            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                var processo_ = from Processo p in context.Processos
                                where p.Id == id
                                select p;

                if (processo_.Count() > 0)
                {
                    processo_.First().Numero = numero;
                    processo_.First().DataInicio = date;
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Remover processo pelo id.
        /// </summary>
        /// <param name="id">Identificação no sistema</param>
        public static void Remover(int id)
        {
            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                //CONSULTAR OS PROCESSOS ANTES DE REMOVER; GERA EXCEÇÃO SE EXISTIR


                var processo_ = from Processo p in context.Processos
                                where p.Id == id
                                select p;

                if (processo_.Count() > 0)
                {
                    context.Processos.Remove(processo_.First());
                    context.SaveChanges();
                }
            }
        }
    }
}