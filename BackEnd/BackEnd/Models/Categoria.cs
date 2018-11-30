using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd
{
    public partial class Categoria
    {
        public static List<Categoria> Listar()
        {
            List<Categoria> categorias = new List<Categoria>();
            using (MeuBancoEntities context = new MeuBancoEntities())
            {
                categorias.AddRange(context.Categorias);
            }
            return categorias;
        }
        public static void Inserir(string nome)
        {
            using (MeuBancoEntities context = new MeuBancoEntities())
            {
                Categoria c = new Categoria();
                c.Nome = nome;

                context.Categorias.Add(c);
                context.SaveChanges();
            }
        }
        public static void Atualizar(int id, string nome)
        {
            using (MeuBancoEntities context = new MeuBancoEntities())
            {
                var categoria_ = from Categoria c in context.Categorias
                                 where c.Id == id
                                 select c;
                if (categoria_.Count() > 0)
                {
                    Categoria c = categoria_.First();
                    c.Nome = nome;
                    context.SaveChanges();
                }
                else
                    throw new Exception("");
            }
        }

        public static Categoria Consultar(int id)
        {
            Categoria categoria = null;
            using (MeuBancoEntities context = new MeuBancoEntities())
            {
                var categoria_ = from Categoria c in context.Categorias
                                 where c.Id == id
                                 select c;
                if (categoria_.Count() > 0)
                {
                    categoria = categoria_.First();
                }

                else
                    throw new Exception("Id não encontrado");
            }
            return categoria;
        }

        public static bool Remover(int id)
        {
            using (MeuBancoEntities context = new MeuBancoEntities())
            {
                var categoria_ = from Categoria c in context.Categorias
                                 where c.Id == id
                                 select c;
                if (categoria_.Count() > 0)
                {
                    context.Categorias.Remove(categoria_.First());
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}