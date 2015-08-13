using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mabruk.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public DateTime DataNascimento { get{return DataNascimento;} set { value = value.Date; } }
        public List<Telefone> Telefones { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}