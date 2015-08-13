using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabruk.Models
{
    public enum TipoTelefone{Residencial = 1, Celular, Comercial};

    public class Telefone
    {
        public string DDD { get; set; }
        public string Fone { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
    }
}
