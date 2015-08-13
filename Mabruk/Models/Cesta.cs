using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mabruk.Models
{
    public class Cesta
    {
        //ref: http://www.macoratti.net/Cursos/aspnmvc/aspn_558.htm
        [Key]
        public int RegistroId { get; set; }
        public string CestaId { get; set; }
        public int ProdutoId { get; set; }
        public int Contador { get; set; }
        public DateTime DataCriacao { get; set; }
        public Produto Produto { get; set; }
        private Produto produto { get; set; }
    }
}