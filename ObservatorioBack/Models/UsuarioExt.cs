using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObservatorioBack.Models
{
    public partial class Usuario
    {
        public static Usuario Consultar(int id)
        {
            Usuario usuario = null;

            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                var usuario_ = from Usuario d in context.Usuarios
                               where d.Id == id
                               select d;

                if (usuario_.Count() > 0)
                {
                    usuario = usuario_.First();
                }
            }
            return usuario;
        }

        public static List<Usuario> Listar()
        {
            List<Usuario> usuarios = null;

            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                usuarios = context.Usuarios.ToList();
            }
            return usuarios;
        }

        public static void Inserir(string nome)
        {
            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                Usuario d = new Usuario();
                d.Nome = nome;

                context.Usuarios.Add(d);
                context.SaveChanges();
            }
        }

        public static void Atualizar(int id, string nome)
        {
            using (ObservatorioEntities context = new ObservatorioEntities())
            {
                var usuario_ = from Usuario d in context.Usuarios
                               where d.Id == id
                               select d;

                if (usuario_.Count() > 0)
                {
                    usuario_.First().Nome = nome;
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


                var usuario_ = from Usuario d in context.Usuarios
                               where d.Id == id
                               select d;

                if (usuario_.Count() > 0)
                {
                    context.Usuarios.Remove(usuario_.First());
                    context.SaveChanges();
                }
            }
        }
    }
}