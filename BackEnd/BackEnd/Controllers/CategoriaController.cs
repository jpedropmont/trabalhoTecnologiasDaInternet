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
    public class CategoriaController : ApiController
    {
        public IHttpActionResult Get()
        {
            CategoriaResponse cResponse = new CategoriaResponse();
            cResponse.Categorias = new List<CategoriaTO>();
            try
            {
                List<Categoria> categorias = Categoria.Listar();
                foreach (Categoria c in categorias)
                {
                    CategoriaTO cTO = new CategoriaTO();
                    cTO.Id = c.Id;
                    cTO.Nome = c.Nome;
                    cResponse.Categorias.Add(cTO);
                }

            }
            catch (Exception ex)
            {
                cResponse.Status = -1;
                cResponse.Descricao = ex.Message;
            }
            return Ok(cResponse);
        }

        public IHttpActionResult Get(int id)
        {
            CategoriaResponse cResponse = new CategoriaResponse();
            cResponse.Categorias = new List<CategoriaTO>();
            try
            {
                Categoria categoria = Categoria.Consultar(id);
                
                    CategoriaTO cTO = new CategoriaTO();
                    cTO.Id = categoria.Id;
                    cTO.Nome = categoria.Nome;
                    cResponse.Categorias.Add(cTO);
                
            }
            catch (Exception ex)
            {
                cResponse.Status = -1;
                cResponse.Descricao = ex.Message;
            }
            return Ok(cResponse);
        }

        public IHttpActionResult Post([FromBody] CategoriaTO cTO)
        {
            CategoriaResponse cResponse = new CategoriaResponse();
            cResponse.Categorias = new List<CategoriaTO>();
            try
            {
                Categoria.Inserir(cTO.Nome);
            }
            catch (Exception ex)
            {
                cResponse.Status = -1;
                cResponse.Descricao = ex.Message;
            }
            return Ok(cResponse);
        }

        public IHttpActionResult Put (int id, [FromBody] CategoriaTO categoria)
        {
            CategoriaResponse cResponse = new CategoriaResponse();

            try
            {
                Categoria.Atualizar(id, categoria.Nome);
            }
            catch (Exception ex)
            {
                cResponse.Status = -1;
                cResponse.Descricao = ex.Message;
            }

            return Ok(cResponse);
        }


        public IHttpActionResult Delete (int id)
        {
            CategoriaResponse cResponse = new CategoriaResponse();

            try
            {
                Categoria.Remover(id);
            }
            catch (Exception ex)
            {
                cResponse.Status = -1;
                cResponse.Descricao = ex.Message;
            }

            return Ok(cResponse);
        }
    }
}