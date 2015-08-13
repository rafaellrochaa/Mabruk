using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mabruk.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public int TipoProdutoId { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public int IdTipoProduto { get; set; }
        public bool Ativo { get; set; }
        public decimal Preco { get; set; }
    }
}