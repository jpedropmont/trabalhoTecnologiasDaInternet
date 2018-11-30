using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd
{
    public partial class Produto
    {
        public static List<Produto> Listar()
        {
            List<Produto> produtos = new List<Produto>();
            using (MeuBancoEntities context = new MeuBancoEntities())
            {
                produtos.AddRange(context.Produtos);
            }
            return produtos;
        }

        public static void Inserir(string marca, string modelo, string motor, string cor, double valor)
        {
            using (MeuBancoEntities context = new MeuBancoEntities())
            {
                Produto produto = new Produto
                {
                    Marca = marca,
                    Modelo = modelo,
                    Motor = motor,
                    Cor = cor,
                    Valor = valor
                };
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        public static void Atualizar (int id, string marca, string modelo, string motor, string cor, double valor)
        {
            using (MeuBancoEntities context = new MeuBancoEntities())
            {
                var produto_ = from Produto p in context.Produtos
                               where p.Id == id
                               select p;
                if (produto_.Count() > 0)
                {
                    Produto p = produto_.First();
                    p.Marca = marca;
                    p.Modelo = modelo;
                    p.Motor = motor;
                    p.Cor = cor;
                    p.Valor = valor;
                    context.SaveChanges();
                }
                else
                    throw new Exception("Não existe esse produto no estoque.");
            }
        }

        public static bool Remover (int id)
        {
            using (MeuBancoEntities context = new MeuBancoEntities())
            {
                var produto_ = from Produto p in context.Produtos
                               where p.Id == id
                               select p;

                if (produto_.Count() > 0)
                {
                    context.Produtos.Remove(produto_.First());
                    return true;
                }
                else {
                    return false;
                    throw new Exception("Não existe esse produto no estoque.");                    
                }
            }
        }

        public static Produto Consultar (int id)
        {
            Produto produto = null;
            using(MeuBancoEntities context = new MeuBancoEntities()) { 
                var produto_ = from p in context.Produtos
                               where p.Id == id
                               select p;
                if(produto_.Count() > 0)
                {
                    produto = produto_.First();
                }
                else
                {
                    throw new Exception("Id não encontrado.");
                }
            }
            return produto;
        }
    }
}