using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mabruk.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
        public DateTime PedidoData { get; set; }
        public List<Produto> Produto { get; set; }
        public List<PedidoDetalhe> PedidoDetalhe { get; set; }
    }
}