using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mabruk.Models
{
    public class CestaCompras
    {
       // public Entities Database { get; set; }
        private string CestaComprasId { get; set; }
        public const string CestaSessionKey = "CestaId";
        
        public CestaCompras GetCesta(HttpContextBase context)
        {
            CestaCompras cesta = new CestaCompras();
            cesta.CestaComprasId = cesta.GetCestaId(context);

            return cesta;
        }
        //Método Helper para simplificar as chamadas a cesta de compras
        public CestaCompras GetCesta(Controller controller)
        {
            CestaCompras cesta = new CestaCompras();
            return GetCesta(controller.HttpContext);
        }

        public void AdicionarNaCesta(Produto produto)
        {
            var cestaItem = new Cesta();//Database.Cestas.SingleOrDefault(c => c.CestaId = CestaComprasId && c.ProdutoId = Produto.ProdutoId);

            if (cestaItem == null)
            {
                //Cria novo item na cesta caso não exista
                cestaItem = new Cesta()
                {
                    ProdutoId = produto.ProdutoId,
                    CestaId = CestaComprasId,
                    Contador = 1,
                    DataCriacao = DateTime.Now
                };
                //Database.Cestas.Add(cestaItem);
            }
            else
            {
                cestaItem.Contador += 1;
            }

            //Database.SaveChanges();
        }

        public int RemoveDaCesta(int id)
        {
            var cestaItem = new Cesta();//Database.Cestas.Single(c => c.CestaId = CestaComprasId && c.RegistroId = id);
            int contaItem = 0;

            if(cestaItem == null)
            {
                if (cestaItem.Contador > 1)
                {
                    cestaItem.Contador -= 1;
                    contaItem = cestaItem.Contador;
                }
                else
                {
                   // Database.Cestas.Remove(cestaItem);
                }
            }
           // Database.SaveChanges();

            return contaItem;
        }

        public void EsvaziaCesta()
        {
            var cestaItens = new List<Cesta>();//Database.Cestas.Where(c => c.CestaId == CestaComprasId);
            foreach (var cestaItem in cestaItens)
            {
                //Database.Cestas.Remove(cestaItem);
            }
            //Database.SaveChanges();
        }

        public List<Cesta> GetItensDaCesta()
        {
            return new List<Cesta>();// Database.Cestas.Where(c => c.CestaId == CestaComprasId).ToList();
        }

        public int GetContador()
        {
            int? conta = 1;
                //(
                //    from cestaItens in Database.Cestas
                //    where cestaItens.CestaId == CestaComprasId
                //    select (int?)cestaItens.Contador).Sum();
            return conta == null ? 0 : (int)conta;
        }

        public decimal GetTotal()
        {
            decimal? total = null;
                //(
                //    from cartItens in Database.Cestas
                //    where cartItens.CestaId == CestaComprasId
                //    select (decimal?)cartItens.Contador * cartItens.Produto.Preco).Sum();
            return total == null ? decimal.Zero : (decimal)total;
        }

        public int CriaPedido(Pedido pedido)
        {
            decimal pedidoTotal = 0;
            var cestaItens = GetItensDaCesta();

            foreach (var item in cestaItens)
            {
                var pedidoDetalhe = new PedidoDetalhe()
                {
                    ProdutoId = item.ProdutoId,
                    PedidoId = pedido.PedidoId,
                    PrecoUnitario = item.Produto.Preco,
                    Quantidade = item.Contador
                };
                pedidoTotal += (item.Contador * item.Produto.Preco);
               // Database.PedidoDetalhes.Add(pedidoDetalhe);
            }

            pedido.Total = pedidoTotal;
           // Database.SaveChanges();
            EsvaziaCesta();

            return pedido.PedidoId;
        }
        // HttpContextBase para permitir o acesso aos cookies
        public string GetCestaId(HttpContextBase context)
        {
            if (context.Session[CestaSessionKey] == null)
            {
                if (!String.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CestaSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCestaId = Guid.NewGuid();
                    context.Session[CestaSessionKey] = tempCestaId.ToString();
                }
            }
            return context.Session[CestaSessionKey].ToString();
        }

        // Quando o usuário que estiver logado migrar sua cesta para um autenticado com seu nome de usuário
        public string MigraCesta(string usuario)
        {
            var cestaCompras = new List<Cesta>();//Database.Cestas.Where(c => c.Cestaid == CestaComprasId);
            foreach (var item in cestaCompras)
            {
                //item.Cestaid = usuario;
            }
            return "";//Database.SaveChanges();
        }
    }
}