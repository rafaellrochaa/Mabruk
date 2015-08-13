using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mabruk.Models
{
    public class PedidoDetalhe
    {
        public int PedidoDetalheId { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public Produto Produto { get; set; }
        public Pedido Pedido { get; set; }
    }
}