using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Controllers.TransferObjects
{
    public class ProdutoTO
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Motor { get; set; }
        public string Cor { get; set; }
        public double Valor { get; set; }
    }
}