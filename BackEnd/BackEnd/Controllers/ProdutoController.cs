using BackEnd.Controllers.Responses;
using BackEnd.Controllers.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BackEnd.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProdutoController : ApiController
    {
        public IHttpActionResult Get()
        {
            ProdutoResponse pResponse = new ProdutoResponse();
            pResponse.Produtos = new List<ProdutoTO>();
            try
            {
                List<Produto> produtos = Produto.Listar();
                foreach (Produto p in produtos)
                {
                    ProdutoTO pTO = new ProdutoTO();
                    pTO.Id = p.Id;
                    pTO.Marca = p.Marca;
                    pTO.Modelo = p.Modelo;
                    pTO.Motor = p.Motor;
                    pTO.Valor = p.Valor;

                    pResponse.Produtos.Add(pTO);
                }

            }
            catch (Exception ex)
            {
                pResponse.Status = -1;
                pResponse.Descricao = ex.Message;
            }
            return Ok(pResponse);
        }

        public IHttpActionResult Get(int id)
        {
            ProdutoResponse pResponse = new ProdutoResponse();
            pResponse.Produtos = new List<ProdutoTO>();
            try
            {
                Produto produto = Produto.Consultar(id);
                
                    ProdutoTO pTO = new ProdutoTO();
                    pTO.Id = produto.Id;
                    pTO.Marca = produto.Marca;
                    pTO.Modelo = produto.Modelo;
                    pTO.Motor = produto.Motor;
                    pTO.Valor = produto.Valor;

                    pResponse.Produtos.Add(pTO);

            }
            catch (Exception ex)
            {
                pResponse.Status = -1;
                pResponse.Descricao = ex.Message;
            }
            return Ok(pResponse);
        }

        public IHttpActionResult Post([FromBody] ProdutoTO pTO)
        {
            ProdutoResponse pResponse = new ProdutoResponse();
            pResponse.Produtos = new List<ProdutoTO>();
            try
            {
                Produto.Inserir(pTO.Marca, pTO.Modelo, pTO.Motor, pTO.Cor, pTO.Valor);
            }
            catch (Exception ex)
            {
                pResponse.Status = -1;
                pResponse.Descricao = ex.Message;
            }
            return Ok(pResponse);
        }

        public IHttpActionResult Put(int id, [FromBody] ProdutoTO produto)
        {
            ProdutoResponse pResponse = new ProdutoResponse();

            try
            {
                Produto.Atualizar(id, produto.Marca, produto.Modelo, produto.Motor, produto.Cor, produto.Valor);
            }
            catch (Exception ex)
            {
                pResponse.Status = -1;
                pResponse.Descricao = ex.Message;
            }

            return Ok(pResponse);
        }


        public IHttpActionResult Delete(int id)
        {
            ProdutoResponse pResponse = new ProdutoResponse();

            try
            {
                Produto.Remover(id);
            }
            catch (Exception ex)
            {
                pResponse.Status = -1;
                pResponse.Descricao = ex.Message;
            }

            return Ok(pResponse);
        }
    }
}