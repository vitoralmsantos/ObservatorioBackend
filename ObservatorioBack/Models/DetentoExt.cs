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
                //CONSULTAR OS PROCESSOS ANTES DE REMOVER; GERA EXCEÇÃO SE EXISTIR


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
    }
}