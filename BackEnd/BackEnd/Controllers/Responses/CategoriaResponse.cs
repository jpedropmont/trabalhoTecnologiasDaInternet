using BackEnd.Controllers.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Controllers.Responses
{
    public class CategoriaResponse : BaseResponses
    {
        public List<CategoriaTO> Categorias { get; set; }
    }
}